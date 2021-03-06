﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class EducDocument : INullable, IComparable
    {

        public EducDocument(UIX.Commands.ICommandManager commandManager, EducDocumentType type):this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, EducDocumentType>(this, "EducDocumentType", type, null), this);
        }

        public override string ToString()
        {
            if (DocDate != null)
                return this.DocSeries + " № " + DocNumber + " от " + Convert.ToDateTime(DocDate).ToShortDateString();
            else
                return this.DocSeries + " № " + DocNumber;
        }




        #region partial Methods

        partial void OnCreated()
        {
            //this.DocDate = DateTime.Today;
        }
        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return (this.ToString().CompareTo((obj as EducDocument).ToString()));
        }

        #endregion
    }


    public class NullEducDocument : EducDocument, INull
    {

        private NullEducDocument()
        {
            this.id = 0;
        }

        public static readonly NullEducDocument Instance = new NullEducDocument();



        public override string ToString()
        {
            return "(Не задан)";
        }

    }

}
