public interface IUnitOfWork
{
    IRepository<Employee> Employees { get; }
    IRepository<EmployeeSalary> EmployeeSalaries { get; }
    Task<int> CompleteAsync();
}