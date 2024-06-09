public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<EmployeeSalary>()
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
    }
}
