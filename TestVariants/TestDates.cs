using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVariants
{
    public class TestDates
    {
        [Fact]
        public void TestCreate()
        {
            var v = new Variant(new DateTime(2023,6,20));
            Assert.Equal(v.AsDateTime(), new DateTime(2023, 6, 20));
            Assert.True(v.AsBool());
            Assert.Contains("20/06/2023", v.AsString());
            v = new Variant(new DateTime(26500));
            Assert.Equal(26500,v.AsInt());
            Assert.Equal(26500.0, v.AsDouble());
        }

        [Fact]
        public void TestCanBe()
        {
            var v = new Variant(new DateTime(2023, 6, 20));
            Assert.True(v.CanBeConvertedInto(TypeVariant.DateTime));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Integer));
            Assert.True(v.CanBeConvertedInto(TypeVariant.String));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Boolean));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Float));
        }

        [Fact]
        public void TestClone()
        {
            var v = new Variant(new DateTime(2023, 6, 20));
            var v2 = v.Clone();
            Assert.Equal(TypeVariant.DateTime, v2.Type);
            Assert.Equal(v.AsDateTime(), v2.AsDateTime());
        }

        [Fact]
        public void TestEquals()
        {
            var v = new Variant(new DateTime(2023, 6, 20));
            var v2 = new Variant(new DateTime(2023, 6, 20));
            Assert.True(v.Equals(v2));
            v = new Variant(new DateTime(1350));
            v2 = new Variant(1350);
            Assert.True(v.Equals(v2));
            v2 = new Variant(new DateTime(1351));
            Assert.False(v.Equals(v2));
        }
    }
}
