/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
  if(head == null || head.next == null)
        return false;

        ListNode faster = head.next.next;
        ListNode slower = head.next;

        while (faster != null && faster.next != null)
        {
            faster = faster.next.next;
            slower = slower.next;

            if(faster == slower)
            return true;
        }

        return false;
    }
}