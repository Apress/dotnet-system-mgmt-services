using System;
using System.Diagnostics;

class CounterHelper {
   public static void Main(string[] args) {
      PerformanceCounterCategory cat = 
         new PerformanceCounterCategory("Processor");
      foreach(PerformanceCounter cntr in cat.GetCounters("0")) {
         Console.WriteLine("{0}: {1}", cntr.CounterName, cntr.CounterHelp);
      }
   }
}
