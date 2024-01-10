using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestVariants
{
    public class TestInts
    {
        [Fact]
        public void Test()
        {
            var v = new Variant(42);
            Assert.Equal(42,v.AsInt());
            Assert.Equal(42.0, v.AsDouble());
            Assert.Equal("42", v.AsString());
            Assert.True(v.AsBool());
            Assert.Equal(42, v.AsDateTime().Ticks);
            v = new Variant(0);
            Assert.False(v.AsBool());
            Assert.Equal(0, v.AsInt());
        }

        [Fact]
        public void TestClone()
        {
            var v = new Variant(-10);
            var copy = v.Clone();
            Assert.Equal(-10, copy.AsInt());
        }

        [Fact]
        public void TestCanBe()
        {
            var v = new Variant(34);
            Assert.True(v.CanBeConvertedInto(TypeVariant.DateTime));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Integer));
            Assert.True(v.CanBeConvertedInto(TypeVariant.String));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Boolean));
            Assert.True(v.CanBeConvertedInto(TypeVariant.Float));
        }
    }
}
