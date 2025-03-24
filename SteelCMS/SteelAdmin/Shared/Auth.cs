// Models/AuthModels.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class AuthState
    {
        public bool IsAuthenticated { get; set; } = false;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Permissions { get; set; } = new List<string>();
        public DateTime TokenExpiration { get; set; }
    }

    public class AuthResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpiration { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Permissions { get; set; } = new List<string>();
    }

    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }

    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "กรุณาระบุชื่อผู้ใช้")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุรหัสผ่าน")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "กรุณาระบุรหัสผ่านปัจจุบัน")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุรหัสผ่านใหม่")]
        [MinLength(8, ErrorMessage = "รหัสผ่านต้องมีความยาวอย่างน้อย 8 ตัวอักษร")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณายืนยันรหัสผ่านใหม่")]
        [Compare("NewPassword", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class RoleModel
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "กรุณาระบุชื่อบทบาท")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุคำอธิบาย")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsSystemRole { get; set; } = false;
    }

    public class PermissionModel
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "กรุณาระบุชื่อสิทธิ์")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุคำอธิบาย")]
        public string Description { get; set; } = string.Empty;

        public string Group { get; set; } = string.Empty;
        public bool IsSystemPermission { get; set; } = false;
    }

    public class RolePermissionModel
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; } = string.Empty;
        public string PermissionDescription { get; set; } = string.Empty;
        public bool HasPermission { get; set; }
    }