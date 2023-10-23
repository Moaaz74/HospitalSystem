using HospitalSystem.Models;
using HospitalSystem.Repositories.Interfaces;
using HospitalSystem.Utilities;

namespace HospitalSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDepartment(Department department)
        {
            _unitOfWork.Repository<Department>().Add(department);
            _unitOfWork.Save();
        }

        public void DeleteDepartment(int DepartmentId)
        {
            Department dept = _unitOfWork.Repository<Department>().GetById(DepartmentId);
            _unitOfWork.Repository<Department>().Delete(dept);
            _unitOfWork.Save();
        }

        public PagedResult<Department> GetAll(int PageNumber, int PageSize)
        {
            int totalCount = 0;
            List<Department> Departments = new List<Department>();
            try
            {
                int ExcludedRecords = (PageSize * PageNumber) - PageSize;

                Departments = _unitOfWork.Repository<Department>().GetAll()
                    .Skip(ExcludedRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.Repository<Department>().GetAll().ToList().Count;


            }catch(Exception ex) { throw; }

            PagedResult<Department> result = new PagedResult<Department>()
            {
                Data = Departments,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return result;
        }

        public Department GetDepartmentById(int DepartmentId)
        {
            return _unitOfWork.Repository<Department>().GetById(DepartmentId);
        }

        public void UpdateDepartment(Department Department)
        {
            Department dept = _unitOfWork.Repository<Department>().GetById(Department.Id);
            dept.Name = Department.Name;
            dept.Description = Department.Description;
            dept.Type = Department.Type;
            dept.Employees = Department.Employees;
            _unitOfWork.Repository<Department>().Update(dept);
            _unitOfWork.Save();
        }
    }
}
