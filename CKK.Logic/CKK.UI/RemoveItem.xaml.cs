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
        InventoryManager inv;
        public RemoveItem(InventoryManager inventory)
        {
            InitializeComponent();
            inv= inventory;
            idBox.Focus();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idBox.Text);

            inv.removeItem(id);
            if ((bool)multipleBox.IsChecked) 
            {
                idBox.Text = string.Empty;
                idBox.Focus();
            }
            else
            {
                this.Close();
            }
            
        }
        private void backButton_Click(object sender, RoutedEventArgs e) //Back to InvMngr
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
