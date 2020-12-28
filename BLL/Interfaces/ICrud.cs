using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(string id);
        TModel Add(TModel model);
    }
}
