using System;
using System.Management;

public class LinkUpMonitor {
   public static void Main(string[] args) {
      ManagementBaseObject mo;
      ManagementEventWatcher ev = 
         new ManagementEventWatcher(@"\\.\root\SNMP\localhost",
            "SELECT * FROM SnmpLinkUpNotification");
      while(true) {
      mo = ev.WaitForNextEvent();
      foreach(PropertyData pd in mo.Properties) {
         Console.WriteLine("{0} {1}", pd.Name, pd.Value);
      }
   }
}
}
