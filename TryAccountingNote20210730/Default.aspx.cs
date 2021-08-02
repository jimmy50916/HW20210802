using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryAccountingNote20210730.SystemAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtAccountquantity.Enabled = false;
            this.txtFirstaccount.Enabled = false;
            this.txtLastaccount.Enabled = false;
            this.txtUserquantity.Enabled = false;
            this.txtFirstaccount.Text = AccountingManager.GetFirstAccounting()["CreateDate"].ToString();
            this.txtLastaccount.Text = AccountingManager.GetLastAccounting()["CreateDate"].ToString();
            this.txtAccountquantity.Text = AccountingManager.GetAccountingQuantity()["AccoutingCount"].ToString();
            this.txtUserquantity.Text = AccountingManager.GetUserQuantity()["UserCount"].ToString();

        }
    }
}