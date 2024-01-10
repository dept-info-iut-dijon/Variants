using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Boolean implementation
    /// </summary>
    public class ImplBool : IVariant
    {
        private bool value;
        /// <summary>
        /// Init the state with a boolean value
        /// </summary>
        /// <param name="value">boolean value</param>
        public ImplBool(bool value)
        {
            this.value = value;
        }

        public TypeVariant Type => TypeVariant.Boolean;

        public bool AsBool()
        {
            return value;
        }

        public DateTime AsDateTime()
        {
            throw new VariantException();
        }

        public double AsDouble()
        {
            return value ? 1.0 : 0.0;
        }

        public int AsInt()
        {
            return value ? 1 : 0;
        }

        public string AsString()
        {
            return value ? "true" : "false";
        }

        public bool CanBeConvertedInto(TypeVariant other)
        {
            return other != TypeVariant.DateTime;
        }

        public IVariant Clone()
        {
            return new ImplBool(value);
        }

        public bool Equals(IVariant other)
        {
            bool ret = false;
            try { ret = value == other.AsBool(); }
            catch { }
            return ret;
        }
    }
}
