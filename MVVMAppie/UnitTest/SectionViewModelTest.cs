using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMAppie.ViewModel;
using MVVMAppie.Model;
using System.Threading;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class SectionViewModelTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            var mockMessenger = mockRepository.Create<Database>();
            var vm = new SectionsVM(mockMessenger.Object);

            Assert.IsTrue(vm.Sections.Count >= 0);
        }

        [TestMethod]
        public void TestMethod2()
        {

        }
    }
}
