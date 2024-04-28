using EmployeeService.InternalContracts.Models;

namespace EmployeeService.Helpers.Requests
{
    public static class ParsingModels
    { 
        public static EmployeeModel ToEmployeeModelFromQuery(this EmployeeQueryModel requestModel)
        {
            return new EmployeeModel
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                Surname = requestModel.Surname,
                Phone = requestModel.Phone,
                CompanyId = requestModel.CompanyId,
                Passport = new PassportModel
                {
                    EmployeeId = requestModel.Id,
                    PassportNumber = requestModel.PassportNumber,
                    PassportType = requestModel.PassportType
                },
                Department = new DepartmentModel
                {
                    EmployeeId = requestModel.Id,
                    DepartmentName = requestModel.DepartmentName,
                    DepartmentPhone = requestModel.DepartmentPhone
                }
            };
        }

        public static EmployeeQueryModel ToQueryFromEmployee(this EmployeeModel employeeModel)
        {
            return new EmployeeQueryModel
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                Phone = employeeModel.Phone,
                CompanyId = employeeModel.CompanyId,
                PassportType = employeeModel.Passport?.PassportType,
                PassportNumber = employeeModel.Passport?.PassportNumber,
                DepartmentName = employeeModel.Department?.DepartmentName,
                DepartmentPhone = employeeModel.Department?.DepartmentPhone,
                EmployeeId = employeeModel.Id
            };
        }

        public static EmployeeQueryModel IsNotUpdated(this EmployeeQueryModel modelEmployee, EmployeeQueryModel queryFromDb)
        {
            modelEmployee.Name ??= queryFromDb.Name;
            modelEmployee.Surname ??= queryFromDb.Surname;
            modelEmployee.Phone ??= queryFromDb.Phone;
            modelEmployee.CompanyId ??= queryFromDb.CompanyId;
            modelEmployee.PassportType ??= queryFromDb.PassportType;
            modelEmployee.PassportNumber ??= queryFromDb.PassportNumber;
            modelEmployee.DepartmentName ??= queryFromDb.DepartmentName;
            modelEmployee.DepartmentPhone ??= queryFromDb.DepartmentPhone;
            modelEmployee.EmployeeId ??= queryFromDb.EmployeeId;
            return modelEmployee;
        }
    }
}
