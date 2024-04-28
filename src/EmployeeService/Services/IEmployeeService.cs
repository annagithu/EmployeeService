using EmployeeService.InternalContracts.Models;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        Task<int>Create(EmployeeModel model);

        Task <EmployeeQueryModel> GetById(int id);

        Task DeleteEmployee(int id);

        Task<List<EmployeeModel>> GetByCompanyId(int id);

        Task<List<EmployeeModel>> GetByDepartmentName(int companyId, string deptName);

        Task UpdateEmployee(EmployeeModel model);
    }
}
