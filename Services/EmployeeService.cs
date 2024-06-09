public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await _unitOfWork.Employees.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task AddEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _unitOfWork.Employees.AddAsync(employee);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        _unitOfWork.Employees.Update(employee);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(id);
        _unitOfWork.Employees.Remove(employee);
        await _unitOfWork.CompleteAsync();
    }
}
