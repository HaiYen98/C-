using QuanLySinhVien.DataAccess;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Business;

public sealed class StudentBusiness
{
    private readonly StudentDataAccess _studentDataAccess = new();
    private readonly StudentClassDataAccess _classDataAccess = new();

    public IReadOnlyList<Student> GetAll() => _studentDataAccess.GetAll();

    public IReadOnlyList<Student> GetByClassId(string classId) => _studentDataAccess.GetByClassId(classId);

    public Student? GetById(string id) => _studentDataAccess.GetById(id);

    public bool Add(Student student, out Dictionary<string, string> errors)
    {
        errors = Validate(student);
        if (errors.Count == 0 && _studentDataAccess.GetById(student.Id) is not null)
        {
            errors[nameof(Student.Id)] = "Mã sinh viên đã tồn tại.";
        }

        return errors.Count == 0 && _studentDataAccess.Add(student);
    }

    public bool Update(Student student, out Dictionary<string, string> errors)
    {
        errors = Validate(student);
        if (errors.Count == 0 && _studentDataAccess.GetById(student.Id) is null)
        {
            errors[nameof(Student.Id)] = "Không tìm thấy sinh viên cần sửa.";
        }

        return errors.Count == 0 && _studentDataAccess.Update(student);
    }

    public bool Delete(string id) => _studentDataAccess.Delete(id);

    private Dictionary<string, string> Validate(Student student)
    {
        var errors = new Dictionary<string, string>();

        student.IsValid(out var validationResults);
        foreach (var validationResult in validationResults)
        {
            foreach (var memberName in validationResult.MemberNames)
            {
                errors.TryAdd(memberName, validationResult.ErrorMessage ?? "Giá trị không hợp lệ.");
            }
        }

        if (!string.IsNullOrWhiteSpace(student.ClassId) && _classDataAccess.GetById(student.ClassId) is null)
        {
            errors.TryAdd(nameof(Student.ClassId), "Lớp học không tồn tại.");
        }

        return errors;
    }
}
