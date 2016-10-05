using System;
using System.Management;

class Monitor {
   bool bComplete = false;
   public void OnObjectReady(object sender, ObjectReadyEventArgs ea) {
      ManagementBaseObject mb = ea.NewObject;
      foreach(PropertyData pd in mb.Properties) {
         Console.WriteLine("{0} {1}", pd.Name, pd.Value);
      }
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
      ob.ObjectReady += new ObjectReadyEventHandler(m.OnObjectReady);
      ManagementClass mc = new ManagementClass("Win32_Process");
      ManagementBaseObject parms = mc.GetMethodParameters("Create");
      parms["CommandLine"] = @"c:\winnt\system32\notepad.exe c:\boot.ini";
      parms["CurrentDirectory"] = ".";
      mc.InvokeMethod(ob, "Create", parms, null);
      while(!m.IsComplete) {
         // do something while waiting
         System.Threading.Thread.Sleep(1000);
      }
   }
}
