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
using CKK.Logic.Interfaces;
using CKK.Persistance.Models;
using CKK.Persistance.Interfaces;

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
            FileStore tp = (FileStore)Application.Current.FindResource("globStore");
            InventoryManager inv = new InventoryManager(tp);

            Product prod = new Product();
            prod.Id = int.Parse(idBox.Text);
            prod.Name = nameBox.Text;
            prod.Price = int.Parse(priceBox.Text);

            inv.addItem(prod, int.Parse(quantityBox.Text));

            inv.Show();
            this.Close();
          
        }
    }
}
