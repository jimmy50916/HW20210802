using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccountingNote.Auth
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID], [Account], [PWD], [Name], [Email] , [CreateDate] , [UserLevel]
                    FROM UserInfo
                    WHERE [Account] = @account
                ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static DataRow GetUserInfoByUID(string userid)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID], [Account], [PWD], [Name], [Email] , [CreateDate] , [UserLevel]
                    FROM UserInfo
                    WHERE [ID] = @uid
                ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@uid", userid));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static bool UpdateUserPWD(string PWD, string ID)  //更改密碼
        {

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [Userinfo]
                    SET
                     PWD = @pwd
                    WHERE 
                     ID = @id;
                 ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@pwd", PWD));
            paramList.Add(new SqlParameter("@id", ID));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

        /// <summary> 新增使用者 預設密碼0000 </summary>
        /// <param name="userAcc"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        /// <param name="userLevel"></param>
        public static void CreateUserInfo(string userAcc, string userName, string userEmail, int userLevel)
        {
            // <<<<< check input >>>>>
            //check  no same account in db


            // <<<<< check input >>>>>

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO [dbo].[UserInfo]
                    (
                        [ID]
                        ,[Account]
                        ,[PWD]
                        ,[Name]
                        ,[Email]
                        ,[UserLevel]
                        ,[CreateDate]
                    )
                    VALUES
                    (
                        NEWID()
                        ,@userAcc
                        ,'0000'
                        ,@userName
                        ,@userEmail
                        ,@userLevel
                        ,@createDate
                    ) ";


            // connect db & execute

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userAcc", userAcc));
            paramList.Add(new SqlParameter("@userName", userName));
            paramList.Add(new SqlParameter("@userEmail", userEmail));
            paramList.Add(new SqlParameter("@userLevel", userLevel));
            paramList.Add(new SqlParameter("@createDate", DateTime.Now));
            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        /// <summary> 根據userID變更使用者名稱與信箱 </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="userEmail"></param>
        public static bool UpdateUserInfo(string userID, string userName, string userEmail)
        {
            // <<<<< check input >>>>>

            // <<<<< check input >>>>>

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET
                         [Name]           = @userName,
                         [Email]          = @userEmail

                    WHERE 
                        ID = @userid ";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userName", userName));
            paramList.Add(new SqlParameter("@userEmail", userEmail));
            paramList.Add(new SqlParameter("@userid", userID));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        /// <summary> 刪除帳號 </summary>
        /// <param name="userID"></param>
        public static void DeleteInfo(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE [UserInfo]
                    WHERE ID = @userid ";


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@userid", userID));


            try
            {
                DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
    }
}
