using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVariants
{
    public class TestDoubles
    {
        [Fact]
        public void Test()
        {
            var v = new Variant(-3.14);
            Assert.Equal(-3.14, v.AsDouble());
            Assert.Throws<VariantException>(()=>v.AsInt());
            Assert.Equal("-3,14", v.AsString());
            Assert.True(v.AsBool());
            Assert.Throws<VariantException>(() => v.AsDateTime());
        }

        [Fact]
        public void TestCanBe()
        {
            var v = new Variant(4.35);
            Assert.False(v.CanBeConvertedInto(TypeVariant.DateTime));
            Assert.False(v.CanBeConvertedInto(TypeVariant.Integer));
            Assert.True(v.CanBeConvertedInto(TypeVariant.String));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Boolean));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Float));
            v = new Variant(4.0);
            Assert.True(v.CanBeConvertedInto(TypeVariant.Integer));
        }

        [Fact]
        public void TestClone()
        {
            Variant v = new Variant(4.35);
            var v2 = v.Clone();
            Assert.Equal(TypeVariant.Float, v2.Type);
            Assert.Equal(v.AsDouble(), v2.AsDouble());
        }

        [Fact]
        public void TestEquals()
        {
            Variant v = new Variant(4.35);
            Assert.True(v.Equals(new Variant(4.35)));
            Assert.True(v.Equals(new Variant("4,35")));
            Assert.False(v.Equals(new Variant(4.351)));
        }
    }
}
