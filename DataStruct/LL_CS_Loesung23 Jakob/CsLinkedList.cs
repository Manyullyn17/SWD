
using System;
using System.Collections;
using System.Text;

namespace LL_CS
{
    class CsLink
    {
        public CsLink next;
        public object data;
        public CsLink(Object aData)
        {
            data = aData;
        }
    }

    class CsLinkedList : IHLContainer
    {
        #region Members
        protected CsLink _head;
        CsLink _tail;
        CsLink _iter;
        #endregion

        public CsLinkedList() { }

        public int Count()
        {
            return 0;
        }

        public object First()
        {
            if (_head == null) // Liste ist leer
                return null;
            _iter = _head;
            return _iter.data;
        }

        public object Next()
        {
            if (_head == null)
                return null;
            if (_iter == null)
                return null;
            _iter = _iter.next;
            if (_iter == null)
                return null;
            return _iter.data;
        }

        public void AddHead(object aObj)
        {
            CsLink elem = new CsLink(aObj);
            if (_head == null) // sonderfall Liste ist leer
            {
                _head = _tail = elem;
                return;
            }
            elem.next = _head; // allgemeiner Fall
            _head = elem;
        }

        public object RemoveHead()
        {
            if (_head == null) // Liste ist leer
                return null;
            CsLink remElem;
            if (_head == _tail) // nur ein Element in der Liste
            {
                remElem = _head;
                _head = _tail = null;
                return remElem.data;
            }
            remElem = _head;
            _head = _head.next; // allgemeiner Fall
            return remElem.data;
        }

        public void AddTail(object aObj)
        {
            // Spezialfälle 0 oder 1 Element in der Liste
            CsLink elem = new CsLink(aObj);

            if (_head == null)
            {
                _head = _tail = elem;
                return;
            }

            _tail.next = elem;
            _tail = elem;
        }

        public object RemoveTail()
        {
            //Spezialfälle Liste ist Leed oder 1 Element in Liste

            // Vörgänger von Tail suchen
            CsLink remElem = _tail;
            CsLink it = _head;
            if (_head == null || _tail == null) return null;

            if (_head == _tail)  // nur ein Element -> Sonderfall
            {
                remElem = _tail;
                _head = _tail = null;
                return remElem.data;
            }

            // den Vorgänger von Tail suchen
            remElem = _tail;
            while (it.next != _tail) it = it.next;


            _tail = it;
            _tail.next = null;
            return remElem.data;
        }

        public object At(int aPos)
        {
            return null;
        }

        public object Find(Object aTestObject, IComparer aCmp)
        {
            object obj = First();
            while (obj != null)
            {
                if (aCmp.Compare(aTestObject, obj) == 0)
                    return obj;
                obj = Next();
            }

            return null;
        }

        public object Remove(Object aObj)
        {
            object obj = First();
            while (obj != null)
            {
                if (obj == aObj)
                {
                    CsLink it = _head;
                    while (it.next != _iter) it = it.next;
                    it.next = _iter.next;
                    return obj;
                }

                obj = Next();
            }

            return obj;
        }

        public object RemoveAt(int aIdx)
        {
            return null;
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            CsLink iter;
            CsLink prev;
            CsLink elem = new CsLink(aObj);

            iter = prev = _head;
            while (iter != null)
            {
                if (aCmp.Compare(iter.data, aObj) > 0)
                {
                    if (iter == _head)
                    {
                        elem.next = _head;
                        _head = elem;
                    }
                    else
                    {
                        prev.next = elem;
                        elem.next = iter;
                    }
                    return;
                }
                prev = iter;
                iter = iter.next;
            }

            if (_tail == null) AddTail(aObj);
            else
            {
                _tail.next = elem;
                _tail = elem;
            }
        }

        public void InsertAtPos(object aObj, int aPos)
        {
        }

        public void Print()
        {
            object obj = First();
            if (obj == null)
                Console.Write("Empty");
            while (obj != null)
            {
                Console.Write("{0} ", obj);
                obj = Next();
            }
            Console.WriteLine();
        }
    }
}
