using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestTask2
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class DataAccess
    {
        private readonly string _connectionString = Helper.CnnVal("DbConnection");
        /// <summary>
        /// Проверка логина
        /// </summary>
        /// <param name="loginName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Булево значение</returns>
        public bool Login(string loginName, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
               
               var loginRes = connection.ExecuteScalar($"select dbo.check_authentication('{loginName}','{password}')").ToString();

                return Convert.ToBoolean(loginRes);

                
            }
        }
        /// <summary>
        /// Метод для возврата всех пользователей
        /// </summary>
        /// <returns>Лист типа User</returns>
        public List<User> SelectUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var loginResult = connection.Query<User>($"select * from dbo.sel_users()").ToList();

                return loginResult;
            }
        }
        /// <summary>
        /// Метод реализующий хранимую функцию для вывода номенклатур.
        /// </summary>
        /// <returns></returns>
        public List<Nomenclature> SelNomenclatures()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var nomenclatures = connection.Query<Nomenclature>($"select * from dbo.sel_nomenclature()").ToList();
                return nomenclatures;
            }
        }
        /// <summary>
        /// Метод реализующий хранимую процедуру для Insert в таблицу номенклатур.
        /// </summary>
        /// <param name="id">Id номенклатуры.</param>
        /// <param name="name">Имя номенклатуры.</param>
        /// <param name="price">Цена номенклатуры.</param>
        /// <param name="fromDate">Начальная дата.</param>
        /// <param name="toDate">Конечная дата.</param>
        public void InsertNomenclature(int id, string name, double price, DateTime fromDate, DateTime toDate)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute($"exec dbo.iud_nomenclature 'I', {id}, '{name}', {price}, '{fromDate}', '{toDate}'");
            }
        }
        /// <summary>
        /// Метод реализующий хранимую процедуру Update для таблицы номенклатур.
        /// </summary>
        /// <param name="id">Id номенклатуры.</param>
        /// <param name="name">Имя номенклатуры.</param>
        /// <param name="price">Цена номенклатуры.</param>
        /// <param name="fromDate">Начальная дата.</param>
        /// <param name="toDate">Конечная дата.</param>
        public void UpdateNomenclature(int id, string name, double price, DateTime fromDate, DateTime toDate)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute($"exec dbo.iud_nomenclature 'U', {id}, '{name}', {price}, '{fromDate}', '{toDate}'");
            }
        }
        /// <summary>
        /// Метод реализующий хранимую процедуру удаления из таблицы номенклатур.
        /// </summary>
        /// <param name="id">Id номенклатуры.</param>
        /// <param name="name">Имя номенклатуры.</param>
        /// <param name="price">Цена номенклатуры.</param>
        /// <param name="fromDate">Начальная дата.</param>
        /// <param name="toDate">Конечная дата.</param>
        public void DeleteNomenclature(int id, string name = default, double price =default, DateTime fromDate=default, DateTime toDate = default)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute($"exec dbo.iud_nomenclature 'D', {id}, '{name}', {price}, '{fromDate}', '{toDate}'");
            }
        }
    }
}
