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
                                      int.Parse(PriceTextBox.Text),
                                      DateTime.Parse(FromDateTextBox.Text),
                                      DateTime.Parse(ToDateTextBox.Text));
            }
            catch (Exception et)
            {

                MessageBox.Show($"{et.Message}", "Ошибка");
            }
            
            DialogResult = true;

        }
    }
}
