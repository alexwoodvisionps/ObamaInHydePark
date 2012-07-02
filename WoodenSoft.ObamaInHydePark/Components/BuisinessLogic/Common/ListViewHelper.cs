using System;
using System.Web.UI.WebControls;
using System.Reflection;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
    public static class ListViewHelper
    {
        public static object GetProperty(this object obj, string name)
        {
            return obj.GetType().InvokeMember(name, BindingFlags.GetProperty | BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public, Type.DefaultBinder, obj,
                                       null);
        }
       
    }
}