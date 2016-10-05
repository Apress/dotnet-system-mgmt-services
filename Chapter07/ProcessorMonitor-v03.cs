using System;
using System.Management;

class ProcessorMonitor {
public static void Main(string[] args) {
   while(true) {
      System.Threading.Thread.Sleep(5000);
      mo = new ManagementObject("Win32_PerfFormattedData_PerfOS_Processor='0'");
      Console.WriteLine(mo["InterruptsPersec"]);
   }
}
}
