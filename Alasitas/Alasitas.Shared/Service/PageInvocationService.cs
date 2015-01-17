using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Alasitas.Service
{
    public class PageInvocationService
    {
        readonly static string Default_View_Namespace;

        static PageInvocationService()
        {
            var nameSpace = typeof(PageInvocationService).Namespace;
            Default_View_Namespace = nameSpace.Remove(nameSpace.LastIndexOf(".") + 1) + "View.";
        }

        public static void Navigate(string pageName, object parameter = null)
        {
            var rootFrama = Window.Current.Content as Frame;
            if (!rootFrama.Navigate(Type.GetType(Default_View_Namespace + pageName), parameter))
            {
                throw new Exception("Failed to call page");
            }
        }
    }
}
