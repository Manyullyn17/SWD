using System;
using System.Collections;

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

            CsLink remElem = _tail;
            if (_head == null || _tail == null) return null;    // Sonderfall Liste Leer

            if (_head == _tail) // Sonderfall nur 1 Element
            {
                remElem = _tail;
                _head = _tail = null;
                return remElem.data;
            }

            CsLink it = _head;
            // Vörgänger von Tail suchen
            while (it.next != _tail) it = it.next;
            remElem = _tail;

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

            if (_head == null)
                return null;
            if (_head == _tail)
            {
                if (aObj == _iter.data)
                {
                    object ret = _head.data;
                    _head = null;
                    return ret;
                }
            }
            if (aObj == _tail.data)
            {
                CsLink it = _head;
                while (it.next != _tail) it = it.next;
                object ret = _tail;
                _tail = it;
                _tail.next = null;
                return ret;
            }
            if (aObj == _head.data)
            {
                object ret = _head.data;
                _head = _head.next;
                return ret;
            }

            while (obj != null)
            {
                if (_iter.next.data == aObj)
                {
                    object ret = _iter.next.data;
                    _iter.next = _iter.next.next;
                    return ret;
                }
                obj = Next();
            }
            return null;
        }

        public object RemoveAt(int aIdx)
        {
            return null;
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            CsLink iter;
            CsLink prev;
            CsLink elem = new CsLink(aObj); // elem ist das einzufügende Element
            iter = prev = _head;
            while (iter != null)
            {
                if (aCmp.Compare(iter.data, aObj) > 0)
                { // vor iter einfügen
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
            // ansonsten hinten anhängen
            _tail.next = elem;
            _tail = elem;
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
