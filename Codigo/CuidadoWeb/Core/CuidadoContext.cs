using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Core;

public partial class CuidadoContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public CuidadoContext()
    {
    }

    public CuidadoContext(DbContextOptions<CuidadoContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public CuidadoContext(DbContextOptions<CuidadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acompanhante> Acompanhante { get; set; }

    public virtual DbSet<Aquisicao> Aquisicao { get; set; }

    public virtual DbSet<AquisicaoProduto> AquisicaoProduto { get; set; }

    public virtual DbSet<AtividadeExterna> AtividadeExterna { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<Cuidado> Cuidado { get; set; }

    public virtual DbSet<EspecialidadeMedicina> EspecialidadeMedicina { get; set; }

    public virtual DbSet<Exame> Exame { get; set; }

    public virtual DbSet<FonteRenda> FonteRenda { get; set; }

    public virtual DbSet<Fornecedor> Fornecedor { get; set; }

    public virtual DbSet<FornecedorOrganizacao> FornecedorOrganizacao { get; set; }

    public virtual DbSet<Funcionario> Funcionario { get; set; }

    public virtual DbSet<Organizacao> Organizacao { get; set; }

    public virtual DbSet<PlanejamentoCuidado> PlanejamentoCuidado { get; set; }

    public virtual DbSet<PlanejamentoCuidadoDiario> PlanejamentoCuidadoDiario { get; set; }

    public virtual DbSet<PlanoAssistencia> PlanoAssistencia { get; set; }

    public virtual DbSet<PlanoSaude> PlanoSaude { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<Residente> Residente { get; set; }

    public virtual DbSet<Responsavel> Responsavel { get; set; }

    public virtual DbSet<TipoCuidado> TipoCuidado { get; set; }

    public virtual DbSet<TipoExame> TipoExame { get; set; }

    public virtual DbSet<Visita> Visita { get; set; }

    public virtual DbSet<Visitante> Visitante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Test")
            return;


        if (_configuration == null)
            throw new InvalidOperationException();

        var connectionString = _configuration.GetConnectionString("CuidadoConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Acompanhante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdAtividadeExternaNavigation).WithMany(p => p.Acompanhante)
                .HasForeignKey(d => d.IdAtividadeExterna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_acompanhantes_atividadeExterna1");
        });

        modelBuilder.Entity<Aquisicao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Aquisicao)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aquisicao_fornecedor1");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Aquisicao)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aquisicao_funcionario1");
        });

        modelBuilder.Entity<AquisicaoProduto>(entity =>
        {
            entity.HasKey(e => new { e.IdAquisicao, e.IdProduto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

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

            entity.HasOne(d => d.IdAquisicaoNavigation).WithMany(p => p.AquisicaoProduto)
                .HasForeignKey(d => d.IdAquisicao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aquisicao_has_produto_aquisicao1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.AquisicaoProduto)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aquisicao_has_produto_produto1");
        });

        modelBuilder.Entity<AtividadeExterna>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdOrganizacao, "fk_atividadeExterna_organizacao1_idx");

            entity.HasIndex(e => e.IdResidente, "fk_atividadeExterna_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataRealizacao).HasColumnName("dataRealizacao");
            entity.Property(e => e.DataTermino).HasColumnName("dataTermino");
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

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.AtividadeExterna)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_atividadeExterna_organizacao1");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.AtividadeExterna)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_atividadeExterna_residente1");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdEspecialidadeMedicina, "fk_consulta_especialidadeMedicina1_idx");

            entity.HasIndex(e => e.IdFuncionario, "fk_consulta_funcionario1_idx");

            entity.HasIndex(e => e.IdResidente, "fk_consulta_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
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
            entity.Property(e => e.IdEspecialidadeMedicina)
                .HasColumnType("int(11)")
                .HasColumnName("idEspecialidadeMedicina");
            entity.Property(e => e.IdFuncionario)
                .HasColumnType("int(11)")
                .HasColumnName("idFuncionario");
            entity.Property(e => e.IdResidente)
                .HasColumnType("int(11)")
                .HasColumnName("idResidente");
            entity.Property(e => e.MedicoResponsavel)
                .HasMaxLength(50)
                .HasColumnName("medicoResponsavel");

            entity.HasOne(d => d.IdEspecialidadeMedicinaNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdEspecialidadeMedicina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_especialidadeMedicina1");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_funcionario1");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_residente1");
        });

        modelBuilder.Entity<Cuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Cuidado)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuidado_funcionario1");

            entity.HasOne(d => d.IdPlanejamentoCuidadoNavigation).WithMany(p => p.Cuidado)
                .HasForeignKey(d => d.IdPlanejamentoCuidado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuidado_planejamentoCuidado1");

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Cuidado)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cuidado_residente1");
        });

        modelBuilder.Entity<EspecialidadeMedicina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Exame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Exame)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_exame_consulta1");

            entity.HasOne(d => d.IdTipoExameNavigation).WithMany(p => p.Exame)
                .HasForeignKey(d => d.IdTipoExame)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_exame_tipoExame1");
        });

        modelBuilder.Entity<FonteRenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.FonteRendaNavigation)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fonteRenda_residente1");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

        modelBuilder.Entity<FornecedorOrganizacao>(entity =>
        {
            entity.HasKey(e => new { e.IdFornecedor, e.IdOrganizacao })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

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

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.FornecedorOrganizacao)
                .HasForeignKey(d => d.IdFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fornecedor_has_organizacao_fornecedor1");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.FornecedorOrganizacao)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fornecedor_has_organizacao_organizacao1");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.DataAdmissao).HasColumnName("dataAdmissao");
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
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
                .HasComment("A -> Ativo\nI -> Inativo")
                .HasColumnType("enum('A','I')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Funcionario)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_funcionario_organizacao1");
        });

        modelBuilder.Entity<Organizacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<PlanejamentoCuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.PlanejamentoCuidado)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planejamentoCuidado_produto1");

            entity.HasOne(d => d.IdTipoCuidaddoNavigation).WithMany(p => p.PlanejamentoCuidado)
                .HasForeignKey(d => d.IdTipoCuidaddo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planejamentoCuidado_tipoCuidado1");
        });

        modelBuilder.Entity<PlanejamentoCuidadoDiario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdPlanejamentoCuidado, "fk_planejamentoCuidadoDiario_planejamentoCuidado1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.IdPlanejamentoCuidado)
                .HasColumnType("int(11)")
                .HasColumnName("idPlanejamentoCuidado");

            entity.HasOne(d => d.IdPlanejamentoCuidadoNavigation).WithMany(p => p.PlanejamentoCuidadoDiario)
                .HasForeignKey(d => d.IdPlanejamentoCuidado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planejamentoCuidadoDiario_planejamentoCuidado1");
        });

        modelBuilder.Entity<PlanoAssistencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdResidente, "fk_planoAssistencia_residente1_idx");

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

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.PlanoAssistencia)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planoAssistencia_residente1");
        });

        modelBuilder.Entity<PlanoSaude>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.PlanoSaude)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_planoSaude_residente1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Produto)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produto_organizacao1");
        });

        modelBuilder.Entity<Residente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
            entity.Property(e => e.EstadoCivil)
                .HasColumnType("enum('Solteiro','Casado','Divorciado','Viúvo','União estável')")
                .HasColumnName("estadoCivil");
            entity.Property(e => e.EstadoNatal)
                .HasMaxLength(2)
                .HasColumnName("estadoNatal");
            entity.Property(e => e.FonteRenda)
                .HasMaxLength(60)
                .HasColumnName("fonteRenda");
            entity.Property(e => e.GrauDepedencia)
                .HasColumnType("tinyint(4)")
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
                .HasColumnType("tinyint(4)")
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

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Residente)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_residente_funcionario1");

            entity.HasOne(d => d.IdOrganizacaoNavigation).WithMany(p => p.Residente)
                .HasForeignKey(d => d.IdOrganizacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_residente_organizacao1");
        });

        modelBuilder.Entity<Responsavel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.Responsavel)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_responsavel_residente1");
        });

        modelBuilder.Entity<TipoCuidado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<TipoExame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdResidente, "fk_tipoExame_residente1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
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

            entity.HasOne(d => d.IdResidenteNavigation).WithMany(p => p.TipoExame)
                .HasForeignKey(d => d.IdResidente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipoExame_residente1");
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdResidente, "fk_visita_residente1_idx");

            entity.HasIndex(e => e.IdVisitante, "fk_visita_visitante1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataVisita).HasColumnName("dataVisita");
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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_visita_residente1");

            entity.HasOne(d => d.IdVisitanteNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.IdVisitante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_visita_visitante1");
        });

        modelBuilder.Entity<Visitante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
