using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascalines.Framework
{
    public interface IDialogService
    {
        Task<bool>  AskConfirmation(string title, string message);
        void DisplayInformation(string title, string message);
    }
}
