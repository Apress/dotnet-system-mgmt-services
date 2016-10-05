using System;
using System.Management;
using System.ComponentModel;
using System.Configuration.Install;
using System.Management.Instrumentation;

[assembly:Instrumented(@"root\CIMV2")]
namespace InstrumentedApplication {
   [RunInstaller(true)]
   public class MyInstaller : DefaultManagementProjectInstaller {}

public class MyManagementEvent : BaseEvent {
      public string Description;
      public int    EventNo;
      public static void Main(string[] args) {
         MyManagementEvent ev = new MyManagementEvent();
         ev.Description       = "SAMPLE MANAGEMENT EVENT";
         ev.EventNo           = 256;
         ev.Fire();
         Console.ReadLine();
      }
   }
}
