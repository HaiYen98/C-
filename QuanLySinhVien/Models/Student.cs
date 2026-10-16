using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLySinhVien.Models;

public sealed class Student
{
    [Required(ErrorMessage = "Vui lòng nhập mã sinh viên.")]
    [StringLength(20, ErrorMessage = "Mã sinh viên không được vượt quá 20 ký tự.")]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
    [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
    public string FullName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập email.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [StringLength(254, ErrorMessage = "Email không được vượt quá 254 ký tự.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
    [RegularExpression("^[0-9]{9,11}$", ErrorMessage = "Số điện thoại phải gồm 9 đến 11 chữ số.")]
    public string Phone { get; set; } = string.Empty;

    [StringLength(10)]
    public string Gender { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn lớp học.")]
    [StringLength(20)]
    public string ClassId { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "10", ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.")]
    public decimal Score { get; set; }

    [StringLength(30)]
    public string Status { get; set; } = string.Empty;

    [ForeignKey(nameof(ClassId))]
    public StudentClass? Class { get; set; }

    public string ClassName => Class?.Name ?? string.Empty;

    public bool IsValid(out List<ValidationResult> validationResults)
    {
        validationResults = [];
        return Validator.TryValidateObject(this, new ValidationContext(this), validationResults, validateAllProperties: true);
    }
}
