using System;
using System.Management;

class Monitor {
   bool bComplete = false;
   public void OnObjectReady(object sender, ObjectReadyEventArgs ea) {
      ManagementBaseObject mb = ea.NewObject;
      Console.WriteLine("Retrieved {0}", mb["__PATH"]);
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
      mc.GetInstances(ob);
      while(!m.IsComplete) {
         // do something while waiting
         System.Threading.Thread.Sleep(1000);
      }
   }
}
