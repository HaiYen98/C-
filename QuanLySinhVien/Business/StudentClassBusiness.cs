using QuanLySinhVien.DataAccess;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Business;

public sealed class StudentClassBusiness
{
    private readonly StudentClassDataAccess _dataAccess = new();

    public IReadOnlyList<StudentClass> GetAll() => _dataAccess.GetAll();

    public StudentClass? GetById(string id) => _dataAccess.GetById(id);
}
