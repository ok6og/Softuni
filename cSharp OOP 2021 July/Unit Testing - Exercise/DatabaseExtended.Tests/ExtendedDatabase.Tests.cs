using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDb;
        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_InitiazlizePeople()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name:{i}");
            }
            extendedDb = new ExtendedDatabase(persons);
            Assert.That(extendedDb.Count, Is.EqualTo(persons.Length));

            foreach (var person in persons)
            {
                Person dbPerson = extendedDb.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Pesho{i}");
            }
            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsExceptionWhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Name{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, "assdasd")));
        }


        [Test]
        public void Add_ThrowsException_WhenUsernameExistsAlready()
        {
            var name = "Pesho";
            extendedDb.Add(new Person(1, name));

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, name)));
        }

        [Test]
        public void Add_ThrowsException_WhenIDExistsAlready()
        {
            var id = 1;
            extendedDb.Add(new Person(id, "asdasd"));

            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(id, "name")));
        }

        [Test]
        public void Add_IncrementValue()
        {
            var expectedCount = 5;
            extendedDb.Add(new Person(1, "Gosho1"));
            extendedDb.Add(new Person(2, "Gosho2"));
            extendedDb.Add(new Person(3, "Gosho3"));
            extendedDb.Add(new Person(4, "Gosho4"));
            extendedDb.Add(new Person(5, "Gosho5"));
            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.Remove());
        }

        [Test]
        public void Remove_RemoveElementFromDb()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Fresh{i}"));
            }
            extendedDb.Remove();
            Assert.That(extendedDb.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsExceptionWhenInvaildUsername(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("skdfjif"));
        }

        [Test]
        public void FindByUsername_ReturnsCorrectResult()
        {
            var person = new Person(2, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void FindById_ThrowsExceptionForInvalidId()
        {

            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(123));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-99)]
        public void FindById_ThrowsExceptionWhenIdIsNegativeValue(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(id));
        }

        [Test]
        public void FindById_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));
        }






    }
}