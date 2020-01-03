# Union find (disjoint set)

A disjoint-set data structure is a data structure that keeps track of a set of elements partitioned into a number of disjoint (non-overlapping) subsets. A union-find algorithm is an algorithm that performs two useful operations on such a data structure:

* Find: Determine which subset a particular element is in. This can be used for determining if two elements are in the same subset.
* Union: Join two subsets into a single subset.

## Path compression

...

## Complexity

|                    | Time |
| ---                | ---  |
| Constriction       | Θ(n) |
| Union              | α(n) |
| Find               | α(n) |
| Get size           | α(n) |
| Check if connected | α(n) |

α(n) - amortized

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/UniotFind/UniotFindUTs.cs)

## Underlying Data Structure(s)

## Related algorithms

* **Trees**
  * Kruskal's minimum spanning tree
