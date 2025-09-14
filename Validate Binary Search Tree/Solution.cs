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
using System.Collections.Generic;

public class Solution{
    public static bool ValidateBst(TreeNode<int> root) {
        return ValidateBst(root, int.MinValue, int.MaxValue, false, false);
    }
    private static bool ValidateBst(TreeNode<int> node, int lower, int upper, bool hasLower, bool hasUpper)
    {
        if (node == null) return true;
    
        if (hasLower && node.data <= lower)
            return false;
        if (hasUpper && node.data >= upper)
            return false;
    
        // Check left subtree: upper bound is node.data
        if (!ValidateBst(node.left, lower, node.data, hasLower, true))
            return false;
        // Check right subtree: lower bound is node.data
        if (!ValidateBst(node.right, node.data, upper, true, hasUpper))
            return false;
    
        return true;
    }
}