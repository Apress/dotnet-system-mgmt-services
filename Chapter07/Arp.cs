using System;
using System.Management;

public class Arp {
public static void Main(string[] args) {
   ManagementClass mc = new ManagementClass(
      @"\\.\root\SNMP\SUN1:SNMP_RFC1213_MIB_ipNetToMediaTable");
   foreach(ManagementObject mo in mc.GetInstances()) {
      Console.WriteLine("{0} {1} {2} {3}",
         mo["ipNetToMediaIfIndex"], mo["ipNetToMediaNetAddress"],
         mo["ipNetToMediaPhysAddress"], mo["ipNetToMediaType"]);
   }
}
}
