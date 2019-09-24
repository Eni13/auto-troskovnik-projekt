using System;

namespace DomainLayer.Models.Expense
{
    public class ExpenseDTO
    {
        public ExpenseDTO() { }
        public int ExpenseId { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int ExpenseTypeId { get; set; }

        public string ExpenseTypeName { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int UserId { get; set; }
    }
}
