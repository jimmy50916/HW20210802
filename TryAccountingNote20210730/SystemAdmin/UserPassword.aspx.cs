using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TryAccountingNote20210730.SystemAdmin
{
    public partial class UserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined()) //檢查是否登入
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                             // 如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

        }

        protected void ChangePWD_Click(object sender, EventArgs e)
        {
            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            string userPWD = currentUser.PWD;
            if (txtPWD.Text == userPWD) //確認使用者密碼
            {
                if (txtNewPWD.Text.Length >= 8 && txtNewPWD.Text.Length <= 16) //新密碼是否為8~16長度
                {
                    if (txtNewPWD.Text != txtCheckPWD.Text) //確認新密碼是否正確
                    {
                        this.ltlMsgPWD.Text = "plz input same password";
                    }
                    else
                    {
                        if (currentUser == null) // 如果帳號不存在，導至登入頁
                        {
                            Response.Redirect("/Login.aspx");
                            return;
                        }

                        string userID = currentUser.ID;
                        string pwd = this.txtNewPWD.Text;
                        UserInfoManager.UpdateUserPWD(pwd, userID); //更改密碼
                    }
                }
                else
                {
                    this.ltlMsgPWD.Text = "new password's length must between 8~16";
                }
            }
            else
            {
                this.ltlMsgPWD.Text = "plz input right password";
                return;
            }

        }
    }
}