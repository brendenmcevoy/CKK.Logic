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
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
   

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
            Store tp = (Store)Application.Current.FindResource("globStore");
            InventoryManager inv = new InventoryManager(tp);

            int id = int.Parse(idBox.Text);
            int q = int.Parse(quantityBox.Text);

            inv.removeItem(id, q);

            inv.Show();
            this.Close();
        }
    }
}
