using System;
using System.Management;

class PrintWMISettings {

public static void Main(string[] args) {
   ManagementObject mo = new ManagementObject("Win32_WMISetting=@");
   foreach( PropertyData pd in mo.Properties ) {
      Console.WriteLine("{0} : {1}", pd.Name, pd.Value );
      }
   }
}
