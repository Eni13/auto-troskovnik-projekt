using CommonComponents;
using DomainLayer.Models.ExpenseType;
using ServiceLayer.Services.ExpenseTypeService;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAcess.Repositories.ExpenseType
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private String _connectionString;

        public ExpenseTypeRepository() { }

        public ExpenseTypeRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(IExpenseTypeModel expenseTypeModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "INSERT INTO ExpenseType (ExpenseTypeName) VALUES (@ExpenseTypeName)";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        try
                        {
                            RecordExistsCheck(cmd, expenseTypeModel);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessResult.CustomMessage = "Kategorija o trošku već postoji u bazi podataka";
                            ex.DataAccessResult.ExceptionMessage = string.Copy(ex.Message);
                            ex.DataAccessResult.StackTrace = string.Copy(ex.StackTrace);
                            throw ex;
                        }

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ExpenseTypeName", expenseTypeModel.ExpenseTypeName);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod stvaranja zapisa o kategoriji troška [ExpenseType->Create]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }
        public void Delete(IExpenseTypeModel expenseTypeModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "DELETE FROM ExpenseType WHERE ExpenseType.ExpenseTypeId = @ExpenseTypeId";

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
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod brisanja zapisa o kategoriji troška [ExpenseType->Delete]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

        public IEnumerable<IExpenseTypeModel> GetAll()
        {
            DataAccessResult dataAccessResult = new DataAccessResult();
            List<ExpenseTypeModel> list = new List<ExpenseTypeModel>();
            string sql = "SELECT * FROM ExpenseType";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {

                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ExpenseTypeModel expenseTypeModel = new ExpenseTypeModel();
                                expenseTypeModel.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                expenseTypeModel.ExpenseTypeName = reader["ExpenseTypeName"].ToString();

                                list.Add(expenseTypeModel);
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
                        customMessage: "Greška kod dohvata svih zapisa kategorije troška [ExpenseType->GetAll]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return list;
        }

        public IExpenseTypeModel GetById(int Id)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();
            ExpenseTypeModel expenseModel = new ExpenseTypeModel();
            string sql = "SELECT * FROM ExpenseType WHERE ExpenseType.ExpenseTypeId = @ExpenseTypeId";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {

                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseTypeId", Id));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                expenseModel.ExpenseTypeId = Int32.Parse(reader["ExpenseTypeId"].ToString());
                                expenseModel.ExpenseTypeName = reader["ExpenseTypeName"].ToString();
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
                        customMessage: "Greška kod dohvata zapisa o trošku [ExpenseType->GetById]",
                        helpLink: e.HelpLink,
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return expenseModel;

        }

        public void Update(IExpenseTypeModel expenseTypeModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "UPDATE ExpenseType SET ExpenseTypeName = @ExpenseTypeName WHERE ExpenseType.ExpenseTypeId = @ExpenseTypeId;";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        try
                        {
                            RecordExistsCheck(cmd, expenseTypeModel);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessResult.CustomMessage = "Kategorija troška već postoji u bazi podataka";
                            ex.DataAccessResult.ExceptionMessage = string.Copy(ex.Message);
                            ex.DataAccessResult.StackTrace = string.Copy(ex.StackTrace);
                            throw ex;
                        }

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseTypeId", expenseTypeModel.ExpenseTypeId));
                        cmd.Parameters.Add(new SQLiteParameter("@ExpenseTypeName", expenseTypeModel.ExpenseTypeName));
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod ažuriranja zapisa kategorije troška [ExpenseType->Update]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

        private bool RecordExistsCheck(SQLiteCommand cmd, IExpenseTypeModel expenseTypeModel)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessResult dataAccessResult = new DataAccessResult();

            cmd.Prepare();
            cmd.CommandText = "Select count(*) from ExpenseType where ExpenseTypeName=@ExpenseTypeName";
            cmd.Parameters.AddWithValue("@ExpenseTypeName", expenseTypeModel.ExpenseTypeName);

            try
            {
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SQLiteException e)
            {
                string msg = e.Message;
                throw;
            }

            if (countOfRecsFound > 0)
            {
                dataAccessResult.Status = "Error";
                RecordExistsCheckPassed = false;
                throw new DataAccessException(dataAccessResult);
            }
            return RecordExistsCheckPassed;
        }
    }
}
