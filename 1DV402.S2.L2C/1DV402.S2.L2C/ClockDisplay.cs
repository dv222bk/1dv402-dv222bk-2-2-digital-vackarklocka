using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    class ClockDisplay
    {
        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay;
        public string Time
        {
            get
            {
                return _hourDisplay.ToString("G") + ":" + _minuteDisplay.ToString("00");
            }
            set
            {
                Regex regex = new Regex("^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    string[] split = match.Value.Split(new Char[] {':'});
                    _hourDisplay.Number = int.Parse(split[0]);
                    _minuteDisplay.Number = int.Parse(split[1]);
                }
                else
                {
                    throw new FormatException(value);
                }
            }
        }
        public ClockDisplay() : this(0, 0) { }
        public ClockDisplay(int hour, int minute)
        {
            _hourDisplay = new NumberDisplay(23, hour);
            _minuteDisplay = new NumberDisplay(59, minute);
        }
        public ClockDisplay(string time)
        {
            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);
            Time = time;
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
        public void Increment()
        {
            _minuteDisplay.Increment();
            if (_minuteDisplay.Number == 0)
            {
                _hourDisplay.Increment();
            }
        }
        public static bool operator !=(ClockDisplay a, ClockDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return !(ReferenceEquals(b, null));
            }
            return !a.Equals(b);
        }
        public static bool operator ==(ClockDisplay a, ClockDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public override string ToString()
        {
            return Time;
        }
    }
}
