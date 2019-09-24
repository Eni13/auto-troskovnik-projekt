using CommonComponents;
using DomainLayer.Models.User;
using ServiceLayer.Services.UserService;
using System;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAcess.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private String _connectionString;

        public UserRepository() { }

        public UserRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(IUserModel userModel)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "INSERT INTO User (FirstName, LastName, CarModel) VALUES (@FirstName, @LastName, @CarModel)";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        try
                        {
                            RecordExistsCheck(cmd, userModel);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessResult.CustomMessage = "Korisnik već postoji u bazi podataka";
                            ex.DataAccessResult.ExceptionMessage = string.Copy(ex.Message);
                            ex.DataAccessResult.StackTrace = string.Copy(ex.StackTrace);
                            throw ex;
                        }

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", userModel.LastName);
                        cmd.Parameters.AddWithValue("@CarModel", userModel.CarModel);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SQLiteException e)
                {
                    dataAccessResult.setValues(
                       status: "Error",
                       operationSucceeded: false,
                       exceptionMessage: e.Message,
                       customMessage: "Greška kod kreiranja novog korisnika [User->Create]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return;
        }

        public IUserModel GetByFirstAndLastName(string firstName, string lastName)
        {
            DataAccessResult dataAccessResult = new DataAccessResult();

            string sql = "SELECT * FROM User u WHERE u.FirstName = @FirstName AND u.LastName = @LastName";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {

                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SQLiteParameter("@FirstName", firstName));
                        cmd.Parameters.Add(new SQLiteParameter("@LastName", lastName));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    UserModel userModel = new UserModel();
                                    userModel.UserId = Int32.Parse(reader["UserId"].ToString());
                                    userModel.FirstName = reader["FirstName"].ToString();
                                    userModel.LastName = reader["LastName"].ToString();
                                    userModel.CarModel = reader["CarModel"].ToString();
                                    return userModel;
                                }
                            }
                            else
                            {
                                dataAccessResult.setValues(
                                   status: "Error",
                                   operationSucceeded: false,
                                   exceptionMessage: "",
                                   customMessage: "Korisnik sa zadanim imenom i prezimenom nije pronađen u bazi podataka",
                                   helpLink: "",
                                   errorCode: 0,
                                   stackTrace: "");

                                throw new DataAccessException(dataAccessResult);
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
                       customMessage: "Greška kod dohvata korisnika po imenu i prezimenu [User->GetByFirstAndLastName]",
                       helpLink: e.HelpLink,
                       errorCode: e.ErrorCode,
                       stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessResult);
                }
            }
            return null;
        }

        private bool RecordExistsCheck(SQLiteCommand cmd, IUserModel userModel)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessResult dataAccessResult = new DataAccessResult();

            cmd.Prepare();
            cmd.CommandText = "Select count(*) from User where FirstName=@FirstName and LastName=@LastName";
            cmd.Parameters.AddWithValue("@FirstName", userModel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", userModel.LastName);

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
