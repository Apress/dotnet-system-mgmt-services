class PrintClassDefinition {
   static void Main(string[] args) {
if (args.Length < 1) {
     Console.WriteLine("usage: ClassDef <path>");
	   return;
	}
      ManagementClass mc = new ManagementClass(args[0]);
// process class qualifiers
	foreach(QualifierData qd in mc.Qualifiers)
	   Console.WriteLine(FormatQualifier(qd,0));
	Console.WriteLine(@"class {0} : {1} {{",
	   mc["__CLASS"], mc["__SUPERCLASS"] );
	// process properties
	foreach(PropertyData pd in mc.Properties) 
	   Console.WriteLine(FormatProperty(pd,3) + ";");
	// process methods
	foreach(MethodData md in mc.Methods) 
	   Console.WriteLine(FormatMethod(md,3) + ";");
	Console.WriteLine("}");
   }
   static object FormatQualifier(QualifierData qd, int indent) {
	StringBuilder sb = new StringBuilder();
	sb.Append(' ', indent);
	sb.AppendFormat("[{0}={1}", qd.Name, FormatValue(qd.Value));
	if (qd.PropagatesToInstance) 
	   sb.Append(" ToInstance");
	if (qd.PropagatesToSubclass)
	   sb.Append(" ToSubclass");
	if (qd.IsAmended)
	   sb.Append(" Amended");
	if(qd.IsOverridable)
	   sb.Append(" Overridable");
	return sb.Append("]");
   }
   static object FormatProperty(PropertyData pd, int indent) {
	StringBuilder sb = new StringBuilder();
	// process property qualifiers
	foreach(QualifierData qd in pd.Qualifiers) {
	   sb.Append(FormatQualifier(qd,indent));
	   sb.Append(Environment.NewLine);
	}
      sb.Append(' ',indent);
	sb.AppendFormat("{0} {1}", 
	   pd.Type.ToString() + (pd.IsArray ? "[]" : string.Empty), pd.Name);
	if ( pd.Value != null )
	   sb.AppendFormat("={0}", FormatValue(pd.Value));
	return sb;
   }
	
   static object FormatMethod(MethodData md, int indent) {
      StringBuilder sb = new StringBuilder();
	// process method qualifiers
	foreach(QualifierData qd in md.Qualifiers) {
	   sb.Append(FormatQualifier(qd,3));
	   sb.Append(Environment.NewLine);
	}
	// eliminate duplicate in/out parameters
	SortedList sl = new SortedList();
	if (md.InParameters != null)
	   foreach(PropertyData pd in md.InParameters.Properties)
	      sl[pd.Qualifiers["ID"].Value] = pd;
	if (md.OutParameters != null) 
	   foreach(PropertyData pd in md.OutParameters.Properties)
	      if (pd.Name != "ReturnValue")
		   sl[pd.Qualifiers["ID"].Value] = pd;
	// format method return type and method name
	sb.Append(' ',indent);
	sb.AppendFormat("{0} {1}(", 
	   ((PropertyData)md.OutParameters.Properties["ReturnValue"]).Type, 
         md.Name); 
	if (sl.Count > 1 ) {
	   sb.Append(Environment.NewLine);
	   string[] arr = new string[sl.Count];
	   int i = 0;
	   foreach(PropertyData pd in sl.Values) 
            arr[i++] = FormatProperty(pd, indent+3).ToString();
	   sb.Append(string.Join(","+Environment.NewLine, arr));
	   sb.Append(Environment.NewLine);
	   sb.Append(' ',indent);
}
	return sb.Append(")");
   }
   static object FormatValue(object v) {
	if (v.GetType().IsArray) {
	   string[] arr = new string[((Array)v).GetUpperBound(0)+1];
	   Array.Copy((Array)v, arr, ((Array)v).GetUpperBound(0)+1);
	   return "{" + string.Join(",", arr) + "}";
	} else {
	   return v;
	}
   }
}
