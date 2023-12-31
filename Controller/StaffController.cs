using backend.Helper;
using backend.Input;
using backend.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        StaffHelper staffHelper;
        public StaffController(StaffHelper staffHelper)
        {
            this.staffHelper = staffHelper;
        }


        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get(string data)
        {
            try
            {
                
                var objJSON = new MsStaffOutput();
                objJSON = staffHelper.getStaffByID(data);

                return new OkObjectResult(objJSON);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("insert")]
        [Produces("application/json")]
        public IActionResult insert(StaffInput data)
        {
            try
            {
                var objJSON = new StatusCode();
                objJSON = staffHelper.insertStaff(data);


                return new OkObjectResult(objJSON);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        [Produces("application/json")]
        public IActionResult update(StaffInput data)
        {
            try
            {
                var objJSON = new StatusCode();
                objJSON = staffHelper.updateStaff(data);

                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        [Produces("application/json")]
        public IActionResult delete(string staffID)
        {
            try
            {
                var objJSON = new StatusCode();
                objJSON = staffHelper.deleteStaff(staffID);

                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
