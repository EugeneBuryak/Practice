# Priority Queue

Priority Queue is an extension of queue with following properties.

* Every item has a priority associated with it.
* An element with high priority is dequeued before an element with low priority.
* If two elements have the same priority, they are served according to their order in the queue.

## Complexity

|                       | Time      |
| ---                   | ---       |
| Dequeue               | Θ(log(n)) |
| Peek                  | Θ(1)      |
| Enqueue (Heap)        | Θ(log(n)) |
| Enqueue (List)        | Θ(n)      |
| Remove (Naive)        | Θ(n)      |
| Remove (Hash table)   | Θ(log(n)) |
| Contains (Naive)      | Θ(n)      |
| Contains (Hash table) | Θ(1)      |

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Queue/PriorityQueueUTs.cs)

## Underlying Data Structure(s)

* Heap (Assumed as default implementation, due to best big O complexity ⬆️)
* Unordered list

## Related Algorithms
