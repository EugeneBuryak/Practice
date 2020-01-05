# Separate chaining

In the method known as separate chaining, each bucket is independent, and has some sort of list of entries with the same index. The time for hash table operations is the time to find the bucket (which is constant) plus the time for the list operation.

## Complexity

|         | Time Average| Time Worst |
| ---     | ---         | ---        |
| Add     | Θ(1)        | Θ(n)       |
| Remove  | Θ(1)        | Θ(n)       |
| Search  | Θ(1)        | Θ(n)       |

## [Unit tests](https://github.com/EugeneBuryak/Practice/tree/master/DataStructures/UTs/Hash/HashTableSeparateChainingUTs.cs)
