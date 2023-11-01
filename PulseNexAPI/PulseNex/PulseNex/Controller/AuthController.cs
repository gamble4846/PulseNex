using Microsoft.AspNetCore.Mvc;
using PulseNex.Helpers;
using PulseNex.Main;
using PulseNex.Model;
using static PulseNex.Model.APIResponse;

namespace PulseNex.Controller
{
    public class AuthController : BaseController
    {
        public AuthController()
        {
        }

        [HttpGet]
        [Route("Auth/CheckIfUserAlreadyExists")]
        public ActionResult CheckIfUserAlreadyExists()
        {
            try
            {
                if (AuthHelper.CheckIfUserAlreadyExists())
                {
                    return Ok(new APIResponse(ResponseCode.ERROR, "User Exists", true));
                }
                else
                {
                    return Ok(new APIResponse(ResponseCode.ERROR, "User Does Not Exist", false));
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(ResponseCode.ERROR, ex.Message, ex));
            }
        }

        [HttpPost]
        [Route("Auth/RegisterUser")]
        public ActionResult RegisterUser(LoginModel model)
        {
            try
            {
                if (AuthHelper.CheckIfUserAlreadyExists())
                    return Ok(new APIResponse(ResponseCode.ERROR, "User Exist Cant Create New User", null));

                bool RegisterFlag = AuthHelper.RegisterUser(model);
                if(!RegisterFlag)
                    return Ok(new APIResponse(ResponseCode.ERROR, "Error Registering", null));

                bool LoginFlag = AuthHelper.LoginUser(model);
                if(!LoginFlag)
                    return Ok(new APIResponse(ResponseCode.ERROR, "Register Completed, Error while Logining user back", null));

                string Token = AuthHelper.CreateJWTToken(model);
                return Ok(new APIResponse(ResponseCode.SUCCESS, "Register Completed", Token));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(ResponseCode.ERROR,ex.Message, ex));
            }
        }

        [HttpPost]
        [Route("Auth/LoginUser")]
        public ActionResult LoginUser(LoginModel model)
        {
            try
            {
                bool LoginFlag = AuthHelper.LoginUser(model);
                if (!LoginFlag)
                    return Ok(new APIResponse(ResponseCode.ERROR, "Login Failed", null));

                string Token = AuthHelper.CreateJWTToken(model);
                return Ok(new APIResponse(ResponseCode.SUCCESS, "Login Completed", Token));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse(ResponseCode.ERROR, ex.Message, ex));
            }
        }
    }
}
