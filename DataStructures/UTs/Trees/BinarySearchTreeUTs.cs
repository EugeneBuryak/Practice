using DS.Trees.BinarySearchTree;
using FluentAssertions;
using NUnit.Framework;

namespace UTs.Trees
{
    [TestFixture]
    public class BinarySearchTreeUTs
    {
        private BinarySearchTree<int> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new BinarySearchTree<int>();
        }

        [Test]
        public void Insert_ShouldBeAbleAddNodesInRightOrder()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);

            _sut.AsEnumerable().Should().BeEquivalentTo(new int[] { 2, 3, 4, 5, 7 });
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void TraversInOrder_ShouldReturnItemsInCorrectOrder()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);

            _sut.AsEnumerable(Traversal.InOrder)
                .Should()
                .BeEquivalentTo(new int[] { 2, 3, 4, 5, 7 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void TraversPreOrder_ShouldReturnItemsInCorrectOrder()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);

            _sut.AsEnumerable(Traversal.PreOrder)
                .Should()
                .BeEquivalentTo(new int[] { 5, 3, 2, 4, 7 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void TraversPostOrder_ShouldReturnItemsInCorrectOrder()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);

            _sut.AsEnumerable(Traversal.PostOrder)
               .Should()
               .BeEquivalentTo(new int[] { 2, 4, 3, 7, 5 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void TraversBreadthFirst_ShouldReturnItemsInCorrectOrder()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);

            _sut.AsEnumerable(Traversal.BreadthFirst)
               .Should()
               .BeEquivalentTo(new int[] { 5, 3, 7, 2, 4 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(5);
        }

        [Test]
        public void Remove_ShouldBeAbleToRemove_WhenOnlyLeftSubTreeExists()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);
            _sut.Insert(8);
            _sut.Insert(1);

            _sut.Remove(2);

            _sut.AsEnumerable()
               .Should()
               .BeEquivalentTo(new int[] { 1, 3, 4, 5, 7, 8 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(6);
        }

        [Test]
        public void Remove_ShouldBeAbleToRemove_WhenOnlyRightSubTreeExists()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);
            _sut.Insert(8);
            _sut.Insert(1);

            _sut.Remove(7);

            _sut.AsEnumerable()
                .Should()
                .BeEquivalentTo(new int[] { 1, 2, 3, 4, 5, 8 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(6);
        }

        [Test]
        public void Remove_ShouldBeAbleToRemove_WhenOBothSubTreesExist()
        {
            _sut.Insert(5);
            _sut.Insert(3);
            _sut.Insert(7);
            _sut.Insert(2);
            _sut.Insert(4);
            _sut.Insert(8);
            _sut.Insert(1);

            _sut.Remove(5);

            _sut.AsEnumerable()
               .Should()
               .BeEquivalentTo(new int[] { 1, 2, 3, 4, 7, 8 }, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(6);
        }
    }
}