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
using System.Windows.Shapes;
using CKK.Logic.Models;
using CKK.DB.UOW;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        InventoryManager inv;
        public AddItem(InventoryManager inventory)
        {
            InitializeComponent();
            inv = inventory;
            nameBox.Focus();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product(); //Create new Product using values from textboxes
            prod.Name = nameBox.Text;
            prod.Price = int.Parse(priceBox.Text);
            prod.Quantity = int.Parse(quantityBox.Text);

            inv.addItem(prod); //Add item to InvMngr

            if ((bool)multipleBox.IsChecked)
            {
                nameBox.Text = String.Empty; 
                priceBox.Text=String.Empty; 
                quantityBox.Text=String.Empty;
                nameBox.Focus();
            }
            else
            {
                this.Close(); //Close window and open InvMngr window
            } 

        }       

        private void backButton_Click(object sender, RoutedEventArgs e) //Go back to InvMngr
        {            
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
