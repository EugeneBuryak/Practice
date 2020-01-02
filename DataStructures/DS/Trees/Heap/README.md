# Binary Heap (Min)

A Binary Heap is a Binary Tree with following properties.

* It’s a complete tree (All levels are completely filled except possibly the last level and the last level has all keys as left as possible). This property of Binary Heap makes them suitable to be stored in an array.

* A Binary Heap is either Min Heap or Max Heap. In a Min Binary Heap, the key at root must be minimum among all keys present in Binary Heap. The same property must be recursively true for all nodes in Binary Tree. Max Binary Heap is similar to MinHeap.

## Complexity

|                       | Time      |
| ---                   | ---       |
| Construction          | Θ(n)      |
| Poll                  | Θ(log(n)) |
| Peek                  | Θ(1)      |
| Add                   | Θ(log(n)) |
| Remove (Naive)        | Θ(n)      |
| Remove (Hash table)   | Θ(log(n)) |
| Contains (Naive)      | Θ(n)      |
| Contains (Hash table) | Θ(1)      |

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Trees/BinaryHeapUTs.cs)

## Underlying Data Structure(s)

* Arrays
* Lists

## Related Algorithms

* **Min to Max conversion**
* ...
