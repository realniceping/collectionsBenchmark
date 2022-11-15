``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                                 Method |          Mean |       Error |      StdDev | Rank |   Gen0 |   Gen1 | Allocated |
|--------------------------------------- |--------------:|------------:|------------:|-----:|-------:|-------:|----------:|
|                     testArrayByForeach |   218.5447 ns |   0.1539 ns |   0.1364 ns |    6 |      - |      - |         - |
|                         testArrayByFor |   219.7654 ns |   0.8931 ns |   0.8354 ns |    6 |      - |      - |         - |
|                       testArrayByWhile |   220.4312 ns |   1.0626 ns |   0.9419 ns |    6 |      - |      - |         - |
|     takeFirstThreeElementOfArrayByTake |    12.5368 ns |   0.0327 ns |   0.0306 ns |    4 | 0.0029 |      - |      48 B |
|     takeFirstThreeElementOfArrayByIter |            NA |          NA |          NA |    ? |      - |      - |         - |
| takeFirstThreeElementOfArraySelfMethod |     0.0003 ns |   0.0003 ns |   0.0003 ns |    1 |      - |      - |         - |
|      takeLastThreeElementOfArrayByLast |    10.7827 ns |   0.0197 ns |   0.0175 ns |    3 |      - |      - |         - |
|                      testListByForeach |   651.7062 ns |   0.8490 ns |   0.7942 ns |    8 |      - |      - |         - |
|                          testListByFor |   434.3572 ns |   0.4224 ns |   0.3527 ns |    7 |      - |      - |         - |
|                        testListByWhile |   435.2781 ns |   0.3440 ns |   0.3218 ns |    7 |      - |      - |         - |
|                         testListByLinq |    14.3310 ns |   0.1357 ns |   0.1269 ns |    5 | 0.0043 |      - |      72 B |
|                 testListMarshallAsSpan |   219.4318 ns |   0.0573 ns |   0.0479 ns |    6 |      - |      - |         - |
|                     testListAsReadOnly | 4,312.4920 ns |  39.8140 ns |  37.2420 ns |   11 |      - |      - |      64 B |
|                         sortListBySort | 8,006.2965 ns | 111.7058 ns | 104.4897 ns |   12 | 0.5035 |      - |    8424 B |
|                      sortListByOrderBy |     6.0520 ns |   0.0503 ns |   0.0471 ns |    2 | 0.0033 |      - |      56 B |
|                 testPasteInDictiontary |   925.6849 ns |  18.1929 ns |  25.5040 ns |    9 | 0.1545 | 0.0381 |    2600 B |
|                testConcurentDictionary | 2,906.2528 ns |  97.7674 ns | 272.5364 ns |   10 | 0.1564 | 0.0381 |    2640 B |

Benchmarks with issues:
  CollectionsBenchmark.takeFirstThreeElementOfArrayByIter: DefaultJob
