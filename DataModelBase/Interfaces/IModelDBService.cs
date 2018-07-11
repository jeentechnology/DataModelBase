using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataModelBase.Interfaces
{
    public interface IModelDBService<T> where T : IModel
    {
        Task<List<T>> GetData();

        Task<T> GetDataById(string id);

        Task<T> SaveData(T model);

        Task<bool> DeleteData(string id);
    }
}
