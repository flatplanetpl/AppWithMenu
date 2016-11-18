using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppWithMenu.View
{
    public static class ViewExtension
    {
        public static T FindTemplateElementByName<T>(this VisualElement page, string name) where T : BindableObject
        {
            var pc = page as IPageController;
            if (pc != null)
            {
                return GetFromPage<T>(pc,name);
            }

            var view = page as Xamarin.Forms.Layout<Xamarin.Forms.View>;
            return GetFromView<T>(view, name);

        }

        private static T GetFromView<T>(Layout<Xamarin.Forms.View> layout, string name) where T : BindableObject
        {
            foreach (var child in layout.Children)
            {
                var result = child.FindByName<T>(name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private static T GetFromPage<T>(IPageController pc, string name) where T : BindableObject
        {

            foreach (var child in pc.InternalChildren)
            {
                var result = child.FindByName<T>(name);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
