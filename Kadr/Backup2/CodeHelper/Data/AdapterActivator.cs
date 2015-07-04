using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace APG.Data
{
    public class AdapterActivator
    {
        public static T Activate<T>(ref T instance, System.Data.SqlClient.SqlConnection connection)
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
                if (instance != null)
                {
                    SetConnection<T>(instance, connection);
                    SetClearBeforeFill<T>(instance);                    
                }
            }
            return instance;
        }

        private static void SetConnection<T>(T instance, System.Data.SqlClient.SqlConnection connection)
        {
            PropertyInfo pi = instance.GetType().GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi != null)
            {
                pi.SetValue(instance, connection, null);
            }
        }

        private static void SetClearBeforeFill<T>(T instance)
        {
            PropertyInfo pi = instance.GetType().GetProperty("ClearBeforeFill");
            if (pi != null)
            {
                pi.SetValue(instance, true, null);
            }
        }
    }

}
