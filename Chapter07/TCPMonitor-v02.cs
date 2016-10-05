using System;
using System.Management;

class TCPMonitor {
   public static void Main(string[] args) {
      while(true) {
         ManagementObject mo = new ManagementObject("PerfMon_TCP=@");
         Console.WriteLine("Connections Established: {0}", 
            mo["ConnectionsEstablished"]);
         Console.WriteLine("Connections Active: {0}", mo["ConnectionsActive"]);
         Console.WriteLine("Connections Passive: {0}", mo["ConnectionsPassive"]);
         System.Threading.Thread.Sleep(5000);
      }
   }
}
