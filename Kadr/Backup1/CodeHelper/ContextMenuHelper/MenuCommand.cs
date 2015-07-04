using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper.ContextMenuHelper
{
    public class MenuCommand
    {
        private object receiver;

        public object Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        private System.Reflection.MethodInfo method;

        public System.Reflection.MethodInfo Method
        {
            get { return method; }
            set { method = value; }
        }
        

        public void Execute(object sender, EventArgs e)
        {
            Method.Invoke(receiver, new object[] { sender });
        }

        public MenuCommand(object receiver, System.Reflection.MethodInfo method)
        {
            this.Receiver = receiver;
            this.Method = method;
        }

       

    }
}
