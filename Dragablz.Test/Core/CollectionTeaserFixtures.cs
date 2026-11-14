using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using FakeItEasy;

namespace Dragablz.Core.Tests
{
    [TestFixture]
    public class CollectionTeaserFixture
    {
        [Test]
        public void WillCreateForList()
        {
            var myList = new ArrayList();

            CollectionTeaser collectionTeaser;
            var result = CollectionTeaser.TryCreate(myList, out collectionTeaser);

            Assert.That(result, Is.True);
            Assert.That(collectionTeaser, Is.Not.Null);
        }

        [Test]
        public void WillCreateForGenericCollection()
        {
            var myList = A.Fake<ICollection<string>>();

            CollectionTeaser collectionTeaser;
            var result = CollectionTeaser.TryCreate(myList, out collectionTeaser);

            Assert.That(result, Is.True);
            Assert.That(collectionTeaser, Is.Not.Null);
        }

        [Test]
        public void WillCreateForCollection()
        {
            var myList = A.Fake<ICollection>();

            CollectionTeaser collectionTeaser;
            var result = CollectionTeaser.TryCreate(myList, out collectionTeaser);

            Assert.That(result, Is.False);
            Assert.That(collectionTeaser, Is.Null);
        }

        [Test]
        public void WillAddForList()
        {
            var myList = new ArrayList();
            CollectionTeaser collectionTeaser;
            Assert.That(CollectionTeaser.TryCreate(myList, out collectionTeaser), Is.True);

            collectionTeaser.Add("i am going to type this in, manually, twice.");

            Assert.That(myList, Is.EquivalentTo(new[] { "i am going to type this in, manually, twice." }));
            //i didnt really.  i copied and pasted it.
        }

        [Test]
        public void WillRemoveForList()
        {
            var myList = new ArrayList
            {
                1,
                2,
                3,
                4,
                5
            };
            CollectionTeaser collectionTeaser;
            Assert.That(CollectionTeaser.TryCreate(myList, out collectionTeaser), Is.True);

            collectionTeaser.Remove(3);

            Assert.That(myList, Is.EquivalentTo(new[] { 1, 2, 4, 5 }));
        }

        [Test]
        public void WillAddForGenericCollection()
        {
            var myList = A.Fake<ICollection<string>>();
            CollectionTeaser collectionTeaser;
            Assert.That(CollectionTeaser.TryCreate(myList, out collectionTeaser), Is.True);

            collectionTeaser.Add("hello");

            A.CallTo(() => myList.Add("hello")).MustHaveHappened();
            A.CallTo(() => myList.Remove("hello")).MustNotHaveHappened();
        }

        [Test]
        public void WillRemoveForGenericCollection()
        {
            var myList = A.Fake<ICollection<string>>();
            CollectionTeaser collectionTeaser;
            Assert.That(CollectionTeaser.TryCreate(myList, out collectionTeaser), Is.True);

            collectionTeaser.Remove("bye");

            A.CallTo(() => myList.Remove("bye")).MustHaveHappened();
            A.CallTo(() => myList.Add("bye")).MustNotHaveHappened();
        }
    }
}