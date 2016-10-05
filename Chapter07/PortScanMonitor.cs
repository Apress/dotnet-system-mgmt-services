using System;
using System.Management;

class PortScanMonitor {
public static void Main(string[] args) {
   DateTime t0 = DateTime.UtcNow;
   DateTime t1;
   ManagementObject mo = new ManagementObject(
      @"\\.\root\SNMP\localhost:SNMP_RFC1213_MIB_tcp=@");
   float v0 = float.Parse(mo["tcpOutRsts"].ToString());
   float v1 = 0;
   while(true) {
      System.Threading.Thread.Sleep(10000);
      t1 = DateTime.UtcNow;
      mo = new ManagementObject(
         @"\\.\root\SNMP\localhost:SNMP_RFC1213_MIB_tcp=@");
      v1 = float.Parse(mo["tcpOutRsts"].ToString());
      if ( (v1-v0)/(t1-t0).Seconds > 2) {
         Console.WriteLine(
            "Incoming connections refused: possible port scanner attack");
      }
      v0 = v1;
      t0 = t1;
   }
}
}
