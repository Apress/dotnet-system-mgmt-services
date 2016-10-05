using System;
using System.Management;

class CPUMonitor {
   public static void Main(string[] args) {
      while(true) {
         ManagementObject mo = new ManagementObject("PerfMon_Processor='0'");
         Console.WriteLine("% Processor Time: {0}", mo["ProcessorTime"]);
         Console.WriteLine("% User Time: {0}", mo["UserTime"]);
         Console.WriteLine("% Privileged Time: {0}", mo["PrivilegedTime"]);
         System.Threading.Thread.Sleep(5000);
      }
   }
}      
