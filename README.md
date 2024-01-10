# Variant Library

This project is a simple library with a Variant type. A Variant is a special kind of variable who can carry several types. This Variant can store a string, an integer, a floating-point value, a date/time value, a boolean value.
This is usefull for Data management.

## Quick Documentation
It's simple to create a variant and store a value inside : `Variant v = new Variant("toto");` for creating a variant who store a string, for example.

A variant can be read with several types. Conversion is automatic. If not possible, a VariantException is thrown. For exemple :
```
Variant v = new Variant("15");
int i = v.AsInt(); // contains 15
double x = v.AsDouble(); // contains 15.0

Variant v2 = new Variant(true);
string s= v2.AsString(); // contains "true"
int i = v2.AsInt(); // contains 1
```

It's possible to know what type is store in the Variant, with its `Type` property.

It's possible to know if a variant can be converted, for example :
```
Variant v = new Variant("13.5");
bool b = v.CanBeConvertedInto(TypeVariant.Integer) ;  // is false
b = v.CanBeConvertedInto(TypeVariant.Float);  // is true
```

A Variant can be converted (VariantException is thrown if not possible), for example :
```
Variant v = new Variant("13");
v.Convert(TypeVariant.Integer);
// now the variant contains an int, it's value is 13
```

## Technical specifications
C# language, .NET 6.0 framework. Project is a class library.

Can be used on Windows, Linux, MacOS (any platform .NET 6). Library can be used with a WPF project, an ASP.Net project, a MAUI project, any .NET 6 compatible app.
