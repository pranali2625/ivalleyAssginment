public interface  IEmployeeService
{
   
    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
   
    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    

    public async Task AddEmployeeAsync(EmployeeDto employeeDto)
  

    public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
   

    public async Task DeleteEmployeeAsync(int id)
  
}
