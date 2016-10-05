using System;
using System.Management;

class ADAPStatus {
   public static void Main(string[] args) {
      ManagementObject mo = 
         new ManagementObject(@"\\.\root\DEFAULT:__ADAPStatus=@");
      Console.WriteLine("Status: {0}", mo["Status"]);
      Console.WriteLine("Last started: {0}", mo["LastStartTime"]);
      Console.WriteLine("Last stopped: {0}", mo["LastStopTime"]);
   }
}
