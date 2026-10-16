using QuanLySinhVien.Models;

namespace QuanLySinhVien.DataAccess;

public static class DataList
{
    public static List<StudentClass> Classes { get; } =
    [
        new StudentClass { Id = "CNTT1", Name = "Công nghệ thông tin 1" },
        new StudentClass { Id = "CNTT2", Name = "Công nghệ thông tin 2" },
        new StudentClass { Id = "QTKD1", Name = "Quản trị kinh doanh 1" }
    ];

    public static List<Student> Students { get; } =
    [
        new Student
        {
            Id = "SV001",
            FullName = "Nguyễn An",
            DateOfBirth = new DateTime(2005, 4, 12),
            Email = "an.nguyen@example.com",
            Phone = "0912345678",
            Gender = "Nam",
            ClassId = "CNTT1",
            Score = 8.5m,
            Status = "Đang học"
        },
        new Student
        {
            Id = "SV002",
            FullName = "Trần Bình",
            DateOfBirth = new DateTime(2005, 9, 3),
            Email = "binh.tran@example.com",
            Phone = "0987654321",
            Gender = "Nữ",
            ClassId = "CNTT2",
            Score = 7.5m,
            Status = "Đang học"
        }
    ];

    static DataList()
    {
        foreach (var student in Students)
        {
            student.Class = Classes.FirstOrDefault(studentClass =>
                string.Equals(studentClass.Id, student.ClassId, StringComparison.OrdinalIgnoreCase));
            student.Class?.Students.Add(student);
        }
    }
}
