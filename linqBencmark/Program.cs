using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace linqBencmark;

class Program {
    static void Main() {

        BenchmarkRunner.Run<ArrayBenchmark>();
    }
    
}

[MemoryDiagnoser]
[RankColumn]
public class ArrayBenchmark {

    public const int size = 1000;
    public int[] testedArray { get; set; }
    public Random valueSetter = new Random();

    
    public ArrayBenchmark() {
        testedArray = new int[size];
        
        for (int i = 0; i < size; i++) {
            testedArray[i] = valueSetter.Next(int.MaxValue);
        }
      
    }

    [Benchmark]
    public void testArrayByForeach() {
        int taked;
        foreach (var el in testedArray) {
            taked = el;
        }
    }

    [Benchmark]
    public void testArrayByFor() {
        int taked;
        for (int i = 0; i < size; i++) {
            taked = testedArray[i];
        }
    }

    [Benchmark]
    public void testArrayByWhile() {
        int taked;
        int i = 0;
        while (i < size) {
            taked = testedArray[i];
            i++;
        }
    }

    [Benchmark]
    public void takeFirstThreeElementOfArrayByTake() {
        IEnumerable<int> takenThree = testedArray.Take(3);
    }

    [Benchmark]
    public void takeFirstThreeElementOfArrayByIter() {
        var iter = testedArray.GetEnumerator();
        int i1 = (int)(iter.Current);
        iter.MoveNext();
        int i2 = (int)(iter.Current);
        iter.MoveNext();
        int i3 = (int)(iter.Current);
        iter.MoveNext();

    }

    [Benchmark]
    public void takeFirstThreeElementOfArraySelfMethod() {
        int taken1 = testedArray[0];
        int taken2 = testedArray[1];
        int taken3 = testedArray[2];
    }

    [Benchmark]
    public void takeLastThreeElementOfArrayByLast() {
        var last1 = testedArray.Last();
    }

}

[MemoryDiagnoser]
[RankColumn]
public class ListBenchmark {

    public List<int> testedList;
    public Random rng = new Random();
    public ListBenchmark()
    {
        testedList = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            testedList.Add(rng.Next(int.MaxValue));
        }
    }

    [Benchmark]
    public void testListByForeach() {
        int taken;
        foreach (var el in testedList)
        {
            taken = el;
        }

    }

    [Benchmark]
    public void testListByFor() {
        int taken;
        for (int i = 0; i < 1000; i++)
        {
            taken = testedList[i];
        }
    }

    [Benchmark]
    public void testListByWhile()
    {
        int taken;
        int i = 0;
        while (i < 1000)
        {
            taken = testedList[i];
        }

    }


}