using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;


namespace Service.Tests
{
    [TestClass()]
    public class CuidadoServiceTests
    {
        private CuidadoContext cuidadoContext;
        private ICuidadoService cuidadoService;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<CuidadoContext>()
                .UseInMemoryDatabase(databaseName: "MyTestDb")
                .Options;

            cuidadoContext = new CuidadoContext(options);
            cuidadoContext.Database.EnsureDeleted();
            cuidadoContext.Database.EnsureCreated();

            var cuidados = new List<Cuidado>
                {
                    new Cuidado
                    {
                        Id = 1,
                        DataExecucao = DateTime.Now,
                        IdResidente = 1,
                        IdFuncionario = 1,
                        IdPlanejamentoCuidado = 1,
                    },
                    new Cuidado
                    {
                        Id = 2,
                        DataExecucao = DateTime.Now,
                        IdResidente = 2,
                        IdFuncionario = 2,
                        IdPlanejamentoCuidado = 2,
                    },
                    new Cuidado
                    {
                        Id = 3,
                        DataExecucao = DateTime.Now,
                        IdResidente = 3,
                        IdFuncionario = 3,
                        IdPlanejamentoCuidado = 3,
                    },
                };

            cuidadoContext.AddRange(cuidados);
            cuidadoContext.SaveChanges();

            cuidadoService = new CuidadoService(cuidadoContext);
        }


        [TestMethod()]
        public void Cria_Cuidado_Test()
        {
            //Act
            var date = DateTime.Now;

            cuidadoService.Create(new Cuidado
                {
                    Id = 4,
                    DataExecucao = date,
                    IdResidente = 4,
                    IdFuncionario = 4,
                    IdPlanejamentoCuidado = 4,
                });

            //Assert
            Assert.AreEqual(4, cuidadoService.GetAll().Count());

            var cuidado = cuidadoService.Get(4);
            Assert.IsNotNull(cuidado);
            Assert.AreEqual(4, cuidado.Id);
            Assert.AreEqual(date, cuidado.DataExecucao);
            Assert.AreEqual(4, cuidado.IdResidente);
            Assert.AreEqual(4, cuidado.IdFuncionario);
            Assert.AreEqual(4, cuidado.IdPlanejamentoCuidado);
        }

        [TestMethod()]
        public void Remove_Cuidado_Test()
        {
            //Act
            cuidadoService.Delete(2);

            //Assert
            Assert.AreEqual(2, cuidadoService.GetAll().Count());
            Assert.AreEqual(null, cuidadoService.Get(2));

        }

        [TestMethod()]
        public void Edita_Cuidado_Test()
        {
            //Act
            var cuidado = cuidadoService.Get(3)!;
            var date = DateTime.Now;

            cuidado.DataExecucao = date;
            cuidado.IdResidente = 10;
            cuidado.IdFuncionario =10;
            cuidado.IdPlanejamentoCuidado = 10;
            cuidadoService.Edit(cuidado);

            //Assert
            cuidado = cuidadoService.Get(3);
            Assert.IsNotNull(cuidado);
            Assert.AreEqual(date, cuidado.DataExecucao);
            Assert.AreEqual(10, cuidado.IdResidente);
            Assert.AreEqual(10, cuidado.IdFuncionario);
            Assert.AreEqual(10, cuidado.IdPlanejamentoCuidado);

        }

        [TestMethod()]
        public void Obtem_Um_Cuidado_Test()
        {
            var cuidado = cuidadoService.Get(1);

            Assert.IsNotNull(cuidado);
            Assert.AreEqual(1, cuidado.Id);
            Assert.AreNotEqual(DateTime.Now, cuidado.DataExecucao);
            Assert.AreEqual(1, cuidado.IdResidente);
            Assert.AreEqual(1, cuidado.IdFuncionario);
            Assert.AreEqual(1, cuidado.IdPlanejamentoCuidado);

        }

        [TestMethod()]
        public void Obtem_Todos_Cuidados_Test()
        {
            //Act
            var listaCuidados = cuidadoService.GetAll();

            //Assert
            Assert.IsInstanceOfType(listaCuidados, typeof(IEnumerable<Cuidado>));
            Assert.IsNotNull(listaCuidados);
            Assert.AreEqual(3, listaCuidados.Count());
            Assert.AreEqual(1, listaCuidados.First().Id);
        }


    }
}
