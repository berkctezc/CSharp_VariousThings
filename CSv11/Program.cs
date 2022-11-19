// Raw string literals

var xmlPrologue = """<?xml version="1.0" encoding="UTF-8"?> """;

var jsonTxt = $$"""
        { 
                "name": "berkc",
                "id" : 1,
                "uuid":{{ Guid.NewGuid()}}   
        }
        """ ;

Console.WriteLine(xmlPrologue);
Console.WriteLine(jsonTxt);

// List patterns

var numbers = new[] {1, 2, 3};

Console.WriteLine(numbers is [1, 2, 3]);
Console.WriteLine(numbers is [0 or 1, <= 2, >= 3]);

if (numbers is [var a, .. var rest]) Console.WriteLine(a);

// UTF8 string literals
var str = "BerkcTezc"u8;

Console.ReadKey();