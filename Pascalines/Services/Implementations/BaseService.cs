using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pascalines.Model;

namespace Pascalines.Services
{
    public abstract class BaseService<TBaseModel> : IBaseService<TBaseModel>
            where TBaseModel : BaseModel
    {
        public BaseService()
        {
        }

        #region méthode abstraites

        public abstract TBaseModel Compute(TBaseModel calculatorModel);
        public abstract void Erase(TBaseModel calculatorModel);
        public abstract void Save(TBaseModel calculatorModel);
        public abstract void Load(TBaseModel calculatorModel);

        #endregion

    }
}
