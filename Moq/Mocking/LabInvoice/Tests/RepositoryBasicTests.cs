using Moq;
using NUnit.Framework;
using LabInvoice;

namespace LabInvoice.Tests {
    [TestFixture]
    class RepositoryBasicTests {
        [Test]
        public void the_repository_remove_should_be_called() {
            var mockRepository = new Mock<IRepository<Invoice>>();

            mockRepository.Setup(x => x.Add(It.IsAny<Invoice>()));

            var sut = new Client(mockRepository.Object);

            sut.Buy(null);

            mockRepository.VerifyAll();
        }
        [Test]
        public void the_repository_returns_false_when_not_find() {
            var mockRepository = new Mock<IRepository<Invoice>>();

            mockRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(() => null);

            var sut = new Client(mockRepository.Object);

            Assert.That(sut.Return(new Invoice()), Is.False);
        }
        [Test]
        public void the_repository_remove_should_be_called_when_find() {
            var mockRepository = new Mock<IRepository<Invoice>>();

            mockRepository.Setup(x => x.FindById(It.IsAny<int>())).Returns(() => new Invoice());

            var sut = new Client(mockRepository.Object);

            sut.Return(new Invoice());

            mockRepository.Verify(x => x.Delete(It.IsAny<Invoice>()),Times.Once);
        }
    }
}
