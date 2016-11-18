using AppWithMenu.View;
using AppWithMenu.ViewModel;
using Xamarin.Forms;

namespace AppWithMenu.View
{
    public class MenuContentPage : ContentPage
    {
       
        private ColumnDefinition _sideBarColumn;

        public MenuContentPage()
        {
            ControlTemplate = (ControlTemplate)App.Current.Resources["MenuTemplate"];
        }

        protected override void OnAppearing()
        {
            var menuComponent = this.FindTemplateElementByName<Xamarin.Forms.View>("Menu");
            if (menuComponent == null)
                return;
            SetupMenu(menuComponent);
            var viewmodel = BindingContext as IMenuPageViewModel;
            menuComponent.BindingContext = viewmodel.Menu;
            base.OnAppearing();
        }

        private void SetupMenu(Xamarin.Forms.View menuComponent)
        {
            var menubtn = menuComponent.FindTemplateElementByName<Image>("MenuButton");
            _sideBarColumn = menuComponent.FindTemplateElementByName<ColumnDefinition>("SideBarColumn");

            menubtn.GestureRecognizers.Add(new TapGestureRecognizer(OnTap));
          
        }

        private void OnTap(Xamarin.Forms.View btn)
        {

            this.AbortAnimation("menuAnimation");
            Animation animation;
            if (_sideBarColumn.Width.Value > 0)
            {
                animation = new Animation(v => _sideBarColumn.Width = v, 200, 0);
            }
            else
            {
                animation = new Animation(v => _sideBarColumn.Width = v, 0, 200);
            }

            animation.Commit(this, "menuAnimation", easing: Easing.CubicInOut);
        }

    }
}