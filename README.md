# EmployeeService
Web-Сервис сотрудников, сделанный на платформе .Net Core.
## Установка
для запуска приложения на компьютере должен быть установлен PostgreSQL.
нужно ввести в файл appsettings.json:
+ Server - хост, на котором доступна база данных.
+ Database - название базы данных.
+ UserId - имя пользователя.
+ Password - пароль пользователя.
> В случае, если база данных/таблицы не существуют, приложение создает бд employeeService.
## Использование
+ Метод CreateEmployee - создает сотрудника по введенным полям и возвращает его ID, присвоенный базой данных.
+ Метод DeleteEmployee - удаляет сотрудника по введенному ID.
+ Метод GetEmployeesByCompanyId - выводит список сотрудников по указанному ID компании.
+ Метод GetEmployeesByDepartment - выводит список сотрудников по указанному ID компании и названию отдела.
+ Метод UpdateEmployeeData - обновляет информацию о сотруднике в базе по введенным полям.

Приложение использует Swagger (пример ссылки: http://localhost:5210/swagger/index.html) 
## Модель сотрудника: 
```
{
Id int
Name string
Surname string
Phone string
CompanyId int
Passport {
Type string
Number string
}
Department {
Name string
Phone string
}
}
```