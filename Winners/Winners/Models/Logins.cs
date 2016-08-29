using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Winners.Models
{
    public class Logins
    {
        public int ID { get; set; }
        [Display(Name ="User Name")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string Fname { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string Lname { get; set; }
        [MaxLength]
        public string HASH { get; set; }
        [MaxLength]
        public byte[] SALT { set; get; }
        public DateTime DateTimeCreated { get; set; }

    }
}