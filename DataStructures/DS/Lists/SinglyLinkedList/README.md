# Singly Linked List

A linked list, in its simplest form, in a collection of nodes that collectively form linear sequence.

In a singly linked list, each node stores a reference to an object that is an element of the sequence, as well as a reference to the next node of the list. It does not store any pointer or reference to the previous node.

## Complexity

|                            | Time |
| ---                        | ---  |
| Remove at head             | Θ(1) |
| Remove at tail             | Θ(n) |
| Remove at                  | Θ(n) |
| Insert at head             | Θ(1) |
| Insert at tail             | Θ(1) |
| Search                     | Θ(n) |

## UTs

[->](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Lists/SinglyLinkedListUTs.cs)

## Underlying Data Structure(s)

* Array (C# List uses arrays: [->](https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs))
* References (C# LinkedList uses references: [->](https://referencesource.microsoft.com/#System/compmod/system/collections/generic/linkedlist.cs))
