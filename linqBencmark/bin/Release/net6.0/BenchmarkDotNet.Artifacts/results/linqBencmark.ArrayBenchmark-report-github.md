``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
AMD Ryzen 7 3700U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                                 Method |        Mean |     Error |     StdDev |      Median |   Gen0 | Allocated |
|--------------------------------------- |------------:|----------:|-----------:|------------:|-------:|----------:|
|                     testArrayByForeach | 272.2621 ns | 5.4833 ns |  9.0092 ns | 279.5787 ns |      - |         - |
|                         testArrayByFor | 277.1082 ns | 5.5457 ns | 11.3285 ns | 274.5274 ns |      - |         - |
|                       testArrayByWhile | 275.2497 ns | 5.5385 ns |  7.7642 ns | 278.0704 ns |      - |         - |
|     takeFirstThreeElementOfArrayByTake |  22.0985 ns | 0.4678 ns |  0.6857 ns |  22.4472 ns | 0.0229 |      48 B |
|     takeFirstThreeElementOfArrayByIter |          NA |        NA |         NA |          NA |      - |         - |
| takeFirstThreeElementOfArraySelfMethod |   0.0000 ns | 0.0000 ns |  0.0000 ns |   0.0000 ns |      - |         - |
|      takeLastThreeElementOfArrayByLast |  20.0409 ns | 0.4328 ns |  0.5777 ns |  20.3331 ns |      - |         - |

Benchmarks with issues:
  ArrayBenchmark.takeFirstThreeElementOfArrayByIter: DefaultJob
