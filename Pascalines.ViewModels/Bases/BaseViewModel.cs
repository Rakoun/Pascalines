﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascalines.ViewModels
{
    /// <summary>
    /// Classe de base pour tous les ViewModel
    /// </summary>
    public class BaseViewModel : BaseObserved
    {
        public BaseViewModel()
        {
            CommandsInitialization();
            ServicesInitialization();
        }


        protected virtual void ServicesInitialization() { }
        protected virtual void CommandsInitialization() { }


        public event EventHandler LocalCanExecuteChanged;


        /// <summary>
        /// Déclenche l'événément indiquant que les conditions
        /// d'éxecution des commandes doivent être réévaluées.
        /// </summary>
        protected void TriggereLocalCanExecuteChanged()
        {
            EventHandler handler = LocalCanExecuteChanged;
            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }


        public string ApplicationName
        {
            get { return "Pascalines"; }//TODO: à mettre en ressource
        }
    }
}
