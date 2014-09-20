using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    class NumberDisplay
    {
        private int _maxNumber;
        private int _number;
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
                    throw new ArgumentException();
                }
            }
        }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value > 0 && value <= _maxNumber)
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
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
            int hashCode = _maxNumber.GetHashCode();
            hashCode ^= _number.GetHashCode();
            return hashCode;
        }
        public void Increment()
        {
            _number++;
            if (_number > _maxNumber)
            {
                _number = 0;
            }
        }
        public NumberDisplay(int maxNumber)
        {
            new NumberDisplay(maxNumber, 0);
        }
        public NumberDisplay(int maxNumber, int number){
            MaxNumber = maxNumber;
            Number = number;
        }
        public static bool operator !=(NumberDisplay a, NumberDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return !(ReferenceEquals(b, null));
            }
            return !a.Equals(b);
        }
        public static bool operator ==(NumberDisplay a, NumberDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return a.Equals(b);
        }
        public override string ToString()
        {
            return _number.ToString();
        }
        public override string ToString(string format)
        {
            Regex regex = new Regex("0{2}|0|G");
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
