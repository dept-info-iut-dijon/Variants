using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Datetime implementation
    /// </summary>
    public class ImplDateTime : IVariant
    {
        private DateTime value;
        /// <summary>
        /// Init the state with a date/time
        /// </summary>
        /// <param name="value">the value</param>
        public ImplDateTime(DateTime value)
        {
            this.value = value;
        }

        public TypeVariant Type => TypeVariant.DateTime;

        public bool AsBool()
        {
            return value != DateTime.MinValue;
        }

        public DateTime AsDateTime()
        {
            return value;
        }

        public double AsDouble()
        {
            return value.Ticks;
        }

        public int AsInt()
        {
            return (int)value.Ticks;
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
            return new ImplDateTime(value);
        }

        public bool Equals(IVariant other)
        {
            bool ret = false;
            try { ret = value == other.AsDateTime(); } catch { }
            return ret;
        }
    }
}
