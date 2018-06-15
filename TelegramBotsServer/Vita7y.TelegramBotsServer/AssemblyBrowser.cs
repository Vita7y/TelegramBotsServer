using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vita7y.TelegramBotsServer
{
    public static class AssemblyBrowser
    {
        public static List<Type> GeTypeses()
        {
            var allTypes = new List<Type>();
            foreach (var dllTypes in GetAssembleTypesAndInterfaces(GetApplicationPathFiles()))
                allTypes.AddRange(dllTypes.Value);
            return allTypes;
        }

        public static T CreateObject<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
        public static object CreateObject(this Type type)
        {
            return Activator.CreateInstance(type);
        }

        static List<string> GetApplicationPathFiles()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            if (appPath == null)
                return null;
            if (!Directory.Exists(appPath))
                return null;

            return Directory.GetFiles(appPath, "*.dll")
                .Where(
                    am =>
                        !am.Contains("DevExpress.")
                        && !am.Contains("Microsoft.")
                        && !am.Contains("System.")).ToList();
        }

        static Type[] GetFileTypes(string file)
        {
            var asm = Assembly.LoadFrom(file);
            if ("System.Reflection.Emit.InternalAssemblyBuilder".Equals(asm.GetType().FullName))
                return null;

            return asm.GetTypes();
        }

        static IDictionary<string, Type[]> GetAssembleTypesAndInterfaces(IEnumerable<string> files)
        {
            var filesTypes = new Dictionary<string, Type[]>();
            foreach (var file in files)
            {
                var types = GetFileTypes(file);
                if (types != null)
                    filesTypes.Add(file, types);
            }
            return filesTypes;
        }
    }
}