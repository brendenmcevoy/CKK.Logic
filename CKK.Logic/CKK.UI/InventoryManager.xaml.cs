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

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InventoryManager : Window
    {
        private IStore _Store;
        public ObservableCollection<StoreItem> _Items { get; private set;}
        public InventoryManager(Store store)
        {
            _Store = store;
            InitializeComponent();
            _Items = new ObservableCollection<StoreItem>();
            lbInventoryList.ItemsSource = _Items;
            RefreshList();
        }

        private void RefreshList()
        {
            _Items.Clear();

            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems()))
            {
                _Items.Add(si);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();

            add.Show();
            this.Close();
           
        }

        public void addItem(Product prod, int quantity)
        {
            _Store.AddStoreItem(prod, quantity);
            RefreshList();
        }

        public void removeItem(int id, int quantity)
        {
            _Store.RemoveStoreItem(id, quantity);
            RefreshList();
        }

       

        

        

    }
}
