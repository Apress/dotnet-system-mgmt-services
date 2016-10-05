using System;
using System.Management;

class Monitor {
   bool stopped = true;
   public bool IsStopped {
      get { return stopped; }
      set { stopped = value; }
   }
   public void OnEventArrived(object sender, EventArrivedEventArgs e) {
      ManagementBaseObject mo = e.NewEvent;
      Console.WriteLine("Event arrived: {0}", mo["__CLASS"]);
      mo = (ManagementBaseObject)mo["TargetInstance"];
      Console.WriteLine("Process handle: {0}. Executable path: {1}", 
         mo["Handle"], mo["ExecutablePath"]);
   }
   public void OnStopped(object sender, StoppedEventArgs e) {
      stopped = true;
   }
   public static void Main(string[] args) {
      Monitor mon = new Monitor();
      ManagementEventWatcher ew = new ManagementEventWatcher(
         @"SELECT * FROM __InstanceCreationEvent WITHIN 10 
           WHERE TargetInstance ISA 'Win32_Process'");
      ew.EventArrived += new EventArrivedEventHandler(mon.OnEventArrived);
      ew.Stopped += new StoppedEventHandler(mon.OnStopped);
      ew.Start();
      mon.IsStopped = false;
      while( true ) { 
         // do something useful..
         System.Threading.Thread.Sleep(10000); 
      }
   }
}  
