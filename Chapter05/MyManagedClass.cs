using System.ComponentModel;
using System.Configuration.Install;
using System.Management.Instrumentation;

[assembly:Instrumented(@"root\CIMV2")]
namespace InstrumentedApplication {
   [RunInstaller(true)]
   public class MyInstaller : DefaultManagementProjectInstaller {};
   
   [InstrumentationClass(InstrumentationType.Instance)]
   public class MyManagedClass {
      public int    Prop1;
      public string Prop2;
      public static void Main(string[] args) {}
   }
}
