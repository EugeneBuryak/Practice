namespace UTs.Lists
{
    using System;
    using DS.Lists.DoublyLinkedList;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class DoublyLinkedListUTs
    {
        private DoublyLinkedList<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new DoublyLinkedList<int>();
        }

        [Test]
        public void Clear_ShouldClearList()
        {
            _sut.Add(0);
            _sut.Add(1);

            _sut.Clear();

            _sut.Count.Should().Be(0);
        }

        [Test]
        public void Indexer_ShouldReturnCorrectValue()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut[1].Should().Be(1);
        }

        [Test]
        public void Indexer_ShouldThrowIndexOutOfRangeException_WhenIndexOtOfRange()
        {
            _sut.Add(0);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = _sut[-1]);
            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = _sut[2]);
        }

        [Test]
        public void Indexer_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _ = _sut[1], "List is empty.");
        }

        [Test]
        public void Add_ShouldInsertNodes()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.PeekFirst().Should().Be(0);
            _sut[1].Should().Be(1);
            _sut.PeekLast().Should().Be(2);
            _sut.Count.Should().Be(3);
        }

        [Test]
        public void AddFirst_ShouldInsertAtHead()
        {
            _sut.Add(1);
            _sut.Add(2);

            _sut.AddFirst(0);

            _sut.PeekFirst().Should().Be(0);
            _sut.Count.Should().Be(3);
        }

        [Test]
        public void Add_ShouldThrowIndexOutOfRange_WhenIndexIsOutOfRange()
        {
            _sut.Add(0);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _sut.Add(1, -1));
            Assert.Throws(typeof(IndexOutOfRangeException), () => _sut.Add(1, 2));
        }

        [Test]
        public void Add_ShouldInsertAtGivenIndex()
        {
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);

            _sut.Add(0, 0);
            _sut.Add(1, 1);

            _sut.PeekFirst().Should().Be(0);
            _sut[1].Should().Be(1);
            _sut[2].Should().Be(2);
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void Remove_ShouldRemoveLastNode()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.Remove();

            _sut.PeekLast().Should().Be(1);
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Remove_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Remove(), "List is empty.");
        }

        [Test]
        public void RemoveFirst_ShouldRemoveFirstNode()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.RemoveFirst();

            _sut.PeekFirst().Should().Be(1);
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void RemoveFirst_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.RemoveFirst(), "List is empty.");
        }

        [Test]
        public void Remove_WithValue_ShouldRemoveNodeWithGivenValue()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);

            _sut.Remove(0);
            _sut.Remove(2);
            _sut.Remove(4);

            _sut.PeekFirst().Should().Be(1);
            _sut[1].Should().Be(3);
            _sut.PeekLast().Should().Be(3);
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Remove_WithValue_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Remove(1), "List is empty.");
        }

        [Test]
        public void RemoveAt_ShouldRemoveNodeAtGivenIndex()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);

            _sut.RemoveAt(4);
            _sut.RemoveAt(2);
            _sut.RemoveAt(0);

            _sut.PeekFirst().Should().Be(1);
            _sut.PeekLast().Should().Be(3);
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void RemoveAt_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.RemoveAt(1), "List is empty.");
        }

        [Test]
        public void RemoveAt_ShouldThrowIndexOutOfRangeException_WheIndexIsOutOfRange()
        {
            _sut.Add(0);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _sut.RemoveAt(-1));
            Assert.Throws(typeof(IndexOutOfRangeException), () => _sut.RemoveAt(1));
        }
        [Test]
        public void IndexOf_ShouldReturnIndex_WhenValueExists()
        {
            _sut.Add(0);
            _sut.Add(1);

            var index = _sut.IndexOf(1);

            index.Should().Be(1);
        }

        [Test]
        public void IndexOf_ShouldReturnNull_WhenValueDoesNotExist()
        {
            _sut.Add(0);
            _sut.Add(1);

            var index = _sut.IndexOf(2);

            index.Should().BeNull();
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenValueExists()
        {
            _sut.Add(0);
            _sut.Add(1);

            var hasValue = _sut.Contains(1);

            hasValue.Should().BeTrue();
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenValueDoesNotExist()
        {
            _sut.Add(0);
            _sut.Add(1);

            var hasValue = _sut.Contains(2);

            hasValue.Should().BeFalse();
        }

        [Test]
        public void PeekFirst_ShouldReturnHead()
        {
            _sut.Add(0);
            _sut.Add(1);

            var value = _sut.PeekFirst();

            value.Should().Be(0);
        }

        [Test]
        public void PeekLast_shouldReturnTail()
        {
            _sut.Add(0);
            _sut.Add(1);

            var value = _sut.PeekLast();

            value.Should().Be(1);
        }

        [Test]
        public void ToArray_ShouldReturnArray()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            var array = _sut.ToArray();

            array.Should().BeEquivalentTo(new int[] { 0, 1, 2 }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue_WhenListIsEmpty()
        {
            _sut.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse_WhenListHasValues()
        {
            _sut.Add(0);

            _sut.IsEmpty().Should().BeFalse();
        }

    }
}