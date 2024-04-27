using Dapper;
using EmployeeService.Helpers;
using EmployeeService.Helpers.Requests;
using EmployeeService.InternalContracts.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace EmployeeService.Repositories
{
    public class EmployeeRepository(DataContext context) : IEmployeeRepository
    {
        private DataContext _context = context;

        public async Task Create(EmployeeModel employee)
        {

            using var connection = _context.CreateConnection();



            EmployeeQueryModel employeeQueryModel = employee.ToQueryFromEmployee();

            var sql = """
            INSERT INTO departments (departmentname, departmentphone, employeeid)
            VALUES (@DepartmentName, @DepartmentPhone, @EmployeeId);

            INSERT INTO passports (passporttype, passportnumber, employeeid)
            VALUES (@PassportType, @PassportNumber, @EmployeeId);

            INSERT INTO employees (id, name, surname, phone, companyId, passport, department)
            VALUES (@Id, @Name, @Surname, @Phone, @CompanyId, @PassportNumber, @DepartmentName);
            """;

            await connection.ExecuteAsync(sql, employeeQueryModel);
        }

        public async Task<EmployeeQueryModel> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT id FROM employees
            WHERE employees.id = @Id
            """;
            return await connection.QuerySingleOrDefaultAsync<EmployeeQueryModel>(sql, new { id });
        }

        public async Task DeleteEmployee(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM employees 
            WHERE id = @id;

            DELETE FROM passports
            WHERE employeeid = @id;

            DELETE FROM departments 
            WHERE employeeid = @id;
            """;

            await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<List<EmployeeModel>> GetByCompanyId(int id)
        {
            using var connection = _context.CreateConnection();

                var sqlId = """
            SELECT emp.id, emp.name, emp.surname, emp.phone, emp.companyId, emp.passport, emp.department, pass.passporttype, pass.passportnumber, dept.departmentname, dept.departmentphone, pass.employeeid
            FROM employees emp
            LEFT JOIN passports pass ON emp.id = pass.employeeid
            LEFT JOIN departments dept ON emp.id = dept.employeeid
            where emp.companyId = @id
            """;

            IEnumerable<EmployeeQueryModel> employeeQueryModels = await connection.QueryAsync<EmployeeQueryModel>(sqlId, new { id });

            List<EmployeeModel> result = [];

            foreach (var employee in employeeQueryModels)
            {
                result.Add(employee.ToEmployeeModelFromQuery());
            }
            
            return result;
        }

        public async Task<List<EmployeeModel>> GetByDepartmentName(string deptName)
        {
            using var connection = _context.CreateConnection();

            var sqlId = """
            SELECT emp.id, emp.name, emp.surname, emp.phone, emp.companyId, emp.passport, emp.department, pass.passporttype, pass.passportnumber, dept.departmentname, dept.departmentphone, pass.employeeid
            FROM employees emp
            LEFT JOIN passports pass ON emp.id = pass.employeeid
            LEFT JOIN departments dept ON emp.id = dept.employeeid
            where dept.departmentname = @deptName
            """;

            IEnumerable<EmployeeQueryModel> employeeQueryModels = await connection.QueryAsync<EmployeeQueryModel>(sqlId, new { deptName });

            List<EmployeeModel> result = [];

            foreach (var employee in employeeQueryModels)
            {
                result.Add(employee.ToEmployeeModelFromQuery());
            }

            return result;
        }

        public async Task UpdateEmployee(EmployeeModel model)
        {
            using var connection = _context.CreateConnection();

            EmployeeQueryModel employeeQueryModel = model.ToQueryFromEmployee();

            var sql = """
            UPDATE departments 
            SET departmentname = @DepartmentName, 
            departmentphone = @DepartmentPhone,
            employeeid = @Id
            WHERE employeeid = @Id;

            UPDATE passports 
            SET passporttype = @PassportType, 
            passportnumber = @PassportNumber,
            employeeid = @Id
            WHERE employeeid = @id;

            UPDATE employees 
            SET name = @Name, 
            surname = @Surname,
            phone = @Phone, 
            companyId = @CompanyId, 
            passport = @PassportNumber,
            department = @DepartmentName
            WHERE id = @Id;
            """;

            await connection.ExecuteAsync(sql, employeeQueryModel);
        }
    }
}
