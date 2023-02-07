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
using System.Windows.Shapes;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;
//using CKK.Persistance.Models;
using CKK.Persistance.Interfaces;
using CKK.DB.UOW;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == string.Empty)
            {
                MessageBox.Show("Must enter a password");
            }
            else
            {
                //UnitOfWork tp = (UnitOfWork)Application.Current.FindResource("globStore");
                InventoryManager inv = new();
                inv.Show();
                this.Close();
            }
            
            
        }
    }
}
