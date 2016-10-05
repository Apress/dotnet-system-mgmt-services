using System;
using System.Management;


class Monitor {
   bool bComplete = false;
   public void OnObjectPut(object sender, ObjectPutEventArgs ea) {
      Console.WriteLine("Updated {0}", ea.Path);
   }
   public void OnCompleted(object sender, CompletedEventArgs ea) {
      if ( ea.Status != ManagementStatus.NoError ) {
         Console.WriteLine(
            "Error occurred: {0}", ea.StatusObject["Description"]);
         Console.WriteLine("Provider: {0}", 
            ea.StatusObject["ProviderName"]);
         Console.WriteLine("Operation: {0}", 
            ea.StatusObject["Operation"]);
         Console.WriteLine("ParameterInfo: {0}", 
            ea.StatusObject["ParameterInfo"]);
      }
      bComplete = true;
   }
   public bool IsComplete {
      get { return bComplete; }
   }
   public static void Main(string[] args) {
      Monitor m = new Monitor();
      ManagementOperationObserver ob = new ManagementOperationObserver();
      ob.Completed += new CompletedEventHandler(m.OnCompleted);
      ob.ObjectPut += new ObjectPutEventHandler(m.OnObjectPut);
      ManagementObject mo = new ManagementObject("Win32_WMISetting=@");
      mo["BackupInterval"] = 120;
      mo.Put(ob);
      while(!m.IsComplete) {
         // do something while waiting
         System.Threading.Thread.Sleep(1000);
      }
   }
}
