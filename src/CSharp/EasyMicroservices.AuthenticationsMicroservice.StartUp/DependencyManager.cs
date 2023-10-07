using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.AuthenticationsMicroservice;
using EasyMicroservices.Configuration.Interfaces;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Database.Logics;
using EasyMicroservices.Cores.Database.Managers;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Mapper.CompileTimeMapper.Interfaces;
using EasyMicroservices.Mapper.CompileTimeMapper.Providers;
using EasyMicroservices.Mapper.Interfaces;
using EasyMicroservices.AuthenticationsMicroservice.Database.Contexts;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace EasyMicroservices.AuthenticationsMicroservice
{
    public class DependencyManager : IDependencyManager
    {
        public virtual IConfigProvider GetConfigProvider()
        {
            throw new NotImplementedException();
        }

        public virtual IContractLogic<TEntity, TCreateRequestContract, TUpdateRequestContract, TResponseContract, long> GetContractLogic<TEntity, TCreateRequestContract, TUpdateRequestContract, TResponseContract>()
            where TEntity : class, IIdSchema<long>
            where TResponseContract : class
        {
            return new LongIdMappedDatabaseLogicBase<TEntity, TCreateRequestContract, TUpdateRequestContract, TResponseContract>(GetDatabase().GetReadableOf<TEntity>(), GetDatabase().GetWritableOf<TEntity>(), GetMapper(), GetUniqueIdentityManager());
        }

        public virtual IDatabase GetDatabase()
        {
            var _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            return new EntityFrameworkCoreDatabaseProvider(new AuthenticationsContext(new DatabaseBuilder(_config)));
        }

        public static string DefaultUniqueIdentity { get; set; }
        public static long MicroserviceId { get; set; }
        public static IUniqueIdentityManager UniqueIdentityManager { get; set; }
        public virtual IUniqueIdentityManager GetUniqueIdentityManager()
        {
            if (UniqueIdentityManager == null)
                UniqueIdentityManager = new DefaultUniqueIdentityManager(DefaultUniqueIdentity, MicroserviceId);
            return UniqueIdentityManager;
        }

        public virtual IMapperProvider GetMapper()
        {
            var mapper = new CompileTimeMapperProvider(new EasyMicroservices.Mapper.SerializerMapper.Providers.SerializerMapperProvider(new EasyMicroservices.Serialization.Newtonsoft.Json.Providers.NewtonsoftJsonProvider()));
            foreach (var type in typeof(IDependencyManager).Assembly.GetTypes())
            {
                if (typeof(IMapper).IsAssignableFrom(type))
                {
                    var instance = Activator.CreateInstance(type, mapper);
                    var returnTypes = type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(x => x.ReturnType != typeof(object) && x.Name == "Map").Select(x => x.ReturnType).ToArray();
                    mapper.AddMapper(returnTypes[0], returnTypes[1], (IMapper)instance);
                }
            }
            return mapper;
        }
    }
}
