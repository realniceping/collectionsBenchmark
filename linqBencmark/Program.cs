using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Runtime.InteropServices;
using System.Collections.Concurrent; 

namespace linqBencmark;

class Program {
    static void Main() {

        //Test();

        BenchmarkRunner.Run<CollectionsBenchmark>();
    }

    static void Test() {
        var cb = new CollectionsBenchmark();
        cb.testPasteInDictiontary();
        Console.WriteLine("past in dictionary correct");
        cb.testConcurentDictionary();
        Console.WriteLine("past in concurrent dictionary correct");
        cb.sortListByOrderBy();
        Console.WriteLine("list order by correct");
        cb.sortListBySort();
        Console.WriteLine("list sort correct");
        cb.testListByLinq();
        Console.WriteLine("take by linq correct");
    }

    
}

[MemoryDiagnoser]
[RankColumn]
public class CollectionsBenchmark {

    public const int size = 1000;
    public int[] testedArray { get; set; }
    public Random valueSetter = new Random();

    public List<int> testedList;
    public Random rng = new Random();

    public Dictionary<string, int> testedDictionary;
    public ConcurrentDictionary<string, int> testedConcurentDictionary;

    public CollectionsBenchmark() {
        
        testedArray = new int[size];
        for (int i = 0; i < size; i++) {
            testedArray[i] = valueSetter.Next(int.MaxValue);
        }

        testedList = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            testedList.Add(rng.Next(int.MaxValue));
        }

        testedDictionary = new Dictionary<string, int>();
        for (int i = 0; i < 1000; i++) {
            string key = string.Empty;
            for (int j = 0; j < 32; j++) {
                key = key + (char)(rng.Next(65, 90));
            }
            
            testedDictionary.Add(key, rng.Next(int.MaxValue));
        }

        testedConcurentDictionary = new ConcurrentDictionary<string, int>();
        for (int i = 0; i < 1000; i++)
        {
            string key = string.Empty;
            for (int j = 0; j < 32; j++)
            {
                key = key + (char)(rng.Next(65, 90));
            }

            testedConcurentDictionary.TryAdd(key, rng.Next(int.MaxValue));
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


    [Benchmark]
    public void testListByForeach()
    {
        int taken;
        foreach (var el in testedList)
        {
            taken = el;
        }

    }

    [Benchmark]
    public void testListByFor()
    {
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
            i++;
        }

    }

    [Benchmark]
    public void testListByLinq() {
        var bylist = from el in testedList select el;
    }

    [Benchmark]
    public void testListMarshallAsSpan() {
        int taken;
        var Span = CollectionsMarshal.AsSpan<int>(testedList);
        foreach(var s in Span)
        {
            taken = s;
        }

    }

    [Benchmark]
    public void testListAsReadOnly() {
        int taken;
        var roTestedList = testedList.AsReadOnly();
        foreach (var el in roTestedList) {
            taken = el;
        }
    }

    [Benchmark]
    public void sortListBySort() {
        /*int comparer(int x, int y){
            if (x == null) {
                if (y == null) {
                    return 0;
                }
                return -1;
            }
            if (y == null) {
                if (x == null) {
                    return 0;
                }
                return 1;
            }
            if (x < y) { return -1; }
            if (x > y) { return 1; }
            return 0;
        }*/
        var copy = new List<int>();
        foreach (var el in testedList) {
            copy.Add(el);
        }

        //copy.sort(comparer);
        copy.Sort();
        
    }

    [Benchmark]
    public void sortListByOrderBy()
    {
        var copy = new List<int>();
        foreach (var el in testedList)
        {
            copy.Add(el);
        }
        var sorted = copy.OrderBy(item => item);
    }

    [Benchmark]
    public void testPasteInDictiontary() {
        string key = string.Empty;
        for (int j = 0; j < 32; j++)
        {
            key = key + (char)(rng.Next(65, 90));
        }

        testedDictionary.Add(key, rng.Next(int.MaxValue));
    }

    [Benchmark]
    public void testConcurentDictionary() {
        string key = string.Empty;
        for (int j = 0; j < 32; j++)
        {
            key = key + (char)(rng.Next(65, 90));
        }

        testedConcurentDictionary.TryAdd(key, rng.Next(int.MaxValue));
        
    }




}
