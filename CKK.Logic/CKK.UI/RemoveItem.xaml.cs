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
    /// Interaction logic for RemoveItem.xaml
    /// </summary>
    public partial class RemoveItem : Window
    {
        public RemoveItem()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryManager inv = new InventoryManager();

            int id = int.Parse(idBox.Text);

            inv.removeItem(id); //Remove item from InvMngr

            inv.Show(); //Close this window and open InvMngr window
            this.Close();
        }
        private void backButton_Click(object sender, RoutedEventArgs e) //Back to InvMngr without saving changes
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
