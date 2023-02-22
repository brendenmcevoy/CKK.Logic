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
using CKK.Logic.Interfaces;
using System.Collections.ObjectModel;
using CKK.Persistance.Interfaces;
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
            RefreshList();
        }

        private void RefreshList()
        {
            _Items.Clear();

            foreach (Product p in new ObservableCollection<Product>(uow.Products.GetAllAsync().Result))
            {
                 _Items.Add(p);
            };
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();

            add.Show();
            this.Close();

        }

        public void addItem(Product prod)
        {
            uow.Products.AddAsync(prod);
            RefreshList();
        }

        public void removeItem(int id)
        {
            uow.Products.DeleteAsync(id);
            RefreshList();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem remove = new RemoveItem();

            remove.Show();
            this.Close();
        }

        private void sortQ_Click(object sender, RoutedEventArgs e)
        {
            List<Product> qList = uow.Products.GetAllAsync().Result;

            var list = qList.OrderBy(x => x.Quantity).ToList();

            lbInventoryList.ItemsSource = list;
        }

        private void sortP_Click(object sender, RoutedEventArgs e)
        {
            List<Product> qList = uow.Products.GetAllAsync().Result;

            var list = qList.OrderBy(x => x.Price).ToList();

            lbInventoryList.ItemsSource = list;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {           
            lbInventoryList.ItemsSource = uow.Products.GetByNameAsync(searchBox.Text).Result;
            RefreshList();
            searchBox.Text = string.Empty;
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            lbInventoryList.ItemsSource = uow.Products.GetAllAsync().Result;
            RefreshList();
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
