namespace UTs.Queues
{
    using DS.Queue.PriorityQueues;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class PriorityQueueUTs
    {
        private PriorityQueue<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PriorityQueue<int>();
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenValueExists()
        {
            _sut.Enqueue(1, 0);
            _sut.Enqueue(1, 1);
            _sut.Enqueue(2, 0);

            _sut.Contains(1).Should().BeTrue();
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenValueDoesNotExist()
        {
            _sut.Enqueue(1, 0);
            _sut.Enqueue(1, 1);
            _sut.Enqueue(2, 0);

            _sut.Contains(3).Should().BeFalse();
        }

        [Test]
        public void Enqueue_ShouldIncrementPriority_WhenPriorityIsNotPassed()
        {
            _sut.Enqueue(0, 10);
            _sut.Enqueue(1);

            _sut.ToArray().Should().BeEquivalentTo(new (int, int)[] { (0, 10), (1, 11) }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void Enqueue_ShouldAddNodesAccordingToPriority()
        {
            _sut.Enqueue(0, 0);
            _sut.Enqueue(1, 1);
            _sut.Enqueue(10, 0);

            _sut.ToArray().Should().BeEquivalentTo(new (int, int)[] { (0, 0), (1, 1), (10, 0) }, opt => opt.WithStrictOrdering());
        }

        [Test]
        public void Dequeue_ShouldReturnFirstValueByPriority()
        {
            _sut.Enqueue(0, 1);
            _sut.Enqueue(1, 1);
            _sut.Enqueue(10, 0);

            var node = _sut.Dequeue();

            node.priority.Should().Be(0);
            node.value.Should().Be(10);
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Peek_ShouldReturnFirstValueByPriority()
        {
            _sut.Enqueue(0, 1);
            _sut.Enqueue(1, 1);
            _sut.Enqueue(10, 0);

            var node = _sut.Peek();

            node.priority.Should().Be(0);
            node.value.Should().Be(10);
            _sut.Count.Should().Be(3);
        }
    }
}