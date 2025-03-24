// Models/UserModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SteelAdmin.Shared
{
    /// <summary>
    /// โมเดลข้อมูลผู้ใช้งานระบบ
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// รหัสผู้ใช้
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// ชื่อผู้ใช้สำหรับเข้าสู่ระบบ
        /// </summary>
        [Required(ErrorMessage = "กรุณาระบุชื่อผู้ใช้")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "ชื่อผู้ใช้ต้องมีความยาวระหว่าง 4-50 ตัวอักษร")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// รหัสผ่าน (ใช้เฉพาะตอนสร้างหรือแก้ไขรหัสผ่าน)
        /// </summary>
        [Required(ErrorMessage = "กรุณาระบุรหัสผ่าน")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// ชื่อ-นามสกุลของผู้ใช้
        /// </summary>
        [Required(ErrorMessage = "กรุณาระบุชื่อ-นามสกุล")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// อีเมลของผู้ใช้
        /// </summary>
        [Required(ErrorMessage = "กรุณาระบุอีเมล")]
        [EmailAddress(ErrorMessage = "รูปแบบอีเมลไม่ถูกต้อง")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// เบอร์โทรศัพท์
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// ตำแหน่งงาน
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// แผนก
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// บทบาทของผู้ใช้
        /// </summary>
        [Required(ErrorMessage = "กรุณาเลือกบทบาท")]
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// รายการบทบาททั้งหมดของผู้ใช้
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();

        /// <summary>
        /// รายการสิทธิ์ของผู้ใช้
        /// </summary>
        public List<string> Permissions { get; set; } = new List<string>();

        /// <summary>
        /// สถานะการเปิดใช้งาน
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// สถานะการล็อคบัญชี
        /// </summary>
        public bool IsLocked { get; set; } = false;

        /// <summary>
        /// วันที่เข้าสู่ระบบล่าสุด
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// ที่อยู่ IP ที่เข้าสู่ระบบล่าสุด
        /// </summary>
        public string LastLoginIp { get; set; } = string.Empty;

        /// <summary>
        /// วันที่ผู้ใช้สร้าง
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// ผู้ที่สร้างผู้ใช้นี้
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// วันที่แก้ไขล่าสุด
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// ผู้ที่แก้ไขล่าสุด
        /// </summary>
        public string ModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// หมายเหตุหรือข้อมูลเพิ่มเติม
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// URL รูปโปรไฟล์
        /// </summary>
        public string ProfileImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// จำนวนครั้งที่เข้าสู่ระบบล้มเหลว
        /// </summary>
        public int FailedLoginAttempts { get; set; } = 0;

        /// <summary>
        /// ตัวเลือกการแจ้งเตือน
        /// </summary>
        public UserNotificationPreference NotificationPreference { get; set; } = new UserNotificationPreference();
    }

    /// <summary>
    /// การตั้งค่าการแจ้งเตือนของผู้ใช้
    /// </summary>
    public class UserNotificationPreference
    {
        /// <summary>
        /// แจ้งเตือนทางอีเมล
        /// </summary>
        public bool EmailNotification { get; set; } = true;

        /// <summary>
        /// แจ้งเตือนในระบบ
        /// </summary>
        public bool SystemNotification { get; set; } = true;

        /// <summary>
        /// แจ้งเตือนเมื่อมีคำสั่งซื้อใหม่
        /// </summary>
        public bool NotifyOnNewOrder { get; set; } = true;

        /// <summary>
        /// แจ้งเตือนเมื่อสินค้าใกล้หมด
        /// </summary>
        public bool NotifyOnLowStock { get; set; } = true;

        /// <summary>
        /// แจ้งเตือนเมื่อมีการเปลี่ยนแปลงสถานะคำสั่งซื้อ
        /// </summary>
        public bool NotifyOnOrderStatusChange { get; set; } = true;
    }

    /// <summary>
    /// โมเดลสำหรับการแสดงข้อมูลผู้ใช้ในรายการ
    /// </summary>
    public class UserListModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }

    /// <summary>
    /// โมเดลสำหรับการเปลี่ยนรหัสผ่าน
    /// </summary>
    public class ChangeUserPasswordModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "กรุณาระบุรหัสผ่านใหม่")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณายืนยันรหัสผ่านใหม่")]
        [Compare("NewPassword", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public bool RequirePasswordChange { get; set; } = false;
    }

    /// <summary>
    /// โมเดลสำหรับการค้นหาผู้ใช้
    /// </summary>
    public class UserSearchModel
    {
        public string SearchText { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SortBy { get; set; } = "Username";
        public bool SortAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}