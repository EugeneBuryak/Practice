namespace UTs.UnionFind
{
    using DS.UnionFind;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class UnionFindUTs
    {
        private UnionFind _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UnionFind(5);
        }

        [Test]
        public void Find_ShouldReturnRootNode()
        {
            _sut.Union(1, 2);
            _sut.Union(1, 3);

            var root = _sut.FindRoot(3);

            root.Should().Be(2);
        }

        [Test]
        public void Connected_ShouldReturnTrue_WhenNodesConnected()
        {
            _sut.Union(1, 2);
            _sut.Union(1, 3);

            _sut.Connected(1, 2).Should().BeTrue();
        }

        [Test]
        public void Connected_ShouldReturnFalse_WhenNodesAreNotConnected()
        {
            _sut.Union(1, 2);
            _sut.Union(1, 3);

            _sut.Connected(0, 2).Should().BeFalse();
        }

        [Test]
        public void Size_ShouldReturnSizeOfTheComponent()
        {
            _sut.Union(1, 2);
            _sut.Union(1, 3);

            _sut.SizeOf(2).Should().Be(3);
        }

        [Test]
        public void Union_ShouldConnectNodes()
        { 
            _sut.Union(1, 2);
            _sut.Union(1, 3);

            _sut.ToArray().Should().BeEquivalentTo(new int[] {0, 2, 2, 2, 4}, opt => opt.WithStrictOrdering());
            _sut.Count.Should().Be(3);
        }


    }
}