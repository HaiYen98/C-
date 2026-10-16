using QuanLySinhVien.Models;

namespace QuanLySinhVien.DataAccess;

public sealed class StudentClassDataAccess
{
    public IReadOnlyList<StudentClass> GetAll() => DataList.Classes.ToList();

    public StudentClass? GetById(string id) =>
        DataList.Classes.FirstOrDefault(item => string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));

    public bool Add(StudentClass studentClass)
    {
        if (GetById(studentClass.Id) is not null)
        {
            return false;
        }

        DataList.Classes.Add(studentClass);
        return true;
    }

    public bool Update(StudentClass studentClass)
    {
        var index = DataList.Classes.FindIndex(item =>
            string.Equals(item.Id, studentClass.Id, StringComparison.OrdinalIgnoreCase));
        if (index < 0)
        {
            return false;
        }

        DataList.Classes[index] = studentClass;
        return true;
    }

    public bool Delete(string id)
    {
        var studentClass = GetById(id);
        return studentClass is not null && DataList.Classes.Remove(studentClass);
    }
}
