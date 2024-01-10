using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Main class, carries variant values
    /// </summary>
    public class Variant : IVariant
    {
        private IVariant? impl;

        public TypeVariant Type => (impl!=null)?impl.Type:TypeVariant.Unknown;

        /// <summary>
        /// Init a variant with any value. The variant does not contain anything.
        /// </summary>
        public Variant()
        {
            impl = null;
        }


        /// <summary>
        /// Init the variant with a string
        /// </summary>
        /// <param name="value">value to store</param>
        public Variant(string value)
        {
            impl = new ImplString(value);
        }

        /// <summary>
        /// Init the variant with an integer
        /// </summary>
        /// <param name="value">the int value</param>
        public Variant(int value)
        {
            impl = new ImplInt(value);
        }

        /// <summary>
        /// Init the variant with a boolean
        /// </summary>
        /// <param name="value">the boolean</param>
        public Variant(bool value)
        {
            impl = new ImplBool(value);
        }

        public Variant(double value)
        {
            impl = new ImplDouble(value);
        }

        /// <summary>
        /// Init the variant with a date/time
        /// </summary>
        /// <param name="value">date-time value</param>
        public Variant(DateTime value)
        {
            impl=new ImplDateTime(value);
        }
        public bool AsBool()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.AsBool();
        }

        public DateTime AsDateTime()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.AsDateTime();
        }

        public double AsDouble()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.AsDouble();
        }

        public int AsInt()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.AsInt();
        }

        public string AsString()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.AsString();
        }

        public IVariant Clone()
        {
            if (impl == null) throw new EmptyVariant();
            return impl.Clone();
        }

        public bool Equals(IVariant other)
        {
            bool isEqual;
            if(impl==null)
            {
                isEqual = other == null || other.Type == TypeVariant.Unknown;
            }
            else
            {
                isEqual = impl.Equals(other);
            }
            return isEqual;
        }

        public override string ToString()
        {            
            return AsString();
        }

        /// <summary>
        /// Change to value stored in the variant
        /// </summary>
        /// <param name="value">the new value</param>
        public void Modify(string value)
        {
            impl = new ImplString(value);
        }
        /// <summary>
        /// Change to value stored in the variant
        /// </summary>
        /// <param name="value">the new value</param>
        public void Modify(int value)
        {
            impl = new ImplInt(value);
        }
        /// <summary>
        /// Change to value stored in the variant
        /// </summary>
        /// <param name="value">the new value</param>
        public void Modify(double value)
        {
            impl = new ImplDouble(value);
        }
        /// <summary>
        /// Change to value stored in the variant
        /// </summary>
        /// <param name="value">the new value</param>
        public void Modify(DateTime value)
        {
            impl = new ImplDateTime(value);
        }
        /// <summary>
        /// Change to value stored in the variant
        /// </summary>
        /// <param name="value">the new value</param>
        public void Modify(bool value)
        {
            impl = new ImplBool(value);
        }



        /// <summary>
        /// Convert the variant type, with the same value
        /// </summary>
        /// <param name="newType">the new type wanted. If same than old, nothing happens</param>
        /// <exception cref="EmptyVariant">If the variant contains no value</exception>
        /// <exception cref="VariantException">if the variant cannot be of this kind</exception>
        public void Convert(TypeVariant newType)
        {
            if(impl == null && newType!=TypeVariant.Unknown) throw new EmptyVariant();
            if(Type!=newType)
            {
                switch(newType)
                {
                    case TypeVariant.Boolean:
                        impl = new ImplBool(AsBool());
                        break;
                    case TypeVariant.DateTime:
                        impl = new ImplDateTime(AsDateTime()); break;
                    case TypeVariant.String: 
                        impl = new ImplString(AsString());
                        break;
                    case TypeVariant.Integer:
                        impl = new ImplInt(AsInt());break;
                    case TypeVariant.Float:
                        impl = new ImplDouble(AsDouble()); break;
                    case TypeVariant.Unknown:
                        throw new VariantException();
                }
            }
        }

        

        public bool CanBeConvertedInto(TypeVariant other)
        {
            return (impl != null) ? impl.CanBeConvertedInto(other) : false;
        }
    }
}
