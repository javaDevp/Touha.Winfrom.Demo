using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Touha.SSO.Client1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public async Task<ActionResult> Login()
        {
            var tokenID = Request["TokenID"];
            if (!string.IsNullOrEmpty(tokenID))
            {
                using (HttpClient http = new HttpClient())
                {
                    //验证Tokend是否有效
                    var isValid = await http.GetStringAsync("http://localhost:8018/Home/TokenIdIsValid?tokenId=" + tokenID);
                    if (bool.Parse(isValid.ToString()))
                    {
                        if (!Tokens.Contains(tokenId))
                        {
                            //记录登录过的Client (主要是为了可以统一登出)
                            Tokens.Add(tokenId);
                        }
                        Session["token"] = tokenId;
                    }
                }
            }
        }
    }
}