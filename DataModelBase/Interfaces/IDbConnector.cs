using DataModelBase.Definitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataModelBase.Interfaces
{
    public interface IDbConnector
    {
        Task<List<T>> GetData<T>(Dictionary<string, string> config) where T : IModel;

        Task<T> SaveData<T>(T item, Dictionary<string, string> config) where T : IModel;

        Task<bool> DeleteData(Dictionary<string, string> config);
    }
}
