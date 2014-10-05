using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    /// <summary>
    /// AlarmClock objects holds all information about a clock
    /// </summary>
    class AlarmClock
    {
        private ClockDisplay[] _alarmTimes;
        private ClockDisplay _time;

        /// <summary>
        /// Used to set and read alarm times from _alarmTimes.
        /// Returns a string array of alarm times.
        /// </summary>
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

        /// <summary>
        /// Used to set and read alarm times from _time
        /// Returns a string of the current time
        /// </summary>
        public string Time
        {
            get
            {
                return _time.ToString();
            }
            set
            {
                _time = new ClockDisplay(value);
            }
        }

        /// <summary>
        /// Constructor creating a new clock with default values
        /// </summary>
        public AlarmClock() : this(0, 0) { }

        /// <summary>
        /// Constructor creating a new clock
        /// </summary>
        /// <param name="hour">The hour the clock should be set to</param>
        /// <param name="minute">The minute the clock should be set to</param>
        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0) { }

        /// <summary>
        /// Constructor creating a new clock with alarm time
        /// </summary>
        /// <param name="hour">The hour the clock should be set to</param>
        /// <param name="minute">The minute the clock should be set to</param>
        /// <param name="alarmHour">The hour of the alarm time</param>
        /// <param name="alarmMinute">The minute of the alarm time</param>
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            _alarmTimes = new ClockDisplay[1] { new ClockDisplay(alarmHour, alarmMinute) };
            _time = new ClockDisplay(hour, minute);
        }

        /// <summary>
        /// Constructor creating a new clock with multiple alarm times
        /// </summary>
        /// <param name="time">String of the time the clock should be set to (HH:mm)</param>
        /// <param name="alarmTimes">String array of the alarm times the clock should use (HH:mm)</param>
        public AlarmClock(string time, params string[] alarmTimes)
        {
            AlarmTimes = alarmTimes;
            _time = new ClockDisplay(time);
        }

        /// <summary>
        /// Overrides the default Equals method
        /// Compares this object to another object
        /// </summary>
        /// <param name="obj">The object to compare this object with</param>
        /// <returns>True if the objects are the same, false otherwise</returns>
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

        /// <summary>
        /// Overrides the default GetHashCode method
        /// Returns a custom hashcode for this object, using the default gethashcode method
        /// </summary>
        /// <returns>This objects hashcode (int)</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Overrides the default != operator when comparing objects of this type
        /// </summary>
        /// <param name="a">AlarmClock object</param>
        /// <param name="b">AlarmClock object</param>
        /// <returns>True if they don't equal eachother, false otherwise</returns>
        public static bool operator !=(AlarmClock a, AlarmClock b)
        {
            if (ReferenceEquals(a, null))
            {
                return !(ReferenceEquals(b, null));
            }
            return !a.Equals(b);
        }

        /// <summary>
        /// Overrides the default == operator when comparing objects of this type
        /// </summary>
        /// <param name="a">AlarmClock object</param>
        /// <param name="b">AlarmClock object</param>
        /// <returns>True if they equal eachother, false otherwise</returns>
        public static bool operator ==(AlarmClock a, AlarmClock b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Advances the clock one minute
        /// </summary>
        /// <returns>True if the new time is equal to an alarm time, false otherwise</returns>
        public bool TickTock()
        {
            _time.Increment();
            for (int i = 0; i < _alarmTimes.Length; i++)
            {
                if (_time == _alarmTimes[i])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Overrides the default toString method
        /// Returns a string value of this object
        /// </summary>
        /// <returns>A string, containing the current time and alarm times</returns>
        public override string ToString()
        {
            string toString = Time;
            toString += " (";
            for (int i = 0; i < _alarmTimes.Length; i++)
            {
                toString += _alarmTimes[i].Time;
                if (i + 1 < _alarmTimes.Length)
                {
                    toString += ", ";
                }
            }
            toString += ")";
            return toString;
        }
    }
}
