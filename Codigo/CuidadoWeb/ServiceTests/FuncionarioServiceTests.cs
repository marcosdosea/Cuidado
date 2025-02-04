using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class FuncionarioServiceTests
    {
        private CuidadoContext? context;
        private IFuncionarioService? funcionarioService;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CuidadoContext>();
            builder.UseInMemoryDatabase("Cuidado");
            var options = builder.Options;
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
            context = new CuidadoContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var funcionarios = new List<Funcionario>
                {
                   new Funcionario
                    {
                        Id = 1,
                        Nome = "Igor Andrade Nepomuceno",
                        Cpf = "48754544068",
                        DataNascimento = DateOnly.Parse("1992-10-27"),
                        DataAdmissao = DateOnly.Parse("2015-01-01"),
                        Cargo = "Cuidador",
                        Status = "Ativo",
                        Salario = 3100.00m,
                        NumeroCasa = 11,
                        IdentificadorCasa = "A",
                        Rua = "Rua dos Escritores",
                        Bairro = "Centro",
                        Cidade = "Itabaiana",
                        Estado = "SE",
                        Cep = 49500511,
                        Complemento = "Apartamento 201",
                        PrimeiroTelefone = "79999194678",
                        SegundoTelefone = "79980054321",
                        IdOrganizacao = 1
                    },
                    new Funcionario
                    {
                        Id = 2,
                        Nome = "Paulo Ramos da Costa",
                        Cpf = "49118473016",
                        DataNascimento = DateOnly.Parse("1990-08-02"),
                        DataAdmissao = DateOnly.Parse("2020-01-01"),
                        Cargo = "Cuidador",
                        Status = "Ativo",
                        Salario = 3100.00m,
                        NumeroCasa = 26,
                        IdentificadorCasa = "A",
                        Rua = "Rua das Flores",
                        Bairro = "Centro",
                        Cidade = "Itabaiana",
                        Estado = "SE",
                        Cep = 49500501,
                        Complemento = "",
                        PrimeiroTelefone = "79999194678",
                        SegundoTelefone = "",
                        IdOrganizacao = 1
                    },
                    new Funcionario
                    {
                        Id = 3,
                        Nome = "Gildete da Silva Matos",
                        Cpf = "87620365052",
                        DataNascimento = DateOnly.Parse("2000-10-02"),
                        DataAdmissao = DateOnly.Parse("2021-01-01"),
                        Cargo = "Diretora",
                        Status = "Ativo",
                        Salario = 4200.00m,
                        NumeroCasa = 12,
                        IdentificadorCasa = "A",
                        Rua = "Rua dos Jarros",
                        Bairro = "Centro",
                        Cidade = "Itabaiana",
                        Estado = "SE",
                        Cep = 49500512,
                        Complemento = "",
                        PrimeiroTelefone = "79999195578",
                        SegundoTelefone = "",
                        IdOrganizacao = 2
                    }
                };

            context.AddRange(funcionarios);
            context.SaveChanges();

            funcionarioService = new FuncionarioService(context);
        }


        [TestMethod()]
        public void CreateTest()
        {
            // Act
            funcionarioService!.Create(
                    new Funcionario
                    {
                        Id = 4,
                        Nome = "Paulo Henrique Soares de Lima",
                        Cpf = "40646520024",
                        DataNascimento = DateOnly.Parse("2004-10-02"),
                        DataAdmissao = DateOnly.Parse("2022-11-01"),
                        Cargo = "Cuidador",
                        Status = "Ativo",
                        Salario = 4200.00m,
                        NumeroCasa = 12,
                        IdentificadorCasa = null,
                        Rua = "Avenida Ivo de Carvalho",
                        Bairro = "Centro",
                        Cidade = "Itabaiana",
                        Estado = "SE",
                        Cep = 49500970,
                        Complemento = "336",
                        PrimeiroTelefone = "79999105555",
                        SegundoTelefone = "",
                        IdOrganizacao = 3
                    }
                );
            // Assert
            Assert.AreEqual(4, funcionarioService.GetAll().Count());
            var funcionario = funcionarioService.Get(4);
            Assert.AreEqual("Paulo Henrique Soares de Lima", funcionario!.Nome);
            Assert.AreEqual("40646520024", funcionario.Cpf);
            Assert.AreEqual(DateOnly.Parse("2004-10-02"), funcionario.DataNascimento);
            Assert.AreEqual(DateOnly.Parse("2022-11-01"), funcionario.DataAdmissao);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            funcionarioService!.Delete(1);
            // Assert
            Assert.AreEqual(2, funcionarioService!.GetAll().Count());
            var funcionario = funcionarioService!.Get(1);
            Assert.AreEqual(null, funcionario);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act
            var funcionario = funcionarioService!.Get(1);
            funcionario!.Cargo = "Enfermeiro";
            funcionario!.IdOrganizacao = 2;
            funcionarioService!.Edit(funcionario);
            // Assert
            funcionario = funcionarioService!.Get(1);
            Assert.AreEqual("Enfermeiro", funcionario!.Cargo);
            Assert.AreEqual(2, funcionario!.IdOrganizacao);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Act
            var funcionario = funcionarioService!.Get(1);
            // Assert
            Assert.IsNotNull(funcionario);
            Assert.AreEqual("Igor Andrade Nepomuceno", funcionario.Nome);
            Assert.AreEqual("48754544068", funcionario.Cpf);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaFuncionarios = funcionarioService!.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaFuncionarios, typeof(IEnumerable<Funcionario>));
            Assert.IsNotNull(listaFuncionarios);
            Assert.AreEqual(3, listaFuncionarios.Count());
        }

        [TestMethod()]
        public async Task BuscarFuncionarioPorCpfTestAsync()
        {
            // Act
            string cpf = "48754544068";
            var funcionarioDTO = await funcionarioService!.BuscarFuncionarioPorCpf(cpf);
            // Assert
            Assert.IsNotNull(funcionarioDTO, "O funcionário não foi encontrado.");
            Assert.AreEqual("Igor Andrade Nepomuceno", funcionarioDTO.Nome);
            Assert.AreEqual(cpf, funcionarioDTO.Cpf);
            Assert.AreEqual(3100.00m, funcionarioDTO.Salario);
            Assert.AreEqual("Ativo", funcionarioDTO.Status);
            Assert.AreEqual("Cuidador", funcionarioDTO.Cargo);
        }
    }
}