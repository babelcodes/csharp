# C# - the language

- [C# - the language](#c---the-language)
  - [Homepage](#homepage)
  - [Types](#types)
  - [Main method](#main-method)
  - [Typed](#typed)
  - [Arrays](#arrays)
  - [List (collection)](#list-collection)
  - [Class](#class)
  - [By ref / out](#by-ref--out)
  - [Garbage collector](#garbage-collector)
  - [Flow of execution](#flow-of-execution)
    - [Loops](#loops)
    - [Switch](#switch)
    - [Pattern Matching (.Net 7.0)](#pattern-matching-net-70)
  - [Command line output/input](#command-line-outputinput)
  - [Exceptions](#exceptions)
  - [OOP](#oop)
    - [Methods](#methods)
    - [Properties](#properties)
    - [readonly](#readonly)
    - [Inheritance](#inheritance)
    - [Abstract class](#abstract-class)
    - [Interface](#interface)
  - [Events](#events)
    - [Delegate](#delegate)
      - [Multi-cast delegates](#multi-cast-delegates)
  - [Event](#event)
  - [Latest](#latest)
    - [Non-nullable reference type](#non-nullable-reference-type)
  - [Effective Programming](#effective-programming)
  - [Generics](#generics)
  - [Asynchronous programming](#asynchronous-programming)
  - [LINQ](#linq)
  - [Functional Programming](#functional-programming)
  - [Design Patterns](#design-patterns)
  - [JetBrains' Rider](#jetbrains-rider)
  - [Facts](#facts)


## Homepage
- [.Net](../README.md)


## Types
- `struct`
- `class`
- `sealed class`


## Main method
Code:
```csharp
using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello " + args[0] + "!!");
            Console.WriteLine($"Hello {args[0]}!!");
        }
    }
}
```
Run:
```shell
$ cd MyProject
$ dotnet run -- Allen
$ dotnet run          ## ==> IndexOutOfRangeException
```


## Typed
```csharp
float x = 3.14; // OK, type given
var y = 8.43;   // OK, type dynamically discovered
var z;          // NOK: no way to discover the type of result => must initialize the value
```


## Arrays
```csharp
int size = 3;
double[] numbers0 = new double[size];
numbers0[0] = 11.1;
numbers0[1] = 22.2;
numbers0[2] = 33.3;
double[] numbers1 = new double[] { 11.1, 22.2, 33.3, 44.4 };  // No need of size
     var numbers2 = new double[] { 11.1, 22.2, 33.3, 44.4 }; // No need of type
     var numbers3 = new[] { 11.1, 22.2, 33.3, 44.4 };        // No need of type
```

Loop:
```csharp
var numbers3 = new[] { 11.1, 22.2, 33.3, 44.4 };
var result = 0.0;
foreach(var number in numbers) {
    result += number;
}
Console.WriteLine(result);
```


## List (collection)
```csharp
using System.Collections.Generic;

var numbers = new[] { 11.1, 22.2, 33.3, 44.4 };
List<double> grades = new List<double>() { 11.1, 22.2, 33.3, 44.4 };
grades.Add(55.5);
var result = 0.0;
foreach(var number in grades) {
    result += number;
}
result /= grades.Count;
Console.WriteLine($"The average grade is {result:N1}");
```






## Class

> As a Type, has some behaviours

```csharp
using System.Collections.Generic;

namespace GradeBook {
    class Book {
        public Book(string name) {
            grades = new List<double>();            
            this.name = name;
        }

        public void AddGrade(double grade) {
            grades.Add(grade); // this. is optional
        }

        List<double> grades;
    }
}
```



## By ref / out
- `out` is similar to `ref` but is assumes that the reference should be initialized

```csharp
        [Fact] // Attribute
        public void BookCalculatesAnAverageGrade() {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private GetBookSetName(ref Book book, string name) {
            book = new Book(name);
        }
```



## Garbage collector
.



## Flow of execution
- `if (a || b && c)  {} else {}`

### Loops

Foreach:
```csharp
foreach(var grade in grades) {
    result = Math.min(grade, result);
}
```

do-while:
```csharp
do {
    result = Math.min(grades[index], result);
    index += 1;
} while (index > grades.Count)
```

while:
```csharp
while (index > grades.Count) {
    result = Math.min(grades[index], result);
    index += 1;
}
```

for:
```csharp
for (var index = 0; index < grades.Count; index += 1) {
    result = Math.min(grades[index], result);
}
```

`continue` (exit step) vs `break` (exit for)

### Switch
```csharp
switch (letter) {
    case 'A':
        AddGrade(90);
        break;
        
    case 'B':
        AddGrade(80);
        break;
        
    default:
        AddGrade(0);
        break;
 }
```

### Pattern Matching (.Net 7.0)
```csharp
switch (result.Average) {
    case var d when d >= 90.0:
        result.letter = 'A';
        break;
        
    case var d when d >= 80:
        result.letter = 'B';
        break;
        
    default:
        result.letter = 'F';
        break;
}
```


## Command line output/input
```csharp
Console.WriteLine("Enter a grade or 'q' to quit:");
var input = Console.ReadLine();
var grade = double.Parse(input);
```


## Exceptions
- Custom vs built-iin

```csharp
try {
    throw new ArgumentException($"Invalid {nameof(grade)}!");
} catch (ArgumentException e) {
    Console.WrtieLine("Enter another value!");
} catch (Exception e) {
    Console.WrtieLine(e.Message);
    throw;
} finally {
    // ALWAYS HERE!
}
```



## OOP
- Encapsulation
- Inheritance
- Polymorphism
> Encapsulation + Inheritance => Polymorphism

### Methods
- Return type is not part of the signature of a method: so it is not take into consideration for overloading

### Properties
- To fine tune access to the field (eg the setter can be private).

```csharp
public string Name {
    get {
        return this.name;
    }
    set {
        if (!String.IsNullOrEmpty(value)) {
            name = value;
        }
    }
}

private string name;
```

Auto-Implemented Properties:
```csharp
public string Name { get: set; };
```

### readonly
- Can be set only on intializion or in the constructor.
```csharp
    class Book {
        public Book(string name) {
            this.name = name;
        }
        readonly string Name;
        const string CATEGORY = "Science";
    }

    // Used as: Book.CATEGORY
```

### Inheritance
```csharp
namespace Gradebook {

    class NamedObject/* : System.Object */ {
        public NamedObject(string name) {
            Name = name;
        }
        public string Name {
            get;
            set;
        }
    }

    class Book: NamedObject {                       // Inheritance
        public Book(string name): base(name) {      // Base contructor call
        }
    }
}

// NamedObject aBook = new Book("my title");        // Parent class as variable type
```

### Abstract class
- A class can be abtract
- And can have abstract method
- That required implementation with `override` keyword
```csharp
namespace Gradebook {

    class abstract BookBase: NamedObject {              // An abstract class
        public BookBase(string name): base(name) {
        }
        public abstract void AddGrade(double grade);    // With an abstract method
    }

    class Book: BookBase {
        public Book(string name): base(name) {
        }
        public override void AddGrade(double grade) {   // Required implementation of the abstract method
        }
    }
}

// BookBase aBook = new Book("my title");               // Abtract class as variable type
```

### Interface
- `override`
- `virtual`
```csharp
namespace Gradebook {

    public inteface IBook {
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }

    class abstract BookBase: NamedObject, IBook {       // Implement interface
        public BookBase(string name): base(name) {
        }

                                                        // So implement/abstract interface's methods:

        public abstract event GradeAddedDelegate GradeAdded;
        // public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics(); 
        // public virtual Statistics GetStatistics() {  // So implement interface's methods (virtual)
        //     throw new NotImplementedException();
        // }
    }

    class InMemoryBook: BookBase {
        List<double> grades;

        public Book(string name): base(name) {
            grades = new List<double>();            
        }

                                                        // So override the interface's methods:

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade) {
            grades.Add(grade);
        }

        public override Statistics GetStatistics() {
            throw new NotImplementedException();
        }
    }
    class DiskBook: BookBase {
        public Book(string name): base(name) {
        }

                                                        // So override the interface's methods:

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade) {
            using(var writer = File.AppendText($"{Name}.txt")) {
                writer.WriteLine(grade);

                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }

                // writer.Dispose();                    // ALWAYS CALL WITH USING KEYWORD
            }
        }

        public override Statistics GetStatistics() {
            var statistics = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt")) {
                var line = reader.ReasdLine();
                while (while != null) {
                    var number = double.Parse(line);
                    statistics.Add(number);
                    line = reader.ReadLine();
                }
            }
            return statistics;
        }
    }
}

// IBook aBook = new InMemoryBook("my title");                  // Interface as variable type
```



## Events
- Web, Mobile or desktop programming, because of every UI has events!

### Delegate
- It is a new type
- **The method name does not matter, only the types of return and parameters**
- A variable that can store a method that should conform to a *delegate* = _first class functions_ (functionnal programming)
- Can have multiple definitions

```csharp
    public delegate string WriteLogDelegate(string logMessage);  // (1) THE DELEGATE

    string ReturnMessage(string message) {                       // (2) AN IMPLEMENTATION
        return message;
    }

    WriteLogDelegate logger;                                     // (3) A VARIABLE
    logger = new WriteLogDelegate(ReturnMessage);                // (4) THE INSTANTIATION
    logger = ReturnMessage;                                      //      - SHORTCUT
    var result = logger("Hello!");                               // (5) THE CALL
```

#### Multi-cast delegates
```csharp
    public delegate string WriteLogDelegate(string logMessage);
    int count = 0;

    string ReturnMessage(string message) {
        return message;
    }
    string IncrementCount(string message) {
        count++;
        return message.ToLower();
    }

    WriteLogDelegate logger = ReturnMessage;
    logger += ReturnMessage;
    logger += IncrementCount;
    var result = logger("Hello!");
    Assert.Equal(3, count);
```

## Event
- An Event field can not be re-assigned/reset, only + or -
```csharp
namespace GradeBook {
    public delegate void GradeAddedDelegate(object sender, EventArfs args); // DEFINE TYPE

    class Book {
        public event GradeAddedDelegate GradeAdded;                         // DEFINE AN EVENT

        public void AddGrade(double grade) {
            grades.Add(grade); // this. is optional
            if (GraddeAdded != null) {
                GraddeAdded(this, new EventArgs());                         // HANDLE
            }
        }
    }

    // ...
    static void Main(string[] args) {
        var book = new Book("B");
        book.GradeAdded += OnGradeAdded; // Only + or - because an event, vs. a delegate
        book.GradeAdded += OnGradeAdded;
        book.GradeAdded -= OnGradeAdded; // REMOVED
        book.GradeAdded += OnGradeAdded;
    }

    static void OnGradeAdded(object sender, EventArgs e) {
        Console.WriteLine("A grade was added!");
    }
}
```


## Latest

### Non-nullable reference type
```xml
<!-- GradeBook.csproj -->
<Project>
    <PropertyGroup>
        <LangVersion>8.0</LangVersion>
        <NullableContextOptions>enable</NullableContextOptions>
    </PropertyGroup>
</Project>
```
```csharp
IBook? book1 = null;
IBook? book2 = new InMemoryBook("my title");
```

## Effective Programming
- https://app.pluralsight.com/paths/skills/c-development-best-practices
- https://app.pluralsight.com/library/courses/csharp-fundamentals-2/table-of-contents
- https://app.pluralsight.com/library/courses/clean-architecture-patterns-practices-principles/table-of-contents


## Generics
- https://app.pluralsight.com/library/courses/csharp-generics/table-of-contents
- https://app.pluralsight.com/library/courses/c-sharp-generics/table-of-contents
- https://app.pluralsight.com/library/courses/c-sharp-10-collections-generics/table-of-contents


## Asynchronous programming
- https://app.pluralsight.com/library/courses/skeet-async/table-of-contents
- https://app.pluralsight.com/library/courses/c-sharp-10-asynchronous-programming/table-of-contents


## LINQ
> Language Integrated Query
- https://app.pluralsight.com/library/courses/linq-fundamentals-csharp-6/table-of-contents


## Functional Programming
- https://app.pluralsight.com/library/courses/functional-programming-csharp/table-of-contents


## Design Patterns
- https://app.pluralsight.com/library/courses/c-sharp-10-design-patterns/table-of-contents


## JetBrains' Rider
- https://app.pluralsight.com/library/courses/csharp-jetbrains-rider-cross-platform-programming/table-of-contents


## Facts
- Conventions
    - Name of public members start with an uppercase
    - One type per file
- `object` is the root class of any object in .Net
- `Object.referenceEquals()`
- Interface name starts with a `I` (eg `IDisposable`)
