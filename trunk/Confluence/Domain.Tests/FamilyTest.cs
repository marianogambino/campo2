using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class FamilyTest
    {
        private Family familiaA;
        private Family familiaB;
        private Family familiaC;

        [SetUp]
        public void SetUp()
        {
            familiaA = new Family("Benvenutto","comen fideos");
            familiaB = new Family("Benvenutto","comen pastas");
            familiaC = new Family("Adams","tiene a Largo (que es lo mas)");
        }
        [Test]
        public void TestEquality()
        {
            //Equality is based on Family#Name

            Assert.That(familiaA,Is.EqualTo(familiaB));
            Assert.That(familiaB,Is.EqualTo(familiaA));

            Assert.That(familiaB, Is.Not.EqualTo(familiaC));
            Assert.That("Los Simpsons", Is.Not.EqualTo(familiaA));
            Assert.That(familiaA, Is.Not.EqualTo("Cualquier Fruta"));
        }
        [Test]
        public void TestHashCode()
        {
            Assert.That(familiaA.GetHashCode(),Is.EqualTo(familiaB.GetHashCode()));
            Assert.That(familiaA.GetHashCode(), Is.Not.EqualTo(familiaC.GetHashCode()));

            IDictionary<Family, String> patenteDic = new Dictionary<Family, String>();
            patenteDic[familiaA] = "una familia";
            patenteDic[familiaB] = "una familia que ya esta";
            patenteDic[familiaC] = "una familia que no esta";

            Assert.That(patenteDic.Count, Is.EqualTo(2));
            Assert.That(patenteDic[familiaA], Is.EqualTo(patenteDic[familiaB]));
        }
    }

}
