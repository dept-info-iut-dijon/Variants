using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestVariants
{
    public class TestEquals
    {
        [Fact]
        public void TestInt()
        {
            var v = new Variant(15);
            Assert.True(v.Equals(new Variant("15")));
            Assert.True(v.Equals(new Variant(15.0)));
            Assert.False(v.Equals(new Variant(10)));
            Assert.False(v.Equals(new Variant("10")));
        }

        [Fact]
        public void TestBool()
        {
            var v = new Variant(false);
            Assert.True(v.Equals(new Variant("false")));
            Assert.True(v.Equals(new Variant(0)));
            Assert.False(v.Equals(new Variant("faux")));
        }
        [Fact]
        public void TestString()
        {
            var v = new Variant("test");
            Assert.True(v.Equals(new Variant("test")));
            Assert.False(v.Equals(new Variant(true)));
            Assert.False(v.Equals(new Variant(0)));
        }

        [Fact]
        public void TestDate()
        {
            var v = new Variant("20/10/2023 11:50:00");
            Assert.True(v.Equals(new Variant("20/10/2023 11:50:00")));
            Assert.True(v.Equals(new Variant(new DateTime(2023, 10, 20, 11, 50, 0))));
            Assert.False(v.Equals(new Variant("20/10/2023 11:51")));
        }
    }
}
