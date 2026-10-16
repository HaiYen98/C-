using QuanLySinhVien.Models;

namespace QuanLySinhVien.DataAccess;

public sealed class StudentDataAccess
{
    public IReadOnlyList<Student> GetAll() => DataList.Students.ToList();

    public Student? GetById(string id) =>
        DataList.Students.FirstOrDefault(item => string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));

    public IReadOnlyList<Student> GetByClassId(string classId) =>
        DataList.Students
            .Where(item => string.Equals(item.ClassId, classId, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public bool Add(Student student)
    {
        if (GetById(student.Id) is not null)
        {
            return false;
        }

        var studentClass = DataList.Classes.FirstOrDefault(item =>
            string.Equals(item.Id, student.ClassId, StringComparison.OrdinalIgnoreCase));
        if (studentClass is null)
        {
            return false;
        }

        student.Class = studentClass;
        student.ClassId = studentClass.Id;
        DataList.Students.Add(student);
        studentClass.Students.Add(student);
        return true;
    }

    public bool Update(Student student)
    {
        var index = DataList.Students.FindIndex(item =>
            string.Equals(item.Id, student.Id, StringComparison.OrdinalIgnoreCase));
        if (index < 0)
        {
            return false;
        }

        var studentClass = DataList.Classes.FirstOrDefault(item =>
            string.Equals(item.Id, student.ClassId, StringComparison.OrdinalIgnoreCase));
        if (studentClass is null)
        {
            return false;
        }

        DataList.Students[index].Class?.Students.Remove(DataList.Students[index]);
        student.Class = studentClass;
        student.ClassId = studentClass.Id;
        DataList.Students[index] = student;
        studentClass.Students.Add(student);
        return true;
    }

    public bool Delete(string id)
    {
        var student = GetById(id);
        if (student is null)
        {
            return false;
        }

        student.Class?.Students.Remove(student);
        return DataList.Students.Remove(student);
    }
}
