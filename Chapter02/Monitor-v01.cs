using System;
using System.Management;

class Monitor {
   bool bComplete = false;
   bool bError = false;
   public void OnCompleted(object sender, CompletedEventArgs ea) {
      if ( ea.Status != ManagementStatus.NoError ) {
         bError = true;
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
   public bool IsError {
      get { return bError; }
   }
   public static void Main(string[] args) {
      Monitor m = new Monitor();
      ManagementOperationObserver ob = new ManagementOperationObserver();
      ob.Completed += new CompletedEventHandler(m.OnCompleted);
      ManagementObject mo = new ManagementObject("Win32_Process=316");
      mo.Get(ob);
      while(!m.IsComplete) {
         // do something while waiting
         System.Threading.Thread.Sleep(1000);
      }
      if(!m.IsError)
         Console.WriteLine("Retrieved {0}", mo["__PATH"]);
   }
}
