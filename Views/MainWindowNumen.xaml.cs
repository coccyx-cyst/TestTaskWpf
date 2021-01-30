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
    /// Логика взаимодействия для MainWindowNumen.xaml
    /// </summary>
    public partial class MainWindowNumen : Window
    {
        //Создаем список для хранения номенклатур
        List<Nomenclature> nomenclatures = new List<Nomenclature>();
        public MainWindowNumen()
        {

            InitializeComponent();
            DataAccess db = new DataAccess();
            nomenclatures = db.SelNomenclatures();
            NomenDataGrid.ItemsSource = nomenclatures;
        }
        /// <summary>
        /// Кнопка Insert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow insertWindow = new InsertWindow();
            insertWindow.ShowDialog();
            insertWindow.Closed += Window_Closed;
        }
        /// <summary>
        /// Кнопка Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.ShowDialog();
            updateWindow.Closed += Window_Closed;
        }
        /// <summary>
        /// Кнопка Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.Closed += Window_Closed;
            deleteWindow.ShowDialog();

        }
        /// <summary>
        /// Обработчик события для закрытия Диалоговых окон.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e) //Для обновления DataGrid
        {
            DataAccess db = new DataAccess();
            NomenDataGrid.ItemsSource = db.SelNomenclatures();
        }
    }
}
