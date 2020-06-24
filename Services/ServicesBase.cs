using JungleApi.Web.Models;
using System;

namespace JungleApi.Web.Services
{
    public abstract class ServicesBase : IDisposable, IServicesBase
    {
        protected JungleDbContext _dbContext;

        public ServicesBase()
        {

            _dbContext = new JungleDbContext();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
