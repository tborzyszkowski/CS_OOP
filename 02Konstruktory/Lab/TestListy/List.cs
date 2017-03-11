using System;
using System.Collections.Generic;
using System.Text;

namespace Listy
{
    public class List
    {
        class Node
        {
            public string Data;
            public Node Next;

            #region Kod dodany
            public void KlonujRekurencyjnie(Node wezel)
            {
                wezel.Data = Data;
                if (Next != null)
                {
                    wezel.Next = new Node();
                    Next.KlonujRekurencyjnie(wezel.Next);
                }
            }
            #endregion
        }

        #region Kod dodany
        public List KlonujRekurencyjnie()
        {
            List nowa = new List();
            if (head != null)
            {
                nowa.head = new Node();
                head.KlonujRekurencyjnie(nowa.head);
            }
            return nowa; 
        }
        public List KlonujIteracyjnie()
        {
            List nowa = new List();
            if (head != null)
            {
                nowa.head = new Node();

                Node tmp = head;
                Node tmp2 = nowa.head;
                tmp2.Data = head.Data;
                while (tmp.Next != null)
                {
                    tmp2.Next = new Node();
                    tmp2 = tmp2.Next;
                    tmp = tmp.Next;
                    tmp2.Data = tmp.Data;
                }
            }
            return nowa;
        }
        #endregion
        private Node head=null;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void AddToHead(string s)
        {
            Node tmp = new Node();
            tmp.Data = s;
            tmp.Next = head;
            head = tmp;
        }

        public string DeleteFromHead()
        {
            if (head == null)           //lista pusta
                throw new InvalidOperationException("Lista jest pusta");
            string x = head.Data;
            head = head.Next;
            return x; 
        }

        
        public void PrintAll()
        {
            for (Node tmp = head; tmp != null; tmp = tmp.Next)
            {
                Console.WriteLine(tmp.Data);
            }
        }

        public int GetCount()
        {
            int i;
            Node tmp;
            for (i = 0, tmp = head; tmp != null; i++, tmp = tmp.Next) ;
            return i;
        }

    }
}
