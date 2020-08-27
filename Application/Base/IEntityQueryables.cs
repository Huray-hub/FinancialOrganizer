using Domain.Entities;
using System.Linq;

namespace Application.Base
{
    public interface IEntityQueryables<T> where T : IBaseEntity
    {
        IQueryable<T> IncludeNavigationProperties(IQueryable<T> query);
    }
}
