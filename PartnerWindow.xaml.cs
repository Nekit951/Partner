using Demo.Contexts;
using Demo.Models;
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
    /// Логика взаимодействия для PartnerWindow.xaml
    /// </summary>
    public partial class PartnerWindow : Window
    {
        private Partner _currentPartner;
        private bool _isEditMode = false;
        public PartnerWindow()
        {
            InitializeComponent();
            _currentPartner = new Partner();
            InitForm();
        }

        public PartnerWindow(Partner selectedPartner)
        {
            InitializeComponent();
            _currentPartner = selectedPartner;
            _isEditMode = true;
            TextBlockTitle.Text = "Редактирование партнёра";
            InitForm();
            LoadPartnerData();
        }

        private void InitForm() 
        {
            ComboBoxType.ItemsSource = new List<string> {"ООО", "ЗАО", "ПАО", "ИП" };
        }

        private void LoadPartnerData()
        {
            TextBoxCompany.Text = _currentPartner.company;
            ComboBoxType.SelectedItem = _currentPartner.partnerType;
            TextBoxRating.Text = _currentPartner.rating.ToString();
            TextBoxDirector.Text = _currentPartner.directorName;
            TextBoxPhone.Text = _currentPartner.phone;
            TextBoxEmail.Text = _currentPartner.email;
            TextBoxInn.Text = _currentPartner.inn;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxCompany.Text) || string.IsNullOrWhiteSpace(TextBoxInn.Text))
            {
                MessageBox.Show("Поля 'Наименование' и 'ИНН' обязательны для заполнения!",
                                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TextBoxRating.Text, out int ratingValue) || ratingValue < 0)
            {
                MessageBox.Show("Рейтинг должен быть целым неотрицательным числом (0 или больше)!",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MyContext myContext = new MyContext();
            _currentPartner.company = TextBoxCompany.Text;
            _currentPartner.partnerType = ComboBoxType.SelectedItem?.ToString();
            _currentPartner.rating = ratingValue;
            _currentPartner.directorName = TextBoxDirector.Text;
            _currentPartner.phone = TextBoxPhone.Text;
            _currentPartner.email = TextBoxEmail.Text;
            _currentPartner.inn = TextBoxInn.Text;

            if (_isEditMode)
            {
                myContext.partner.Update(_currentPartner);
            }
            else
            {
                myContext.partner.Add(_currentPartner);
            }

            myContext.SaveChanges();
            this.DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
