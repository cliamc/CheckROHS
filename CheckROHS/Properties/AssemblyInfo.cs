﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("CheckROHS")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CheckROHS")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("21f8af54-5489-4842-bc5f-1385ea8d2f8c")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0.0.3")]
//[assembly: AssemblyVersion("1.0.0.3")]
//[assembly: AssemblyVersion("1.0.0.4")]                          // Use Epicor table FlattenedBOM to check if a part is a sub or not; 11/3/2021
[assembly: AssemblyVersion("1.0.0.5")]                          // For RMA items, include InActive status entries
//[assembly: AssemblyVersion("1.0.0.5")]                          // Upgrade Epicor 9.05 to Kinetic 11.1
