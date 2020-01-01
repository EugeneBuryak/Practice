using System;
using DS.Stack;
using FluentAssertions;
using NUnit.Framework;

namespace UTs.Stack
{
    [TestFixture]
    public class StackUTs
    {
        private Stack<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Stack<int>();
        }

        [Test]
        public void Peek_ShouldREturnItemWithourRemovingIt()
        {
            _sut.Push(0);
            _sut.Push(1);

            var peek = _sut.Peek();

            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Peek_ShouldThrowNullRefException_WhenStackIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Peek(), "Stack is empty.");
        }

        [Test]
        public void Push_ShouldAddItem()
        {
            _sut.Push(0);

            _sut.Peek().Should().Be(0);
        }

        [Test]
        public void Pop_ShoudlRemoveLastItem()
        {
            _sut.Push(0);
            _sut.Push(1);

            var item = _sut.Pop();

            item.Should().Be(1);
            _sut.Count.Should().Be(1);
        }

        [Test]
        public void Pop_ShouldThrowNullRefException_WhenStackIsEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => _sut.Pop(), "Stack is empty.");
        }
    }
}