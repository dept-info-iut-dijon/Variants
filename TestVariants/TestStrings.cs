using System.Runtime.Intrinsics;

namespace TestVariants
{
    public class TestStrings
    {
        [Fact]
        public void TestDouble()
        {
            var v1 = new Variant("16,35");
            Assert.Equal("16,35", v1.AsString());
            Assert.Throws<VariantException>(() => v1.AsInt());
            Assert.Equal(16.35, v1.AsDouble());
            Assert.True(v1.AsBool());
            Assert.Throws<VariantException>(() => v1.AsDateTime());
        }

        [Fact]
        public void TestString()
        {
            var v2 = new Variant("toto");
            Assert.Equal("toto", v2.AsString());
            Assert.Throws<VariantException>(() => v2.AsInt());
            Assert.Throws<VariantException>(() => v2.AsDouble());
            Assert.Throws<VariantException>(() => v2.AsDateTime());
            Assert.True(v2.AsBool());
            v2 = new Variant("false");
            Assert.False(v2.AsBool());
        }

        [Fact]
        public void TestInt()
        {
            var v = new Variant("0");
            Assert.Equal(0, v.AsInt());
            Assert.Equal("0", v.AsString());
            Assert.Equal(0.0, v.AsDouble());
            Assert.False(v.AsBool());
            Assert.Throws<VariantException>(() => v.AsDateTime());
        }

        [Fact]
        public void TestDate()
        {
            var v = new Variant("19/09/2022 14:20");
            Assert.Equal("19/09/2022 14:20", v.AsString());
            Assert.Throws<VariantException>(() => v.AsInt());
            Assert.Throws<VariantException>(() => v.AsDouble());
            Assert.Equal(new DateTime(2022,09,19,14,20,0), v.AsDateTime()); 
            Assert.True(v.AsBool());
        }

        [Fact]
        public void TestClone()
        {
            var v2 = new Variant("toto");
            var copy = v2.Clone();
            Assert.Equal("toto", copy.AsString());            
        }

        [Fact]
        public void TestCanBe()
        {
            var v = new Variant("toto");
            Assert.False(v.CanBeConvertedInto(TypeVariant.DateTime));
            Assert.False(v.CanBeConvertedInto(TypeVariant.Integer));
            Assert.True(v.CanBeConvertedInto(TypeVariant.String));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Boolean));
            Assert.False(v.CanBeConvertedInto(TypeVariant.Float));

            v = new Variant("15");
            Assert.True(v.CanBeConvertedInto(TypeVariant.Integer));

            v = new Variant("-32,5");
            Assert.True(v.CanBeConvertedInto(TypeVariant.Float));

            v = new Variant(DateTime.Now.ToString());
            Assert.True(v.CanBeConvertedInto(TypeVariant.DateTime));
        }
    }
}