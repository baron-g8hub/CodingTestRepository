using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XCompanyDashboard.Models
{

    [Table("Users")]
    public class User
    {
        public User()
        {
            // empty
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("User_ID")]
        public int UserId { get; set; }

        [Key]
        [StringLength(150)]
        public string Username { get; set; } = null!;


        public int UserType { get; set; } = 0;
        public string CompanyUid { get; set; }

     
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }


        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
