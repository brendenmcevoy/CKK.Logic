using CKK.Logic.Interfaces;
using CKK.Logic.Models;
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
using CKK.Persistance.Models;
using CKK.Persistance.Interfaces;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for AddItemUC.xaml
    /// </summary>
    public partial class AddItemUC : UserControl
    {
        
        public AddItemUC()
        {
            InitializeComponent();
        }
      
        public void Show()
        {
            Visibility = Visibility.Visible; //open addBar
        }

        private void submitButon_Click(object sender, RoutedEventArgs e)
        {
            FileStore tp = (FileStore)Application.Current.FindResource("globStore");
            InventoryManager inv = new InventoryManager(tp);

            Product prod = new Product();
            prod.Name = nameBox.Text;
            prod.Id = int.Parse(idBox.Text);
            prod.Price = decimal.Parse(priceBox.Text);

            inv.addItem(prod, int.Parse(qBox.Text));
                        
            Visibility = Visibility.Collapsed; //close addBar
        }
    }
}
