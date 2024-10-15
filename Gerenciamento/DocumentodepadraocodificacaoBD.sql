-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ModeloCuidado
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ModeloCuidado
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ModeloCuidado` DEFAULT CHARACTER SET utf8 ;
USE `ModeloCuidado` ;

-- -----------------------------------------------------
-- Table `ModeloCuidado`.`organizacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`organizacao` (
  `idorganizacao` INT NOT NULL AUTO_INCREMENT,
  `cnpj` VARCHAR(14) NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idorganizacao`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`funcionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`funcionario` (
  `id` INT NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(45) NOT NULL,
  `dataNascimento` DATE NOT NULL,
  `dataAdmissao` DATE NOT NULL,
  `cargo` VARCHAR(15) NOT NULL,
  `status` ENUM("0", "1") NOT NULL,
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
    REFERENCES `ModeloCuidado`.`organizacao` (`idorganizacao`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`residente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`residente` (
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
    REFERENCES `ModeloCuidado`.`organizacao` (`idorganizacao`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_residente_funcionario1`
    FOREIGN KEY (`idFuncionario`)
    REFERENCES `ModeloCuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`responsavel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`responsavel` (
  `id` INT NOT NULL,
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
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`fonteRenda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`fonteRenda` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  `valor` DECIMAL NOT NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_fonteRenda_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_fonteRenda_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`planoAssistencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`planoAssistencia` (
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
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`planoSaude`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`planoSaude` (
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
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`atividadeExterna`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`atividadeExterna` (
  `id` INT NOT NULL,
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
    REFERENCES `ModeloCuidado`.`organizacao` (`idorganizacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_atividadeExterna_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`acompanhante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`acompanhante` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `idAtividadeExterna` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_acompanhantes_atividadeExterna1_idx` (`idAtividadeExterna` ASC) VISIBLE,
  CONSTRAINT `fk_acompanhantes_atividadeExterna1`
    FOREIGN KEY (`idAtividadeExterna`)
    REFERENCES `ModeloCuidado`.`atividadeExterna` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`especialidadeMedicina`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`especialidadeMedicina` (
  `idespecialidadeMedicina` INT NOT NULL AUTO_INCREMENT,
  `nomeEspecialidade` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idespecialidadeMedicina`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`consulta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`consulta` (
  `idconsulta` INT NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(200) NULL,
  `dataConsulta` DATETIME NOT NULL,
  `dataRetorno` DATETIME NULL,
  `medicoResponsavel` VARCHAR(50) NOT NULL,
  `examesSolicitados` TINYINT(1) NOT NULL,
  `idEspecialidadeMedicina` INT NOT NULL,
  `residente_id` INT NOT NULL,
  `funcionario_id` INT NOT NULL,
  PRIMARY KEY (`idconsulta`),
  INDEX `fk_consulta_especialidadeMedicina1_idx` (`idEspecialidadeMedicina` ASC) VISIBLE,
  INDEX `fk_consulta_residente1_idx` (`residente_id` ASC) VISIBLE,
  INDEX `fk_consulta_funcionario1_idx` (`funcionario_id` ASC) VISIBLE,
  CONSTRAINT `fk_consulta_especialidadeMedicina1`
    FOREIGN KEY (`idEspecialidadeMedicina`)
    REFERENCES `ModeloCuidado`.`especialidadeMedicina` (`idespecialidadeMedicina`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_consulta_residente1`
    FOREIGN KEY (`residente_id`)
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_consulta_funcionario1`
    FOREIGN KEY (`funcionario_id`)
    REFERENCES `ModeloCuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`tipoExame`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`tipoExame` (
  `idtipoExame` INT NOT NULL AUTO_INCREMENT,
  `nomeExame` VARCHAR(50) NOT NULL,
  `preparacao` VARCHAR(100) NOT NULL,
  `descricao` VARCHAR(100) NULL,
  `idResidente` INT NOT NULL,
  PRIMARY KEY (`idtipoExame`),
  INDEX `fk_tipoExame_residente1_idx` (`idResidente` ASC) VISIBLE,
  CONSTRAINT `fk_tipoExame_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`exame`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`exame` (
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
    REFERENCES `ModeloCuidado`.`consulta` (`idconsulta`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_exame_tipoExame1`
    FOREIGN KEY (`idTipoExame`)
    REFERENCES `ModeloCuidado`.`tipoExame` (`idtipoExame`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`visitante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`visitante` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`visita`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`visita` (
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
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_visita_visitante1`
    FOREIGN KEY (`idVisitante`)
    REFERENCES `ModeloCuidado`.`visitante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`fornecedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`fornecedor` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `primeiroTelefone` VARCHAR(13) NULL,
  `segundoTelefone` VARCHAR(13) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`aquisicao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`aquisicao` (
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
    REFERENCES `ModeloCuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_aquisicao_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `ModeloCuidado`.`fornecedor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`produto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `classificacao` VARCHAR(30) NOT NULL,
  `idOrganizacao` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_produto_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_produto_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `ModeloCuidado`.`organizacao` (`idorganizacao`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`aquisicaoProduto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`aquisicaoProduto` (
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
    REFERENCES `ModeloCuidado`.`aquisicao` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_aquisicao_has_produto_produto1`
    FOREIGN KEY (`idProduto`)
    REFERENCES `ModeloCuidado`.`produto` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`fornecedorOrganizacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`fornecedorOrganizacao` (
  `idFornecedor` INT NOT NULL,
  `idOrganizacao` INT NOT NULL,
  `observacoes` VARCHAR(200) NULL,
  PRIMARY KEY (`idFornecedor`, `idOrganizacao`),
  INDEX `fk_fornecedor_has_organizacao_organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  INDEX `fk_fornecedor_has_organizacao_fornecedor1_idx` (`idFornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_fornecedor_has_organizacao_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `ModeloCuidado`.`fornecedor` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_fornecedor_has_organizacao_organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `ModeloCuidado`.`organizacao` (`idorganizacao`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`tipoCuidado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`tipoCuidado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nomeCuidado` VARCHAR(50) NOT NULL,
  `categoria` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`planejamentoCuidado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`planejamentoCuidado` (
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
    REFERENCES `ModeloCuidado`.`tipoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_planejamentoCuidado_produto1`
    FOREIGN KEY (`idProduto`)
    REFERENCES `ModeloCuidado`.`produto` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`cuidado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`cuidado` (
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
    REFERENCES `ModeloCuidado`.`funcionario` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cuidado_planejamentoCuidado1`
    FOREIGN KEY (`idPlanejamentoCuidado`)
    REFERENCES `ModeloCuidado`.`planejamentoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_cuidado_residente1`
    FOREIGN KEY (`idResidente`)
    REFERENCES `ModeloCuidado`.`residente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModeloCuidado`.`planejamentoCuidadoDiario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ModeloCuidado`.`planejamentoCuidadoDiario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `diaSemana` DATE NOT NULL,
  `hora` TIME NOT NULL,
  `idPlanejamentoCuidado` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_planejamentoCuidadoDiario_planejamentoCuidado1_idx` (`idPlanejamentoCuidado` ASC) VISIBLE,
  CONSTRAINT `fk_planejamentoCuidadoDiario_planejamentoCuidado1`
    FOREIGN KEY (`idPlanejamentoCuidado`)
    REFERENCES `ModeloCuidado`.`planejamentoCuidado` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
