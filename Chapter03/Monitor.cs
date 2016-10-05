using System;
using System.Management;

class Monitor {
   bool bComplete = false;
   public bool Completed {
      get { return bComplete; }
      set { bComplete = value; }
   }
   public void OnCompleted(object sender, CompletedEventArgs ea) {
      Completed = true;
   }
   public void OnObjectReady(object sender, ObjectReadyEventArgs ea) {
      Console.WriteLine(ea.NewObject["__PATH"]);
   }
   public static void Main(string[] args) {
      Monitor mo = new Monitor();
      ManagementOperationObserver ob = new ManagementOperationObserver();
      ob.Completed += new CompletedEventHandler(mo.OnCompleted);
      ob.ObjectReady += new ObjectReadyEventHandler(mo.OnObjectReady);
      ManagementObjectSearcher ms = new ManagementObjectSearcher(
         "SELECT * FROM Win32_Process");
      ms.Get(ob);
      while(!mo.Completed) {
         System.Threading.Thread.Sleep(1000);
      }
   }
}      
