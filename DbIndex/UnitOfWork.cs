public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Employees = new Repository<Employee>(context);
        EmployeeSalaries = new Repository<EmployeeSalary>(context);
    }

    public IRepository<Employee> Employees { get; private set; }
    public IRepository<EmployeeSalary> EmployeeSalaries { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

