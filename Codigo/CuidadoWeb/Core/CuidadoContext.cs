using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class CuidadoContext : DbContext
{
    public CuidadoContext()
    {
    }

    public CuidadoContext(DbContextOptions<CuidadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acompanhante> Acompanhantes { get; set; }

    public virtual DbSet<Aquisicao> Aquisicaos { get; set; }

    public virtual DbSet<Aquisicaoproduto> Aquisicaoprodutos { get; set; }

    public virtual DbSet<Atividadeexterna> Atividadeexternas { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Cuidado> Cuidados { get; set; }

    public virtual DbSet<Especialidademedicina> Especialidademedicinas { get; set; }

    public virtual DbSet<Exame> Exames { get; set; }

    public virtual DbSet<Fonterendum> Fonterenda { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Fornecedororganizacao> Fornecedororganizacaos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Organizacao> Organizacaos { get; set; }

    public virtual DbSet<Planejamentocuidado> Planejamentocuidados { get; set; }

    public virtual DbSet<Planejamentocuidadodiario> Planejamentocuidadodiarios { get; set; }

    public virtual DbSet<Planoassistencium> Planoassistencia { get; set; }

    public virtual DbSet<Planosaude> Planosaudes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Residente> Residentes { get; set; }

    public virtual DbSet<Responsavel> Responsavels { get; set; }

    public virtual DbSet<Tipocuidado> Tipocuidados { get; set; }

    public virtual DbSet<Tipoexame> Tipoexames { get; set; }

    public virtual DbSet<Visitante> Visitantes { get; set; }

    public virtual DbSet<Visitum> Visita { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acompanhante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acompanhante");

            entity.HasIndex(e => e.IdAtividadeExterna, "fk_acompanhantes_atividadeExterna1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdAtividadeExterna)
                .HasColumnType("int(11)")
                .HasColumnName("idAtividadeExterna");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdAtividadeExternaNavigation).WithMany(p => p.Acompanhantes)
                .HasForeignKey(d => d.IdAtividadeExterna)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_acompanhantes_atividadeExterna1");
        });

        modelBuilder.Entity<Aquisicao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aquisicao");

            entity.HasIndex(e => e.IdFornecedor, "fk_aquisicao_fornecedor1_idx");

            entity.HasIndex(e => e.IdFuncionario, "fk_aquisicao_funcionario1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataEntrada)
                .HasColumnType("datetime")
                .HasColumnName("dataEntrada");
            entity.Property(e => e.DataSolicitacao)
                .HasColumnType("datetime")
                .HasColumnName("dataSolicitacao");
            entity.Property(e => e.IdFornecedor)
                .HasColumnType("int(11)")
                .HasColumnName("idFornecedor");
            entity.Property(e => e.IdFuncionario)
                .HasColumnType("int(11)")
                .HasColumnName("idFuncionario");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(200)
                .HasColumnName("observacoes");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Aquisicaos)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aquisicao_fornecedor1");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Aquisicaos)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aquisicao_funcionario1");
        });

        modelBuilder.Entity<Aquisicaoproduto>(entity =>
        {
            entity.HasKey(e => new { e.IdAquisicao, e.IdProduto }).HasName("PRIMARY");

            entity.ToTable("aquisicaoproduto");

            entity.HasIndex(e => e.IdAquisicao, "fk_aquisicao_has_produto_aquisicao1_idx");

            entity.HasIndex(e => e.IdProduto, "fk_aquisicao_has_produto_produto1_idx");

            entity.Property(e => e.IdAquisicao)
                .HasColumnType("int(11)")
                .HasColumnName("idAquisicao");
            entity.Property(e => e.IdProduto)
                .HasColumnType("int(11)")
                .HasColumnName("idProduto");
            entity.Property(e => e.DataValidade)
                .HasColumnType("datetime")
                .HasColumnName("dataValidade");
            entity.Property(e => e.Lote)
                .HasMaxLength(50)
                .HasColumnName("lote");
            entity.Property(e => e.Quantidade)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdAquisicaoNavigation).WithMany(p => p.Aquisicaoprodutos)
                .HasForeignKey(d => d.IdAquisicao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aquisicao_has_produto_aquisicao1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Aquisicaoprodutos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aquisicao_has_produto_produto1");
        });

        modelBuilder.Entity<Atividadeexterna>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atividadeexterna");

            entity.HasIndex(e => e.IdOrganizacao, "fk_atividadeExterna_organizacao1_idx");

            entity.HasIndex(e => e.IdResidente, "fk_atividadeExterna_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataRealizacao)
                .HasColumnType("date")
                .HasColumnName("dataRealizacao");
            entity.Property(e => e.DataTermino)
                .HasColumnType("date")
                .HasColumnName("dataTermino");
            entity.Property(e => e.HorarioRealizacao)
                .HasColumnType("time")
                .HasColumnName("horarioRealizacao");
            entity.Property(e => e.HorarioTermino)
                .HasColumnType("time")
                .HasColumnName("horarioTermino");
            entity.Property(e => e.IdOrganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idOrganizacao");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.TipoAtividade)
                .HasMaxLength(30)
                .HasColumnName("tipoAtividade");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Atividadeexternas)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_atividadeExterna_organizacao1");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Atividadeexternas)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_atividadeExterna_residente1");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.Idconsulta).HasName("PRIMARY");

            entity.ToTable("consulta");

            entity.HasIndex(e => e.IdEspecialidadeMedicina, "fk_consulta_especialidadeMedicina1_idx");

            entity.HasIndex(e => e.FuncionarioId, "fk_consulta_funcionario1_idx");

            entity.HasIndex(e => e.ResidenteId, "fk_consulta_residente1_idx");

            entity.Property(e => e.Idconsulta)
                .HasColumnType("int(11)")
                .HasColumnName("idconsulta");
            entity.Property(e => e.DataConsulta)
                .HasColumnType("datetime")
                .HasColumnName("dataConsulta");
            entity.Property(e => e.DataRetorno)
                .HasColumnType("datetime")
                .HasColumnName("dataRetorno");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.ExamesSolicitados).HasColumnName("examesSolicitados");
            entity.Property(e => e.FuncionarioId)
                .HasColumnType("int(11)")
                .HasColumnName("funcionario_id");
            entity.Property(e => e.IdEspecialidadeMedicina)
                .HasColumnType("int(11)")
                .HasColumnName("idEspecialidadeMedicina");
            entity.Property(e => e.MedicoResponsavel)
                .HasMaxLength(50)
                .HasColumnName("medicoResponsavel");
            entity.Property(e => e.ResidenteId)
                .HasColumnType("int(11)")
                .HasColumnName("residente_id");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_consulta_funcionario1");

            entity.HasOne(d => d.IdEspecialidadeMedicinaNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdEspecialidadeMedicina)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_consulta_especialidadeMedicina1");

            entity.HasOne(d => d.Residente).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_consulta_residente1");
        });

        modelBuilder.Entity<Cuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cuidado");

            entity.HasIndex(e => e.IdFuncionario, "fk_cuidado_funcionario1_idx");

            entity.HasIndex(e => e.IdPlanejamentoCuidado, "fk_cuidado_planejamentoCuidado1_idx");

            entity.HasIndex(e => e.IdResidente, "fk_cuidado_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataExecucao)
                .HasColumnType("datetime")
                .HasColumnName("dataExecucao");
            entity.Property(e => e.IdFuncionario)
                .HasColumnType("int(11)")
                .HasColumnName("idFuncionario");
            entity.Property(e => e.IdPlanejamentoCuidado)
                .HasColumnType("int(11)")
                .HasColumnName("idPlanejamentoCuidado");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Cuidados)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cuidado_funcionario1");

            entity.HasOne(d => d.IdPlanejamentoCuidadoNavigation).WithMany(p => p.Cuidados)
                .HasForeignKey(d => d.IdPlanejamentoCuidado)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cuidado_planejamentoCuidado1");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Cuidados)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuidado_residente1");
        });

        modelBuilder.Entity<Especialidademedicina>(entity =>
        {
            entity.HasKey(e => e.IdespecialidadeMedicina).HasName("PRIMARY");

            entity.ToTable("especialidademedicina");

            entity.Property(e => e.IdespecialidadeMedicina)
                .HasColumnType("int(11)")
                .HasColumnName("idespecialidadeMedicina");
            entity.Property(e => e.NomeEspecialidade)
                .HasMaxLength(50)
                .HasColumnName("nomeEspecialidade");
        });

        modelBuilder.Entity<Exame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("exame");

            entity.HasIndex(e => e.IdConsulta, "fk_exame_consulta1_idx");

            entity.HasIndex(e => e.IdTipoExame, "fk_exame_tipoExame1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataRealizacao)
                .HasColumnType("datetime")
                .HasColumnName("dataRealizacao");
            entity.Property(e => e.DataResultado)
                .HasColumnType("datetime")
                .HasColumnName("dataResultado");
            entity.Property(e => e.IdConsulta)
                .HasColumnType("int(11)")
                .HasColumnName("idConsulta");
            entity.Property(e => e.IdTipoExame)
                .HasColumnType("int(11)")
                .HasColumnName("idTipoExame");
            entity.Property(e => e.Resultado)
                .HasMaxLength(100)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Exames)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_exame_consulta1");

            entity.HasOne(d => d.IdTipoExameNavigation).WithMany(p => p.Exames)
                .HasForeignKey(d => d.IdTipoExame)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_exame_tipoExame1");
        });

        modelBuilder.Entity<Fonterendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fonterenda");

            entity.HasIndex(e => e.IdResidente, "fk_fonteRenda_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .HasColumnName("nome");
            entity.Property(e => e.Valor)
                .HasPrecision(10)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Fonterenda)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_fonteRenda_residente1");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fornecedor");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");
        });

        modelBuilder.Entity<Fornecedororganizacao>(entity =>
        {
            entity.HasKey(e => new { e.IdFornecedor, e.IdOrganizacao }).HasName("PRIMARY");

            entity.ToTable("fornecedororganizacao");

            entity.HasIndex(e => e.IdFornecedor, "fk_fornecedor_has_organizacao_fornecedor1_idx");

            entity.HasIndex(e => e.IdOrganizacao, "fk_fornecedor_has_organizacao_organizacao1_idx");

            entity.Property(e => e.IdFornecedor)
                .HasColumnType("int(11)")
                .HasColumnName("idFornecedor");
            entity.Property(e => e.IdOrganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idOrganizacao");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(200)
                .HasColumnName("observacoes");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Fornecedororganizacaos)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_fornecedor_has_organizacao_fornecedor1");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Fornecedororganizacaos)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_fornecedor_has_organizacao_organizacao1");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcionario");

            entity.HasIndex(e => e.IdOrganizacao, "fk_funcionario_organizacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cargo)
                .HasMaxLength(15)
                .HasColumnName("cargo");
            entity.Property(e => e.Cep)
                .HasColumnType("int(11)")
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(30)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .HasColumnName("complemento");
            entity.Property(e => e.Cpf)
                .HasMaxLength(45)
                .HasColumnName("cpf");
            entity.Property(e => e.DataAdmissao)
                .HasColumnType("date")
                .HasColumnName("dataAdmissao");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdOrganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idOrganizacao");
            entity.Property(e => e.IdentificadorCasa)
                .HasMaxLength(10)
                .HasColumnName("identificadorCasa");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NumeroCasa)
                .HasColumnType("int(11)")
                .HasColumnName("numeroCasa");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Salario)
                .HasPrecision(10)
                .HasColumnName("salario");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");
            entity.Property(e => e.Status)
                .HasColumnType("enum('0','1')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_funcionario_organizacao1");
        });

        modelBuilder.Entity<Organizacao>(entity =>
        {
            entity.HasKey(e => e.Idorganizacao).HasName("PRIMARY");

            entity.ToTable("organizacao");

            entity.Property(e => e.Idorganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idorganizacao");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Planejamentocuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planejamentocuidado");

            entity.HasIndex(e => e.IdProduto, "fk_planejamentoCuidado_produto1_idx");

            entity.HasIndex(e => e.IdTipoCuidaddo, "fk_planejamentoCuidado_tipoCuidado1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Continuo).HasColumnName("continuo");
            entity.Property(e => e.DataFim)
                .HasColumnType("datetime")
                .HasColumnName("dataFim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("datetime")
                .HasColumnName("dataInicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.FrequenciaDiaria)
                .HasMaxLength(50)
                .HasColumnName("frequenciaDiaria");
            entity.Property(e => e.IdProduto)
                .HasColumnType("int(11)")
                .HasColumnName("idProduto");
            entity.Property(e => e.IdTipoCuidaddo)
                .HasColumnType("int(11)")
                .HasColumnName("idTipoCuidaddo");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Planejamentocuidados)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_planejamentoCuidado_produto1");

            entity.HasOne(d => d.IdTipoCuidaddoNavigation).WithMany(p => p.Planejamentocuidados)
                .HasForeignKey(d => d.IdTipoCuidaddo)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_planejamentoCuidado_tipoCuidado1");
        });

        modelBuilder.Entity<Planejamentocuidadodiario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planejamentocuidadodiario");

            entity.HasIndex(e => e.IdPlanejamentoCuidado, "fk_planejamentoCuidadoDiario_planejamentoCuidado1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DiaSemana)
                .HasColumnType("date")
                .HasColumnName("diaSemana");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.IdPlanejamentoCuidado)
                .HasColumnType("int(11)")
                .HasColumnName("idPlanejamentoCuidado");

            entity.HasOne(d => d.IdPlanejamentoCuidadoNavigation).WithMany(p => p.Planejamentocuidadodiarios)
                .HasForeignKey(d => d.IdPlanejamentoCuidado)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_planejamentoCuidadoDiario_planejamentoCuidado1");
        });

        modelBuilder.Entity<Planoassistencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planoassistencia");

            entity.HasIndex(e => e.ResidenteId, "fk_planoAssistencia_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasColumnType("int(11)")
                .HasColumnName("numero");
            entity.Property(e => e.NumeroSerie)
                .HasColumnType("int(11)")
                .HasColumnName("numeroSerie");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.ResidenteId)
                .HasColumnType("int(11)")
                .HasColumnName("residente_id");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");

            entity.HasOne(d => d.Residente).WithMany(p => p.Planoassistencia)
                .HasForeignKey(d => d.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_planoAssistencia_residente1");
        });

        modelBuilder.Entity<Planosaude>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("planosaude");

            entity.HasIndex(e => e.IdResidente, "fk_planoSaude_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasColumnType("int(11)")
                .HasColumnName("numero");
            entity.Property(e => e.NumeroSerie)
                .HasColumnType("int(11)")
                .HasColumnName("numeroSerie");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Planosaudes)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planoSaude_residente1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("produto");

            entity.HasIndex(e => e.IdOrganizacao, "fk_produto_organizacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Classificacao)
                .HasMaxLength(30)
                .HasColumnName("classificacao");
            entity.Property(e => e.IdOrganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idOrganizacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_produto_organizacao1");
        });

        modelBuilder.Entity<Residente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("residente");

            entity.HasIndex(e => e.IdFuncionario, "fk_residente_funcionario1_idx");

            entity.HasIndex(e => e.IdOrganizacao, "fk_residente_organizacao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CertidaoNascimento)
                .HasMaxLength(32)
                .HasColumnName("certidaoNascimento");
            entity.Property(e => e.CidadeNatal)
                .HasMaxLength(30)
                .HasColumnName("cidadeNatal");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(10)
                .HasColumnName("estadoCivil");
            entity.Property(e => e.EstadoNatal)
                .HasMaxLength(2)
                .HasColumnName("estadoNatal");
            entity.Property(e => e.FonteRenda)
                .HasMaxLength(60)
                .HasColumnName("fonteRenda");
            entity.Property(e => e.GrauDepedencia)
                .HasColumnType("enum('0','1')")
                .HasColumnName("grauDepedencia");
            entity.Property(e => e.GrauEscolaridade)
                .HasColumnType("enum('Fundamental Incompleto','Fundamental Completo','Médio Incompleto','Médio Completo','Superior Incompleto','Superior Completo','Pós-graduação','Mestrado','Doutorado')")
                .HasColumnName("grauEscolaridade");
            entity.Property(e => e.IdFuncionario)
                .HasColumnType("int(11)")
                .HasColumnName("idFuncionario");
            entity.Property(e => e.IdOrganizacao)
                .HasColumnType("int(11)")
                .HasColumnName("idOrganizacao");
            entity.Property(e => e.Interditado)
                .HasColumnType("enum('0','1')")
                .HasColumnName("interditado");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NomeMae)
                .HasMaxLength(50)
                .HasColumnName("nomeMae");
            entity.Property(e => e.NomePai)
                .HasMaxLength(50)
                .HasColumnName("nomePai");
            entity.Property(e => e.NumeroNis)
                .HasMaxLength(11)
                .HasColumnName("numeroNis");
            entity.Property(e => e.NumeroSus)
                .HasMaxLength(15)
                .HasColumnName("numeroSus");
            entity.Property(e => e.QuantidadeFilhos)
                .HasColumnType("int(11)")
                .HasColumnName("quantidadeFilhos");
            entity.Property(e => e.Rg)
                .HasMaxLength(9)
                .HasColumnName("rg");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Residentes)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_residente_funcionario1");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Residentes)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_residente_organizacao1");
        });

        modelBuilder.Entity<Responsavel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("responsavel");

            entity.HasIndex(e => e.IdResidente, "fk_responsavel_residente1_idx");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasColumnType("int(11)")
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(30)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .HasColumnName("complemento");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.Identificador)
                .HasMaxLength(10)
                .HasColumnName("identificador");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NumeroCasa)
                .HasColumnType("int(11)")
                .HasColumnName("numeroCasa");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.Rg)
                .HasMaxLength(9)
                .HasColumnName("rg");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");
            entity.Property(e => e.Vinculo)
                .HasMaxLength(20)
                .HasColumnName("vinculo");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Responsavels)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsavel_residente1");
        });

        modelBuilder.Entity<Tipocuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipocuidado");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.NomeCuidado)
                .HasMaxLength(50)
                .HasColumnName("nomeCuidado");
        });

        modelBuilder.Entity<Tipoexame>(entity =>
        {
            entity.HasKey(e => e.IdtipoExame).HasName("PRIMARY");

            entity.ToTable("tipoexame");

            entity.HasIndex(e => e.IdResidente, "fk_tipoExame_residente1_idx");

            entity.Property(e => e.IdtipoExame)
                .HasColumnType("int(11)")
                .HasColumnName("idtipoExame");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.NomeExame)
                .HasMaxLength(50)
                .HasColumnName("nomeExame");
            entity.Property(e => e.Preparacao)
                .HasMaxLength(100)
                .HasColumnName("preparacao");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Tipoexames)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_tipoExame_residente1");
        });

        modelBuilder.Entity<Visitante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visitante");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.PrimeiroTelefone)
                .HasMaxLength(13)
                .HasColumnName("primeiroTelefone");
            entity.Property(e => e.SegundoTelefone)
                .HasMaxLength(13)
                .HasColumnName("segundoTelefone");
        });

        modelBuilder.Entity<Visitum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visita");

            entity.HasIndex(e => e.IdResidente, "fk_visita_residente1_idx");

            entity.HasIndex(e => e.IdVisitante, "fk_visita_visitante1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataVisita)
                .HasColumnType("date")
                .HasColumnName("dataVisita");
            entity.Property(e => e.HorarioVisita)
                .HasColumnType("time")
                .HasColumnName("horarioVisita");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.IdVisitante)
                .HasColumnType("int(11)")
                .HasColumnName("idVisitante");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visita_residente1");

            entity.HasOne(d => d.IdVisitanteNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.IdVisitante)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visita_visitante1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
