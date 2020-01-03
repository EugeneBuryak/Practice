namespace UTs.Lists
{
    using System;
    using DS.Lists.SinglyLinkedList;
    using FluentAssertions;
    using NUnit.Framework;
    
    [TestFixture]
    public class SinglyLinkedListUTs
    {
        private SinglyLinkedList<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SinglyLinkedList<int>();
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

            _sut[1].Should().Be(1);
        }

        [Test]
        public void Indexer_ShouldThrowIndexOutOfRangeException_WhenIndexOtOfRange()
        {
            _sut.Add(0);
            _sut.Add(1);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = _sut[-1]);
            Assert.Throws(typeof(IndexOutOfRangeException), () => _ = _sut[2]);
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
        public void PeekLast_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.PeekLast(), "List is empty.");
        }

        [Test]
        public void PeekFirst_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.PeekFirst(), "List is empty.");
        }

        [Test]
        public void PeekLast_ShouldReturnTail()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.PeekLast().Should().Be(2);
        }

        [Test]
        public void PeekFirst_ShouldReturnHead()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.PeekFirst().Should().Be(0);
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenValueExists()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.Contains(2).Should().BeTrue();
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenValueDoesNotExist()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.Contains(3).Should().BeFalse();
        }

        [Test]
        public void ToArray_ShouldConverToArray()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            var array = _sut.ToArray();

            array.Should().BeEquivalentTo(new int[] { 0, 1, 2 });
        }

        [Test]
        public void IndexOf_ShouldReturnNull_WhenValueDoesNotExist()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.IndexOf(3).Should().BeNull();
        }

        [Test]
        public void IndexOf_ShouldReturnIndex_WhenValueExist()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);

            _sut.IndexOf(2).Should().Be(2);
        }

        [Test]
        public void Remove_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Remove(), "List is empty");
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
        public void RemoveFirst_ShouldThrowNullRefException_WhenListIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.RemoveFirst(), "List is empty");
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
        public void Remove_WithValue_ShouldRemoveNodeWithThatValue()
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
            _sut.PeekLast().Should().Be(3);
            _sut.Count.Should().Be(2);
        }
    }
}