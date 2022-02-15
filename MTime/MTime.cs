using System;
using System.Text;

namespace MTime
{
    class MTime
    {
        string _name;
        int _Hours;
        int _Minutes;
        int _Seconds;

        // alle Membervariablen auf null setzen
        public MTime(string aName)
        {
            _name = aName;
            _Hours = _Minutes = _Seconds = 0;
        }

        // hh:mm:ss setzen
        public MTime(string aName, int aHours, int aMinutes, int aSeconds)
        {
            _name = aName;
            _Hours = aHours; _Minutes = aMinutes; _Seconds = aSeconds;
        }

        public void AddSeconds(int aSeconds)
        {
            _Seconds += aSeconds;

            while(_Seconds >= 60)
            {
                AddMinutes(1);
                _Seconds -= 60;
            }
        }

        public void AddMinutes(int aMinutes)
        {
            _Minutes += aMinutes;

            while(_Minutes >= 60)
            {
                AddHours(1);
                _Minutes -= 60;
            }
        }

        public void AddHours(int aHours)
        {
            _Hours += aHours;
        }

        public void SetMinutes(int aMinutes)
        {
            if (aMinutes >= 0 && aMinutes < 60)
                _Minutes = aMinutes;
        }

        // Property
        public int Minutes
        {
            set
            {
                if (value >= 0 && value < 60)
                    _Minutes = value;
            }
            get
            {
                return _Minutes;
            }
        }

        public void Print()
        {
            Console.WriteLine("{0} = {1}:{2}:{3}", _name, _Hours, _Minutes, _Seconds);
        }
    }
}
