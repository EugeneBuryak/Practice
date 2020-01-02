# Queue

A Queue is a linear structure which follows a particular order in which the operations are performed. The order is First In First Out (FIFO).

## Complexity

|         | Time |
| ---     | ---  |
| Enqueue | Θ(1) |
| Dequeue | Θ(1) |
| Peek    | Θ(1) |
| Search  | Θ(n) |
| Remove  | Θ(n) |

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Queue/QueueUTs.cs)

## Underlying Data Structure(s)

* **Array**
  * Should be able to adjust the size of the array. (C# Queue uses array: [->](https://referencesource.microsoft.com/#System/compmod/system/collections/generic/queue.cs))
* **List**
  * Doubly- and Singly-linked.
