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

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len = nums1.Length + nums2.Length;
            // 判断奇偶性
            bool isOddNumber = len % 2 == 1;
            int m = isOddNumber ? len / 2 + 1 : len / 2;
            int k = m;

            int p1 = -1;
            int p2 = -1;
            int k2 = k / 2;
            while (k2 > 0 && p1 < nums1.Length - 1 && p2 < nums2.Length - 1)
            {
                int k2_1 = GetOffset(p1, k2, nums1);
                int k2_2 = GetOffset(p2, k2, nums2);
                k2 = k2_1 < k2_2 ? k2_1 : k2_2;

                int offsetP1 = p1 + k2;
                int offsetP2 = p2 + k2;
                if (nums1[offsetP1] < nums2[offsetP2])
                {
                    p1 = offsetP1;
                }
                else
                {
                    p2 = offsetP2;
                }
                k = k - k2;
                k2 = k / 2;
            }

            // 最终p1、p2为 nums 删除的最后一个元素 index

            // 下一个元素
            int l1 = p1 + 1;
            int l2 = p2 + 1;

            //如果是奇数
            if (isOddNumber)
            {
                if (l1 > nums1.Length - 1) return nums2[m - p1 - 2];
                if (l2 > nums2.Length - 1) return nums1[m - p2 - 2];
                return nums2[l2] < nums1[l1] ? nums2[l2] : nums1[l1];
            }
            else
            {
                if (l1 > nums1.Length - 1) return (nums2[m - p1 - 2] + nums2[m - p1 - 1]) / 2.0;
                if (l2 > nums2.Length - 1) return (nums1[m - p2 - 2] + nums1[m - p2 - 1]) / 2.0;
                int m1 = nums2[l2] < nums1[l1] ? nums2[l2++] : nums1[l1++];

                if (l1 > nums1.Length - 1) return (nums2[l2] + m1) / 2.0;
                if (l2 > nums2.Length - 1) return (nums1[l1] + m1) / 2.0;
                int m2 = nums2[l2] < nums1[l1] ? nums2[l2] : nums1[l1];
                return (m1 + m2) / 2.0;
            }

        }

        private static int GetOffset(int index, int offset, int[] nums)
        {
            int roffset = (index + offset) > nums.Length - 1 ? nums.Length - 1 - index : offset;
            return roffset;
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

            // int[] num1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // int[] num2 = new int[9] { 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            // int[] num1 = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            // int[] num2 = new int[9] { 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            int[] num1 = new int[2] { 1, 2 };
            int[] num2 = new int[2] { 3, 4 };


            Console.WriteLine(FindMedianSortedArrays(num1, num2));
        }
    }
}
