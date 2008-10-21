using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Confluence.Domain.Tests
{
    public abstract class EqualityTest<T>
    {
        private T original;
        private T copy;
        private T different;

        public T Original
        {
            get { return original; }
            set { original = value; }
        }
        public T Copy
        {
            get { return copy; }
            set { copy = value; }
        }
        public T Different
        {
            get { return different; }
            set { different = value; }
        }

        [Test]
        public void TestEquality()
        {
            Assert.AreEqual(Original, Copy);
            Assert.AreEqual(Copy, Original);

            Assert.AreNotEqual(Copy, Different);
            Assert.AreNotEqual("Any String", Copy);
            Assert.AreNotEqual(Original, "Any Thing");
        }
        [Test]
        public void TestHashCode()
        {
            Assert.AreEqual(Original.GetHashCode(), Copy.GetHashCode());
            Assert.AreNotEqual(Original.GetHashCode(), Different.GetHashCode());

            IDictionary<T, String> patenteDic = new Dictionary<T, String>();
            patenteDic[Original] = "first entity";
            patenteDic[Copy] = "duplicate entity (does not enter in the Dic";
            patenteDic[Different] = "third entity (enters)";

            Assert.AreEqual(patenteDic.Count, 2);
            Assert.AreEqual(patenteDic[Original], patenteDic[Copy]);
        }
    }
}
