using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    /// <summary>
    /// ClockDisplay objects holds the numbers in a clock
    /// </summary>
    class ClockDisplay
    {
        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay;

        /// <summary>
        /// Used to set and read the minute and hours from _hourDisplay and _minuteDisplay
        /// Returns a string with the values contained in _hourDisplay and _minuteDisplay (HH:mm)
        /// </summary>
        public string Time
        {
            get
            {
                return _hourDisplay.ToString() + ":" + _minuteDisplay.ToString("00");
            }
            set
            {
                Regex regex = new Regex("^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$"); // Checks if pattern is a correct time in the format HH:mm
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

        /// <summary>
        /// Constructor creating new clock times with default values
        /// </summary>
        public ClockDisplay() : this(0, 0) { }

        /// <summary>
        /// Constructor creating new clock times
        /// </summary>
        /// <param name="hour">The hour to be set</param>
        /// <param name="minute">The minute to be set</param>
        public ClockDisplay(int hour, int minute)
        {
            _hourDisplay = new NumberDisplay(23, hour);
            _minuteDisplay = new NumberDisplay(59, minute);
        }

        /// <summary>
        /// Constructor creating new clock times from a string
        /// </summary>
        /// <param name="time">String with the clock time in the format HH:mm</param>
        public ClockDisplay(string time)
        {
            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);
            Time = time;
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
        /// Increases the minute by one.
        /// If the minute than becomes 0, increase the hour by one as well.
        /// </summary>
        public void Increment()
        {
            _minuteDisplay.Increment();
            if (_minuteDisplay.Number == 0)
            {
                _hourDisplay.Increment();
            }
        }

        /// <summary>
        /// Overrides the default != operator when comparing objects of this type
        /// </summary>
        /// <param name="a">ClockDisplay object</param>
        /// <param name="b">ClockDisplay object</param>
        /// <returns>True if they don't equal eachother, false otherwise</returns>
        public static bool operator !=(ClockDisplay a, ClockDisplay b)
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
        /// <param name="a">ClockDisplay object</param>
        /// <param name="b">ClockDisplay object</param>
        /// <returns>True if they equal eachother, false otherwise</returns>
        public static bool operator ==(ClockDisplay a, ClockDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Overrides the default toString method
        /// Returns a string value of this object
        /// </summary>
        /// <returns>A string, containing the hour and minute</returns>
        public override string ToString()
        {
            return Time;
        }
    }
}
