using backend.Input;
using backend.Model.StaffDB;
using backend.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Helper
{
    public class StaffHelper
    {

        private StaffDBContext staffContext;
        public StaffHelper(StaffDBContext staffContext)
        {
            this.staffContext = staffContext;
        }

        public MsStaffOutput getStaffByID(string data)
        {

            try
            {
                var returnValue = new MsStaffOutput();

                var staffs = staffContext.MsStaff.ToList();

                var staffsbyId = staffs.Where(staff => staff.staffID.Contains(data)).ToList(); 
                var staffsbyName = staffs.Where(staff => staff.staffName.Contains(data)).ToList();

                if (staffsbyId != null && staffsbyId.Count > 0 )
                {
                    Console.WriteLine("Masuk Masuk By Id Setting");
                    returnValue = new MsStaffOutput{ staffs = staffsbyId.Select(staff => new Staff {
                        staffID = staff.staffID,
                        staffName = staff.staffName,
                        Address = staff.Address,
                        DOB = staff.DOB,
                        Email = staff.Email,
                        Gender = staff.Gender,
                        picture = staff.picture,
                        Position = staff.Position
                    }).ToList()};
                } else if(staffsbyName != null && staffsbyName.Count > 0)
                {
                    Console.WriteLine("Masuk Masuk By Name setting");
                    returnValue = new MsStaffOutput
                    {
                        staffs = staffsbyName.Select(staff => new Staff
                        {
                            staffID = staff.staffID,
                            staffName = staff.staffName,
                            Address = staff.Address,
                            DOB = staff.DOB,
                            Email = staff.Email,
                            Gender = staff.Gender,
                            picture = staff.picture,
                            Position = staff.Position
                        }).ToList()
                    };
                }
                
                return returnValue;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public StatusCode insertStaff(StaffInput data)
        {

            var returnValue = new StatusCode();
            try
            {

                staffContext.MsStaff.Add(new MsStaff
                {
                    staffID = data.staffID,
                    staffName = data.staffName,
                    Address = data.Address,
                    DOB = data.DOB,
                    Email = data.Email,
                    Gender = data.Gender,
                    picture = data.picture,
                    Position = data.Position
                });

                staffContext.SaveChanges();

                returnValue.code = 200;
                returnValue.message = "Success";

                return returnValue;
            }
            catch(Exception ex)
            {
                returnValue.code = 500;
                returnValue.message = ex.Message;

                return returnValue;
            }

        }

        public StatusCode updateStaff(StaffInput data)
        {

            var returnValue = new StatusCode();
            try
            {

                var staffs = staffContext.MsStaff.Where(staff => staff.staffID == data.staffID).FirstOrDefault();

                if(staffs == null)
                {
                    return new StatusCode{ code = 500, message = "Error" };
                }

                staffs.picture = data.picture;
                staffs.staffID = data.staffID; 
                staffs.staffName = data.staffName;
                staffs.Gender = data.Gender;
                staffs.DOB = data.DOB;
                staffs.Email = data.Email;
                staffs.Address = data.Address;
                staffs.Position = data.Position;

                staffContext.MsStaff.Update(staffs);

                staffContext.SaveChanges();

                returnValue.code = 200;
                returnValue.message = "Success";

                return returnValue;
            }
            catch (Exception ex)
            {
                returnValue.code = 500;
                returnValue.message = ex.Message;

                return returnValue;
            }

        }

        public StatusCode deleteStaff(string staffID)
        {

            var returnValue = new StatusCode();
            try
            {

                var staffs = staffContext.MsStaff.Where(staff => staff.staffID == staffID).FirstOrDefault();

                if (staffs == null)
                {
                    return new StatusCode { code = 500, message = "Error" };
                }

                staffContext.MsStaff.Remove(staffs);

                staffContext.SaveChanges();

                returnValue.code = 200;
                returnValue.message = "Success";

                return returnValue;
            }
            catch (Exception ex)
            {
                returnValue.code = 500;
                returnValue.message = ex.Message;

                return returnValue;
            }

        }

    }
}
