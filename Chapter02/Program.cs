﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] t = { 9, 4, 2, 5, 5, 5, 5, 7, 12, 4, 4, 4, 4, 43, 9, 2, 7 };
            //int[] t = { 9, 4, 2, 5, 7, 12, 43 };
            //int[] t = { 3, 5, 8, 5, 10, 2, 1, 9, 4, 2, 5, 7, 12, 43 };
            int[] t1 = { 7, 1, 6, 3, 5, 8};
            int[] t2 = { 4, 9, 2 };

            SingleLinkedList sList1 = new SingleLinkedList();
            foreach (int n in t1)
            {
                sList1.AppendToTail(n);
            }

            SingleLinkedList sList2 = new SingleLinkedList();
            foreach (int n in t2)
            {
                sList2.AppendToTail(n);
            }

            // 2.1
            //RemoveDups(sList);
            //nd = sList.head;
            
            // 2.2
            //SingleLinkedList result = GetKthToLast(sList, 8);
            
            // 2.3
            //SingleLinkedList result = DeleteTheMidddle(sList, new Node(5));

            // 2.4
            //SingleLinkedList result = Partition(sList, new Node(10));
            //nd = result.head;
            //while (nd != null)
            //{
            //    Console.WriteLine(nd.data);
            //    nd = nd.next;
            //}

            // 2.5
            //Console.WriteLine(SumLists(sList1, sList2));
            
            // 2.6
            //string[] sa = {"ra", "ce", "c", "ar" };
            //SingleLinkedList sList3 = new SingleLinkedList();
            //foreach (string s in sa)
            //{
            //    sList3.AppendToTail(s);
            //}
            //Console.WriteLine(IsPalindrome(sList3));

            // 2.7
            // Node d = FindIntersecting_v2(sList1, sList2);
            // Console.WriteLine(d.data);

            // 2.8
            string[] sa = { "a", "b", "c", "d", "e", "f"};
            SingleLinkedList loopList = new SingleLinkedList();
            foreach (string s in sa)
            {
                loopList.AppendToTail(s);
            }

            Node lNd = loopList.head;
            while (lNd != null)
            {
                if (lNd.next == null)
                {
                    Node iNd = loopList.head;
                    while (iNd != null)
                    {
                        if (iNd.strData == "b")
                        {
                            lNd.next = iNd;
                            break;
                        }
                        iNd = iNd.next;
                    }
                    break;
                }
                lNd = lNd.next;
            }

            Node d = FindLooped(loopList);
            Console.WriteLine(d.strData);

            Console.ReadKey();
        }

        // 2.8
        static Node FindLooped(SingleLinkedList list)
        {
            Node nd = list.head;
            HashSet<Node> ndSet = new HashSet<Node>();
            while(nd != null)
            {
                if (ndSet.Add(nd) != true)
                {
                    return nd;
                }
                nd = nd.next;
            }
            return null;
        }

        // 2.7.1
        static Node FindIntersecting_v2(SingleLinkedList list1, SingleLinkedList list2)
        {
            MergeLinkedLists(list1, list2);
            HashSet<Node> d2Set = new HashSet<Node>();

            Node d2 = list2.head;
            while (d2 != null)
            {
                d2Set.Add(d2);
                d2 = d2.next;
            }


            Node d1 = list1.head;
            while (d1 != null)
            {
                if (d2Set.Contains(d1))
                {
                    return d1;
                }
                d1 = d1.next;
            }
            return null;
        }

        // 2.7
        static Node FindIntersecting(SingleLinkedList list1, SingleLinkedList list2)
        {
            MergeLinkedLists(list1, list2);

            Node d1 = list1.head;          
            while(d1 != null)
            {
                Node d2 = list2.head;
                while (d2 != null)
                {
                    if (d1 == d2)
                    {
                        return d1;
                    }
                    d2 = d2.next;
                }
                d1 = d1.next;
            }
            return null;
        }

        static void MergeLinkedLists(SingleLinkedList sList1, SingleLinkedList sList2)
        {
            Node nd2 = sList2.head;
            while (nd2 != null)
            {
                //Console.WriteLine(nd.data);
                if (nd2.next == null)
                {
                    Node nd1 = sList1.head;
                    {
                        while (nd1 != null)
                        {
                            if (nd1.data == 5)
                            {
                                nd2.next = nd1;
                                break;
                            }
                            nd1 = nd1.next;
                        }
                    }
                    break;
                }
                nd2 = nd2.next;
            } 
        }


        // 2.6
        static bool IsPalindrome(SingleLinkedList list)
        {
            string s = "";
            Node nd = list.head;
            while (nd != null)
            {
                s += nd.strData;
                nd = nd.next;
            }
            return IsPalindrome(s);
        }

        static bool IsPalindrome(string s)
        {
            char[] chs = s.ToCharArray();
            var charCnt = new Dictionary<char, int?>();

            for (int i = 0; i < chs.Length; i++)
            {
                if (chs[i] == ' ')
                {
                    continue;
                }
                else
                {
                    if (chs[i] < 'a')
                    {
                        int cht = (int)chs[i] + 32;
                        chs[i] = (char)(cht);
                    }
                }

                int? cnt = 0;
                if (charCnt.TryGetValue(chs[i], out cnt))
                {
                    cnt += 1;
                    charCnt[chs[i]] = cnt;
                }
                else
                {
                    charCnt.Add(chs[i], 1);
                }
            }

            int oddCnt = 0;
            foreach (var kvp in charCnt)
            {
                if (kvp.Value % 2 == 0)
                    continue;

                if (kvp.Value % 2 == 1)
                {
                    oddCnt += 1;
                    if (oddCnt > 1)
                        return false;
                }
            }
            return true; ;
        }

        // 2.5
        static int SumLists(SingleLinkedList list1, SingleLinkedList list2)
        {
            int sum = 0;
            Stack<int> stk1 = new Stack<int>();
            Node nd = list1.head;
            while (nd != null)
            {
                //Console.WriteLine(nd.data);
                stk1.Push(nd.data);
                nd = nd.next;
            }

            String s1 = "";
            while(stk1.Count > 0)
            {
                s1 += stk1.Pop().ToString();
            }

            Stack<int> stk2 = new Stack<int>();
            nd = list2.head;
            while (nd != null)
            {
                //Console.WriteLine(nd.data);
                stk2.Push(nd.data);
                nd = nd.next;
            }
            
            String s2 = "";
            while (stk2.Count > 0)
            {
                s2 += stk2.Pop().ToString();
            }

            sum = int.Parse(s1) + int.Parse(s2);
            return sum;
        }

        // 2.4
        static SingleLinkedList Partition(SingleLinkedList list, Node x)
        {
            SingleLinkedList result = new SingleLinkedList();
            SingleLinkedList later = new SingleLinkedList();
            Node nd = list.head;
            while (nd != null)
            {
                if (nd.data < x.data)
                {
                    result.AppendToTail(nd.data);
                }
                else
                {
                    later.AppendToTail(nd.data);
                }
                nd = nd.next;
            }

            nd = result.head;
            while (nd != null)
            {
                if (nd.next == null)
                {
                    nd.next = later.head;
                    break;
                }
                nd = nd.next;
            }
            return result;
        }

        // 2.3
        static SingleLinkedList DeleteTheMidddle(SingleLinkedList list, Node t)
        {
            SingleLinkedList result = list;
            Node pre = list.head;
            Node nd = list.head.next;
            while (nd != null)
            {
                if (nd.next != null && nd.data == t.data )
                {
                    pre.next = nd.next;
                    break;
                }
                pre = nd;
                nd = nd.next;
            }
           return list;
        }

        // 2.2
        static SingleLinkedList GetKthToLast(SingleLinkedList sList, int k)
        {
            SingleLinkedList result = new SingleLinkedList();
            if (k < 1)
            {
                return result;
            }
            else if (k == 1)
            {
                return sList;
            }

            Node nd = sList.head;

            while (nd != null && k > 0)
            {
                k -= 1;
                nd = nd.next;

                if (k == 1)
                {
                    break;
                }
            }
            return new SingleLinkedList(nd);;
        }

        // 2.1
        static void RemoveDups(SingleLinkedList list)
        {
            Node nd = list.head;
            Node pre = null;
            HashSet<int> dSet = new HashSet<int>();
            while (nd != null)
            {
                if (dSet.Contains(nd.data)) 
                {
                    if (nd.next != null)
                    {
                        if (!dSet.Contains(nd.next.data)) // then connect nd's pre to nd's next.
                        {
                            pre.next = nd.next;
                            pre = nd;
                        }
                        // else skip this node
                    }
                    else if (nd.next == null)// nd is the end node, remove it.
                    {
                        pre.next = nd.next;
                    }
                }
                else 
                {
                    dSet.Add(nd.data);
                    pre = nd;
                }
                nd = nd.next;
            }
        }
    }

    public class SingleLinkedList
    {
        public Node head;

        public SingleLinkedList()
        {
            head = null;
        }

        public SingleLinkedList(Node h)
        {
            head = h;
        }

        public void AppendToTail(int n)
        {
            Node end = new Node(n);
            if (this.head == null)
            {
                this.head = end;
            }
            else
            {
                Node nd = this.head;
                while (nd.next != null)
                {
                    nd = nd.next;
                }
                nd.next = end;
            }
        }

        public void AppendToTail(string s)
        {
            Node end = new Node(s);
            if (this.head == null)
            {
                this.head = end;
            }
            else
            {
                Node nd = this.head;
                while (nd.next != null)
                {
                    nd = nd.next;
                }
                nd.next = end;
            }
        }

        // Error, append the actual nd will cause looping when ttry to reach the end
        //public void AppendToTail(Node end)
        //{
        //    if (this.head == null)
        //    {
        //        this.head = end;
        //    }
        //    else
        //    {
        //        Node nd = this.head;
        //        while (nd.next != null)
        //        {
        //            nd = nd.next;
        //        }
        //        nd.next = end;
        //    }
        //}
    }

    public class Node
    {
        public Node next = null;
        public int data;
        public string strData;

        public Node(int d)
        {
            data = d;
        }

        public Node(string s)
        {
            strData = s;
        }
    }
}
