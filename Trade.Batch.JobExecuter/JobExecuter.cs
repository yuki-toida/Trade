using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using Trade.Core.Job;

namespace Trade.Batch.JobExecuter
{
    public class JobExecuter
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 1 || !args[0].Contains(','))
            {
                Console.WriteLine("[異常終了] [USAGE] <FullyQualifiedName>,<AssemblyName>");
                return;
            }

            var asmArray = args[0].Split(',');
            var type = asmArray[0];
            var asm = asmArray[1];
            var typeName = new Stack<string>(type.Split('.')).Pop();

            try
            {
                var job = LoadJob(type, asm);
                var argument = args.ToList();
                var result = job.Execute(argument.GetRange(1, argument.Count - 1).ToArray());

                Console.WriteLine(result == JobResultCode.Success
                    ? $"[正常終了] [{typeName}]"
                    : $"[異常終了] [{typeName}] {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[異常終了] [{ex.Message}]");
                throw;
            }
        }

        private static IJob LoadJob(string typeName, string assemblyName)
        {
            var assembly = GetReferencingAssembly(assemblyName);
            var t = assembly.GetType(typeName);
            return (IJob)Activator.CreateInstance(t);
        }

        private static Assembly GetReferencingAssembly(string assemblyName)
        {
            var targetLibrary = DependencyContext.Default.RuntimeLibraries.FirstOrDefault(x => x.Name == assemblyName);
            return targetLibrary == null
                ? null
                : Assembly.Load(new AssemblyName(targetLibrary.Name));
        }
    }
}
