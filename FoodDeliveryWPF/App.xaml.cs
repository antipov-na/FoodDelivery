using System.Windows;
using FoodDelivery.Persistence;
using FoodDeliveryWPF.ViewModels;
using FoodDeliveryWPF.Views;

namespace FoodDeliveryWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ApiDataProvider context = new ApiDataProvider();
            MainView main = new()
            {
                DataContext = new MainViewModel(context)
            };
            main.Show();
        }
    }
}
