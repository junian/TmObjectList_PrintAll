using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAccessTm.CppSharpGen
{
    internal class SmartAccessTmLibrary : ILibrary
    {
        public void Postprocess(Driver driver, ASTContext ctx)
        {
            //throw new NotImplementedException();
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            //throw new NotImplementedException();
        }

        public void Setup(Driver driver)
        {
            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.CompileCode = true;
            options.GenerateFinalizers = true;


            var module = options.AddModule(nameof(SmartAccessTmLibrary).Replace("Library", ""));
            module.IncludeDirs.Add(@"C:\Smart_Access\SmartAccessTm_5_3_1\include");
            var list = new List<string>()
            {
                "ExternalTypes.h",
                "VersionedIface.h",

                "CommunicationServicesIface.h",

                "DeviceMonitorServiceIface.h",
                "Instruction.h",
                "InstructionBatch.h",
                "InstructionServiceIface.h",
                "OSALIface.h",
                "OSALTypes.h",
                "TimeSyncMasterIface.h",
                "TimeSyncServiceIface.h",
                "TimeSyncSlaveIface.h",
                "UpdateServiceIface.h",


            };
            foreach (var item in list)
            {
                module.Headers.Add(item);
            }

            module.LibraryDirs.Add(@"C:\Smart_Access\SmartAccessTm_5_3_1\lib-windows-x86_64-msvc_16");
            module.Libraries.Add("com_lib.lib");
            module.Libraries.Add("osal.lib");
            module.Libraries.Add("basev1.0.2_user_interface.lib");
            module.Libraries.Add("fallbackv1.1.1_user_interface.lib");
            module.Libraries.Add("smart_access.lib");
            //module.Libraries.Add("smart_access_binding.lib");
            module.Libraries.Add("tmv8.7.0_user_interface.lib");
            //module.Libraries.Add("tm_v8_7_0_binding.lib");
        }

        public void SetupPasses(Driver driver)
        {
            //throw new NotImplementedException();
        }
    }
}
