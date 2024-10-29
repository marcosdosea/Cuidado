using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;


namespace Service.Tests
{
    [TestClass()]
    public class VisitanteServiceTests
    {
        private CuidadoContext cuidadoContext;
        private IVisitanteService visitanteService;

        [TestInitialize]
        public void Initialize()
        { 
            var options = new DbContextOptionsBuilder<CuidadoContext>()
           .UseInMemoryDatabase(databaseName: "MyTestDb")
           .Options;
            cuidadoContext = new CuidadoContext(options);
            cuidadoContext.Database.EnsureDeleted();
            cuidadoContext.Database.EnsureCreated();

            var visitantes = new List<Visitante>
                {
                    new() { Id = 1, Nome = "Visitante 1", Cpf = "12345678901", PrimeiroTelefone = "123456789", SegundoTelefone = "987654321" },
                    new Visitante { Id = 2, Nome = "Visitante 2", Cpf = "12345678902", PrimeiroTelefone = "123456789", SegundoTelefone = "987654321" },
                    new Visitante { Id = 3, Nome = "Visitante 3", Cpf = "12345678903", PrimeiroTelefone = "123456789", SegundoTelefone = "987654321" }
                };

            cuidadoContext.AddRange(visitantes);
            cuidadoContext.SaveChanges();

            visitanteService = new VisitanteService(cuidadoContext);
        }


        [TestMethod()]
        public void CreateTest()
        {
            //Act
            visitanteService.Create(new Visitante { Id = 4, Nome = "Visitante 4", Cpf = "12345678904", PrimeiroTelefone = "123456789", SegundoTelefone = "987654321" });
            //Assert
            Assert.AreEqual(4, visitanteService.GetAll().Count());
            var visitante = visitanteService.Get(4);
            Assert.AreEqual("Visitante 4", visitante.Nome);
            Assert.AreEqual("12345678904", visitante.Cpf);
            Assert.AreEqual("123456789", visitante.PrimeiroTelefone);
            Assert.AreEqual("987654321", visitante.SegundoTelefone);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Act
            visitanteService.Delete(2);
            //Assert
            Assert.AreEqual(2, visitanteService.GetAll().Count());
            var visitante = visitanteService.Get(2);
            Assert.AreEqual(null, visitante);

        }

        [TestMethod()]
        public void EditTest()
        {
            //Act
            var visitante = visitanteService.Get(3);
            visitante.Nome = "Visitante 3 ";
            visitante.Cpf = "12345678903 ";
            visitante.PrimeiroTelefone = "123456789 ";
            visitante.SegundoTelefone = "987654321 ";
            visitanteService.Edit(visitante);
            //Assert
            visitante = visitanteService.Get(3);
            Assert.IsNotNull(visitante);
            Assert.AreEqual("Visitante 3 ", visitante.Nome);
            Assert.AreEqual("12345678903 ", visitante.Cpf);
            Assert.AreEqual("123456789 ", visitante.PrimeiroTelefone);
            Assert.AreEqual("987654321 ", visitante.SegundoTelefone);

        }

        [TestMethod()]
        public void GetTest()
        {
            var visitante = visitanteService.Get(1);
            Assert.IsNotNull(visitante);
            Assert.AreEqual("Visitante 1", visitante.Nome);
            Assert.AreEqual("12345678901", visitante.Cpf);
            Assert.AreEqual("123456789", visitante.PrimeiroTelefone);
            Assert.AreEqual("987654321", visitante.SegundoTelefone);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaVisitantes = visitanteService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaVisitantes, typeof(IEnumerable<Visitante>));
            Assert.IsNotNull(listaVisitantes);
            Assert.AreEqual(3, listaVisitantes.Count());
            Assert.AreEqual(1, listaVisitantes.First().Id);
            Assert.AreEqual("Visitante 1", listaVisitantes.First().Nome);
        }


    }
}