using System;
using Goals.Persistence;

namespace Goals.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {

        protected readonly GoalsDbContext Context;

        public TestCommandBase()
        {
            Context = GoalsContextFactory.Create();
        }

        public void Dispose()
        {
            GoalsContextFactory.Destroy(Context);
        }
    }
}
