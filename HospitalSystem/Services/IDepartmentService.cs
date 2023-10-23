using HospitalSystem.Models;
using HospitalSystem.Utilities;

namespace HospitalSystem.Services
{
    public interface IDepartmentService
    {
        PagedResult<Department> GetAll(int PageNumber, int PageSize);

        Department GetDepartmentById(int DepartmentId);

        void AddDepartment (Department department);

        void UpdateDepartment (Department Department);

        void DeleteDepartment (int DepartmentId);

    }
}
