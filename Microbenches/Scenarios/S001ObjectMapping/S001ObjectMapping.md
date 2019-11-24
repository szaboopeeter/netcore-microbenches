## 1 - Mapping objects

We often get into the situation, where you need to do simple mapping of objects with the same, or similar shape, maybe dropping a few fields. Most developers find copying values of fields a tedious waste of time, and some of them come up with creative, yet suboptimal solutions.

One of my "favorite" solutions, which for some reason keeps popping up quite often is using a JSON serializer to serialize the source object, then deserialize it to the target. Using [Json.NET](https://www.newtonsoft.com/json) in the example he code is short and elegant, right:

```csharp
JsonConvert.DeserializeObject<Target>(JsonConvert.SerializeObject(source))
```

I chose a fairly small and simple model as benchmarking example, `Employee`, which can have a collection of nested `Employee`s as subordinates (in the benchmark, I used a simple level of nesting):

```csharp
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public int YearsOfService { get; set; }
    public List<Employee> Subordinates { get; set; }
}
```

So, let's see how the serialization-magic performs, and let's compare it with maybe the two most obvious solutions: manually copying the values, and using [AutoMapper](https://github.com/AutoMapper/AutoMapper).


|     Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|    Mapping |    108.1 ns |   2.19 ns |   2.25 ns |  1.00 |    0.00 | 0.0764 |     - |     - |     360 B |
| Automapper |    474.9 ns |   9.22 ns |   8.63 ns |  4.39 |    0.07 | 0.1187 |     - |     - |     560 B |
|       Json | 10,483.8 ns | 201.29 ns | 223.73 ns | 97.18 |    3.22 | 1.4038 |     - |     - |    6656 B |

``` ini
BenchmarkDotNet=v0.12.0, OS=macOS 10.15.1 (19B88) [Darwin 19.0.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
```
