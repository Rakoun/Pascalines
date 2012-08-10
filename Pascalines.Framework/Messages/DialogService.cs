using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Pascalines.Framework
{
    public class DialogService : IDialogService
    {
        // inspiré de : http://tinyurl.com/9kyg48f
        async public Task<bool> AskConfirmation(string title, string message)
        {
            var messageDialog = new MessageDialog(message, title);

            // ajout des commandes et positionnement de leur id
            messageDialog.Commands.Add(new UICommand("OK",null, 0));
            messageDialog.Commands.Add(new UICommand("Cancel", null, 1));

            // définition de la commande par défaut
            messageDialog.DefaultCommandIndex = 1;

            // affiche la boite de dialogue et récupère l'évènement invoqué
            // par l'opérateur async
            IUICommand result = await messageDialog.ShowAsync();

            return (int)result.Id == 0;
            
        }

        async public void DisplayInformation(string title, string message)
        {
            var messageDialog = new MessageDialog(message, title);
            await messageDialog.ShowAsync();
        }
    }
}
