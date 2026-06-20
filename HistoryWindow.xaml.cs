using Demo.Contexts;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(Partner selectedPartner)
        {
            InitializeComponent();
            TextBlockPartnerName.Text = $"История реализации: {selectedPartner.company}";
            LoadHistory(selectedPartner.id);
        }

        private void LoadHistory(int partnerId)
        {
            MyContext myContext = new MyContext();
            var historyList = myContext.sale
                .Include(s => s.ProductNavigation)
                .Where(s => s.partner == partnerId)
                .OrderByDescending(s => s.data)
                .ToList();

            DataGridHistory.ItemsSource = historyList;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
