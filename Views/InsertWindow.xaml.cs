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
    /// Логика взаимодействия для InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        List<Nomenclature> nomenclatures = new List<Nomenclature>();
        public InsertWindow()
        { 
            InitializeComponent();
            
        }
        /// <summary>
        /// Логика для кнопки сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowNumen windowNumen = new MainWindowNumen();
            DataAccess db = new DataAccess();
            nomenclatures = db.SelNomenclatures();

            try
            {
                db.InsertNomenclature(int.Parse(IdTextBox.Text),
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
