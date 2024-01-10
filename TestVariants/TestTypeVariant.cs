namespace TestVariants
{
    public class TestTypeVariant
    {
        [Fact]
        public void TestString()
        {
            Variant v = new Variant("toto");
            Assert.Equal(TypeVariant.String, v.Type);
        }

        [Fact]
        public void TestBoolean()
        {
            Variant v = new Variant(false);
            Assert.Equal(TypeVariant.Boolean, v.Type);
        }

        [Fact]
        public void TestInteger()
        {
            Variant v = new Variant(44);
            Assert.Equal(TypeVariant.Integer, v.Type);
        }

        [Fact]
        public void TestDouble()
        {
            Variant v = new Variant(-56.2);
            Assert.Equal(TypeVariant.Float, v.Type);
        }

        [Fact]
        public void TestDateTime()
        {
            Variant v= new Variant(DateTime.Now);
            Assert.Equal(TypeVariant.DateTime, v.Type);
        }
    }
}