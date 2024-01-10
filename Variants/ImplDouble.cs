using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    public class ImplDouble : IVariant
    {
        private double value;
        public ImplDouble(double value)
        {
            this.value = value;
        }

        public TypeVariant Type => TypeVariant.Float;

        public bool AsBool()
        {
            return !(value == 0);
        }

        public DateTime AsDateTime()
        {
            throw new VariantException();
        }

        public double AsDouble()
        {
            return value;
        }

        public int AsInt()
        {
            if ((int)value != value) throw new VariantException();
            return (int)value;
        }

        public string AsString()
        {
            return value.ToString();
        }

        public bool CanBeConvertedInto(TypeVariant other)
        {
            return !(
                    other == TypeVariant.DateTime ||
                    (other == TypeVariant.Integer && (int)value != value)
                );
        }

        public IVariant Clone()
        {
            return new ImplDouble(value);
        }

        public bool Equals(IVariant other)
        {
            bool ret = false;
            try { ret = Math.Abs(value - other.AsDouble()) < 1E-7; } catch { }
            return ret;
        }
    }
}
