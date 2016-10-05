using System;
using System.Management;

class ProcessorMonitor {
public static void Main(string[] args) {
   ulong t0, t1, tb;
   float v0, v1;
   ManagementObject mo = 
      new ManagementObject("Win32_PerfRawData_PerfOS_Processor='0'");
   v0 = float.Parse(mo["InterruptsPersec"].ToString());
   t0 = ulong.Parse(mo["Timestamp_PerfTime"].ToString());
   tb = ulong.Parse(mo["Frequency_PerfTime"].ToString());
   while(true) {
      System.Threading.Thread.Sleep(5000);
      mo = new ManagementObject("Win32_PerfRawData_PerfOS_Processor='0'");
      v1 = float.Parse(mo["InterruptsPersec"].ToString());
      t1 = ulong.Parse(mo["Timestamp_PerfTime"].ToString());
      Console.WriteLine((v1-v0)/((t1-t0)/tb));
      v0 = v1;
      t0 = t1;
   }
}
}
