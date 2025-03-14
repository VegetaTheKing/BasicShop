﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BasicShop.View
{
    /// <summary>
    /// Interaction logic for AdminAccountPage.xaml
    /// </summary>
    public partial class AdminAccountPage : Page
    {
        CollectionViewSource viewSource;
        shopEntities ctx = new shopEntities(DatabaseHelper.GetConnectionString());

        public AdminAccountPage()
        {
            InitializeComponent();
            viewSource = ((CollectionViewSource)(FindResource("accountViewSource")));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadScreenProcess(() =>
            {
                ctx.account.Load();
            }, () =>
            {
                viewSource.Source = ctx.account.Local;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            account a = new account();
            ctx.account.Add(a);
            viewSource.View.MoveCurrentTo(a);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            account a = viewSource.View.CurrentItem as account;
            ctx.account.Remove(a);
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
