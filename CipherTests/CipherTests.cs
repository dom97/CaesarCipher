using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cipher;

namespace CipherTests
{
    [TestClass]
    public class CipherTests
    {
        private CaesarCipher caesar;

        [TestInitialize]
        public void Initialize()
        {
            caesar = new CaesarCipher(3);
        }

        [TestMethod]
        public void SingleCharacterIsEncodedCorrectly()
        {
            Assert.AreEqual("D", caesar.Encode("A"));
            Assert.AreEqual("A", caesar.Encode("X"));
        }

        [TestMethod]
        public void SingleWordIsEncodedCorrectly()
        {
            Assert.AreEqual("FRGH", caesar.Encode("Code"));
        }

        [TestMethod]
        public void PhraseIsEncdodedCorrectly()
        {
            Assert.AreEqual("ZKDW LV XS GDZJC", caesar.Encode("What is up dawgz"));
        }

        [TestMethod]
        public void SingleCharacterIsDecodedCorrectly()
        {
            Assert.AreEqual("X", caesar.Decode("A"));
            Assert.AreEqual("A", caesar.Decode("D"));
        }

        [TestMethod]
        public void SingleWordIsDecodedCorrectly()
        {
            Assert.AreEqual("CODE", caesar.Decode("FRGH"));
        }

        [TestMethod]
        public void PhraseIsDecdodedCorrectly()
        {
            Assert.AreEqual("WHAT IS UP DAWGZ", caesar.Decode("ZKDW LV XS GDZJC"));
        }
    }
}
