using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace APG.CodeHelper.DBTreeView
{
    /// <summary>
    /// Базовый класс команд DBTreeView
    /// </summary>
    public abstract class DBTreeNodeAction: APG.CodeHelper.Actions.UIAction
    {

        private DBTreeNodeObject treeNodeObject = null;
        
        /// <summary>
        /// 
        /// </summary>
        private DBTreeNodeAction() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeObj"></param>
        protected DBTreeNodeAction(DBTreeNodeObject nodeObj)
        {
            treeNodeObject = nodeObj;
        }

        /// <summary>
        /// 
        /// </summary>
        public DBTreeNodeObject NodeObject
        {
            get
            {
                return treeNodeObject;
            }
            set
            {
                treeNodeObject = value;
            }
        }

        public DBTreeView treeView
        {
            get
            {
                return this.NodeObject.treeView;    
            }
            
        }

        protected void HandleRemoveException(System.Exception e)
        {
            /*ISGB.Dialogs.ISGBExceptionDialog exceptionDialog;

            exceptionDialog = new ISGB.Dialogs.ISGBExceptionDialog(e);
            exceptionDialog.ExceptionMessage = "С удаляемым объектом связана информация,"+
                " которая будет потеряна в случае его удаления. Некоторые объекты нельзя удалять по принципиальным причинам, если их удаление нарушит технологический цикл. В первую очередь удалите все зависимые данные и повторите попытку удаления.";
            exceptionDialog.AboutMessage = "Удаление отменено";
            exceptionDialog.MessageIcon = MessageBoxIcon.Information;
            exceptionDialog.BtnRaport.Visible = true;
            exceptionDialog.Text = "Нарушение целостности";

            exceptionDialog.ShowDialog();
            */
        }
       

    }

}