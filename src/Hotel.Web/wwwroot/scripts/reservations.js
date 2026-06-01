const containerElement = document.getElementById("dependents-container");
const templateElement = document.getElementById("dependent-template");
const addButtonElement = document.getElementById("add-dependent");
const remainingGuestsLabelElement = document.getElementById("remaining-guests");
const maxDependents = Number(containerElement.dataset.maxDependents);

let nextIndex = containerElement.querySelectorAll("[data-dependent-item]").length;

function updateRemainingGuests() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;
    const remaining = maxDependents - currentDependents;

    remainingGuestsLabelElement.textContent = remaining.toString();
}

function refreshAddButtonState() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;
    addButtonElement.disabled = currentDependents >= maxDependents;
}

function reindexDependents() {
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");

    cardElements.forEach((card, index) => {
        const title = card.querySelector("h4");

        if (title) {
            title.textContent = `Dependent ${index + 1}`;
        }

        const nameInput = card.querySelector('input[name$=".Name"]');

        if (nameInput) {
            nameInput.name = `Dependents[${index}].Name`;
        }

        const birthdayInput = card.querySelector('input[name$=".BirthdayDate"]');

        if (birthdayInput) {
            birthdayInput.name = `Dependents[${index}].BirthdayDate`;
        }
    });

    nextIndex = cardElements.length;

    refreshAddButtonState();
    updateRemainingGuests();
}

function removeDependent(card) {
    card.remove();
    reindexDependents();
}

function attachRemoveHandler(card) {
    console.log(card);
    const removeButton = card.querySelector(".btn-remove-dependent");
    
    if (!removeButton) {
        return;
    }

    removeButton.addEventListener("click", () => removeDependent(card));
}

function createDependent() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;

    if (currentDependents >= maxDependents) {
        return;
    }

    const html = templateElement.innerHTML.replaceAll("__index__", nextIndex);
    containerElement.insertAdjacentHTML("beforeend", html);
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");
    const newCard = cardElements[cardElements.length - 1];

    attachRemoveHandler(newCard);
    nextIndex++;
    refreshAddButtonState();
    updateRemainingGuests();

    console.log("Dependente Criado!");
}

function initializeExistingDependents() {
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");
    cardElements.forEach(card => { attachRemoveHandler(card); });
}

function initialize() {
    initializeExistingDependents();
    refreshAddButtonState();
    updateRemainingGuests();
}

addButtonElement.addEventListener("click", createDependent);

initialize();
