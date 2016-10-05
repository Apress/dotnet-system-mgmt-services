using System;
using System.Management;

class TCPMonitor {
   public static void Main(string[] args) {
      ManagementClass mc = new ManagementClass("PerfMon_TCP");
      foreach(ManagementObject mo in mc.GetInstances()) {
         Console.WriteLine("Key: {0}", mo["KeyProp"]);
      }
   }
}
