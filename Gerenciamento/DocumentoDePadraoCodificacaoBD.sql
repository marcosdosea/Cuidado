-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Cuidado
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `Cuidado` ;

-- -----------------------------------------------------
-- Schema Cuidado
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Cuidado` DEFAULT CHARACTER SET utf8 ;
USE `Cuidado` ;

-- -----------------------------------------------------
-- Table `Cuidado`.`organizacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`organizacao` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`organizacao` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`funcionario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`funcionario` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`funcionario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `dataNascimento` DATE NOT NULL,
  `dataAdmissao` DATE NOT NULL,
  `cargo` VARCHAR(15) NOT NULL,
  `status` ENUM("A", "I") NOT NULL COMMENT 'A -> Ativo\nI -> Inativo',
  `salario` DECIMAL NOT NULL,
  `numeroCasa` INT NOT NULL,
  `identificadorCasa` VARCHAR(10) NULL,
  `rua` VARCHAR(50) NOT NULL,
  `bairro` VARCHAR(50) NOT NULL,
  `cidade` VARCHAR(30) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `cep` INT NOT NULL,
  `complemento` VARCHAR(100) NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  `idOrganizacao` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_funcionario_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_funcionario_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `Cuidado`.`organizacao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`residente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`residente` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`residente` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `nomeMae` VARCHAR(50) NOT NULL,
  `nomePai` VARCHAR(50) NOT NULL,
  `dataNascimento` DATE NOT NULL,
  `estadoCivil` VARCHAR(10) NOT NULL,
  `cidadeNatal` VARCHAR(30) NOT NULL,
  `estadoNatal` VARCHAR(2) NOT NULL,
  `grauEscolaridade` ENUM("Fundamental Incompleto", "Fundamental Completo", "Médio Incompleto", "Médio Completo", "Superior Incompleto", "Superior Completo", "Pós-graduação", "Mestrado", "Doutorado") NOT NULL,
  `quantidadeFilhos` INT NOT NULL,
  `grauDepedencia` ENUM("0", "1") NOT NULL,
  `interditado` ENUM("0", "1") NOT NULL,
  `fonteRenda` VARCHAR(60) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `rg` VARCHAR(9) NOT NULL,
  `certidaoNascimento` VARCHAR(32) NOT NULL,
  `numeroSus` VARCHAR(15) NOT NULL,
  `numeroNis` VARCHAR(11) NOT NULL,
  `idOrganizacao` INT NOT NULL,
  `idFuncionario` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_residente_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  INDEX `fk_residente_funcionario1_idx` (`idFuncionario` ASC) VISIBLE,
  CONSTRAINT `fk_residente_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `Cuidado`.`organizacao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_residente_funcionario1`
    FOREIGN KEY (`idFuncionario`)
    REFERENCES `Cuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`responsavel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`responsavel` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`responsavel` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `rg` VARCHAR(9) NOT NULL,
  `vinculo` VARCHAR(20) NOT NULL,
  `numeroCasa` INT NOT NULL,
  `identificador` VARCHAR(10) NULL,
  `cep` INT NOT NULL,
  `cidade` VARCHAR(30) NOT NULL,
  `estado` VARCHAR(2) NOT NULL,
  `rua` VARCHAR(50) NOT NULL,
  `bairro` VARCHAR(50) NOT NULL,
  `complemento` VARCHAR(100) NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_nome` (`nome` ASC) VISIBLE,
  INDEX `fk_responsavel_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_responsavel_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`fonteRenda`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`fonteRenda` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`fonteRenda` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  `valor` DECIMAL NOT NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_fonteRenda_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_fonteRenda_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`planoAssistencia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`planoAssistencia` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`planoAssistencia` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `numero` INT NOT NULL,
  `numeroSerie` INT NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  `residente_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_planoAssistencia_residente1_idx` (`residente_id` ASC) VISIBLE,
  CONSTRAINT `fk_planoAssistencia_residente1`
    FOREIGN KEY (`residente_id`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`planoSaude`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`planoSaude` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`planoSaude` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `numero` INT NOT NULL,
  `numeroSerie` INT NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_planoSaude_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_planoSaude_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`atividadeExterna`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`atividadeExterna` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`atividadeExterna` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `dataRealizacao` DATE NOT NULL,
  `horarioRealizacao` TIME NOT NULL,
  `dataTermino` DATE NOT NULL,
  `horarioTermino` TIME NOT NULL,
  `tipoAtividade` VARCHAR(30) NOT NULL,
  `idOrganizacao` INT NOT NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_atividadeExterna_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  INDEX `fk_atividadeExterna_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_atividadeExterna_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `Cuidado`.`organizacao` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_atividadeExterna_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`acompanhante`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`acompanhante` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`acompanhante` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `idAtividadeExterna` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_acompanhantes_atividadeExterna1_idx` (`idAtividadeExterna` ASC) VISIBLE,
  CONSTRAINT `fk_acompanhantes_atividadeExterna1`
    FOREIGN KEY (`idAtividadeExterna`)
    REFERENCES `Cuidado`.`atividadeExterna` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`especialidadeMedicina`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`especialidadeMedicina` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`especialidadeMedicina` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`consulta`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`consulta` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`consulta` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NULL,
  `dataConsulta` DATETIME NOT NULL,
  `dataRetorno` DATETIME NULL,
  `medicoResponsavel` VARCHAR(50) NOT NULL,
  `examesSolicitados` TINYINT(1) NOT NULL,
  `idEspecialidadeMedicina` INT NOT NULL,
  `residente_id` INT NOT NULL,
  `funcionario_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_consulta_especialidadeMedicina1_idx` (`idEspecialidadeMedicina` ASC) VISIBLE,
  INDEX `fk_consulta_residente1_idx` (`residente_id` ASC) VISIBLE,
  INDEX `fk_consulta_funcionario1_idx` (`funcionario_id` ASC) VISIBLE,
  CONSTRAINT `fk_consulta_especialidadeMedicina1`
    FOREIGN KEY (`idEspecialidadeMedicina`)
    REFERENCES `Cuidado`.`especialidadeMedicina` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_consulta_residente1`
    FOREIGN KEY (`residente_id`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_consulta_funcionario1`
    FOREIGN KEY (`funcionario_id`)
    REFERENCES `Cuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`tipoExame`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`tipoExame` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`tipoExame` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nomeExame` VARCHAR(50) NOT NULL,
  `preparacao` VARCHAR(100) NOT NULL,
  `descricao` VARCHAR(100) NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tipoExame_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_tipoExame_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`exame`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`exame` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`exame` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `dataRealizacao` DATETIME NULL,
  `dataResultado` DATETIME NULL,
  `resultado` VARCHAR(100) NULL,
  `idConsulta` INT NOT NULL,
  `idTipoExame` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_exame_consulta1_idx` (`idConsulta` ASC) VISIBLE,
  INDEX `fk_exame_tipoExame1_idx` (`idTipoExame` ASC) VISIBLE,
  CONSTRAINT `fk_exame_consulta1`
    FOREIGN KEY (`idConsulta`)
    REFERENCES `Cuidado`.`consulta` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_exame_tipoExame1`
    FOREIGN KEY (`idTipoExame`)
    REFERENCES `Cuidado`.`tipoExame` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`visitante`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`visitante` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`visitante` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`visita`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`visita` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`visita` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `dataVisita` DATE NOT NULL,
  `horarioVisita` TIME NOT NULL,
  `idResidente` INT NOT NULL,
  `idVisitante` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_visita_residente1_idx` (`idResidente` ASC) VISIBLE,
  INDEX `fk_visita_visitante1_idx` (`idVisitante` ASC) VISIBLE,
  CONSTRAINT `fk_visita_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_visita_visitante1`
    FOREIGN KEY (`idVisitante`)
    REFERENCES `Cuidado`.`visitante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`fornecedor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`fornecedor` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`fornecedor` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`aquisicao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`aquisicao` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`aquisicao` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `observacoes` VARCHAR(200) NULL,
  `dataSolicitacao` DATETIME NOT NULL,
  `dataEntrada` DATETIME NULL,
  `idFuncionario` INT NOT NULL,
  `idFornecedor` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_aquisicao_funcionario1_idx` (`idFuncionario` ASC) VISIBLE,
  INDEX `fk_aquisicao_fornecedor1_idx` (`idFornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_aquisicao_funcionario1`
    FOREIGN KEY (`idFuncionario`)
    REFERENCES `Cuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_aquisicao_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `Cuidado`.`fornecedor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`produto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`produto` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`produto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `classificacao` VARCHAR(30) NOT NULL,
  `idOrganizacao` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_produto_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_produto_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `Cuidado`.`organizacao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`aquisicaoProduto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`aquisicaoProduto` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`aquisicaoProduto` (
  `idAquisicao` INT NOT NULL,
  `idProduto` INT NOT NULL,
  `dataValidade` DATETIME NOT NULL,
  `quantidade` INT NOT NULL,
  `lote` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idAquisicao`, `idProduto`),
  INDEX `fk_aquisicao_has_produto_produto1_idx` (`idProduto` ASC) VISIBLE,
  INDEX `fk_aquisicao_has_produto_aquisicao1_idx` (`idAquisicao` ASC) VISIBLE,
  CONSTRAINT `fk_aquisicao_has_produto_aquisicao1`
    FOREIGN KEY (`idAquisicao`)
    REFERENCES `Cuidado`.`aquisicao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_aquisicao_has_produto_produto1`
    FOREIGN KEY (`idProduto`)
    REFERENCES `Cuidado`.`produto` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`fornecedorOrganizacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`fornecedorOrganizacao` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`fornecedorOrganizacao` (
  `idFornecedor` INT NOT NULL,
  `idOrganizacao` INT NOT NULL,
  `observacoes` VARCHAR(200) NULL,
  PRIMARY KEY (`idFornecedor`, `idOrganizacao`),
  INDEX `fk_fornecedor_has_organizacao_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  INDEX `fk_fornecedor_has_organizacao_fornecedor1_idx` (`idFornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_fornecedor_has_organizacao_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `Cuidado`.`fornecedor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_fornecedor_has_organizacao_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `Cuidado`.`organizacao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`tipoCuidado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`tipoCuidado` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`tipoCuidado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `categoria` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`planejamentoCuidado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`planejamentoCuidado` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`planejamentoCuidado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NULL,
  `dataInicio` DATETIME NOT NULL,
  `dataFim` DATETIME NULL,
  `frequenciaDiaria` VARCHAR(50) NOT NULL,
  `continuo` TINYINT(1) NOT NULL,
  `idTipoCuidaddo` INT NOT NULL,
  `idProduto` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_planejamentoCuidado_tipoCuidado1_idx` (`idTipoCuidaddo` ASC) VISIBLE,
  INDEX `fk_planejamentoCuidado_produto1_idx` (`idProduto` ASC) VISIBLE,
  CONSTRAINT `fk_planejamentoCuidado_tipoCuidado1`
    FOREIGN KEY (`idTipoCuidaddo`)
    REFERENCES `Cuidado`.`tipoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_planejamentoCuidado_produto1`
    FOREIGN KEY (`idProduto`)
    REFERENCES `Cuidado`.`produto` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`cuidado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`cuidado` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`cuidado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `dataExecucao` DATETIME NOT NULL,
  `idFuncionario` INT NOT NULL,
  `idPlanejamentoCuidado` INT NOT NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cuidado_funcionario1_idx` (`idFuncionario` ASC) VISIBLE,
  INDEX `fk_cuidado_planejamentoCuidado1_idx` (`idPlanejamentoCuidado` ASC) VISIBLE,
  INDEX `fk_cuidado_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_cuidado_funcionario1`
    FOREIGN KEY (`idFuncionario`)
    REFERENCES `Cuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cuidado_planejamentoCuidado1`
    FOREIGN KEY (`idPlanejamentoCuidado`)
    REFERENCES `Cuidado`.`planejamentoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cuidado_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `Cuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cuidado`.`planejamentoCuidadoDiario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Cuidado`.`planejamentoCuidadoDiario` ;

CREATE TABLE IF NOT EXISTS `Cuidado`.`planejamentoCuidadoDiario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `diaSemana` DATE NOT NULL,
  `hora` TIME NOT NULL,
  `idPlanejamentoCuidado` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_planejamentoCuidadoDiario_planejamentoCuidado1_idx` (`idPlanejamentoCuidado` ASC) VISIBLE,
  CONSTRAINT `fk_planejamentoCuidadoDiario_planejamentoCuidado1`
    FOREIGN KEY (`idPlanejamentoCuidado`)
    REFERENCES `Cuidado`.`planejamentoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
