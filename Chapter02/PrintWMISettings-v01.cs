using System;
using System.Management;

class PrintWMISettings {

public static void Main(string[] args) {
   ManagementObject mo = new ManagementObject("Win32_WMISetting=@");
   Console.WriteLine("ASPScriptDefaultNamespace : {0}", 
      mo["ASPScriptDefaultNamespace"]);
   Console.WriteLine("ASPScriptEnabled : {0}", mo["ASPScriptEnabled"]);
   Console.WriteLine("AutorecoverMofs : {0}", mo["AutorecoverMofs"]);
   Console.WriteLine("AutoStartWin9X : {0}", mo["AutoStartWin9X"]);
   Console.WriteLine("BackupInterval : {0}", mo["BackupInterval"]);
   Console.WriteLine("BackupLastTime : {0}", mo["BackupLastTime"]);
   Console.WriteLine("BuildVersion : {0}", mo["BuildVersion"]);
   Console.WriteLine("Caption : {0}", mo["Caption"]);
   Console.WriteLine("DatabaseDirectory : {0}", mo["DatabaseDirectory"]);
   Console.WriteLine("DatabaseMaxSize : {0}", mo["DatabaseMaxSize"]);
   Console.WriteLine("Description : {0}", mo["Description"]);
   Console.WriteLine("EnableAnonWin9xConnections : {0}",
      mo["EnableAnonWin9xConnections"]);
   Console.WriteLine("EnableEvents : {0}", mo["EnableEvents"]);
   Console.WriteLine("EnableStartupHeapPreallocation : {0}", 
      mo["EnableStartupHeapPreallocation"]);
   Console.WriteLine("HighThresholdOnClientObjects : {0}",
      mo["HighThresholdOnClientObjects"]);
   Console.WriteLine("HighThresholdOnEvents : {0}", 
      mo["HighThresholdOnEvents"]);
   Console.WriteLine("InstallationDirectory : {0}", 
      mo["InstallationDirectory"]);
   Console.WriteLine("LastStartupHeapPreallocation : {0}", 
      mo["LastStartupHeapPreallocation"]);
   Console.WriteLine("LoggingDirectory : {0}", mo["LoggingDirectory"]);
   Console.WriteLine("LoggingLevel : {0}", mo["LoggingLevel"]);
   Console.WriteLine("LowThresholdOnClientObjects : {0}", 
      mo["LowThresholdOnClientObjects"]);
   Console.WriteLine("LowThresholdOnEvents : {0}", 
      mo["LowThresholdOnEvents"]);
   Console.WriteLine("MaxLogFileSize : {0}", mo["MaxLogFileSize"]);
   Console.WriteLine("MaxWaitOnClientObjects : {0}", 
      mo["MaxWaitOnClientObjects"]);
   Console.WriteLine("MaxWaitOnEvents : {0}", mo["MaxWaitOnEvents"]);
   Console.WriteLine("MofSelfInstallDirectory : {0}",
      mo["MofSelfInstallDirectory"]);
   Console.WriteLine("SettingID : {0}", mo["SettingID"]);	
   }
}
