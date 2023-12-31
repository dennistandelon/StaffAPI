namespace backend.Output
{
    public class MsStaffOutput
    {
        public List<Staff> staffs { get; set; }
        public MsStaffOutput()
        {
            staffs = new List<Staff>();
        }
    }

    public class Staff {
        public string picture { get; set; }
        public string staffName { get; set; }
        public string staffID { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }

}
