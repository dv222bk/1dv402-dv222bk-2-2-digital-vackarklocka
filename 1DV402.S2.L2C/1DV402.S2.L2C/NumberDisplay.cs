using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            }
            set
            {

            }
        }
        public int Number
        {
            get
            {
                
            }
            set
            {

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

        }
        public NumberDisplay(int maxNumber, int number){

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

        }
        public override string ToString(string format)
        {

        }
    }
}
