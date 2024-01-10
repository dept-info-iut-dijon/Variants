using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Interface to a variant (state pattern)
    /// </summary>
    public interface IVariant
    {
        /// <summary>
        /// Type of variant stored
        /// </summary>
        TypeVariant Type { get; }
        /// <summary>
        /// Give variant on string value
        /// </summary>
        /// <returns>string value of the variant</returns>
        /// <exception cref="VariantException">If value cannot be converted</exception>
        string AsString();
        
        /// <summary>
        /// Give variant on boolean value
        /// </summary>
        /// <returns>boolean value of the variant</returns>
        /// <exception cref="VariantException">If value cannot be converted</exception>
        bool AsBool();
        

        /// <summary>
        /// Give variant as integer value
        /// </summary>
        /// <returns>integer value of the variant</returns>
        /// <exception cref="VariantException">If value cannot be converted</exception>
        int AsInt();

        /// <summary>
        /// GIve variant as float-point format value
        /// </summary>
        /// <returns>floating-point value of variant</returns>
        /// <exception cref="VariantException">If value cannot be converted</exception>
        double AsDouble();

        /// <summary>
        /// Give variant as datetime value
        /// </summary>
        /// <returns>datetime value of the variant</returns>
        /// <exception cref="VariantException">If value cannot be converted</exception>
        DateTime AsDateTime();


        /// <summary>
        /// Clone the variant
        /// </summary>
        /// <returns>another variant object, with same value, same type</returns>
        IVariant Clone();
        /// <summary>
        /// Compares 2 variants
        /// </summary>
        /// <param name="other">the other variant</param>
        /// <returns>true if variants have same value inside (regardless of type)</returns>
        /// <pre>other may not be null</pre>        
        bool Equals(IVariant other);

        /// <summary>
        /// Tells if the variant can be converted in another type
        /// </summary>
        /// <param name="other">other type</param>
        /// <returns>true if value can be of this type</returns>
        bool CanBeConvertedInto(TypeVariant other);
    }
}
