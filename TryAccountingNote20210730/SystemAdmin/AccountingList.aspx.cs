﻿using AccountingNote.Auth;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is logined
            if (!AuthManager.IsLogined())
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

            // read accounting data
            var dt = AccountingManager.GetAccountingList(currentUser.ID);

            if (dt.Rows.Count > 0)  // check is empty data
            {
                this.gvAccountingList.DataSource = dt;
                this.gvAccountingList.DataBind();
            }
            else
            {
                this.gvAccountingList.Visible = false;
                this.plcNoData.Visible = true;
            }
            int TotalAmount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ActType"].ToString() == "1")
                {
                    TotalAmount += Convert.ToInt32(dr["Amount"]);
                }
                else
                {
                    TotalAmount -= Convert.ToInt32(dr["Amount"]);

                }
            }

            this.lblTotalAmount.Text = TotalAmount.ToString() + "元";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;
                Label lbl = row.FindControl("lblActType") as Label;

                var dr = row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");

                if (actType == 0)
                {
                    //ltl.Text = "支出";
                    lbl.Text = "支出";
                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }

                if (dr.Row.Field<int>("Amount") > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }
    }
}