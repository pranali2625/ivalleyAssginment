public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeDto employeeDto)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.AddEmployeeAsync(employeeDto);
            return RedirectToAction(nameof(Index));
        }
        return View(employeeDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EmployeeDto employeeDto)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return RedirectToAction(nameof(Index));
        }
        return View(employeeDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
