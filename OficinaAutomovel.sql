-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 30, 2026 at 11:00 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `OficinaAutomovel`
--

-- --------------------------------------------------------

--
-- Table structure for table `Clientes`
--

CREATE TABLE `Clientes` (
  `IdCliente` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `NIF` varchar(9) NOT NULL,
  `Telefone` varchar(15) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Morada` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Clientes`
--

INSERT INTO `Clientes` (`IdCliente`, `Nome`, `NIF`, `Telefone`, `Email`, `Morada`) VALUES
(1, 'João Silva', '123456789', '912345678', 'joao.silva@email.com', 'Leiria'),
(2, 'Maria Ferreira', '234567891', '913456789', 'maria.ferreira@email.com', 'Marinha Grande'),
(3, 'Pedro Costa', '345678912', '914567890', 'pedro.costa@email.com', 'Pombal'),
(4, 'Ana Rodrigues', '456789123', '915678901', 'ana.rodrigues@email.com', 'Batalha'),
(5, 'Carlos Gomes', '567891234', '916789012', 'carlos.gomes@email.com', 'Caldas da Rainha');

-- --------------------------------------------------------

--
-- Table structure for table `Funcionarios`
--

CREATE TABLE `Funcionarios` (
  `IdFuncionario` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Cargo` varchar(50) DEFAULT NULL,
  `Telefone` varchar(15) DEFAULT NULL,
  `Salario` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Funcionarios`
--

INSERT INTO `Funcionarios` (`IdFuncionario`, `Nome`, `Cargo`, `Telefone`, `Salario`) VALUES
(1, 'Ricardo Santos', 'Mecânico', '917111111', 1400.00),
(2, 'Miguel Oliveira', 'Mecânico', '917222222', 1350.00),
(3, 'Sofia Martins', 'Rececionista', '917333333', 1100.00),
(4, 'André Lopes', 'Gerente', '917444444', 1800.00);

-- --------------------------------------------------------

--
-- Table structure for table `Pecas`
--

CREATE TABLE `Pecas` (
  `IdPeca` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Preco` decimal(10,2) DEFAULT NULL,
  `Stock` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Pecas`
--

INSERT INTO `Pecas` (`IdPeca`, `Nome`, `Preco`, `Stock`) VALUES
(1, 'Filtro de óleo', 12.50, 30),
(2, 'Pastilhas de travão', 45.00, 20),
(3, 'Pneu 205/55 R16', 90.00, 15),
(4, 'Bateria 70Ah', 110.00, 10),
(5, 'Filtro de ar', 18.00, 25),
(6, 'Velas de ignição', 8.50, 40);

-- --------------------------------------------------------

--
-- Table structure for table `ReparacaoPecas`
--

CREATE TABLE `ReparacaoPecas` (
  `IdReparacao` int(11) NOT NULL,
  `IdPeca` int(11) NOT NULL,
  `Quantidade` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ReparacaoPecas`
--

INSERT INTO `ReparacaoPecas` (`IdReparacao`, `IdPeca`, `Quantidade`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 5, 1),
(4, 3, 4),
(5, 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `ReparacaoServico`
--

CREATE TABLE `ReparacaoServico` (
  `IdReparacao` int(11) NOT NULL,
  `IdServico` int(11) NOT NULL,
  `Quantidade` int(11) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ReparacaoServico`
--

INSERT INTO `ReparacaoServico` (`IdReparacao`, `IdServico`, `Quantidade`) VALUES
(1, 1, 1),
(2, 6, 1),
(3, 2, 1),
(4, 4, 4),
(5, 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Reparacoes`
--

CREATE TABLE `Reparacoes` (
  `IdReparacao` int(11) NOT NULL,
  `DataEntrada` date NOT NULL,
  `DataSaida` date DEFAULT NULL,
  `Estado` varchar(30) DEFAULT NULL,
  `Observacoes` varchar(300) DEFAULT NULL,
  `IdVeiculo` int(11) NOT NULL,
  `IdFuncionario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Reparacoes`
--

INSERT INTO `Reparacoes` (`IdReparacao`, `DataEntrada`, `DataSaida`, `Estado`, `Observacoes`, `IdVeiculo`, `IdFuncionario`) VALUES
(1, '2026-06-20', '2026-06-21', 'Concluído', 'Mudança de óleo e filtro.', 1, 1),
(2, '2026-06-22', NULL, 'Em Reparação', 'Problema no sistema de travagem.', 2, 2),
(3, '2026-06-18', '2026-06-19', 'Concluído', 'Revisão anual.', 3, 1),
(4, '2026-06-23', NULL, 'Em Espera', 'A aguardar chegada de peças.', 4, 2),
(5, '2026-06-24', NULL, 'Em Reparação', 'Diagnóstico de avaria eletrónica.', 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Servicos`
--

CREATE TABLE `Servicos` (
  `IdServico` int(11) NOT NULL,
  `Descricao` varchar(100) NOT NULL,
  `Preco` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Servicos`
--

INSERT INTO `Servicos` (`IdServico`, `Descricao`, `Preco`) VALUES
(1, 'Mudança de óleo', 65.00),
(2, 'Revisão geral', 150.00),
(3, 'Alinhamento de direção', 40.00),
(4, 'Troca de pneus', 80.00),
(5, 'Diagnóstico eletrónico', 35.00),
(6, 'Substituição de travões', 120.00);

-- --------------------------------------------------------

--
-- Table structure for table `Veiculos`
--

CREATE TABLE `Veiculos` (
  `IdVeiculo` int(11) NOT NULL,
  `Matricula` varchar(10) NOT NULL,
  `Marca` varchar(50) NOT NULL,
  `Modelo` varchar(50) NOT NULL,
  `Ano` int(11) DEFAULT NULL,
  `Combustivel` varchar(20) DEFAULT NULL,
  `IdCliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Veiculos`
--

INSERT INTO `Veiculos` (`IdVeiculo`, `Matricula`, `Marca`, `Modelo`, `Ano`, `Combustivel`, `IdCliente`) VALUES
(1, '12-AA-34', 'Peugeot', '208', 2020, 'Gasolina', 1),
(2, '45-BB-67', 'Volkswagen', 'Golf', 2018, 'Diesel', 2),
(3, '89-CC-10', 'Renault', 'Clio', 2021, 'Gasolina', 3),
(4, '11-DD-22', 'BMW', '320d', 2019, 'Diesel', 4),
(5, '33-EE-44', 'Toyota', 'Corolla', 2022, 'Híbrido', 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Clientes`
--
ALTER TABLE `Clientes`
  ADD PRIMARY KEY (`IdCliente`),
  ADD UNIQUE KEY `NIF` (`NIF`);

--
-- Indexes for table `Funcionarios`
--
ALTER TABLE `Funcionarios`
  ADD PRIMARY KEY (`IdFuncionario`);

--
-- Indexes for table `Pecas`
--
ALTER TABLE `Pecas`
  ADD PRIMARY KEY (`IdPeca`);

--
-- Indexes for table `ReparacaoPecas`
--
ALTER TABLE `ReparacaoPecas`
  ADD PRIMARY KEY (`IdReparacao`,`IdPeca`),
  ADD KEY `IdPeca` (`IdPeca`);

--
-- Indexes for table `ReparacaoServico`
--
ALTER TABLE `ReparacaoServico`
  ADD PRIMARY KEY (`IdReparacao`,`IdServico`),
  ADD KEY `IdServico` (`IdServico`);

--
-- Indexes for table `Reparacoes`
--
ALTER TABLE `Reparacoes`
  ADD PRIMARY KEY (`IdReparacao`),
  ADD KEY `IdVeiculo` (`IdVeiculo`),
  ADD KEY `IdFuncionario` (`IdFuncionario`);

--
-- Indexes for table `Servicos`
--
ALTER TABLE `Servicos`
  ADD PRIMARY KEY (`IdServico`);

--
-- Indexes for table `Veiculos`
--
ALTER TABLE `Veiculos`
  ADD PRIMARY KEY (`IdVeiculo`),
  ADD UNIQUE KEY `Matricula` (`Matricula`),
  ADD KEY `IdCliente` (`IdCliente`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Clientes`
--
ALTER TABLE `Clientes`
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `Funcionarios`
--
ALTER TABLE `Funcionarios`
  MODIFY `IdFuncionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Pecas`
--
ALTER TABLE `Pecas`
  MODIFY `IdPeca` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Reparacoes`
--
ALTER TABLE `Reparacoes`
  MODIFY `IdReparacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `Servicos`
--
ALTER TABLE `Servicos`
  MODIFY `IdServico` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Veiculos`
--
ALTER TABLE `Veiculos`
  MODIFY `IdVeiculo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ReparacaoPecas`
--
ALTER TABLE `ReparacaoPecas`
  ADD CONSTRAINT `reparacaopecas_ibfk_1` FOREIGN KEY (`IdReparacao`) REFERENCES `Reparacoes` (`IdReparacao`),
  ADD CONSTRAINT `reparacaopecas_ibfk_2` FOREIGN KEY (`IdPeca`) REFERENCES `Pecas` (`IdPeca`);

--
-- Constraints for table `ReparacaoServico`
--
ALTER TABLE `ReparacaoServico`
  ADD CONSTRAINT `reparacaoservico_ibfk_1` FOREIGN KEY (`IdReparacao`) REFERENCES `Reparacoes` (`IdReparacao`),
  ADD CONSTRAINT `reparacaoservico_ibfk_2` FOREIGN KEY (`IdServico`) REFERENCES `Servicos` (`IdServico`);

--
-- Constraints for table `Reparacoes`
--
ALTER TABLE `Reparacoes`
  ADD CONSTRAINT `reparacoes_ibfk_1` FOREIGN KEY (`IdVeiculo`) REFERENCES `Veiculos` (`IdVeiculo`),
  ADD CONSTRAINT `reparacoes_ibfk_2` FOREIGN KEY (`IdFuncionario`) REFERENCES `Funcionarios` (`IdFuncionario`);

--
-- Constraints for table `Veiculos`
--
ALTER TABLE `Veiculos`
  ADD CONSTRAINT `veiculos_ibfk_1` FOREIGN KEY (`IdCliente`) REFERENCES `Clientes` (`IdCliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
