using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVariants
{
    public class TestVariant
    {
        [Fact]
        public void TestCreateEmpty()
        {
            Variant v = new Variant();
            Assert.Equal(TypeVariant.Unknown, v.Type);            
        }

        [Fact]
        public void TestAsEmpty()
        {
            Variant v = new Variant();
            Assert.Throws<EmptyVariant>(() => v.AsBool());
            Assert.Throws<EmptyVariant>(() => v.AsDateTime());
            Assert.Throws<EmptyVariant>(() => v.AsDouble());
            Assert.Throws<EmptyVariant>(() => v.AsInt());
            Assert.Throws<EmptyVariant>(() => v.AsString());
        }

        [Fact]
        public void TestToString()
        {
            Variant v = new Variant("toto");
            Assert.Equal("toto", v.ToString());
            v = new Variant(15);
            Assert.Equal("15", v.ToString());
            v = new Variant(false);
            Assert.Equal("false", v.ToString());
            v = new Variant(4.2);
            Assert.Equal("4,2", v.ToString());
            v = new Variant(new DateTime(2020, 12, 31));
            Assert.Contains((new DateTime(2020, 12, 31)).ToShortDateString(), v.ToString());
        }

        [Fact]
        public void TestModify()
        {
            Variant v = new Variant("toto");
            v.Modify(15);
            Assert.Equal(15, v.AsInt());
            Assert.Equal(TypeVariant.Integer, v.Type);

            v.Modify(true);
            Assert.True(v.AsBool());
            Assert.Equal(TypeVariant.Boolean,v.Type);

            v.Modify(3.5);
            Assert.Equal(3.5, v.AsDouble(), 7);
            Assert.Equal(TypeVariant.Float,v.Type);

            v.Modify(new DateTime(2020, 12, 31));
            Assert.Equal(new DateTime(2020,12,31), v.AsDateTime());
            Assert.Equal(TypeVariant.DateTime, v.Type);

            v.Modify("encore");
            Assert.Equal("encore", v.AsString());
            Assert.Equal(TypeVariant.String, v.Type);
        }

        [Fact]
        public void TestConvert()
        {
            Variant v = new Variant();
            Assert.Throws<EmptyVariant>(() => v.Convert(TypeVariant.Boolean));
            
            v = new Variant("toto");                        
            Assert.Throws<VariantException>(() => v.Convert(TypeVariant.Integer));
            Assert.Throws<VariantException>(() => v.Convert(TypeVariant.DateTime));
            Assert.Throws<VariantException>(() => v.Convert(TypeVariant.Float));
            v.Convert(TypeVariant.String);
            Assert.Equal("toto", v.AsString());
            Assert.Equal(TypeVariant.String,v.Type);

            v = new Variant(15);
            v.Convert(TypeVariant.String);
            Assert.Equal(TypeVariant.String, v.Type);
            Assert.Equal(15, v.AsInt());
          
            v.Convert(TypeVariant.Integer);
            Assert.Equal(15, v.AsInt());
            
            v.Convert(TypeVariant.DateTime);
            Assert.Equal(new DateTime(15), v.AsDateTime());
            Assert.Equal(TypeVariant.DateTime, v.Type);

            v.Convert(TypeVariant.Float);
            Assert.Equal(TypeVariant.Float, v.Type);

            v = new Variant("true");
            v.Convert(TypeVariant.Boolean);
            Assert.Equal(TypeVariant.Boolean, v.Type);
            Assert.True(v.AsBool());
            v.Convert(TypeVariant.Integer);
            Assert.True(v.AsBool());
            Assert.Equal(1,v.AsInt());
            v.Convert(TypeVariant.Boolean);
            v.Convert(TypeVariant.String);
            Assert.Equal(TypeVariant.String, v.Type);
            Assert.Equal("true", v.AsString());

            Assert.Throws<VariantException>(() => v.Convert(TypeVariant.Unknown));
        }

        [Fact]
        public void TestCloneEmpty()
        {
            Variant v = new Variant();
            Assert.Throws<EmptyVariant>(() => v.Clone());
        }

        [Fact]
        public void TestEmptyCanBeConverted()
        {
            Variant v = new Variant();
            Assert.False(v.CanBeConvertedInto(TypeVariant.String));
        }

        [Fact]
        public void TestEmptyCanBeEquals()
        {
            Variant v = new Variant();
            Variant v2 = new Variant(3);
            Variant v3 = new Variant();
            Assert.True(v.Equals(v3));
            Assert.False(v2.Equals(v3));
        }
    }
}
