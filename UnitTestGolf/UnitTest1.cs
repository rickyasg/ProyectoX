using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HamDataModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnitTestGolf
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetGolCategoria()
        {
            GolfCategoria gc = new GolfCategoria();
            gc = GolfCategoria.GetGolCategoria(13);

            GolfCategoria gc1 = new GolfCategoria();
            gc1.CategoriaId = 13;
            gc1.Descripcion = "CATEGORIA A (0 - 16)";
            gc1.EventoDeportivoId = 2;
            gc1.Porcentaje = 80.0;

            Assert.AreEqual(gc1.Descripcion, gc.Descripcion);
        }
        //[TestMethod]
        //public void TestGetGolfCategorias()
        //{
        //    string json = "[{\"categoriaId\":13,\"descripcion\":\"CATEGORIA A (0 - 16)\",\"eventoDeportivoId\":2,\"porcentaje\":80.0},{\"categoriaId\":14,\"descripcion\":\"CATEGORIA B (17 - 36)\",\"eventoDeportivoId\":2,\"porcentaje\":80.0}]";
        //    JsonSerializer serializer = new JsonSerializer();
        //    GolfCategoria gc = new GolfCategoria();
        //    List<GolfCategoria> expected = JsonConvert.DeserializeObject<List<GolfCategoria>>(json);
        //    List<GolfCategoria> actual = GolfCategoria.GetGolCategorias();
        //    Assert.AreEqual(expected.Count, actual.Count);
        //    int idx = 0;
        //    foreach (var item in actual)
        //    {
        //        Assert.AreEqual(expected[idx].CategoriaId, item.CategoriaId);
        //        Assert.AreEqual(expected[idx].Descripcion, item.Descripcion);
        //        Assert.AreEqual(expected[idx].EventoDeportivoId, item.EventoDeportivoId);
        //        Assert.AreEqual(expected[idx].Porcentaje, item.Porcentaje);
        //        idx++;
        //    }
        //}

        //[TestMethod]
        //public void TestGetGolfCategoriasVacias()
        //{
        //    GolfCategoria gc = new GolfCategoria();
        //    List<GolfCategoria> actual = GolfCategoria.GetGolCategorias();
        //    Assert.AreNotEqual(0, actual.Count);
        //}
    }
}
