using System;
using System.Collections.Generic;
using System.Linq;
using DS.Hash.HashTable;
using FluentAssertions;
using NUnit.Framework;

namespace UTs.Hash
{
    [TestFixture]
    public class HashTableSeparateChainingUTs
    {
        private HashTableSeparateChaining<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new HashTableSeparateChaining<int>();
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void Ctor_ShouldThrowArgumentException_WhenCapacityIsIncorrect(int capacity)
        {
            Action act = () => new HashTableSeparateChaining<int>(capacity);
            act.Should().Throw<ArgumentException>().WithMessage("Invalid capacity value.");
        }

        [TestCase(Double.NaN)]
        [TestCase(Double.NegativeInfinity)]
        [TestCase(1.1)]
        [TestCase(0)]
        public void Ctor_ShouldThrowArgumentException_WhenGrowthFactorIsIncorrect(double growth)
        {
            Action act = () => new HashTableSeparateChaining<int>(6, growth);
            act.Should().Throw<ArgumentException>().WithMessage("Invalid growth factor value.");
        }

        [Test]
        public void Add_ShouldCreateNewBucketForItem_WhenBucketIsNull()
        {
            _sut.Add(1);

            var key = _sut.GetKey(1);
            var bucket = _sut.GetItems(key.Value);

            bucket.Should().BeEquivalentTo(new List<int> { 1 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(1);
        }

        [Test]
        public void Add_ShouldAddToExistingBucket_WhenBucketExist()
        {
            _sut.Add(1);
            _sut.Add(1);

            var key = _sut.GetKey(1);
            var bucket = _sut.GetItems(key.Value);

            bucket.Should().BeEquivalentTo(new List<int> { 1, 1 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(2);
        }

        [Test]
        public void Add_ShouldBeAbleToResizeTable()
        {
            _sut.Add(1);
            _sut.Add(-2);
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(4);
            _sut.Add(5);
            _sut.Add(-5);

            _sut.Count.Should().Be(7);
        }

        [Test]
        public void Add_ShouldThrowArgumentException_WhenItemIsNull()
        {
            var sut = new HashTableSeparateChaining<string>();
            Action act = () => sut.Add(null);

            act.Should().Throw<ArgumentException>().WithMessage("Value should not be null.");
        }

        [Test]
        public void Remove_ShouldRemoveItemFromBucket_AndReturnTrue_WhenItemExists()
        {
            _sut.Add(1);

            _sut.Remove(1).Should().BeTrue();
            _sut.Count.Should().Be(0);
        }

        [Test]
        public void Remove_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            _sut.Add(1);

            _sut.Remove(2).Should().BeFalse();
            _sut.Count.Should().Be(1);
        }

        [Test]
        public void Remove_ShouldThrowArgumentException_WhenItemIsNull()
        {
            var sut = new HashTableSeparateChaining<string>();
            Action act = () => sut.Remove(null);

            act.Should().Throw<ArgumentException>().WithMessage("Value should not be null.");
        }

        [Test]
        public void GetKey_ShouldReturnKey_WhenItemExists()
        {
            _sut.Add(1);

            _sut.GetKey(1).Should().NotBeNull();
        }

        [Test]
        public void GetKey_ShouldReturnNull_WhenItemDoesNotExist()
        {
            _sut.Add(1);

            _sut.GetKey(2).Should().BeNull();
        }

        [Test]
        public void GetKey_ShouldThrowArgumentException_WhenItemIsNull()
        {
            var sut = new HashTableSeparateChaining<string>();
            Action act = () => sut.GetKey(null);

            act.Should().Throw<ArgumentException>().WithMessage("Value should not be null.");
        }

        [Test]
        public void GetItems_ShouldReturnItemsInBucket()
        {
            _sut.Add(1);
            _sut.Add(1);

            var key = _sut.GetKey(1);

            _sut.GetItems(key.Value).Should().BeEquivalentTo(new List<int> { 1, 1, });
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void GetItems_ShouldThrowIndexOutOfRangeException(int index)
        {
            Action act = () => _sut.GetItems(index);

            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Test]
        public void Contains_ShouldReturnItemsInBucket()
        {
            _sut.Add(1);
            _sut.Add(2);

            _sut.Contains(2).Should().BeTrue();
        }

        [Test]
        public void Contains_ShouldThrowArgumentException_WhenItemIsNull()
        {
            var sut = new HashTableSeparateChaining<string>();
            Action act = () => sut.Contains(null);

            act.Should().Throw<ArgumentException>().WithMessage("Value should not be null.");
        }

        [Test]
        public void Enumerator_ShouldReturnValues()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(2);
            _sut.Add(3);

            _sut.ToList().Should().BeEquivalentTo(new List<int> { 1, 2, 2, 3 });
        }
    }
}