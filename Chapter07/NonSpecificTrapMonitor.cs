using System;
using System.Management;

public class NonSpecificTrapMonitor {
   public static void Main(string[] args) {
      ManagementBaseObject mo;
      ManagementEventWatcher ev = 
         new ManagementEventWatcher(@"\\.\root\SNMP\localhost",
            "SELECT * FROM SnmpV2Notification");
      while(true) {
      mo = ev.WaitForNextEvent();
      foreach(ManagementBaseObject o in (
         ManagementBaseObject[])mo["VarBindLIst"]) {
         Console.Write("{0} ({1}): 0x", 
            o["ObjectIdentifier"], o["Encoding"]);
         foreach(byte b in (byte[])o["Value"]) {
            Console.Write(b.ToString("X2"));
         }
         Console.WriteLine();
       }
   }
 }
}
