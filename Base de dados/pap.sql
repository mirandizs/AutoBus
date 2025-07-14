-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Tempo de geração: 14-Jul-2025 às 17:53
-- Versão do servidor: 9.3.0
-- versão do PHP: 8.2.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de dados: `pap`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `atividades`
--

CREATE TABLE `atividades` (
  `id` tinyint NOT NULL,
  `estado` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `atividades`
--

INSERT INTO `atividades` (`id`, `estado`) VALUES
(0, 'inativo'),
(1, 'ativo');

-- --------------------------------------------------------

--
-- Estrutura da tabela `autocarro`
--

CREATE TABLE `autocarro` (
  `idautocarro` int NOT NULL,
  `numero` int NOT NULL,
  `capacidade` int NOT NULL,
  `arCondicionado` tinyint NOT NULL,
  `wifi` tinyint NOT NULL,
  `servico` tinyint NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `autocarro`
--

INSERT INTO `autocarro` (`idautocarro`, `numero`, `capacidade`, `arCondicionado`, `wifi`, `servico`) VALUES
(1, 24, 40, 1, 1, 1),
(2, 32, 45, 1, 1, 1),
(3, 17, 50, 1, 1, 1),
(4, 5, 39, 1, 1, 1),
(5, 103, 42, 1, 1, 1),
(6, 11, 36, 1, 1, 1),
(7, 14, 44, 1, 1, 1),
(8, 12, 46, 1, 1, 1),
(9, 28, 40, 1, 1, 1),
(10, 6, 50, 1, 1, 1),
(11, 10, 38, 1, 1, 0),
(12, 54, 22, 0, 1, 1),
(13, 77, 40, 1, 1, 1),
(14, 78, 44, 1, 1, 1),
(15, 79, 38, 1, 1, 1),
(16, 80, 42, 1, 1, 1),
(17, 81, 50, 1, 1, 1),
(18, 82, 45, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `carrinho`
--

CREATE TABLE `carrinho` (
  `id_produto` int NOT NULL,
  `id_utilizador` int NOT NULL,
  `id_ponto_partida` int NOT NULL,
  `id_ponto_chegada` int NOT NULL,
  `preco` double NOT NULL,
  `tipo` enum('Ida','Volta') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `data` date NOT NULL,
  `hora` time NOT NULL,
  `distancia_km` float NOT NULL,
  `duracao_estimada` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `hora_chegada` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `compras`
--

CREATE TABLE `compras` (
  `id_compraRealizada` int NOT NULL,
  `id_utilizador` int NOT NULL,
  `id_ponto_partida` int NOT NULL,
  `id_ponto_chegada` int NOT NULL,
  `preco` double NOT NULL,
  `data` date NOT NULL,
  `hora` time DEFAULT NULL,
  `tipo` enum('Ida','Volta') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `distancia_km` float NOT NULL,
  `duracao_estimada` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `hora_chegada` time NOT NULL,
  `tipo_pagamento` enum('cartao','mbway') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `compras`
--

INSERT INTO `compras` (`id_compraRealizada`, `id_utilizador`, `id_ponto_partida`, `id_ponto_chegada`, `preco`, `data`, `hora`, `tipo`, `distancia_km`, `duracao_estimada`, `hora_chegada`, `tipo_pagamento`) VALUES
(19, 1, 72, 69, 35.75050803422279, '2025-07-10', '17:30:00', 'Ida', 357.51, '4h 28min', '06:58:00', 'cartao'),
(20, 1, 22, 23, 4.712883623177592, '2025-07-10', '07:30:00', 'Ida', 47.13, '0h 35min', '08:05:00', 'cartao'),
(21, 1, 22, 23, 4.712883623177592, '2025-07-10', '07:30:00', 'Ida', 47.13, '0h 35min', '08:05:00', 'cartao'),
(22, 1, 16, 18, 17.69826795856634, '2025-07-10', '07:00:00', 'Ida', 176.98, '2h 13min', '09:13:00', 'mbway'),
(23, 1, 22, 23, 3.1419224154517282, '2025-07-13', '07:30:00', 'Ida', 47.13, '0h 35min', '08:05:00', 'cartao'),
(24, 1, 22, 23, 3.1419224154517282, '2025-07-13', '07:30:00', 'Ida', 47.13, '0h 35min', '08:05:00', 'cartao'),
(25, 1, 16, 18, 11.798845305710893, '2025-07-13', '07:00:00', 'Ida', 176.98, '2h 13min', '09:13:00', 'cartao'),
(26, 1, 106, 107, 3.1419224154517282, '2025-07-13', '06:30:00', 'Ida', 47.13, '0h 35min', '07:05:00', 'cartao'),
(27, 1, 107, 110, 3.1419224154517282, '2025-07-13', '07:15:00', 'Ida', 47.13, '0h 35min', '07:50:00', 'cartao'),
(28, 113, 18, 20, 11.798845305710893, '2025-07-14', '10:00:00', 'Ida', 176.98, '2h 13min', '12:13:00', 'cartao');

-- --------------------------------------------------------

--
-- Estrutura da tabela `pagamentos`
--

CREATE TABLE `pagamentos` (
  `id_pagamento` int NOT NULL,
  `nome_cartao` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `numero_cartao` bigint NOT NULL,
  `validade` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `id_utilizador` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `pagamentos`
--

INSERT INTO `pagamentos` (`id_pagamento`, `nome_cartao`, `numero_cartao`, `validade`, `id_utilizador`) VALUES
(10, 'asasads', 5675677777777777, '07/25', 1),
(11, 'sofia', 4444444444444444, '02/27', 113);

-- --------------------------------------------------------

--
-- Estrutura da tabela `pontos_rotas`
--

CREATE TABLE `pontos_rotas` (
  `id_ponto` int NOT NULL,
  `idautocarro` int NOT NULL,
  `local` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `latitude` double NOT NULL,
  `longitude` double NOT NULL,
  `hora_partida` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `pontos_rotas`
--

INSERT INTO `pontos_rotas` (`id_ponto`, `idautocarro`, `local`, `latitude`, `longitude`, `hora_partida`) VALUES
(1, 1, 'Guarda', 40.5373, -7.2675, '07:00:00'),
(2, 1, 'Vila Real', 41.3006, -7.7461, '08:34:00'),
(3, 1, 'Aveiro', 40.6405, -8.6538, '10:13:00'),
(4, 1, 'Portalegre', 39.2967, -7.4289, '13:00:00'),
(5, 1, 'Guarda', 40.5373, -7.2675, '15:13:00'),
(6, 2, 'Braga', 41.5488, -8.4212, '07:00:00'),
(7, 2, 'Bragança', 41.806, -6.7567, '09:29:00'),
(8, 2, 'Portalegre', 39.2967, -7.4289, '13:38:00'),
(9, 2, 'Lisboa', 38.7169, -9.1399, '16:10:00'),
(10, 2, 'Braga', 41.5488, -8.4212, '19:00:00'),
(11, 3, 'Évora', 38.5667, -7.9, '07:00:00'),
(12, 3, 'Beja', 38.0151, -7.8632, '08:00:00'),
(13, 3, 'Faro', 37.0194, -7.9322, '09:30:00'),
(14, 3, 'Setúbal', 38.5244, -8.8882, '12:00:00'),
(15, 3, 'Évora', 38.5667, -7.9, '14:30:00'),
(16, 4, 'Coimbra', 40.211, -8.4292, '07:00:00'),
(17, 4, 'Leiria', 39.7436, -8.8071, '08:15:00'),
(18, 4, 'Lisboa', 38.7169, -9.1399, '10:00:00'),
(19, 4, 'Santarém', 39.2333, -8.6833, '12:00:00'),
(20, 4, 'Coimbra', 40.211, -8.4292, '14:00:00'),
(21, 5, 'Viana do Castelo', 41.6932, -8.8329, '07:00:00'),
(22, 5, 'Braga', 41.5488, -8.4212, '07:30:00'),
(23, 5, 'Porto', 41.1496, -8.6109, '08:15:00'),
(24, 5, 'Aveiro', 40.6405, -8.6538, '09:45:00'),
(25, 5, 'Viana do Castelo', 41.6932, -8.8329, '11:30:00'),
(61, 7, 'Guarda', 40.5373, -7.2675, '06:00:00'),
(62, 7, 'Castelo Branco', 39.8222, -7.4908, '07:30:00'),
(63, 7, 'Évora', 38.5667, -7.9, '09:00:00'),
(64, 7, 'Beja', 38.0151, -7.8632, '10:30:00'),
(65, 7, 'Faro', 37.0194, -7.9322, '12:00:00'),
(66, 7, 'Guarda', 40.5373, -7.2675, '17:30:00'),
(67, 8, 'Faro', 37.0194, -7.9322, '13:00:00'),
(68, 8, 'Lisboa', 38.7169, -9.1399, '15:30:00'),
(69, 8, 'Coimbra', 40.211, -8.4292, '17:30:00'),
(70, 8, 'Porto', 41.1496, -8.6109, '19:00:00'),
(71, 8, 'Braga', 41.5488, -8.4212, '20:00:00'),
(72, 8, 'Faro', 37.0194, -7.9322, '02:30:00'),
(73, 9, 'Santarém', 39.2333, -8.6833, '04:00:00'),
(74, 9, 'Leiria', 39.7436, -8.8071, '05:15:00'),
(75, 9, 'Coimbra', 40.211, -8.4292, '06:30:00'),
(76, 9, 'Porto', 41.1496, -8.6109, '08:00:00'),
(77, 9, 'Viana do Castelo', 41.6932, -8.8329, '09:15:00'),
(78, 9, 'Santarém', 39.2333, -8.6833, '14:30:00'),
(79, 10, 'Beja', 38.0151, -7.8632, '21:00:00'),
(80, 10, 'Évora', 38.5667, -7.9, '21:45:00'),
(81, 10, 'Viseu', 40.661, -7.9097, '01:30:00'),
(82, 10, 'Vila Real', 41.3006, -7.7461, '03:00:00'),
(83, 10, 'Bragança', 41.806, -6.7567, '04:00:00'),
(84, 10, 'Beja', 38.0151, -7.8632, '09:30:00'),
(85, 11, 'Porto', 41.1496, -8.6109, '07:00:00'),
(86, 11, 'Aveiro', 40.6405, -8.6538, '08:00:00'),
(87, 11, 'Leiria', 39.7436, -8.8071, '09:30:00'),
(88, 11, 'Lisboa', 38.7169, -9.1399, '11:00:00'),
(89, 11, 'Évora', 38.5667, -7.9, '12:30:00'),
(90, 11, 'Porto', 41.1496, -8.6109, '17:00:00'),
(91, 13, 'Lisboa', 38.7169, -9.1399, '06:00:00'),
(92, 13, 'Santarém', 39.2333, -8.6833, '07:15:00'),
(93, 13, 'Leiria', 39.7436, -8.8071, '08:45:00'),
(94, 13, 'Porto', 41.1496, -8.6109, '11:30:00'),
(95, 13, 'Lisboa', 38.7169, -9.1399, '16:00:00'),
(96, 14, 'Faro', 37.0194, -7.9322, '08:00:00'),
(97, 14, 'Beja', 38.0151, -7.8632, '09:30:00'),
(98, 14, 'Évora', 38.5667, -7.9, '11:00:00'),
(99, 14, 'Setúbal', 38.5244, -8.8882, '12:45:00'),
(100, 14, 'Faro', 37.0194, -7.9322, '15:30:00'),
(101, 15, 'Viseu', 40.661, -7.9097, '07:00:00'),
(102, 15, 'Coimbra', 40.211, -8.4292, '08:15:00'),
(103, 15, 'Aveiro', 40.6405, -8.6538, '09:30:00'),
(104, 15, 'Porto', 41.1496, -8.6109, '11:00:00'),
(105, 15, 'Viseu', 40.661, -7.9097, '14:30:00'),
(106, 16, 'Braga', 41.5488, -8.4212, '06:30:00'),
(107, 16, 'Porto', 41.1496, -8.6109, '07:15:00'),
(108, 16, 'Coimbra', 40.211, -8.4292, '09:00:00'),
(109, 16, 'Lisboa', 38.7169, -9.1399, '11:45:00'),
(110, 16, 'Braga', 41.5488, -8.4212, '17:00:00'),
(111, 17, 'Setúbal', 38.5244, -8.8882, '07:00:00'),
(112, 17, 'Évora', 38.5667, -7.9, '08:45:00'),
(113, 17, 'Beja', 38.0151, -7.8632, '10:15:00'),
(114, 17, 'Faro', 37.0194, -7.9322, '12:00:00'),
(115, 17, 'Setúbal', 38.5244, -8.8882, '16:00:00'),
(116, 18, 'Viana do Castelo', 41.6932, -8.8329, '06:00:00'),
(117, 18, 'Braga', 41.5488, -8.4212, '07:00:00'),
(118, 18, 'Vila Real', 41.3006, -7.7461, '08:45:00'),
(119, 18, 'Bragança', 41.806, -6.7567, '10:15:00'),
(120, 18, 'Viana do Castelo', 41.6932, -8.8329, '14:00:00'),
(121, 5, 'Coimbra', 40.2033, -8.4103, '23:00:00'),
(122, 1, 'Coimbra', 40.2033, -8.4103, '23:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `sessions`
--

CREATE TABLE `sessions` (
  `session_id` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `expires` int UNSIGNED NOT NULL,
  `data` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Extraindo dados da tabela `sessions`
--

INSERT INTO `sessions` (`session_id`, `expires`, `data`) VALUES
('CU9joU2_Bd_QblzFltGQuzXyTCL5qbeI', 1752576229, '{\"cookie\":{\"originalMaxAge\":null,\"expires\":null,\"secure\":false,\"httpOnly\":true,\"path\":\"/\"},\"dados_utilizador\":{\"id_utilizador\":1,\"nif\":123456789,\"nome\":\"admin\",\"nascimento\":\"1997-02-13\",\"telefone\":123456789,\"localidade\":\"Lisboa\",\"email\":\"autobus.pap@gmail.com\",\"tipo_utilizador\":0,\"atividade\":1},\"utilizador\":\"admin\"}'),
('PsgLQUuuXc_EweBIRUHuLxl9uuHVBh5F', 1752532508, '{\"cookie\":{\"originalMaxAge\":null,\"expires\":null,\"secure\":false,\"httpOnly\":true,\"path\":\"/\"},\"dados_utilizador\":{\"id_utilizador\":109,\"nif\":287428684,\"nome\":\"ana\",\"nascimento\":\"1989-08-16\",\"telefone\":987877778,\"localidade\":\"Coimbra\",\"email\":\"ana@gmail.com\",\"tipo_utilizador\":1,\"atividade\":1},\"utilizador\":\"ana\"}'),
('YTuDkW920QXOnmDR6DARXGp0RBf9eR4Z', 1752601763, '{\"cookie\":{\"originalMaxAge\":null,\"expires\":null,\"secure\":false,\"httpOnly\":true,\"path\":\"/\"},\"dados_utilizador\":{\"id_utilizador\":1,\"nif\":123456789,\"nome\":\"admin\",\"nascimento\":\"1997-02-13\",\"telefone\":123456789,\"localidade\":\"Lisboa\",\"email\":\"autobus.pap@gmail.com\",\"tipo_utilizador\":0,\"atividade\":1},\"utilizador\":\"admin\"}');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipoutilizador`
--

CREATE TABLE `tipoutilizador` (
  `id` tinyint NOT NULL,
  `tipo` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `tipoutilizador`
--

INSERT INTO `tipoutilizador` (`id`, `tipo`) VALUES
(0, 'admin'),
(1, 'cliente');

-- --------------------------------------------------------

--
-- Estrutura da tabela `utilizadores`
--

CREATE TABLE `utilizadores` (
  `id_utilizador` int NOT NULL,
  `nif` int NOT NULL,
  `nome` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `nascimento` date NOT NULL,
  `telefone` int NOT NULL,
  `localidade` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(41) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `tipo_utilizador` tinyint NOT NULL,
  `atividade` tinyint NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `utilizadores`
--

INSERT INTO `utilizadores` (`id_utilizador`, `nif`, `nome`, `nascimento`, `telefone`, `localidade`, `email`, `password`, `tipo_utilizador`, `atividade`) VALUES
(1, 123456789, 'admin', '1997-02-13', 123456789, 'Lisboa', 'autobus.pap@gmail.com', '123', 0, 1),
(2, 999999999, 'sofia', '2006-03-04', 918942618, 'Coimbra', 'sofissmiranda.sm@gmail.com', '123', 1, 1),
(100, 294456090, 'Gabriel', '2006-07-25', 298899187, 'Coimbra', 'gabriel@gmail.com', 'Senha111', 0, 1),
(109, 287428684, 'ana', '1989-08-16', 987877778, 'Coimbra', 'ana@gmail.com', 'Senha111', 1, 1),
(113, 288888888, 'Sofia', '2003-05-12', 988888888, 'Porto', 'wobebel281@jxbav.com', 'Pass12345', 1, 0);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `atividades`
--
ALTER TABLE `atividades`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `autocarro`
--
ALTER TABLE `autocarro`
  ADD PRIMARY KEY (`idautocarro`),
  ADD KEY `fk_atividade` (`servico`);

--
-- Índices para tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD PRIMARY KEY (`id_produto`),
  ADD KEY `fk_idutilizador` (`id_utilizador`),
  ADD KEY `fk_pontoPartida` (`id_ponto_partida`),
  ADD KEY `fk_pontoChegada` (`id_ponto_chegada`);

--
-- Índices para tabela `compras`
--
ALTER TABLE `compras`
  ADD PRIMARY KEY (`id_compraRealizada`),
  ADD KEY `foreign_id_utilizador` (`id_utilizador`);

--
-- Índices para tabela `pagamentos`
--
ALTER TABLE `pagamentos`
  ADD PRIMARY KEY (`id_pagamento`),
  ADD KEY `fk_id_utilizador` (`id_utilizador`);

--
-- Índices para tabela `pontos_rotas`
--
ALTER TABLE `pontos_rotas`
  ADD PRIMARY KEY (`id_ponto`),
  ADD KEY `idautocarro` (`idautocarro`);

--
-- Índices para tabela `sessions`
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`session_id`);

--
-- Índices para tabela `tipoutilizador`
--
ALTER TABLE `tipoutilizador`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `utilizadores`
--
ALTER TABLE `utilizadores`
  ADD PRIMARY KEY (`id_utilizador`),
  ADD UNIQUE KEY `nif` (`nif`,`email`),
  ADD KEY `tipo_utilizador` (`tipo_utilizador`),
  ADD KEY `atividade` (`atividade`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `autocarro`
--
ALTER TABLE `autocarro`
  MODIFY `idautocarro` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de tabela `carrinho`
--
ALTER TABLE `carrinho`
  MODIFY `id_produto` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=125;

--
-- AUTO_INCREMENT de tabela `compras`
--
ALTER TABLE `compras`
  MODIFY `id_compraRealizada` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT de tabela `pagamentos`
--
ALTER TABLE `pagamentos`
  MODIFY `id_pagamento` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de tabela `pontos_rotas`
--
ALTER TABLE `pontos_rotas`
  MODIFY `id_ponto` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- AUTO_INCREMENT de tabela `utilizadores`
--
ALTER TABLE `utilizadores`
  MODIFY `id_utilizador` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `autocarro`
--
ALTER TABLE `autocarro`
  ADD CONSTRAINT `fk_atividade` FOREIGN KEY (`servico`) REFERENCES `atividades` (`id`);

--
-- Limitadores para a tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD CONSTRAINT `fk_idutilizador` FOREIGN KEY (`id_utilizador`) REFERENCES `utilizadores` (`id_utilizador`),
  ADD CONSTRAINT `fk_pontoChegada` FOREIGN KEY (`id_ponto_chegada`) REFERENCES `pontos_rotas` (`id_ponto`),
  ADD CONSTRAINT `fk_pontoPartida` FOREIGN KEY (`id_ponto_partida`) REFERENCES `pontos_rotas` (`id_ponto`);

--
-- Limitadores para a tabela `compras`
--
ALTER TABLE `compras`
  ADD CONSTRAINT `foreign_id_utilizador` FOREIGN KEY (`id_utilizador`) REFERENCES `utilizadores` (`id_utilizador`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Limitadores para a tabela `pagamentos`
--
ALTER TABLE `pagamentos`
  ADD CONSTRAINT `fk_id_utilizador` FOREIGN KEY (`id_utilizador`) REFERENCES `utilizadores` (`id_utilizador`);

--
-- Limitadores para a tabela `pontos_rotas`
--
ALTER TABLE `pontos_rotas`
  ADD CONSTRAINT `idautocarro` FOREIGN KEY (`idautocarro`) REFERENCES `autocarro` (`idautocarro`);

--
-- Limitadores para a tabela `utilizadores`
--
ALTER TABLE `utilizadores`
  ADD CONSTRAINT `atividade` FOREIGN KEY (`atividade`) REFERENCES `atividades` (`id`),
  ADD CONSTRAINT `id_tipo_utilizador` FOREIGN KEY (`tipo_utilizador`) REFERENCES `tipoutilizador` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
