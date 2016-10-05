using System;
using System.Management;

public class LinkUpMonitor {
   public static void Main(string[] args) {
      ManagementBaseObject mo;
      ManagementEventWatcher ev = 
         new ManagementEventWatcher(@"\\.\root\SNMP\localhost",
            "SELECT * FROM SnmpLinkUpExtendedNotification");
      while(true) {
      mo = ev.WaitForNextEvent();

      ManagementBaseObject mo1 = (ManagementBaseObject)mo["ifIndex"];
      if ( mo1 != null )
         Console.WriteLine("ifIndex: {0}", mo1["ifIndex"]);
      mo1 = (ManagementBaseObject)mo["ifAdminStatus"];
      if (mo1 != null)
         Console.WriteLine("ifAdminStatus: {0}", mo1["ifAdminStatus"]);
      mo1 = (ManagementBaseObject)mo["ifOperStatus"];
      if (mo1 != null)
         Console.WriteLine("ifOperStatus: {0}", mo1["ifOperStatus"]);
      }
   }
}
