using System.Collections.Generic;
using System.Linq;
using DomainLayer.Models.ExpenseType;
using ServiceLayer.Services.ExpenseService;

namespace ServiceLayer.Services.ExpenseTypeService
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private IExpenseTypeRepository expenseTypeRepository;
        private IExpenseRepository expenseRepository;

        public ExpenseTypeService() { }

        public ExpenseTypeService(IExpenseTypeRepository expenseTypeRepository, IExpenseRepository expenseRepository)
        {
            this.expenseTypeRepository = expenseTypeRepository;
            this.expenseRepository = expenseRepository;
        }

        public void Create(ExpenseTypeDTO expenseTypeDTO)
        {
            expenseTypeRepository.Create(expenseType_dtoToModel(expenseTypeDTO));
        }

        public void Delete(ExpenseTypeDTO expenseTypeDTO)
        {
            expenseTypeRepository.Delete(expenseType_dtoToModel(expenseTypeDTO));
        }

        public IEnumerable<ExpenseTypeDTO> GetAll()
        {
            return expenseTypeRepository.GetAll().Select(item => expenseType_modelToDto(item)).ToList();
        }

        public ExpenseTypeDTO GetById(int Id)
        {
            return expenseType_modelToDto(expenseTypeRepository.GetById(Id));
        }

        public void Update(ExpenseTypeDTO expenseTypeDTO)
        {
            expenseTypeRepository.Update(expenseType_dtoToModel(expenseTypeDTO));
        }


        private ExpenseTypeDTO expenseType_modelToDto(IExpenseTypeModel expenseTypeModel)
        {
            ExpenseTypeDTO dto = new ExpenseTypeDTO();
            dto.ExpenseTypeId = expenseTypeModel.ExpenseTypeId;
            dto.ExpenseTypeName = expenseTypeModel.ExpenseTypeName;
            return dto;
        }

        private IExpenseTypeModel expenseType_dtoToModel(ExpenseTypeDTO dto)
        {
            ExpenseTypeModel model = new ExpenseTypeModel();
            model.ExpenseTypeId = dto.ExpenseTypeId;
            model.ExpenseTypeName = dto.ExpenseTypeName;
            return model;
        }
    }
}
