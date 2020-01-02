# Stack

A stack is an ordered collection of items for which we can only add or remove items from one end (the top of the stack).

## Complexity

|         | Time |
| ---     | ---  |
| Peek    | Θ(1) |
| Pop     | Θ(1) |
| Push    | Θ(1) |
| Search  | Θ(n) |

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Stack/StackUTs.cs)

## Underlying Data Structure(s)

* **Array**
  * Should be able to adjust the size of the array. (C# Stack uses array: [->](https://referencesource.microsoft.com/#System/compmod/system/collections/generic/stack.cs))
* **List**
  * Doubly- and Singly-linked.
