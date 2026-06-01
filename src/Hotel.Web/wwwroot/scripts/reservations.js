// Elementos do DOM para gerenciar dependentes
const containerElement = document.getElementById("dependents-container");
const templateElement = document.getElementById("dependent-template");
const addButtonElement = document.getElementById("add-dependent");
const remainingGuestsLabelElement = document.getElementById("remaining-guests");
const maxDependents = Number(containerElement.dataset.maxDependents);

// Índice para controlar o próximo dependente a ser adicionado
let nextIndex = containerElement.querySelectorAll("[data-dependent-item]").length;

// Atualiza a quantidade de hóspedes restantes que podem ser adicionados
function updateRemainingGuests() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;
    const remaining = maxDependents - currentDependents;

    remainingGuestsLabelElement.textContent = remaining.toString();
}

// Habilita ou desabilita o botão de adicionar dependentes
function refreshAddButtonState() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;
    addButtonElement.disabled = currentDependents >= maxDependents;
}

// Reindexa todos os dependentes após adição ou remoção
function reindexDependents() {
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");

    cardElements.forEach((card, index) => {
        const title = card.querySelector("h4");

        if (title) {
            title.textContent = `Dependent ${index + 1}`;
        }

        // Atualiza o atributo name do campo de nome
        const nameInput = card.querySelector('input[name$=".Name"]');

        if (nameInput) {
            nameInput.name = `Dependents[${index}].Name`;
        }

        // Atualiza o atributo name do campo de data de nascimento
        const birthdayInput = card.querySelector('input[name$=".BirthdayDate"]');

        if (birthdayInput) {
            birthdayInput.name = `Dependents[${index}].BirthdayDate`;
        }
    });

    nextIndex = cardElements.length;

    refreshAddButtonState();
    updateRemainingGuests();
}

// Remove um dependente do formulário
function removeDependent(card) {
    card.remove();
    reindexDependents();
}

// Vincula o evento de clique ao botão de remover
function attachRemoveHandler(card) {
    console.log(card);
    const removeButton = card.querySelector(".btn-remove-dependent");
    
    if (!removeButton) {
        return;
    }

    removeButton.addEventListener("click", () => removeDependent(card));
}

// Cria um novo dependente e adiciona ao formulário
function createDependent() {
    const currentDependents = containerElement.querySelectorAll("[data-dependent-item]").length;

    // Verifica se já atingiu o máximo de dependentes
    if (currentDependents >= maxDependents) {
        return;
    }

    // Clona o template e substitui o placeholder do índice
    const html = templateElement.innerHTML.replaceAll("__index__", nextIndex);
    containerElement.insertAdjacentHTML("beforeend", html);
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");
    const newCard = cardElements[cardElements.length - 1];

    // Vincula o handler de remoção ao novo elemento
    attachRemoveHandler(newCard);
    nextIndex++;
    refreshAddButtonState();
    updateRemainingGuests();

    console.log("Dependente Criado!");
}

// Inicializa os manipuladores de remoção para dependentes existentes
function initializeExistingDependents() {
    const cardElements = containerElement.querySelectorAll("[data-dependent-item]");
    cardElements.forEach(card => { attachRemoveHandler(card); });
}

// Função de inicialização geral
function initialize() {
    initializeExistingDependents();
    refreshAddButtonState();
    updateRemainingGuests();
}

// Adiciona listener ao botão para criar novo dependente
addButtonElement.addEventListener("click", createDependent);

// Inicializa a página
initialize();
