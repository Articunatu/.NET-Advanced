using System;
using System.Collections.Generic;
using System.Text;

namespace CustomInterface
{
    public interface IDeckEntity<TEntity>
    {
        IList<TEntity> GetAll();
        TEntity Find(int id);

        void Add(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);
    }
}
