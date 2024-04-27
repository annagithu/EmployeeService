using EmployeeService.Helpers;
using EmployeeService.InternalContracts.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Create(EmployeeModel model)
        {
            if (await _employeeRepository.GetById(model.Id) != null)
                throw new AppException("Employee with the ID '" + model.Id + "' already exists");

            await _employeeRepository.Create(model);
        }

        public async Task<EmployeeQueryModel> GetById(int id)
        {
            var getEmployee = await _employeeRepository.GetById(id);

            return getEmployee ?? throw new KeyNotFoundException("Employee not found");
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<List<EmployeeModel>> GetByCompanyId(int id)
        {
            return await _employeeRepository.GetByCompanyId(id);
        }

        public async Task<List<EmployeeModel>> GetByDepartmentName(string deptName)
        {
            return await _employeeRepository.GetByDepartmentName(deptName);
        }

        public async Task UpdateEmployee(EmployeeModel model)
        {
            if (await _employeeRepository.GetById(model.Id) == null)
                throw new AppException("Employee with the ID '" + model.Id + "' doesn't exist");

            await _employeeRepository.UpdateEmployee(model);
        }
    }
}
