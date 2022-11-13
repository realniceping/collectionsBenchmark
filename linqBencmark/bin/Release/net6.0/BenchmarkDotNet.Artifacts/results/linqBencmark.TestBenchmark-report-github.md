``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
AMD Ryzen 7 3700U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
| Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|------- |----------:|----------:|----------:|----------:|-----:|----------:|
|    foo | 0.0654 ns | 0.0300 ns | 0.0785 ns | 0.0367 ns |    1 |         - |
