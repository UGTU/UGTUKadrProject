using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Prikaz : UIX.Views.IDecorable, INull, UIX.Views.IValidatable,IComparable
    {
        public const int MaterialPrikaz = 18;
        
        public Prikaz(UIX.Commands.ICommandManager commandManager, PrikazType type)
            : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Prikaz, PrikazType>(this, "PrikazType", type, null), this);
        }

        public override string ToString()
        {
            return this.PrikazFullName;
        }

        public string PrikazFullName
        {
            get
            {
                return this.PrikazName + " от " + this.DatePrikaz.GetValueOrDefault().ToShortDateString();//GetValueOrDefault()
            }
        }

        #region partial Methods

        partial void OnCreated()
        {
            //DateBegin = DateTime.Today;
            //this.
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (PrikazType.IsNull()) throw new ArgumentNullException("Вид приказа.");
            }
            if (DateBegin != null)
                DateBegin = DateBegin.Value.Date;
        }
        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new PrikazDecorator(this);
        }

        #endregion        

        #region Члены IValidatable

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullPrikaz : Prikaz, INull
    {

        private NullPrikaz()
        {
            this.PrikazName = "(Не задан)";
            //this.PrikazLongName = "(Не задан)";
        }

        public static readonly NullPrikaz Instance = new NullPrikaz();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }
}
