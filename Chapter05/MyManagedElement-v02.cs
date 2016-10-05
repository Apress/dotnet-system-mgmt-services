using System;
using System.Management;
using System.ComponentModel;
using System.Configuration.Install;
using System.Management.Instrumentation;

[assembly:Instrumented(@"root\CIMV2")]
namespace InstrumentedApplication {
   [RunInstaller(true)]
   public class MyInstaller : DefaultManagementProjectInstaller {}

public class MyManagedElement : Instance {
      public string Description;
      public int    Count;
      public static void Main(string[] args) {
         MyManagedElement el = new MyManagedElement();
         el.Description = "SAMPLE INSTANCE";
         el.Count       = 256;
         Instrumentation.Publish(el);
         Console.WriteLine( "Instance published (true/false): {0}", el.Published);
         Console.ReadLine();
         Instrumentation.Revoke(el);
         Console.WriteLine( "Instance published (true/false): {0}", el.Published);
      }
   }
}
