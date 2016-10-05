using System;
using System.Management;
using System.ComponentModel;
using System.Configuration.Install;
using System.Management.Instrumentation;

[assembly:Instrumented(@"root\CIMV2")]
namespace InstrumentedApplication {
   [RunInstaller(true)]
   public class MyInstaller : DefaultManagementProjectInstaller {}

   [InstrumentationClass(InstrumentationType.Instance)]
   public class MyManagedElement {
      public string Description;
      public int    Count;
      public static void Main(string[] args) {
         MyManagedElement el = new MyManagedElement();
         el.Description = "SAMPLE INSTANCE";
         el.Count       = 256;
         Instrumentation.Publish(el);
         Console.ReadLine();
         Instrumentation.Revoke(el);
      }
   }
}
