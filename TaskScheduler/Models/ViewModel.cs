using System;
using System.ComponentModel.DataAnnotations;

namespace TaskScheduler.ViewModel
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string PasswordConfirm { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }

    public class ChangeModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }

    //public class TaskViewModel
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Название")]
    //    public string Name { get; set; }

    //    [Display(Name = "Описание")]
    //    public string Description { get; set; }

    //    public int? Priority { get; set; }

    //    [Display(Name = "Дата окончания")]
    //    public DateTime? ExpirationDate { get; set; }
    //}
}