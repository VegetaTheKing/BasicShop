﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BasicShop.View
{
    /// <summary>
    /// Interaction logic for AdminRolePage.xaml
    /// </summary>
    public partial class AdminRolePage : Page
    {
        CollectionViewSource viewSource;
        shopEntities ctx = new shopEntities(DatabaseHelper.GetConnectionString());

        public AdminRolePage()
        {
            InitializeComponent();
            viewSource = ((CollectionViewSource)(FindResource("roleViewSource")));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadScreenProcess(() =>
            {
                ctx.role.Load();
            }, () =>
            {
                viewSource.Source = ctx.role.Local;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            role r = new role();
            ctx.role.Add(r);
            viewSource.View.MoveCurrentTo(r);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            role r = viewSource.View.CurrentItem as role;
            ctx.role.Remove(r);
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
