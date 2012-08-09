using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pascalines.Model.Tools;

namespace Pascalines.Services.Tools
{
    public class ConverterService : BaseService<ConverterModel>
    {
        #region méthodes surchargées de BaseService

        public override ConverterModel Compute(ConverterModel calculatorModel)
        {
            throw new NotImplementedException();
        }

        public override void Erase(ConverterModel calculatorModel)
        {
            throw new NotImplementedException();
        }

        public override void Save(ConverterModel calculatorModel)
        {
            throw new NotImplementedException();
        }

        public override void Load(ConverterModel calculatorModel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
