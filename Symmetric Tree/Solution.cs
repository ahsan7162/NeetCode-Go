// Definiton of a binary tree node class
// class TreeNode<T> {
//     T data;
//     TreeNode<T> left;
//     TreeNode<T> right;

//     TreeNode(T data) {
//         this.data = data;
//         this.left = null;
//         this.right = null;
//     }
// }

using System;

public class Solution
{
    public static bool IsSymmetric(TreeNode<int> root)
    {
        if (root == null) return true;
        return IsMirror(root.left, root.right);
    }

    private static bool IsMirror(TreeNode<int> left, TreeNode<int> right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;
        if (!left.data.Equals(right.data)) return false;

        return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
    }
}