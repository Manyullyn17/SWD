
using System;
using System.Collections;
using System.Text;

namespace LL_CS
{
    class DynArray
    {
        #region Members
        protected int _capacity;
        protected int _count;
        protected object[] _ary;
        #endregion

        public DynArray()
        {
            _count = 0;
            _capacity = 10;
            _ary = new object[_capacity];
        }

        protected void CheckSpace()
        {
            if (_count < _capacity - 2)
                return;
            _capacity += 10;
            object[] newAry = new object[_capacity];
            for (int i = 0; i < _count; i++)
                newAry[i] = _ary[i];
            // delete _ary; würde man in C++ noch brauchen
            _ary = newAry;
        }

        protected void CreateSlot(int aIdx)
        {
            // muss _count++ machen
            if (aIdx >= _count) throw new Exception("wrong index");
            _count++;
            CheckSpace();
            for (int i = (_capacity - 1); i >= aIdx; i--) _ary[i] = _ary[i - 1];
            _ary[aIdx] = null;
        }

        protected void RemoveSlot(int aIdx)
        {
            if (aIdx >= _count) throw new Exception("wrong index");
            for (int i = aIdx; i < (_count - 1); i++) _ary[i] = _ary[i + 1];
            _ary[_count - 1] = null;
            _count--;
        }
    }


    class CsArrayList : DynArray, IHLContainer
    {
        public CsArrayList()
        {
        }

        public int Count()
        {
            return _count;
        }

        public void Clear()
        {
        }

        public object First()
        {
            return null;
        }

        public object Next()
        {
            return null;
        }

        public void AddHead(object aObj)
        {
        }

        public object RemoveHead()
        {
            return null;
        }

        public void AddTail(object aObj)
        {
            CheckSpace();
            _ary[_count] = aObj;
            _count++;
        }

        public object RemoveTail()
        {
            return null;
        }

        public object At(int aPos)
        {
            return null;
        }

        public object Find(object aTestObject, IComparer aCmp)
        {
            return null;
        }

        public object Remove(object aObj)
        {
            return null;
        }

        public object RemoveAt(int aIdx)
        {
            object temp = _ary[aIdx];
            RemoveSlot(aIdx);
            return temp;
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {

        }

        public void InsertAtPos(object aObj, int aPos)
        {
            CreateSlot(aPos);
            _ary[aPos] = aObj;
        }

        public void Print()
        {
            if (_count == 0)
            {
                Console.WriteLine("Empty!!");
                return;
            }
            for (int i = 0; i < _count; i++)
                Console.Write(" {0}", _ary[i]);
            Console.WriteLine();
        }
    }
}
