using System;
using System.Collections.Generic;
using System.Linq;
using CommonComponents;
using CommonComponents.ViewModels;
using DomainLayer.Models.Expense;
using DomainLayer.Models.ExpenseType;
using ServiceLayer.Services.ExpenseTypeService;

namespace ServiceLayer.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository expenseRepository;
        private IExpenseTypeRepository expenseTypeRepository;

        public ExpenseService() { }

        public ExpenseService(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            this.expenseRepository = expenseRepository;
            this.expenseTypeRepository = expenseTypeRepository;
        }
        public void Create(ExpenseDTO expenseDTO)
        {
            expenseRepository.Create(expense_dtoToModel(expenseDTO));
        }

        public void Delete(ExpenseDTO expenseDTO)
        {
            expenseRepository.Delete(expense_dtoToModel(expenseDTO));
        }

        public IEnumerable<ExpenseDTO> GetAllByUserId(int UserId)
        {
            return expenseRepository.GetAllByUserId(UserId).Select(item => expense_modelToDto(item)).ToList();
        }

        public IEnumerable<ExpenseDTO> GetAllByUserIdAndExpenseType(int UserId, ExpenseTypeDTO expenseTypeDTO)
        {
            return expenseRepository.GetAllByUserIdAndExpenseType(UserId, expenseType_dtoToModel(expenseTypeDTO)).Select(item => expense_modelToDto(item)).ToList();
        }

        public void Update(ExpenseDTO expenseModel)
        {
            expenseRepository.Update(expense_dtoToModel(expenseModel));
        }


        private ExpenseDTO expense_modelToDto(IExpenseModel e) {
            ExpenseDTO expenseDTO = new ExpenseDTO();
            expenseDTO.ExpenseId = e.ExpenseId;
            expenseDTO.ExpenseTypeId = e.ExpenseTypeId;
            expenseDTO.Date = DateTime.Parse(e.Date);
            expenseDTO.Cost = e.Cost;
            expenseDTO.UserId = e.UserId;
            IExpenseTypeModel expenseTypeModel = expenseTypeRepository.GetById(e.ExpenseTypeId);
            expenseDTO.ExpenseTypeName = expenseTypeModel != null? expenseTypeModel.ExpenseTypeName : "";
            return expenseDTO;
        }
        private IExpenseModel expense_dtoToModel(ExpenseDTO dto)
        {
            ExpenseModel model = new ExpenseModel();
            model.ExpenseId = dto.ExpenseId;
            model.ExpenseTypeId = dto.ExpenseTypeId;
            model.Cost = dto.Cost;
            model.Date = TimeHelpers.dateTimeToString(dto.Date);
            model.UserId = dto.UserId;
            return model;
        }


        private IExpenseTypeModel expenseType_dtoToModel(ExpenseTypeDTO dto)
        {
            ExpenseTypeModel model = new ExpenseTypeModel();
            model.ExpenseTypeId = dto.ExpenseTypeId;
            model.ExpenseTypeName = dto.ExpenseTypeName;
            return model;
        }

        public List<int> GetDistinctYears(int UserId)
        {
            return expenseRepository.GetDistinctYears(UserId);
        }

        public IEnumerable<MonthCategoryCost> GetTotalCostPerCategoryAndMonth(int year, int month, int UserId)
        {
            return expenseRepository.GetTotalCostPerCategoryAndMonth(year, month, UserId);
        }

        public IEnumerable<YearCategoryCost> GetTotalCostPerCategoryAndYear(int year, int UserId)
        {
            return expenseRepository.GetTotalCostPerCategoryAndYear(year, UserId);
        }
    }
}
