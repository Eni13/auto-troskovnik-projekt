using CommonComponents;
using CommonComponents.ViewModels;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using ServiceLayer.Services.ExpenseService;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAcess.Repositories.Expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private String _connectionString;

        public ExpenseRepository() { }
        public ExpenseRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(IExpenseModel expenseModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "INSERT INTO Expense (ExpenseTypeId, Date, Cost, UserId) VALUES (@ExpenseTypeId, @Date, @Cost, @UserId)";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ExpenseTypeId", expenseModel.ExpenseTypeId);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Parse(expenseModel.Date));
                        cmd.Parameters.AddWithValue("@Cost", expenseModel.Cost);
                        cmd.Parameters.AddWithValue("@UserId", expenseModel.UserId);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod kreiranja zapisa troška [Expense->Create]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

        public void Delete(IExpenseModel expenseModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "DELETE FROM Expense WHERE Expense.ExpenseId = @ExpenseId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseId", expenseModel.ExpenseId));
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod brisanja zapisa troška [Expense->Delete]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

        public IEnumerable<IExpenseModel> GetAllByUserId(int UserId)
        {
            List<ExpenseModel> list = new List<ExpenseModel>();
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT * FROM Expense WHERE Expense.UserId = @UserId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", UserId));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ExpenseModel expenseModel = new ExpenseModel();
                                expenseModel.ExpenseId = Int32.Parse(reader["ExpenseId"].ToString());
                                expenseModel.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                expenseModel.Date = reader["Date"].ToString();
                                expenseModel.Cost = Double.Parse(reader["Cost"].ToString());
                                list.Add(expenseModel);
                            }
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                        status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Greška kod dohvata zapisa o trošku[Expense->GetAll]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public IEnumerable<IExpenseModel> GetAllByUserIdAndExpenseType(int UserId, IExpenseTypeModel expenseTypeModel)
        {
            List<ExpenseModel> list = new List<ExpenseModel>();
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT * FROM Expense WHERE Expense.UserId = @UserId AND Expense.ExpenseTypeId = @ExpenseTypeId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseTypeId", expenseTypeModel.ExpenseTypeId));
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", UserId));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ExpenseModel expenseModel = new ExpenseModel();
                                expenseModel.ExpenseId = Int32.Parse(reader["ExpenseId"].ToString());
                                expenseModel.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                expenseModel.Date = reader["Date"].ToString();
                                expenseModel.Cost = Double.Parse(reader["Cost"].ToString());
                                list.Add(expenseModel);
                            }
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod dohvata zapisa o trošku za zadanu kategoriju troška [Expense->getAllByExpenseType]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public List<int> GetDistinctYears(int UserId)
        {
            List<int> list = new List<int>();
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT DISTINCT(strftime('%Y', Date)) as Year from Expense WHERE UserId = @UserId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", UserId));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(Int32.Parse(reader["Year"].ToString()));
                            }
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                        status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Greška kod dohvata liste godina potrošnje [Expense->GetDistinctYears]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public IEnumerable<MonthCategoryCost> GetTotalCostPerCategoryAndMonth(int year, int month, int UserId)
        {
            List<MonthCategoryCost> list = new List<MonthCategoryCost>();
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT Expense.ExpenseTypeId, " +
                        "ExpenseType.ExpenseTypeName, " +
                        "SUM(Cost) as TotalCost " +
                        "from Expense INNER JOIN ExpenseType " +
                        "ON Expense.ExpenseTypeId = ExpenseType.ExpenseTypeId " +
                        "WHERE UserId = @UserId AND strftime('%Y', Expense.Date) = @Year AND strftime('%m', Expense.Date) = @Month " +
                        "GROUP BY Expense.ExpenseTypeId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", UserId));
                        cmd.Parameters.Add(new SQLiteParameter("@Year", year.ToString()));
                        cmd.Parameters.Add(new SQLiteParameter("@Month", month.ToString("00")));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MonthCategoryCost item = new MonthCategoryCost();
                                item.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                item.ExpenseTypeName = reader["ExpenseTypeName"].ToString();
                                item.TotalCost = Double.Parse(reader["TotalCost"].ToString());
                                list.Add(item);
                            }
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                        status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Greška kod dohvata zapisa o trošku za zadani mjesec i kategoriju [Expense->GetTotalCostPerCategoryAndMonth]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public IEnumerable<YearCategoryCost> GetTotalCostPerCategoryAndYear(int year, int UserId)
        {

            List<YearCategoryCost> list = new List<YearCategoryCost>();
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT Expense.ExpenseTypeId, " +
                        "ExpenseType.ExpenseTypeName, " +
                        "SUM(Cost) as TotalCost " +
                        "from Expense INNER JOIN ExpenseType " +
                        "ON Expense.ExpenseTypeId = ExpenseType.ExpenseTypeId " +
                        "WHERE UserId = @UserId AND strftime('%Y', Expense.Date) = @Year " +
                        "GROUP BY Expense.ExpenseTypeId ";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@UserId", UserId));
                        cmd.Parameters.Add(new SQLiteParameter("@Year", year.ToString()));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                YearCategoryCost item = new YearCategoryCost();
                                item.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                item.ExpenseTypeName = reader["ExpenseTypeName"].ToString();
                                item.TotalCost = Double.Parse(reader["TotalCost"].ToString());
                                list.Add(item);
                            }
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                        status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Greška kod dohvata zapisa o trošku za zadanu godinu i kategoriju [Expense->GetTotalCostPerCategoryAndYear]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public void Update(IExpenseModel expenseModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "UPDATE Expense SET ExpenseTypeId = @ExpenseTypeId, Date = @Date, Cost = @Cost WHERE Expense.ExpenseId = @ExpenseId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseId", expenseModel.ExpenseId));
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseTypeId", expenseModel.ExpenseTypeId));
                        cmd.Parameters.Add(new SQLiteParameter("@Date", expenseModel.Date));
                        cmd.Parameters.Add(new SQLiteParameter("@Cost", expenseModel.Cost));
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Unable to update expense [Expense->Update]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

      
    }
}
