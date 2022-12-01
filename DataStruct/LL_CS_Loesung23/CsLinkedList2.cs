
using System;
using System.Collections;
using System.Text;

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

    public CsLlEnumerator(CsLink aHead)
    {
      
    }

    public object Current
    {
      get
      {
        return null;
      }
    }

    public bool MoveNext()
    {
      return false;
    }

    public void Reset()
    {
      
    }
  }
}
