-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 28-Abr-2026 às 16:14
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `hotel`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `dependants`
--

CREATE TABLE `dependants` (
  `id_dependants` int(6) NOT NULL,
  `dependants_name` varchar(255) NOT NULL,
  `dependants_age` int(2) NOT NULL,
  `id_guest` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `employees`
--

CREATE TABLE `employees` (
  `id_employee` int(6) NOT NULL,
  `employee_name` varchar(255) NOT NULL,
  `admission_date` date NOT NULL,
  `salary` decimal(6,0) NOT NULL,
  `employee_cpf` varchar(11) NOT NULL,
  `employee_pis` varchar(11) NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `flow`
--

CREATE TABLE `flow` (
  `id_flow` int(6) NOT NULL,
  `check-in` date NOT NULL,
  `check-out` date NOT NULL,
  `id_guest` int(6) NOT NULL,
  `id_room` int(6) NOT NULL,
  `id_reserve` int(6) NOT NULL,
  `id_employee` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `guest`
--

CREATE TABLE `guest` (
  `id_guest` int(6) NOT NULL,
  `guest_name` varchar(255) NOT NULL,
  `guest_phone` varchar(15) NOT NULL,
  `guest_cpf` varchar(11) NOT NULL,
  `guest_email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `payments`
--

CREATE TABLE `payments` (
  `id_payments` int(6) NOT NULL,
  `id_flow` int(6) NOT NULL,
  `paymente_date` date NOT NULL,
  `total_prize` decimal(4,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `reserve`
--

CREATE TABLE `reserve` (
  `id_reserve` int(6) NOT NULL,
  `check-in` date NOT NULL,
  `check-out` date NOT NULL,
  `id_room` int(6) NOT NULL,
  `id_guest` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `room`
--

CREATE TABLE `room` (
  `id_room` int(6) NOT NULL,
  `room_description` varchar(255) NOT NULL,
  `room_price` decimal(6,0) NOT NULL,
  `room_capacity` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `dependants`
--
ALTER TABLE `dependants`
  ADD PRIMARY KEY (`id_dependants`),
  ADD KEY `FK id_guest` (`id_guest`);

--
-- Índices para tabela `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id_employee`),
  ADD UNIQUE KEY `CPF` (`employee_cpf`),
  ADD UNIQUE KEY `PIS` (`employee_pis`);

--
-- Índices para tabela `flow`
--
ALTER TABLE `flow`
  ADD PRIMARY KEY (`id_flow`),
  ADD KEY `FK id_room` (`id_room`),
  ADD KEY `FK id_employee` (`id_employee`),
  ADD KEY `FK id_reserve` (`id_reserve`);

--
-- Índices para tabela `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`id_guest`),
  ADD UNIQUE KEY `CPF` (`guest_cpf`);

--
-- Índices para tabela `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`id_payments`),
  ADD KEY `FK id_flow` (`id_flow`);

--
-- Índices para tabela `reserve`
--
ALTER TABLE `reserve`
  ADD PRIMARY KEY (`id_reserve`),
  ADD KEY `fk_id_room` (`id_room`),
  ADD KEY `fk_id_guest` (`id_guest`);

--
-- Índices para tabela `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`id_room`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `dependants`
--
ALTER TABLE `dependants`
  ADD CONSTRAINT `FK id_guest` FOREIGN KEY (`id_guest`) REFERENCES `guest` (`id_guest`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `flow`
--
ALTER TABLE `flow`
  ADD CONSTRAINT `FK id_employee` FOREIGN KEY (`id_employee`) REFERENCES `employees` (`id_employee`),
  ADD CONSTRAINT `FK id_reserve` FOREIGN KEY (`id_reserve`) REFERENCES `reserve` (`id_reserve`),
  ADD CONSTRAINT `FK id_room` FOREIGN KEY (`id_room`) REFERENCES `room` (`id_room`);

--
-- Limitadores para a tabela `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `FK id_flow` FOREIGN KEY (`id_flow`) REFERENCES `flow` (`id_flow`);

--
-- Limitadores para a tabela `reserve`
--
ALTER TABLE `reserve`
  ADD CONSTRAINT `fk_id_guest` FOREIGN KEY (`id_guest`) REFERENCES `guest` (`id_guest`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_id_room` FOREIGN KEY (`id_room`) REFERENCES `room` (`id_room`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
