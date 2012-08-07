using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pascalines.Model
{
    public partial class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
        }

        //TODO: ajouter membres ou méthodes utilisables par les classes filles

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Déclenche l'évènement PropertyChanged pour une propriété
        /// donnée.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">L'expression permettant de retrouvler la
        /// propriété.</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;
            if (memberExpression != null)
            {
                string propertyName = memberExpression.Member.Name;
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}
