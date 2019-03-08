namespace EstelApi.Core.Seedwork.Adapter.Implementation
{
    using System;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    /// <summary>
    /// The auto mapper type adapter factory.
    /// </summary>
    public class AutoMapperTypeAdapterFactory
        : ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperTypeAdapterFactory"/> class. 
        /// <see cref="Create"/> a new AutoMapper type adapter factory
        /// </summary>
        public AutoMapperTypeAdapterFactory()
        {
            // scan all assemblies finding AutoMapper Profile
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.GetName().FullName.Contains("EstelApi"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetTypeInfo().BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2"
                        && item.FullName != "AutoMapper.MapperConfiguration+NamedProfile")
                    {
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                    }
                }
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        /// <inheritdoc />
        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter();
        }

        #endregion
    }
}