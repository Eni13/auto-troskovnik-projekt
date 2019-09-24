using System;

namespace CommonComponents
{
    public class DataAccessException : Exception
    {
        public DataAccessException() { }


        public DataAccessException(DataAccessResult dataAccessResult)
        {
            _dataAccessResult = dataAccessResult;
        }

        public DataAccessException(string message, Exception innerException, DataAccessResult dataAccessResult) : base(message, innerException)
        {
            _dataAccessResult = dataAccessResult;
        }


        private DataAccessResult _dataAccessResult { get; set; }

        public DataAccessResult DataAccessResult
        {
            get { return _dataAccessResult; }
            set { _dataAccessResult = value; }
        }
    }
}
