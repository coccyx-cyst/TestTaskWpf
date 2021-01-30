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
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        List<Nomenclature> nomenclatures = new List<Nomenclature>();

        public DeleteWindow()
        {
            InitializeComponent();
            DataAccess db = new DataAccess();
            nomenclatures = db.SelNomenclatures();
            DeleteDataGrid.ItemsSource = nomenclatures;
        }
        /// <summary>
        /// Логика для кнопки удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            DataAccess db = new DataAccess();
            
            //Вызываем Message Box
            MessageBoxResult msgBoxRes = MessageBox.Show("Вы уверены, что хотите удалить?", 
                                                         "Подтверждение",
                                                         MessageBoxButton.YesNo, 
                                                         MessageBoxImage.Question);
            switch (msgBoxRes)//Switch для удобной работы с Enum
            {
                case MessageBoxResult.Yes:
                    db.DeleteNomenclature(int.Parse(TextBox.Text));
                    DialogResult = true;
                    break;
                case MessageBoxResult.No:
                    DialogResult = false;
                    break;
                default:
                    DialogResult = false;
                    break;
            }
            
        }
        /// <summary>
        /// Обработчик события нажатия на DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Nomenclature obj = DeleteDataGrid.SelectedItem as Nomenclature;
            if (obj != null)
            {
                TextBox.Text = obj.Id.ToString();
                
            }
        }
    }
}
