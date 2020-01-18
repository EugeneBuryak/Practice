using DS.Trees.AVL;
using FluentAssertions;
using NUnit.Framework;

namespace UTs.Trees
{
    [TestFixture]
    public class AVLTreeUTs
    {
        private AVLTree<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new AVLTree<int>();
        }

        [Test]
        public void Add_ShouldAddNewValue()
        {
            _sut.Add(3);
            _sut.Add(4);
            _sut.Add(2);
            _sut.Add(-1);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {3, 2, 4, -1}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Add_ShouldLeftRotate()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {2, 1, 3}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Add_ShouldRightRotate()
        {
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(1);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {2, 1, 3}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Add_ShouldRightLeftRotate()
        {
            _sut.Add(1);
            _sut.Add(3);
            _sut.Add(2);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {2, 1, 3}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Add_ShouldLeftRightRotate()
        {
            _sut.Add(3);
            _sut.Add(1);
            _sut.Add(2);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {2, 1, 3}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Add_ShouldBalance()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);
            _sut.Add(5);
            _sut.Add(6);
            _sut.Add(7);
            _sut.Add(8);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {4, 2, 6, 1, 3, 5, 7, 8}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Remove_RemoveNodeWithNoChild()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);
            _sut.Add(5);
            _sut.Add(6);
            _sut.Add(7);
            _sut.Add(8);

            _sut.Remove(8);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {4, 2, 6, 1, 3, 5, 7}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Remove_RemoveNodeWithRightChild()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);
            _sut.Add(5);
            _sut.Add(6);
            _sut.Add(7);
            _sut.Add(8);

            _sut.Remove(7);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {4, 2, 6, 1, 3, 5, 8}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Remove_RemoveNodeWithLeftChild()
        {
            _sut.Add(5);
            _sut.Add(6);
            _sut.Add(4);
            _sut.Add(3);

            _sut.Remove(4);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {5, 3, 6}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Remove_RemoveNodeWithBothChildren()
        {
            _sut.Add(1);
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(4);
            _sut.Add(5);
            _sut.Add(6);
            _sut.Add(7);
            _sut.Add(8);

            _sut.Remove(4);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {3, 2, 6, 1, 5, 7, 8}, c => c.WithoutStrictOrdering());
        }

        [Test]
        public void Remove_RemoveRoot()
        {
            _sut.Add(1);

            _sut.Remove(1);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {}, c => c.WithoutStrictOrdering());
        }
    }
}