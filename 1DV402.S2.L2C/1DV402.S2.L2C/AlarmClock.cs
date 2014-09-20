using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    class AlarmClock
    {
        private ClockDisplay[] _alarmTimes;
        private ClockDisplay _time;
        public string[] AlarmTimes
        {
            get
            {
                string[] alarmTimes = new string[_alarmTimes.Length];
                for (int i = 0; i < _alarmTimes.Length; i++)
                {
                    alarmTimes[i] = _alarmTimes[i].ToString();
                }
                return alarmTimes;
            }
            set
            {
                _alarmTimes = new ClockDisplay[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    _alarmTimes[i] = new ClockDisplay(value[i]);
                }
            }
        }
        public string Time
        {
            get
            {
                return _time.ToString();
            }
            set
            {
                _time.Time = value;
            }
        }
        public AlarmClock()
        {
            new AlarmClock(0, 0);
        }
        public AlarmClock(int hour, int minute)
        {
            new AlarmClock(hour, minute, 0, 0);
        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            _alarmTimes = new ClockDisplay[1] { new ClockDisplay(alarmHour, alarmMinute) };
            _time = new ClockDisplay(hour, minute);
        }
        public AlarmClock(string time, params string[] alarmTimes)
        {
            AlarmTimes = alarmTimes;
            _time = new ClockDisplay(time);
        }
        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null)
            {
                return false;
            }
            // Equivalent data types. Can be avoided if type is sealed.
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            // Compare hashcodes
            return (this.GetHashCode() == obj.GetHashCode());
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator !=(AlarmClock a, AlarmClock b)
        {
            if (ReferenceEquals(a, null))
            {
                return !(ReferenceEquals(b, null));
            }
            return !a.Equals(b);
        }
        public static bool operator ==(AlarmClock a, AlarmClock b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public bool TickTock()
        {
            for (int i = 0; i < _alarmTimes.Length; i++)
            {
                if (_time == _alarmTimes[i])
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string toString = _time.Time;
            for (int i = 0; i < _alarmTimes.Length; i++)
            {
                toString += "\"" + _alarmTimes[i].Time + "\"";
            }
            return toString;
        }
    }
}
