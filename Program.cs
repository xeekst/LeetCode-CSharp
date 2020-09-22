using System;
using System.Collections.Generic;

namespace LeetCode
{

    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int j = 0;
            int i = 0;
            ListNode root = null;
            ListNode last = null;
            while (l1 != null || l2 != null)
            {
                int v1 = 0;
                int v2 = 0;
                if (l1 != null)
                {
                    v1 = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    v2 = l2.val;
                    l2 = l2.next;
                }
                int v = v1 + v2;
                i = (v + j) % 10;
                j = (v + j) / 10;
                var newNode = new ListNode(i);
                if (root == null)
                {
                    root = newNode;
                }
                else
                {
                    last.next = newNode;
                }
                last = newNode;
            }
            if (j > 0)
            {
                i = j % 10;
                j = j / 10;
                var newNode = new ListNode(i);
                last.next = newNode;
            }
            return root;
        }
        
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            int sumLeft = (root.left != null && root.left.left == null && root.left.right == null) ? root.left.val : SumOfLeftLeaves(root.left);
            return sumLeft + SumOfLeftLeaves(root.right);
        }

        static void Main(string[] args)
        {
            // TreeNode root = new TreeNode(1);
            // TreeNode l1 = new TreeNode(2);
            // TreeNode r1 = new TreeNode(3);
            // TreeNode l2 = new TreeNode(4);
            // TreeNode r2 = new TreeNode(5);
            // root.left = l1;
            // root.right = r1;
            // l1.left = l2;
            // l1.right = r2;
            // Console.WriteLine(SumOfLeftLeaves(root));

            ListNode l1 = new ListNode(5);
            ListNode l2 = new ListNode(5);
            ListNode l21 = new ListNode(9);
            l2.next = l21;
            AddTwoNumbers(l1, l2);
        }
    }
}
