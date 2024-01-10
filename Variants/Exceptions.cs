using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    /// <summary>
    /// Generic exception of Variants library
    /// </summary>
    public class VariantException : Exception
    {
    }

    public class EmptyVariant : VariantException { }
    
}
