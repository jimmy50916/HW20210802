using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryAccountingNote20210730.SystemAdmin
{
	public partial class UserDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            // check is logined
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["UserLoginInfo"] as string;
            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                             // 如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            if (!this.IsPostBack)
            {
                // Check is create mode or edit mode
                if (this.Request.QueryString["UID"] == null)
                {
                    this.btnDeleteUserInfo.Visible = false;
                    this.btnEditUserPassword.Visible = false;
                    this.lblCreatedDate.Text = DateTime.Now.ToString();
                }
                else
                {
                    this.btnDeleteUserInfo.Visible = true;
                    this.txtAccount.Enabled = false;
                    this.ddlUserLevel.Enabled = false;

                    string idText = this.Request.QueryString["UID"];
                    if (UserInfoManager.GetUserInfoByUID(idText).ToString() != string.Empty)
                    {
                        var drUserInfo = UserInfoManager.GetUserInfoByUID(idText);

                        if (drUserInfo == null)
                        {
                            this.ltUserDetailMsg.Text = "Data doesn't exist";
                            this.btnSaveUserInfo.Visible = false;
                            this.btnDeleteUserInfo.Visible = false;
                        }
                        else
                        {
                            this.txtAccount.Text = drUserInfo["Account"].ToString();
                            this.txtUserName.Text = drUserInfo["Name"].ToString();
                            this.txtUserEmail.Text = drUserInfo["Email"].ToString();
                            this.ddlUserLevel.Text = drUserInfo["UserLevel"].ToString();
                            this.lblCreatedDate.Text = drUserInfo["CreateDate"].ToString();
                        }
                    }
                    else
                    {
                        this.ltUserDetailMsg.Text = "ID is required.";
                        this.btnSaveUserInfo.Visible = false;
                        this.btnDeleteUserInfo.Visible = false;

                    }
                }
            }
        }
        protected void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltUserDetailMsg.Text = string.Join("<br/>", msgList);
                return;
            }


            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string userID = this.Request.QueryString["UID"]?.ToString();
            string accountText = this.txtAccount.Text;
            string nameText = this.txtUserName.Text;
            string emailText = this.txtUserEmail.Text;
            string userLevelText = this.ddlUserLevel.SelectedValue.ToString();
            

            int userLevel = Convert.ToInt32(userLevelText);

            string idText = this.Request.QueryString["UID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                // Execute 'insert db UserInfo table'
                UserInfoManager.CreateUserInfo(accountText, nameText, emailText, userLevel);
            }
            else
            {
                if (UserInfoManager.GetUserInfoByUID(userID) != null)
                {
                    // Execute 'update db'
                    UserInfoManager.UpdateUserInfo(userID, nameText, emailText);
                }
            }

            Response.Redirect("/SystemAdmin/UserList.aspx");
        }
        protected void btnDeleteUserInfo_Click(object sender, EventArgs e)
        {
            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string userID = this.Request.QueryString["UID"].ToString();
            UserInfoManager.DeleteInfo(userID);

  

            string idText = this.Request.QueryString["UID"];


            Response.Redirect("/SystemAdmin/UserList.aspx");
        }
        protected void btnEditUserPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/SystemAdmin/UserPassword.aspx?UID={this.Request.QueryString.ToString()}");
        }
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // UserLevel Check
            if (this.ddlUserLevel.SelectedValue != "0" &&
                this.ddlUserLevel.SelectedValue != "1")
            {
                msgList.Add("UserLevel must be 0 or 1.");
            }
            //UserAccount isnull check
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
                msgList.Add("UserAccount is required");
            //UserName isnull check
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
                msgList.Add("UserName is required");
            //Email isnull check
            if (string.IsNullOrWhiteSpace(this.txtUserEmail.Text))
                msgList.Add("Email is required");

            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }
    }
}