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
            AddItem add = new AddItem();

            add.Show();
            this.Close();

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
            RemoveItem remove = new RemoveItem();

            remove.Show();
            this.Close();
        }

        private async void sortQ_Click(object sender, RoutedEventArgs e) //Sort Products by Quantity ascending
        {
            List<Product> qList = await Task.Run(() => uow.Products.GetAllAsync().Result);

            var list = qList.OrderBy(x => x.Quantity).ToList();

            lbInventoryList.ItemsSource = list;
        }

        private async void sortP_Click(object sender, RoutedEventArgs e) //Sort Products by Price ascending
        {
            List<Product> qList = await Task.Run(() => uow.Products.GetAllAsync().Result);

            var list = qList.OrderBy(x => x.Price).ToList();

            lbInventoryList.ItemsSource = list;
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
