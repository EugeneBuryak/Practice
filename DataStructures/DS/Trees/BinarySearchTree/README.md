# Binary Search Tree

Binary Search Tree is a node-based binary tree data structure which has the following properties:

* The left subtree of a node contains only nodes with keys lesser than the node’s key.
* The right subtree of a node contains only nodes with keys greater than the node’s key.
* The left and right subtree each must also be a binary search tree.

Searching and adding a node:

1. To search a given key in Binary Search Tree, we first compare it with root, if the key is present at root, we return root.
2. If key is greater than root’s key, we recur for right subtree of root node. Otherwise we recur for left subtree.

Removing a node:

1. Node to be deleted is leaf: Simply remove from the tree.
2. Node to be deleted has only one child: Copy the child to the node and delete the child
3. Node to be deleted has two children: Find successor of the node (either the largest value of the left sub-tree or the smallest of the right sub-tree). Copy, and go to step #1 or #2.

## Complexity

|        | Time (Avg) | Time (Worst)|
| ---    | ---        | ---         |
| Insert | Θ(log(n))  | Θ(n)        |
| Remove | Θ(log(n))  | Θ(n)        |
| Search | Θ(log(n))  | Θ(n)        |

## [Unit tests](https://github.com/EugeneBuryak/Practice/blob/master/DataStructures/UTs/Trees/BinarySearchTreeUTs.cs)
