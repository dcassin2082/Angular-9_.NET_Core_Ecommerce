using JungleApi.Web.DataAccess;
using JungleApi.Web.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace JungleApi.Web.Services
{
    public class CoreService<T> : ServicesBase, ICoreService<T> where T : class
    {
        private readonly IRepository<T> _repo;

        public CoreService()
        {
            _repo = _repo ?? (_repo = new Repository<T>(_dbContext));
        }

        public void InsertCollection(IList<T> list, string sql, string parmeterName, string typeName)
        {
            SqlParameter parm = new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = parmeterName,
                TypeName = typeName,
                Value = DataAccessMethods.ConvertToDataTable(list)
            };

            _dbContext.Database.ExecuteSqlInterpolated($"{sql} {parm}");
        }
    }
}
