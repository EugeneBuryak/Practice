# Dynamic Array

Dynamic arrays are arrays that can scale capacity dynamically.

* **Strengths**:
  * Fast lookups. Just like arrays, retrieving the element at a given index takes O(1)O(1) time.
  * Variable size. You can add as many items as you want, and the dynamic array will expand to hold them.
  * Cache-friendly. Just like arrays, dynamic arrays place items right next to each other in memory, making efficient use of caches.
* **Weaknesses**:
  * Slow worst-case appends. Usually, adding a new element at the end of the dynamic array takes O(1)O(1) time. But if the dynamic array doesn't have any room for the new item, it'll need to expand, which takes O(n)O(n) time.
  * Costly inserts and deletes. Just like arrays, elements are stored adjacent to each other. So adding or removing an item in the middle of the array requires "scooting over" other elements, which takes O(n)O(n) time.

## Complexity

|                            | Time           |
| ---                        | ---            |
| Access                     | Θ(1)           |
| Search                     | O(n)           |
| Insert/delete at beginning | Θ(n)           |
| Insert/delete at end       | Θ(1) amortized |
| Insert/delete in middle    | Θ(n)           |

## Unit tests

[->](https://github.com/EugeneBuryak/Practice/tree/master/DataStructures/UTs/DynamicArray)
