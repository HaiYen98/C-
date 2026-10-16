using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models;

public sealed class StudentClass
{
    [Required(ErrorMessage = "Vui lòng nhập mã lớp.")]
    [StringLength(20, ErrorMessage = "Mã lớp không được vượt quá 20 ký tự.")]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên lớp.")]
    [StringLength(100, ErrorMessage = "Tên lớp không được vượt quá 100 ký tự.")]
    public string Name { get; set; } = string.Empty;

    public List<Student> Students { get; set; } = [];

    public bool IsValid(out List<ValidationResult> validationResults)
    {
        validationResults = [];
        return Validator.TryValidateObject(this, new ValidationContext(this), validationResults, validateAllProperties: true);
    }

    public override string ToString() => Name;
}
