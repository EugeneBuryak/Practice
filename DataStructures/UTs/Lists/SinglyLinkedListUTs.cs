using System;
using DS.Lists.SinglyLinkedList;
using FluentAssertions;
using NUnit.Framework;

namespace UTs.Lists
{
    [TestFixture]
    public class SinglyLinkedListUTs
    {
        [Test]
        public void Clear_ShouldClearList()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);

            sut.Clear();

            Assert.Throws(typeof(NullReferenceException), () => sut.PeekLast(), "List is empty.");
            Assert.Throws(typeof(NullReferenceException), () => sut.PeekFirst(), "List is empty.");
            sut.Count.Should().Be(0);
        }

        [Test]
        public void Indexer_ShouldReturnCorrectValue()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);

            sut[1].Should().Be(1);
        }

        [Test]
        public void Indexer_ShouldThrowIndexOutOfRangeException_WhenIndexOtOfRange()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = sut[-1]);
            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = sut[2]);
        }

        [Test]
        public void Add_ShouldAddNode()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.PeekFirst().Should().Be(0);
            sut[1].Should().Be(1);
            sut.PeekLast().Should().Be(2);
        }

        [Test]
        public void PeekLast_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            var sut = new SinglyLinkedList<int>();

            Assert.Throws(typeof(NullReferenceException), () => sut.PeekLast(), "List is empty.");

        }

        [Test]
        public void PeekFirst_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            var sut = new SinglyLinkedList<int>();

            Assert.Throws(typeof(NullReferenceException), () => sut.PeekFirst(), "List is empty.");
        }

        [Test]
        public void PeekLast_ShouldReturnTail()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.PeekLast().Should().Be(2);
        }

        [Test]
        public void PeekFirst_ShouldReturnHead()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.PeekFirst().Should().Be(0);
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenValueExists()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Contains(2).Should().BeTrue();
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenValueDoesNotExists()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Contains(3).Should().BeFalse();
        }

        [Test]
        public void ToArray_ShouldConverToArray()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            var array = sut.ToArray();

            array.Should().BeOfType(typeof(int[]));
            array.Should().BeEquivalentTo(new int[] { 0, 1, 2 });
        }

        [Test]
        public void IndexOf_ShouldReturnNull_WhenValueDoesNotExists()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.IndexOf(3).Should().BeNull();
        }

        [Test]
        public void IndexOf_ShouldReturnIndex_WhenValueExists()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.IndexOf(2).Should().Be(2);
        }

        [Test]
        public void Remove_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            var sut = new SinglyLinkedList<int>();

            Assert.Throws(typeof(NullReferenceException), () => sut.Remove(), "List is empty");
        }

        [Test]
        public void Remove_ShouldRemoveLastItem()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Remove();

            sut.PeekLast().Should().Be(1);
            sut.Count.Should().Be(2);
        }

        [Test]
        public void RemoveFirst_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            var sut = new SinglyLinkedList<int>();

            Assert.Throws(typeof(NullReferenceException), () => sut.RemoveFirst(), "List is empty");
        }

        [Test]
        public void RemoveFirst_ShouldRemoveFirstItem()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.RemoveFirst();

            sut.PeekLast().Should().Be(2);
            sut.PeekFirst().Should().Be(1);
            sut.Count.Should().Be(2);
        }

        [Test]
        public void Remove_ShouldRemoveFirstValue_WhenFirstValueIsPassedAsParam()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Remove(0);

            sut.PeekLast().Should().Be(2);
            sut.PeekFirst().Should().Be(1);
            sut.Count.Should().Be(2);
        }

        [Test]
        public void Remove_ShouldRemoveValue_WhenValueIsPassedAsParam()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Remove(1);

            sut.PeekLast().Should().Be(2);
            sut.PeekFirst().Should().Be(0);
            sut.Count.Should().Be(2);
        }

        [Test]
        public void Remove_ShouldBeAbleToRemoveLastValue_WhenValueIsPassedAsParam()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Add(0);
            sut.Add(1);
            sut.Add(2);

            sut.Remove(2);

            sut.PeekLast().Should().Be(1);
            sut.PeekFirst().Should().Be(0);
            sut.Count.Should().Be(2);
        }


    }
}