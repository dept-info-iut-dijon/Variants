using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Integer implementation of state variant
    /// </summary>
    public class ImplInt : IVariant
    {
        private int value;
        /// <summary>
        /// Init the state
        /// </summary>
        /// <param name="value">integer value</param>
        public ImplInt(int value)
        {
            this.value = value;               
        }

        public TypeVariant Type => TypeVariant.Integer;

        public bool AsBool()
        {
            return !(value == 0);
        }

        public DateTime AsDateTime()
        {
            return new DateTime(value);            
        }

        public double AsDouble()
        {
            return (double)value;
        }

        public int AsInt()
        {
            return value;
        }

        public string AsString()
        {
            return value.ToString();
        }

        public bool CanBeConvertedInto(TypeVariant other)
        {
            return true;
        }

        public IVariant Clone()
        {
            return new ImplInt(value);
        }

        public bool Equals(IVariant other)
        {
            bool ret = false;
            try { ret = value == other.AsInt(); }
            catch { }
            return ret;
        }
    }
}
