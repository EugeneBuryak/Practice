using System;
using NUnit.Framework;
using DS.DynamicArray;
using FluentAssertions;

namespace UTs.DynamicArrayUTs
{
    [TestFixture]
    public class DynamicArrayUTs
    {

        [Test]
        public void InitializeNewArray_ShouldHaveCapacityThatWasPassed()
        {
            const int capacity = 2;
            var sut = new DynamicArray<int>(capacity);
            sut.Capacity.Should().Be(capacity);
        }

        [Test]
        public void InitializeNewArray_ShouldThrowException_WhenCapacityIsLessThanZero()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new DynamicArray<int>(-1));
        }

        [Test]
        public void ShouldAccessItem_WhenIndexIsInRange()
        {
            const int expected = 2;
            var sut = new DynamicArray<int>(1) { expected };
            var value = sut[0];

            value.Should().Be(expected);
        }

        [Test]
        public void ShouldDoubleInSize_WhenAddingNewItem_AndCapacityIsAtMax()
        {
            const int initialCapacity = 1;
            var sut = new DynamicArray<int>(initialCapacity) { 0 };
            sut.Add(1);

            sut.Capacity.Should().Be(initialCapacity * 2);
        }

        [Test]
        public void ShouldHaveItemsOnTheRightPlaces_AfterSizeDoubled()
        {
            const int itemAtZero = 0;
            const int itemAtOne = 1;
            var sut = new DynamicArray<int>(1) { itemAtZero };
            sut.Add(itemAtOne);

            sut[itemAtZero].Should().Be(itemAtZero);
            sut[itemAtOne].Should().Be(itemAtOne);
        }

        [Test]
        public void ShouldRemoveItem()
        {
            var sut = new DynamicArray<int> { 0, 1, 2 };
            sut.Remove(1);

            sut.Count.Should().Be(2);
            sut[1].Should().Be(2);
        }

        [Test]
        public void RemoveItemAt_ShouldRemoveItem()
        {
            const int indexToRemoveAt = 0;
            var sut = new DynamicArray<int> { 0, 1, 2 };
            sut.RemoveAt(indexToRemoveAt);

            sut.Count.Should().Be(2);
            sut[0].Should().Be(1);
        }

        [Test]
        public void RemoveItemAt_ShouldThrowException_WhenIndexIsOutOfRange()
        {
            var sut = new DynamicArray<int> { 0, 1, 2 };
            Assert.Throws(typeof(IndexOutOfRangeException), () => sut.RemoveAt(-1));
        }

        [Test]
        public void IndexOf_ShouldReturnIndex_WhenItemExsists()
        {
            var sut = new DynamicArray<int> { 0, 1, 2, 3 };

            sut.IndexOf(2).Should().Be(2);
        }

        [Test]
        public void IndexOf_ShouldReturnNull_WhenItemDoesNotExsits()
        {
            var sut = new DynamicArray<int> { 0, 1, 2, 3 };

            sut.IndexOf(4).Should().Be(null);
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenItemDoesNotExsits()
        {
            var sut = new DynamicArray<int> { 0, 1, 2, 3 };

            sut.Contains(4).Should().BeFalse();
        }

        [Test]
        public void Contains_ShouldReturntrue_WhenItemExsits()
        {
            var sut = new DynamicArray<int> { 0, 1, 2, 3 };

            sut.Contains(2).Should().BeTrue();
        }

        [Test]
        public void ClearItems_ShoulDefaultItems()
        {
            var sut = new DynamicArray<int> { 0, 1, 2, 3 };
            sut.ClearItems();

            sut.Should().AllBeEquivalentTo(0);
        }
    }
}