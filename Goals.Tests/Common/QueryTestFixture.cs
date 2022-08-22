using AutoMapper;
using System;
using Goals.Application.Interfaces;
using Goals.Application.Common.Mappings;
using Goals.Persistence;
using Xunit;

namespace Goals.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {

        public GoalsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = GoalsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IGoalsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            GoalsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> 
    {
    }

}
