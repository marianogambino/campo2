using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class PatenteTest
    {
        private Patente pat1;
        private Patente pat2;
        private Patente pat3;

        [SetUp]
        public void SetUp()
        {
            pat1 = new Patente(0, "Nombre", "Pathio");
            pat2 = new Patente(0, "Nombresss", "Pathioss");
            pat3 = new Patente(1, "Nombres", "Pathio2");
        }
        [Test]
        public void TestEquality()
        {
            //Equality is based on Patente#Id

            Assert.That(pat1,Is.EqualTo(pat2));
            Assert.That(pat2,Is.EqualTo(pat1));

            Assert.That(pat2, Is.Not.EqualTo(pat3));
            Assert.That("not a patente", Is.Not.EqualTo(pat1));
            Assert.That(pat1, Is.Not.EqualTo("Nombre"));
        }
        [Test]
        public void TestHashCode()
        {
            //Hashcode is based on Patente#Id

            Assert.That(pat1.GetHashCode(),Is.EqualTo(pat2.GetHashCode()));
            Assert.That(pat1.GetHashCode(), Is.Not.EqualTo(pat3.GetHashCode()));

            IDictionary<Patente, String> patenteDic = new Dictionary<Patente, String>();
            patenteDic[pat1] = "una patente";
            patenteDic[pat2] = "una patente que no va";
            patenteDic[pat3] = "una patente que si va";

            Assert.That(patenteDic.Count, Is.EqualTo(2));
            Assert.That(patenteDic[pat1], Is.EqualTo(patenteDic[pat2]));
        }
    }
}
