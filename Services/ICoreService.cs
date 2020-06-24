using System.Collections.Generic;

namespace JungleApi.Web.Services
{
    public interface ICoreService<T> where T : class
    {
        void InsertCollection(IList<T> list, string sql, string parmeterName, string typeName);
    }
}
