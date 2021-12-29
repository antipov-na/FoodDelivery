using Domain.Entities;
using Domain.Identity;
using FoodDelivery.Persistence;
using FoodDeliveryWPF.Model;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace FoodDeliveryWPF.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private int id { get; set; } = -1;
        private string name;
        private string description;
        private string price;
        private ObservableCollection<FoodItem> foodList;
        private FoodItem selectedItem;
        private IDataProvider _context;
        private string pathToImage;

        public FormFile Image { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("description");
            }
        }
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("price");
            }
        }

        public MainViewModel(IDataProvider context)
        {
            _context = context;
        }

        public ObservableCollection<FoodItem> Foodlist
        {
            get => foodList;
            set
            {
                foodList = value;
                OnPropertyChanged("foodList");
            }
        }
        public FoodItem SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("selectedItem");
            }
        }
        public string PathToImage
        {
            get => pathToImage;
            set
            {
                pathToImage = value;
                OnPropertyChanged("pathToImage");
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand => editCommand ??= new RelayCommand(obj =>
        {
            id = selectedItem.Id;
            Name = selectedItem.Name;
            Description = selectedItem.Description;
            Price = selectedItem.Price.ToString();
        });

        private RelayCommand refreshListCommand;
        public RelayCommand RefreshListCommand => refreshListCommand ??= new RelayCommand(obj =>
        {
            Foodlist = new ObservableCollection<FoodItem>(_context.GetAll());
        });

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand => cancelCommand ??= new RelayCommand(obj =>
        {
            Clear();
        });

        private RelayCommand confirmCommand;
        public RelayCommand ConfirmCommand => confirmCommand ??= new RelayCommand(obj =>
        {
            FileStream stream = new FileStream(path: PathToImage, FileMode.Open);
            FormFile formFile = new FormFile(stream, 0, stream.Length, stream.Name, stream.Name);
            FoodItemDTO item = new()
            {
                Dto = new FoodItemDTO.Data
                {
                    Id = id,
                    Name = Name,
                    Description = Description,
                    Price = decimal.Parse(Price)
                },
                Image = formFile
            };
            if (id != -1)
            {
                _context.EditItem(item);
            }
            else
            {
                _context.AddItem(item);
            }
            Clear();
        });

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand => deleteCommand ??= new RelayCommand(obj =>
        {
            _context.DeleteItem(selectedItem.Id);
        });

        private RelayCommand selectImageCommand;
        public RelayCommand SelectImageCommand => selectImageCommand ??= new RelayCommand(obj =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                PathToImage = openFileDialog.FileName;
            }
        });


        private void Clear()
        {
            Name = "";
            Description = "";
            Price = "";
            id = -1;
        }
    }
}