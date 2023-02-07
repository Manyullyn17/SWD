using System.Collections;

namespace LL_CS
{

    // Eine CsLinkedList die das IEnumerable-Interface implementiert

    class CsLinkedList2 : CsLinkedList, IEnumerable
    {
        public CsLinkedList2() { }

        public IEnumerator GetEnumerator()
        {
            return new CsLlEnumerator(_head);
        }
    }


    class CsLlEnumerator : IEnumerator
    {
        CsLink _head;
        CsLink _it;
        bool _first;

        public CsLlEnumerator(CsLink aHead)
        {
            _head = aHead;
            Reset();
        }

        public object Current
        {
            get
            {
                if (_it == null)
                    return null;
                else
                    return _it.data;
            }
        }

        public bool MoveNext()
        {
            if (_it == null)
                return false;
            if (_first)
            {
                _first = false;
                return true;
            }
            _it = _it.next;
            if (_it == null)
                return false;
            return true;
        }

        public void Reset()
        {
            _it = _head; _first = true;
        }
    }
}
