-- MySQL Workbench Synchronization
-- Generated: 2024-08-14 22:48
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Guilherme

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_funcionario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nomeMae` VARCHAR(45) NULL DEFAULT NULL,
  `cpf` VARCHAR(45) NOT NULL,
  `cargo` VARCHAR(25) NOT NULL,
  `dataAdmissao` DATE NOT NULL,
  `status` ENUM("0", "1") NOT NULL,
  `salario` DECIMAL NULL DEFAULT NULL,
  `observacoes` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_consulta` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NOT NULL,
  `dataConsulta` DATE NOT NULL,
  `dataRetorno` DATE NOT NULL,
  `medicoResponsavel` VARCHAR(45) NOT NULL,
  `examesSolicitados` TINYINT(4) NOT NULL,
  `especialidadeMedico` VARCHAR(30) NOT NULL,
  `tb_funcionario_id` INT(11) NOT NULL,
  `tb_residente_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_consulta_tb_funcionario2_idx` (`tb_funcionario_id` ASC) VISIBLE,
  INDEX `fk_tb_consulta_tb_residente1_idx` (`tb_residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_consulta_tb_funcionario2`
    FOREIGN KEY (`tb_funcionario_id`)
    REFERENCES `cuidado`.`tb_funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_tb_consulta_tb_residente1`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_residente` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nomeCompleto` VARCHAR(45) NOT NULL,
  `nomeMae` VARCHAR(45) NOT NULL,
  `nomePai` VARCHAR(45) NULL DEFAULT NULL,
  `dataNascimento` DATE NOT NULL,
  `estadoCivil` VARCHAR(20) NOT NULL,
  `cidadeNatal` VARCHAR(30) NOT NULL,
  `estadoNatal` VARCHAR(45) NOT NULL,
  `grauEscolaridade` VARCHAR(20) NOT NULL,
  `quantidadeFilhos` INT(11) NOT NULL,
  `grauDepedencia` VARCHAR(40) NOT NULL,
  `planoSaude` VARCHAR(30) NOT NULL,
  `planoAssistencia` VARCHAR(30) NOT NULL,
  `interditado` ENUM("0", "1") NOT NULL,
  `nomeCurador` VARCHAR(45) NOT NULL,
  `telefoneCurador` VARCHAR(13) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `rg` VARCHAR(10) NOT NULL,
  `certidaoNascimento` VARCHAR(32) NOT NULL,
  `numeroSus` VARCHAR(15) NOT NULL,
  `numeroNis` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE,
  UNIQUE INDEX `rg_UNIQUE` (`rg` ASC) VISIBLE,
  UNIQUE INDEX `certidaoNascimento_UNIQUE` (`certidaoNascimento` ASC) VISIBLE,
  UNIQUE INDEX `numeroSus_UNIQUE` (`numeroSus` ASC) VISIBLE,
  UNIQUE INDEX `numeroNis_UNIQUE` (`numeroNis` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_fonteRenda` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(60) NOT NULL,
  `tb_residente_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_fonteRenda_tb_residente_idx` (`tb_residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_fonteRenda_tb_residente`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_parentescoResponsavel` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(11) NOT NULL,
  `rg` VARCHAR(10) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `rua` VARCHAR(30) NOT NULL,
  `numeroCasa` INT(11) NOT NULL,
  `bairro` VARCHAR(30) NOT NULL,
  `cep` VARCHAR(8) NOT NULL,
  `cidade` VARCHAR(30) NOT NULL,
  `estado` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_residente_has_tb_parentescoResponsavel` (
  `tb_residente_id` INT(11) NOT NULL,
  `tb_parentescoResponsavel_id` INT(11) NOT NULL,
  PRIMARY KEY (`tb_residente_id`, `tb_parentescoResponsavel_id`),
  INDEX `fk_tb_residente_has_tb_parentescoResponsavel_tb_parentescoR_idx` (`tb_parentescoResponsavel_id` ASC) VISIBLE,
  INDEX `fk_tb_residente_has_tb_parentescoResponsavel_tb_residente1_idx` (`tb_residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_residente_has_tb_parentescoResponsavel_tb_residente1`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_tb_residente_has_tb_parentescoResponsavel_tb_parentescoRes1`
    FOREIGN KEY (`tb_parentescoResponsavel_id`)
    REFERENCES `cuidado`.`tb_parentescoResponsavel` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_responsavelTelefone` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `telefone` VARCHAR(13) NOT NULL,
  `tb_parentescoResponsavel_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`, `telefone`),
  INDEX `fk_tb_responsavelTelefone_tb_parentescoResponsavel1_idx` (`tb_parentescoResponsavel_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_responsavelTelefone_tb_parentescoResponsavel1`
    FOREIGN KEY (`tb_parentescoResponsavel_id`)
    REFERENCES `cuidado`.`tb_parentescoResponsavel` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_visitante` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `telefone` VARCHAR(13) NOT NULL,
  `tb_residente_id` INT(11) NOT NULL,
  INDEX `fk_tb_visitante_tb_residente1_idx` (`tb_residente_id` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_tb_visitante_tb_residente1`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_visita` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `data` DATE NOT NULL,
  `horario` TIME NOT NULL,
  `tb_residente_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_visita_tb_residente1_idx` (`tb_residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_visita_tb_residente1`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_visita_has_tb_visitante` (
  `tb_visita_id` INT(11) NOT NULL,
  `tb_visitante_id` INT(11) NOT NULL,
  PRIMARY KEY (`tb_visita_id`, `tb_visitante_id`),
  INDEX `fk_tb_visita_has_tb_visitante_tb_visitante1_idx` (`tb_visitante_id` ASC) VISIBLE,
  INDEX `fk_tb_visita_has_tb_visitante_tb_visita1_idx` (`tb_visita_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_visita_has_tb_visitante_tb_visita1`
    FOREIGN KEY (`tb_visita_id`)
    REFERENCES `cuidado`.`tb_visita` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_tb_visita_has_tb_visitante_tb_visitante1`
    FOREIGN KEY (`tb_visitante_id`)
    REFERENCES `cuidado`.`tb_visitante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_aquisicaoMedicamento` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `quantidade` INT(11) NOT NULL,
  `observacoes` VARCHAR(200) NULL DEFAULT NULL,
  `dataSolicitacao` DATE NULL DEFAULT NULL,
  `tb_funcionario_id` INT(11) NOT NULL,
  `tb_medicamento_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_aquisicaoMedicamento_tb_funcionario1_idx` (`tb_funcionario_id` ASC) VISIBLE,
  INDEX `fk_tb_aquisicaoMedicamento_tb_medicamento1_idx` (`tb_medicamento_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_aquisicaoMedicamento_tb_funcionario1`
    FOREIGN KEY (`tb_funcionario_id`)
    REFERENCES `cuidado`.`tb_funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_tb_aquisicaoMedicamento_tb_medicamento1`
    FOREIGN KEY (`tb_medicamento_id`)
    REFERENCES `cuidado`.`tb_medicamento` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_medicamento` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `classificacao` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `cuidado`.`tb_cuidado` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NULL DEFAULT NULL,
  `diasAplicados` VARCHAR(50) NOT NULL,
  `horario` TIME NOT NULL,
  `observacoes` VARCHAR(200) NULL DEFAULT NULL,
  `tb_funcionario_id` INT(11) NOT NULL,
  `tb_residente_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_cuidado_tb_funcionario1_idx` (`tb_funcionario_id` ASC) VISIBLE,
  INDEX `fk_tb_cuidado_tb_residente1_idx` (`tb_residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_tb_cuidado_tb_funcionario1`
    FOREIGN KEY (`tb_funcionario_id`)
    REFERENCES `cuidado`.`tb_funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_tb_cuidado_tb_residente1`
    FOREIGN KEY (`tb_residente_id`)
    REFERENCES `cuidado`.`tb_residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
