using EmployeeService.InternalContracts.Models;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task Create(EmployeeModel model);

        Task <EmployeeQueryModel> GetById(int id);

        Task DeleteEmployee(int id);

        Task<List<EmployeeModel>> GetByCompanyId(int id);

        Task<List<EmployeeModel>> GetByDepartmentName(string deptName);

        Task UpdateEmployee(EmployeeModel model);
    }
}
