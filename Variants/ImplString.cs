using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// String intern implementation of variant
    /// </summary>
    public class ImplString : IVariant
    {
        private string value;
        /// <summary>
        /// Init the variant with a string value
        /// </summary>
        /// <param name="value">the string value to store   </param>
        public ImplString(string value)
        {
            this.value = value;
        }

        public TypeVariant Type => TypeVariant.String;

        public bool AsBool()
        {
            return (value == "0" || value == "false") ? false : true;
        }

        public DateTime AsDateTime()
        {
            DateTime test;
            if (!DateTime.TryParse(value, out test))
            {
                throw new VariantException();
            }
            return test;
        }

        public double AsDouble()
        {
            double test = 0.0;
            try
            {
                test = Convert.ToDouble(value);
            }
            catch
            {
                throw new VariantException();
            }
            return test;
        }

        public int AsInt()
        {
            int test = 0;
            try
            {
                test = Convert.ToInt32(value);
            }
            catch
            {
                throw new VariantException();
            }
            return test;
        }

        public string AsString()
        {
            return value;
        }

        public bool CanBeConvertedInto(TypeVariant other)
        {
            bool canBe = false;
            switch(other)
            {
                case TypeVariant.Boolean:
                    canBe = true; break;
                case TypeVariant.DateTime:
                        DateTime dummyDate;
                        canBe = DateTime.TryParse(value,out dummyDate); break;
                case TypeVariant.String: canBe = true; break;
                case TypeVariant.Integer:
                    int dummyInt;
                    canBe = int.TryParse(value,out dummyInt); break;
                case TypeVariant.Float:
                    double dummyDouble;
                    canBe = double.TryParse(value,out dummyDouble); break;
            }
            return canBe;
        }

        public IVariant Clone()
        {
            return new ImplString(value);
        }

        public bool Equals(IVariant other)
        {
            Debug.Assert(other != null);
            bool ret = false;
            try
            {
                ret = value == other.AsString();
            }
            catch
            {
            }
            return ret;
        }
    }
}
