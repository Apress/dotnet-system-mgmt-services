using System;
using System.Management;

class ProcessorMonitor {
public static void Main(string[] args) {
   DateTime t0 = DateTime.UtcNow;
   DateTime t1;
   ManagementObject mo = 
      new ManagementObject("Win32_PerfRawData_PerfOS_Processor='0'");
   float v0 = float.Parse(mo["InterruptsPersec"].ToString());
   float v1 = 0;
   while(true) {
      System.Threading.Thread.Sleep(10000);
      t1 = DateTime.UtcNow;
      mo = new ManagementObject("Win32_PerfRawData_PerfOS_Processor='0'");
      v1 = float.Parse(mo["InterruptsPersec"].ToString());
      Console.WriteLine((v1-v0)/(t1-t0).Seconds);
      v0 = v1;
      t0 = t1;
   }
}
}
