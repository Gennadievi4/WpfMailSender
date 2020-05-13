using MailSender.lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailsender.lib.Tests.Services
{
    [TestClass]
    public class RecipientStoreInMemoryTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentNullException_if_T_null()
        {
            var store = new RecipientStoreInMemory();
            store.Create(null);
        }

        [TestMethod]
        public void Create_throw_ArgumentNullException_if_T_null2()
        {
            var store = new RecipientStoreInMemory();
            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));
        }
    }
}
