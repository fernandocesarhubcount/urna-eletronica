using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrnaEletronica.DAL;
using UrnaEletronica.DAL.Repositories;
using UrnaEletronica.Model;

namespace UrnaEletronica.Tests
{
    [TestClass]
    public class EleitorRepositorioTeste
    {
        [TestMethod]
        public void DeveSavarCandidatoNoBanco()
        {
            var context = new UrnaEletronicaContext();
            var repositorio = new CandidatoRepositorio(context);
            var candidato = new Candidato("Elias Carneiro", "Roberto Carlos", null, 56);
            repositorio.Salvar(candidato);
        }
    }
}
