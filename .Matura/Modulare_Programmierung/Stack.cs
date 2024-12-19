using System;
using System.Text;

namespace Stack17
{
  // Fehlerbehandlung für OverFlow und UnderFlow
  class StackException : Exception
  {
    public StackException(string message) :
      base(message)
    {
      // Konstruktor ohne Code
    }
  }
  
  class Stack
  {
    int[] _ary;
    int _sp;
    public int tmp;

    public Stack()
    {
    }

    public Stack(int aSize)
    {
      _ary = new int[aSize];
      _sp = 0;
    }

    // Copy Konstructor
    // Exakte Kopie von aStk erstellen
    public Stack(Stack aStk)
    {
      _ary = new int[aStk._ary.Length];
      _sp = aStk._sp;
      // daten kopieren
      for (int i = 0; i < _sp; i++)
      {
        _ary[i] = aStk._ary[i];
      }
    }

    public void Push(int aVal)
    {
      if (_sp >= _ary.Length)
        throw new StackException("overflow");
      _ary[_sp] = aVal;
      _sp++;
    }

    public int Pop()
    {
      if (_sp <= 0)
        throw new StackException("underflow");
      _sp--;
      return _ary[_sp];
    }

    // Inhalt des Stacks auf der Konsole ausgeben
    public void Print()
    {
      for(int i=0; i<_sp; i++)
      {
        Console.Write("{0} ", _ary[i]);
      }
      Console.WriteLine();
    }
  }
}
