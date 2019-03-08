namespace EstelApi.Core.Seedwork.Adapter.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyModel;

    /// <summary>
    /// The app domain.
    /// </summary>
    public class AppDomain
    {
        /// <summary>
        /// Initializes static members of the <see cref="AppDomain"/> class.
        /// </summary>
        static AppDomain()
        {
            CurrentDomain = new AppDomain();
        }

        /// <summary>
        /// Gets the current domain.
        /// </summary>
        public static AppDomain CurrentDomain { get; private set; }

        /// <summary>
        /// The get assemblies.
        /// </summary>
        /// <returns>
        /// The <see cref="Assembly"/>.
        /// </returns>
        public Assembly[] GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateCompilationLibrary(library))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }

            return assemblies.ToArray();
        }

        /// <summary>
        /// The is candidate compilation library.
        /// </summary>
        /// <param name="compilationLibrary">
        /// The compilation library.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
        {
            return compilationLibrary.Name == "EstelApi"
                   || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("EstelApi"));
        }
    }
}
