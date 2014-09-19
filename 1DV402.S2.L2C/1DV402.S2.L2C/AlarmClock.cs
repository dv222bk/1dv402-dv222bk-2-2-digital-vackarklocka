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

            }
            set
            {

            }
        }
        public string Time
        {
            get
            {
                
            }
            set
            {

            }
        }
        public AlarmClock()
        {

        }
        public AlarmClock(int hour, int minute)
        {

        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {

        }
        public AlarmClock(string time, params string[] alarmTimes)
        {

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
