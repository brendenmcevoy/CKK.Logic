using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for itemBox.xaml
    /// </summary>
    public partial class itemBox : UserControl
    {
        public itemBox()
        {
            InitializeComponent();
            
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product();
            prod.Id = int.Parse(idBox.Text);
            prod.Name = nameBox.Text;
            prod.Price = int.Parse(priceBox.Text);
            int quantity = int.Parse(quantityBox.Text);
            StoreItem item = new StoreItem(prod, quantity);
        }
    }
}
