using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestTask2
{
    /// <summary>
    /// Метод для определения строки подключения
    /// </summary>
    public static class Helper
    {
        public static string CnnVal(string name)//Метод для определения строки подключения
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
