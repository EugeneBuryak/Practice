namespace UTs.Queues
{
    using System;
    using DS.Queue.Queues;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class QueueUTs
    {
        private Queue<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Queue<int>();
        }

        [Test]
        public void Peek_ShouldReturnItemWithoutRemovingIt()
        {
            _sut.Enqueue(0);
            _sut.Enqueue(1);

            var peek = _sut.Peek();

            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Peek_ShouldThrowNullRefException_WhenStackIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Peek(), "Queue is empty.");
        }

        [Test]
        public void Enqueue_ShouldAddItems()
        {
            _sut.Enqueue(0);
            _sut.Enqueue(1);

            _sut.Peek().Should().Be(0);
        }

        [Test]
        public void Dequeue_ShouldRemoveFirstItem()
        {
            _sut.Enqueue(0);
            _sut.Enqueue(1);

            var item = _sut.Dequeue();

            item.Should().Be(0);
            _sut.Count.Should().Be(1);
        }

        [Test]
        public void Dequeue_ShouldThrowNullRefException_WhenStackIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Dequeue(), "Queue is empty.");
        }
    }
}