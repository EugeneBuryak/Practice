namespace UTs.Trees
{
    using System;
    using DS.Trees.BinaryHeap;
    using FluentAssertions;
    using NUnit.Framework;
    
    [TestFixture]
    public class BinaryHeapUTs
    {
        private BinaryHeap<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new BinaryHeap<int>();
        }

        [TearDown]
        public void TearDown()
        {
            if (!_sut.IsEmpty())
                BinaryHeapInvarianceCheck(0).Should().BeTrue();
        }

        [Test]
        public void Add_ShouldAddNodesInCorrectOreder()
        {
            _sut.Add(2);
            _sut.Add(0);
            _sut.Add(4);
            _sut.Add(4);
            _sut.Add(1);

            _sut.ToArray().Should().BeEquivalentTo(new int[] { 0, 1, 4, 4, 2 }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void Poll_ShouldRemoveRootNode_AndRestoreOrder_Left()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);

            _sut.Poll();

            _sut.ToArray().Should().BeEquivalentTo(new int[] { 1, 3, 2 }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void Poll_ShouldRemoveRootNode_AndRestoreOrder_Right()
        {
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(1);
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(3);

            _sut.Poll();

            _sut.ToArray().Should().BeEquivalentTo(new int[] { 1, 2, 1, 3, 3, 3 }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void IndexOf_ShouldReturnIndex_WhenNodeExists()
        {
            _sut.Add(0);
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(2);

            _sut.IndexOf(2).Should().Be(1);
        }

        [Test]
        public void IndexOf_ShouldReturnNull_WhenNodeDoesNotExist()
        {
            _sut.Add(0);
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(2);

            _sut.IndexOf(4).Should().BeNull();
        }

        [Test]
        public void RemoveAt_ShouldThrowNullRefException_WhenHeapIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.RemoveAt(0), "Heap is empty.");
        }

        [Test]
        public void RemoveAt_ShouldThrowArgumentOutOfRangeException_WhenIndexIsOutOfRange()
        {
            _sut.Add(0);

            Assert.Throws(typeof(IndexOutOfRangeException), () => _sut.RemoveAt(1));
        }

        [Test]
        public void RemoveAt_ShouldBeAbleRemoveRoot_WhenHeapHasJustOneNode()
        {
            _sut.Add(0);

            _sut.RemoveAt(0);

            _sut.Count.Should().Be(0);
        }

        [Test]
        public void RemoveAt_ShouldRemoveNodeAtGivenIndex()
        {
            _sut.Add(0);
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(0);

            _sut.RemoveAt(2);

            _sut.Count.Should().Be(3);
            _sut.Contains(1).Should().BeFalse();
        }

        [Test]
        public void Remove_ShouldRemoveNode_WhenNodeExists()
        {
            _sut.Add(0);
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);

            _sut.Remove(2);

            _sut.Count.Should().Be(4);
            _sut.Contains(2).Should().BeFalse();
        }

        [Test]
        public void Peek_ShouldReturnRootNode()
        {
            _sut.Add(0);
            _sut.Add(0);
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);

            var node = _sut.Peek();

            node.Should().Be(0);
        }

        [Test]
        public void Construction_FromEnumerableShouldProduceRightSequence()
        {
            _sut = new BinaryHeap<int>(new int[] { 4, 5, 1, 0, 3, 2, 6 });

            _sut.ToArray().Should().BeEquivalentTo(new int[] { 0, 3, 1, 5, 4, 2, 6 }, opt => opt.WithStrictOrdering());
        }

        private bool BinaryHeapInvarianceCheck(int currentIndex)
        {
            if (currentIndex >= _sut.Count) return true;

            int leftChildNodeIndex = currentIndex * 2 + 1;
            int rightChildNodeIndex = currentIndex * 2 + 2;

            if (leftChildNodeIndex < _sut.Count && _sut[currentIndex] > _sut[leftChildNodeIndex]) return false;
            if (rightChildNodeIndex < _sut.Count && _sut[currentIndex] > _sut[rightChildNodeIndex]) return false;

            return BinaryHeapInvarianceCheck(leftChildNodeIndex) && BinaryHeapInvarianceCheck(rightChildNodeIndex);
        }

    }
}