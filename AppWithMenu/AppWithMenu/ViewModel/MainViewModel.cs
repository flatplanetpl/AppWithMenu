using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace AppWithMenu.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IMenuPageViewModel
    {
        public string Title { get; set; } = "Hello from VM";
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Menu = new MenuViewModel();
            Menu.Items = new ObservableCollection<string>()
            {
                "Menu item 1",
                "Menu item 2",
                "Menu item 3",
                "Menu item 4",
            };
        }

        public MenuViewModel Menu { get; set; }
    }

    public interface IMenuPageViewModel
    {
        MenuViewModel Menu { get; set; }
    }

    public class MenuViewModel
    {
        public ObservableCollection<string> Items { get; set; }
    }
}