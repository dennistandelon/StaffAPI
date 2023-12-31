using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model.StaffDB
{
    public class MsStaff
    {
        public string picture { get; set; }
        public string staffName { get; set; }

        [Key]
        public string staffID { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
