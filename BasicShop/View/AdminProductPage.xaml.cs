﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BasicShop.View
{
    /// <summary>
    /// Interaction logic for AdminProductPage.xaml
    /// </summary>
    public partial class AdminProductPage : Page
    {
        CollectionViewSource viewSource;
        shopEntities ctx = new shopEntities(DatabaseHelper.GetConnectionString());

        public AdminProductPage()
        {
            InitializeComponent();
            viewSource = ((CollectionViewSource)(FindResource("productViewSource")));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadScreenProcess(() =>
            {
                ctx.product.Load();
            }, () =>
            {
                viewSource.Source = ctx.product.Local;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            product p = new product();
            ctx.product.Add(p);
            viewSource.View.MoveCurrentTo(p);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            product p = viewSource.View.CurrentItem as product;
            ctx.product.Remove(p);
            viewSource.View.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
            viewSource.View.Refresh();
        }

        private async void LoadScreenProcess(Action action, Action cont = null)
        {
            loading.Visibility = Visibility.Visible;

            await Task.Factory.StartNew(action);

            if (cont != null)
                cont();

            loading.Visibility = Visibility.Collapsed;
        }
    }
}
