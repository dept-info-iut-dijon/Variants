using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVariants
{
    public class TestBools
    {
        [Fact]
        public void TestTrue()
        {
            var v = new Variant(true);
            Assert.True(v.AsBool());
            Assert.Equal("true", v.AsString());
            Assert.Equal(1,v.AsInt());
            Assert.Equal(1.0,v.AsDouble());
            Assert.Throws<VariantException>(() => v.AsDateTime());            
        }
        [Fact]
        public void TestFalse()
        {
            var v = new Variant(false);
            Assert.False(v.AsBool());
            Assert.Equal("false", v.AsString());
            Assert.Equal(0, v.AsInt());
            Assert.Equal(0.0, v.AsDouble());
            Assert.Throws<VariantException>(() => v.AsDateTime());
        }

        [Fact]
        public void TestClone()
        {
            var v = new Variant(false);
            var copy = v.Clone();
            Assert.False(copy.AsBool());
        }

        [Fact]
        public void TestCanBe()
        {
            var v = new Variant(false);
            Assert.False(v.CanBeConvertedInto(TypeVariant.DateTime));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Integer));
            Assert.True(v.CanBeConvertedInto(TypeVariant.String));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Boolean));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Float));
        }
    }
}
