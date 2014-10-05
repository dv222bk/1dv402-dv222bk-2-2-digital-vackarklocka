using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    /// <summary>
    /// NumberDisplay objects holds a single number for a clock
    /// </summary>
    class NumberDisplay
    {
        private int _maxNumber;
        private int _number;

        /// <summary>
        /// Used to set and read the maximum number this object can hold from _maxNumber
        /// Returns the number stored in _maxNumber
        /// </summary>
        public int MaxNumber
        {
            get
            {
                return _maxNumber;
            }
            set
            {
                if (value > 0)
                {
                    _maxNumber = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
        }

        /// <summary>
        /// Used to set and read the number in _number
        /// Returns the number stored in _number
        /// </summary>
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value >= 0 && value <= _maxNumber)
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(value.ToString());
                }
            }
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
            int hashCode = _maxNumber.GetHashCode();
            hashCode ^= _number.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Increases the hold number by one.
        /// If the number than exceedes the maximum number, the number becomes 0.
        /// </summary>
        public void Increment()
        {
            _number++;
            if (_number > _maxNumber)
            {
                _number = 0;
            }
        }

        /// <summary>
        /// Constructor making the object hold the number 0 that can be increased to the maximum of maxNumber
        /// </summary>
        /// <param name="maxNumber">The maximum the number contained in this object can become</param>
        public NumberDisplay(int maxNumber) : this (maxNumber, 0) { }

        /// <summary>
        /// Constructor making the object hold the number send, that can be increased to the maximum of maxNumber
        /// </summary>
        /// <param name="maxNumber">The maximum the number contained in this object can become</param>
        /// <param name="number">The number this object should hold</param>
        public NumberDisplay(int maxNumber, int number){
            MaxNumber = maxNumber;
            Number = number;
        }

        /// <summary>
        /// Overrides the default != operator when comparing objects of this type
        /// </summary>
        /// <param name="a">NumberDisplay object</param>
        /// <param name="b">NumberDisplay object</param>
        /// <returns>True if they don't equal eachother, false otherwise</returns>
        public static bool operator !=(NumberDisplay a, NumberDisplay b)
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
        /// <param name="a">NumberDisplay object</param>
        /// <param name="b">NumberDisplay object</param>
        /// <returns>True if they equal eachother, false otherwise</returns>
        public static bool operator ==(NumberDisplay a, NumberDisplay b)
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
        /// <returns>A string, containing the number in this object</returns>
        public override string ToString()
        {
            return _number.ToString();
        }

        /// <summary>
        /// Returns a string value of this object using a specific format:
        /// G or 0: Return the number stored in this object as a string
        /// 00: If the number is lower than 10, return it with a 0 in front, as a string, otherwise just return the number
        /// </summary>
        /// <returns>A string, containing the number in this object in a formated manner</returns>
        public string ToString(string format)
        {
            Regex regex = new Regex("0{2}|0|G"); //Regcheck, that checks if the format string is "0, G or 00".
            Match match = regex.Match(format);
            if (match.Success)
            {
                if ("0" == match.Value || "G" == match.Value)
                {
                    return _number.ToString();
                } else if ("00" == match.Value){
                    if (_number < 10)
                    {
                        return "0" + _number.ToString();
                    }
                    else
                    {
                        return _number.ToString();
                    }
                }
            }
            throw new FormatException();
        }
    }
}
