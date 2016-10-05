using System;
using System.Management;
using System.Text;

class PrintWMISettings {

public static void Main(string[] args) {
   ManagementObject mo = new ManagementObject("Win32_WMISetting=@");
   foreach( PropertyData pd in mo.Properties ) {
      Console.WriteLine("{0} : {1}", pd.Name, Format(pd) );
      }
   }
public static object Format(PropertyData pd) {
   if (pd.IsArray) {
      Array pa = (Array)pd.Value;
      StringBuilder sb = new StringBuilder();
      sb.Append(Environment.NewLine);
      for(int i=pa.GetLowerBound(0); i<pa.GetUpperBound(0); i++) {
         sb.Append(pa.GetValue(i));
         sb. Append(Environment.NewLine);
         }
         return sb;
      } else {
         return pd.Value;
      }
   }
}
