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

namespace WpfTestTask2.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        List<Nomenclature> nomenclatures = new List<Nomenclature>();
        public UpdateWindow()
        {
            InitializeComponent();
            DataAccess db = new DataAccess();
            nomenclatures = db.SelNomenclatures();
            UpdateGrid.ItemsSource = nomenclatures;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();
                db.UpdateNomenclature(int.Parse(IdTextBox.Text),
                                      NameTextBox.Text,
                                      double.Parse(PriceTextBox.Text),
                                      DateTime.Parse(FromDateTextBox.Text),
                                      DateTime.Parse(ToDateTextBox.Text));
            }
            catch (Exception et)
            {

                MessageBox.Show($"{et.Message}", "Ошибка");
            }

            DialogResult = true;

        }
        /// <summary>
        /// Обработчик события нажатия на Ячейку DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Nomenclature obj = UpdateGrid.SelectedItem as Nomenclature;
            if (obj != null)
            {
                IdTextBox.Text = obj.Id.ToString();
                NameTextBox.Text = obj.Name;
                PriceTextBox.Text = obj.Price.ToString();
                ToDateTextBox.Text = obj.ToDate.ToString();
                FromDateTextBox.Text = obj.FromDate.ToString();
            }
        }

    }
}