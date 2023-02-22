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
        public AddItem()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            
            InventoryManager inv = new InventoryManager();

            Product prod = new Product(); //Create new Product using values from textboxes
            prod.Name = nameBox.Text;
            prod.Price = int.Parse(priceBox.Text);
            prod.Quantity = int.Parse(quantityBox.Text);

            inv.addItem(prod); //Add item to InvMngr
           
            inv.Show();
            this.Close(); //Close window and open InvMngr window
        }       

        private void backButton_Click(object sender, RoutedEventArgs e) //Go back to InvMngr without saving changes
        {
            InventoryManager inv = new InventoryManager();

            inv.Show(); 
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
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
