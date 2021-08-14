namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorInitalizeCorrectly()
        {
            string name = "aName";
            int capacity = 1;
            Aquarium aquarium = new Aquarium(name, capacity);
            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);

        }

        [Test]
        public void SetNameThrowExc()
        {
            Assert.Throws<ArgumentNullException>(()=> new Aquarium(null,1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 1));
        }

        [Test]
        public void SetCapacityException()
        {
            
            Assert.Throws<ArgumentException>(() => new Aquarium("zz", -1));
            Assert.Throws<ArgumentException>(() => new Aquarium("z232z", -33));
        }

        [Test]
        public void Count()
        {

            Aquarium aquarium = new Aquarium("aaa", 2);
            aquarium.Add(new Fish("aveEi"));
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddShouldThrowException()
        {

            Aquarium aquarium = new Aquarium("aaa", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("FishyBBB")));
        }

        [Test]
        public void RemoveThrowsException()
        {
            Aquarium aquarium = new Aquarium("aaa", 3);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void RemoveWorks()
        {
            Aquarium aquarium = new Aquarium("aaa", 23);
            aquarium.Add(new Fish("alabalaLOL"));
            Assert.That(aquarium.Count, Is.EqualTo(1));
            aquarium.RemoveFish("alabalaLOL");
            Assert.AreEqual(aquarium.Count, 0);

        }

        [Test]
        public void SellFishThrowsException()
        {
            Aquarium aquarium = new Aquarium("aaa", 23);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));

        }
        [Test]
        public void SellFish()
        {
            Aquarium aquarium = new Aquarium("aaa", 23);
            aquarium.Add(new Fish("alabalaLOL"));

            Fish fish = aquarium.SellFish("alabalaLOL");
            Assert.AreEqual(fish.Name, "alabalaLOL");
            Assert.AreEqual(fish.Available, false);

        }

        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium("aaa", 23);
            aquarium.Add(new Fish("alabalaLOL"));
            Fish fish = aquarium.SellFish("alabalaLOL");
            string expectedMessage = $"Fish available at aaa: alabalaLOL";
            Assert.AreEqual(expectedMessage, aquarium.Report());
        }
    }
}
