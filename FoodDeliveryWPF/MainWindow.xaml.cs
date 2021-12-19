using System.Collections.ObjectModel;
using System.Windows;
using FoodDelivery.Domain;
using FoodDelivery.Persistence;
using Microsoft.Win32;

namespace FoodDeliveryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiDataProvider context;
        public MainWindow()
        {
            context = new ApiDataProvider();
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            context.DeleteItem((itemList.SelectedItem as FoodItem).Id);
        }

        private void Udpate_Click(object sender, RoutedEventArgs e)
        {
            FoodItem item = itemList.SelectedItem as FoodItem;
            id.Text = item.Id.ToString();
            name.Text = item.Name.ToString();
            description.Text = item.Description.ToString();
            price.Text = item.Price.ToString();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            itemList.ItemsSource = new ObservableCollection<FoodItem>(context.GetAll());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            FoodItemDTO item = new()
            {
                Dto = new FoodItemDTO.Data
                {
                    Id = int.Parse(id.Text),
                    Name = name.Text,
                    Description = description.Text,
                    Price = decimal.Parse(price.Text)
                }
            };

            if (id.Text != string.Empty)
            {
                context.EditItem(item);
            }
            else
            {
                context.AddItem(item);
            }
            ClearForm();
        }

        private void ClearForm()
        {
            id.Text = string.Empty;
            name.Text = string.Empty;
            description.Text = string.Empty;
            price.Text = string.Empty;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
            }
        }
    }
}

