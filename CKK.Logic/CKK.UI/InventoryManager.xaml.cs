﻿using System;
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
//using CKK.Persistance.Models;
using CKK.DB.UOW;
using CKK.DB.Interfaces;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InventoryManager : Window
    {
        //private FileStore _Store;
        private IConnectionFactory conn;
        private UnitOfWork uow;
        public ObservableCollection<Product> _Items { get; private set; }
        public InventoryManager() //FileStore store)
        {
            //_Store = store;
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

            foreach (Product p in new ObservableCollection<Product>(uow.Products.GetAll()))
            {
                _Items.Add(p);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();

            add.Show();
            this.Close();

        }

        public void addItem(Product prod) // int quantity)
        {
            //_Store.AddStoreItem(prod, quantity);
            uow.Products.Add(prod);
            RefreshList();
        }

        public void removeItem(int id) //, int quantity)
        {
            //_Store.RemoveStoreItem(id, quantity);
            uow.Products.Delete(id);
            RefreshList();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem remove = new RemoveItem();

            remove.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            //_Store.Close();
            this.Close();
        }

        private void sortQ_Click(object sender, RoutedEventArgs e)
        {
            //_Store.GetProductsByQuantity();
            //RefreshList();
            throw new NotImplementedException();
        }

        private void sortP_Click(object sender, RoutedEventArgs e)
        {
            //_Store.GetProductsByPrice();
            //RefreshList();
            throw new NotImplementedException();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //lbInventoryList.ItemsSource = _Store.GetAllProductsByName(searchBox.Text);
            throw new NotImplementedException();

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            lbInventoryList.ItemsSource = _Items;
            RefreshList();
        }
    }
}
