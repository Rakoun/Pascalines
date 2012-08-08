using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pascalines.Model;

namespace Pascalines.Services
{
    /// <summary>
    /// Interface de base pour les services.
    /// </summary>
    /// <typeparam name="TBaseModel"></typeparam>
    public interface IBaseService<TBaseModel>
            where TBaseModel : BaseModel
    {
        TBaseModel Compute(TBaseModel calculatorModel);
        void Erase(TBaseModel calculatorModel);
        void Save(TBaseModel calculatorModel);
        void Load(TBaseModel calculatorModel);
    }
}
