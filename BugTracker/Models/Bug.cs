using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Bug
    {
        [Key]
        [DisplayName("Bug Track Id")]
        public int BugTrackId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bug Title")]
        [Required(ErrorMessage = "This field is required.")]
        public string BugName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Bug Description")]
        [Required(ErrorMessage = "This field is required.")]
        public string BugDescription { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Priority")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only.")]
        public string Priority { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        [DisplayName("Date Filed")]
        public DateTime DateFiled { get; set; }
    }
}
