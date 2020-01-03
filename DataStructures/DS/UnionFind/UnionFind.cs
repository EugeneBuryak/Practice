using System;
namespace DS.UnionFind
{
    public class UnionFind
    {
        private int[] _map;
        private int[] _sizeMap;
        public int Count { get; private set; }

        public UnionFind(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException();

            Count = size;
            _map = new int[size];
            _sizeMap = new int[size];

            for (var i = 0; i < size; i++)
            {
                _map[i] = i;
                _sizeMap[i] = 1;
            }
        }

        public int FindRoot(int index)
        {
            var root = index;
            while (root != _map[root])
            {
                root = _map[root];
            }

            while (index != root)
            {
                var tmp = _map[index];
                _map[index] = root;
                index = _map[tmp];
            }

            return root;
        }

        public void Union(int firstIndex, int secondIndex)
        {
            var firstRoot = FindRoot(firstIndex);
            var secondRoot = FindRoot(secondIndex);
            int firstSize = SizeOf(firstRoot);
            int secondSize = SizeOf(secondRoot);

            if (firstRoot == secondRoot)
                return;

            if (firstSize <= secondSize)
            {
                _map[firstIndex] = secondRoot;
                _sizeMap[secondRoot] += firstSize;
            }
            else
            {
                _map[secondIndex] = firstRoot;
                _sizeMap[firstRoot] += secondSize;
            }

            Count--;
        }

        public bool Connected(int firstIndex, int secondIndex)
        {
            return FindRoot(firstIndex) == FindRoot(secondIndex);
        }

        public int SizeOf(int index)
        {
            return _sizeMap[FindRoot(index)];
        }

        public int[] ToArray()
        {
            return _map;
        }

    }
}