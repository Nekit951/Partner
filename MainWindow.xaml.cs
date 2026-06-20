using Demo.Contexts;
using Demo.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPartner();
        }

        void LoadPartner()
        {
            DiscountService discountService = new DiscountService();
            MyContext myContext = new MyContext();
            var partnerList = myContext.partner.ToList();

            foreach (var p in partnerList)
            {
                int totalQuantity = myContext.sale.Where(s => s.partner == p.id && s.quantity.HasValue).Sum(s => s.quantity.Value);

                p.currentDiscount = discountService.CalcDiscount(totalQuantity);
            }

            ListBoxPartners.ItemsSource = partnerList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            PartnerWindow partnerWindow = new PartnerWindow();
            partnerWindow.Owner = this;

            // Если форма закрылась с успешным сохранением — обновляем таблицу
            if (partnerWindow.ShowDialog() == true)
            {
                LoadPartner(); // Перезагружаем список
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли карточка в ListBox
            if (ListBoxPartners.SelectedItem is Partner selectedPartner)
            {
                PartnerWindow partnerWindow = new PartnerWindow(selectedPartner);
                partnerWindow.Owner = this;
                if (partnerWindow.ShowDialog() == true)
                {
                    LoadPartner(); // Обновляем список на экране
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнера из списка для редактирования!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxPartners.SelectedItem is Partner selectedPartner)
            {
                HistoryWindow historyWindow = new HistoryWindow(selectedPartner);
                historyWindow.Owner = this;
                historyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнера из списка для просмотра истории!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}