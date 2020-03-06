using NUnit.Framework;

namespace AssertDemo.Tests.ObjectTypesAndProperties
{
    [TestFixture]
    public class EnemyFactoryTests
    {
        [Test]
        public void ShouldCreateNormalEnemy()
        {
            var sut = new EnemyFactory();

            object enemy = sut.Create(false);

            Assert.That(enemy, Is.TypeOf<NormalEnemy>());
        }


        [Test]
        public void ShouldCreateBossEnemy()
        {
            var sut = new EnemyFactory();

            object enemy = sut.Create(true);

            Assert.That(enemy, Is.TypeOf<BossEnemy>());
        }


        [Test]
        public void ShouldBeOfBaseType()
        {
            var sut = new EnemyFactory();

            object enemy = sut.Create(true);

            Assert.That(enemy, Is.InstanceOf<Enemy>());            
        }


        [Test]
        public void ShouldHaveExtraPower()
        {
            var sut = new EnemyFactory();

            object enemy = sut.Create(true);

            Assert.That(enemy, Has.Property("ExtraPower"));

            //Assert.That(enemy, Has.Property("SomeOtherProperty"));
        }
    }
}
