using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Models;
using System.Collections.ObjectModel;
using CKK.DB.UOW;
using CKK.DB.Interfaces;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InventoryManager : Window
    {
        private IConnectionFactory conn;
        private UnitOfWork uow;
        public ObservableCollection<Product> _Items { get; private set; }

        public InventoryManager()
        {
            conn = new DatabaseConnectionFactory();
            uow = new UnitOfWork(conn);
            InitializeComponent();
            _Items = new ObservableCollection<Product>();
            lbInventoryList.ItemsSource = _Items;
            RefreshListAsync();
        }


        private async void RefreshListAsync() //Delete and Reload all Products in DB
        {
            _Items.Clear();

            foreach (Product p in new ObservableCollection<Product>(await Task.Run(() => uow.Products.GetAllAsync().Result)))
            {
                _Items.Add(p);
            };
        }

        private void addButton_Click(object sender, RoutedEventArgs e) //Opens Add Item window
        {
            lbInventoryList.ItemsSource = _Items; // Added incase sorting methods were used, resets the listbox binding to an unsorted list

            InventoryManager inventory = this;
            AddItem add = new AddItem(inventory);

            add.Show();;
        }

        public void addItem(Product prod)
        {
            uow.Products.AddAsync(prod); //Adds item to the DB
            RefreshListAsync();
        }

        public void removeItem(int id) //Remove Item from DB
        {
 
            uow.Products.DeleteAsync(id);
            RefreshListAsync();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e) //Opens Remove Item window
        {
            lbInventoryList.ItemsSource = _Items; // Added incase sorting methods were used, resets the listbox binding to an unsorted list

            InventoryManager inventory = this;
            RemoveItem remove = new RemoveItem(inventory);

            remove.Show();
        }

        private void sortQ_Click(object sender, RoutedEventArgs e) //Sort Products by Quantity ascending
        {
            var sortList = _Items.OrderBy(x => x.Quantity);

            lbInventoryList.ItemsSource = sortList;
            RefreshListAsync();
        }

        private void sortP_Click(object sender, RoutedEventArgs e) //Sort Products by Price ascending
        {           
            var sortList = _Items.OrderBy(x => x.Price);

            lbInventoryList.ItemsSource = sortList;
            RefreshListAsync();
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e) //Search DB for Products using keyword, makes a new list with results and Refreshes list.
        {  
            var searchString = searchBox.Text;
            var task = await Task.Run(() => uow.Products.GetByNameAsync(searchString).Result);
            lbInventoryList.ItemsSource = task;
            RefreshListAsync();
            searchBox.Text = string.Empty;
        }

        private async void refreshButton_Click(object sender, RoutedEventArgs e) //Refresh list manually
        {
            lbInventoryList.ItemsSource = await Task.Run(() => uow.Products.GetAllAsync().Result);
            RefreshListAsync();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
