To compile and build the sample code:

1. To build using Visual Studio.NET:
   a) Create a new C# Project - Console Application
   b) Delete the default Class - Class1.cs
   c) Add the class file of interest - for instance, if you're trying 
      to build Arp.cs example from Chapter07, use File->Add Existing Item (Ctrl+Alt+A)
      to add the Arp.cs file to the Project
   d) Add references to the requered namespaces (Project->Add Reference) - typically,
      System.Management, System.Management.Instrumentation, System.Collections, etc. (see
      the "using" statements at the beginning of the code samples)
   e) Build the executable by chosing Build->Build Solution (Ctrl+Shft+8) from the menu

2. To build using the command line tools (C# Compiler):
   a) open command prompt (CMD.EXE) and issue the following command:
      CSC.EXE /r:System.Management.dll <name of the C# sample file>
  