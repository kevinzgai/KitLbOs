using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;
namespace Kit.DAL
{
    /// <summary>
    /// 数据访问类:KlableroleBase
    /// </summary>
    public partial class KlableroleBase
    {
        public KlableroleBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Lid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KlableroleBase");
            strSql.Append(" where Lid=@Lid");
            SqlParameter[] parameters = {
                    new SqlParameter("@Lid", SqlDbType.Int,4)
            };
            parameters[0].Value = Lid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kit.Model.KlableroleBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KlableroleBase(");
            strSql.Append("Lname,Lcontent,Lcontentsate,Llabletypeid,Llabletypename,LlableImg,Llableloopid,Llableloopname,LProductid,Ltime)");
            strSql.Append(" values (");
            strSql.Append("@Lname,@Lcontent,@Lcontentsate,@Llabletypeid,@Llabletypename,@LlableImg,@Llableloopid,@Llableloopname,@LProductid,@Ltime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Lname", SqlDbType.NVarChar,200),
                    new SqlParameter("@Lcontent", SqlDbType.NVarChar,250),
                    new SqlParameter("@Lcontentsate", SqlDbType.Text),
                    new SqlParameter("@Llabletypeid", SqlDbType.NChar,10),
                    new SqlParameter("@Llabletypename", SqlDbType.NVarChar,200),
                    new SqlParameter("@LlableImg", SqlDbType.NVarChar,200),
                    new SqlParameter("@Llableloopid", SqlDbType.Int,4),
                    new SqlParameter("@Llableloopname", SqlDbType.NVarChar,200),
                    new SqlParameter("@LProductid", SqlDbType.Int,4),
                    new SqlParameter("@Ltime", SqlDbType.DateTime)};
            parameters[0].Value = model.Lname;
            parameters[1].Value = model.Lcontent;
            parameters[2].Value = model.Lcontentsate;
            parameters[3].Value = model.Llabletypeid;
            parameters[4].Value = model.Llabletypename;
            parameters[5].Value = model.LlableImg;
            parameters[6].Value = model.Llableloopid;
            parameters[7].Value = model.Llableloopname;
            parameters[8].Value = model.LProductid;
            parameters[9].Value = model.Ltime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Kit.Model.KlableroleBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KlableroleBase set ");
            strSql.Append("Lname=@Lname,");
            strSql.Append("Lcontent=@Lcontent,");
            strSql.Append("Lcontentsate=@Lcontentsate,");
            strSql.Append("Llabletypeid=@Llabletypeid,");
            strSql.Append("Llabletypename=@Llabletypename,");
            strSql.Append("LlableImg=@LlableImg,");
            strSql.Append("Llableloopid=@Llableloopid,");
            strSql.Append("Llableloopname=@Llableloopname,");
            strSql.Append("LProductid=@LProductid,");
            strSql.Append("Ltime=@Ltime");
            strSql.Append(" where Lid=@Lid");
            SqlParameter[] parameters = {
                    new SqlParameter("@Lname", SqlDbType.NVarChar,200),
                    new SqlParameter("@Lcontent", SqlDbType.NVarChar,250),
                    new SqlParameter("@Lcontentsate", SqlDbType.Text),
                    new SqlParameter("@Llabletypeid", SqlDbType.NChar,10),
                    new SqlParameter("@Llabletypename", SqlDbType.NVarChar,200),
                    new SqlParameter("@LlableImg", SqlDbType.NVarChar,200),
                    new SqlParameter("@Llableloopid", SqlDbType.Int,4),
                    new SqlParameter("@Llableloopname", SqlDbType.NVarChar,200),
                    new SqlParameter("@LProductid", SqlDbType.Int,4),
                    new SqlParameter("@Ltime", SqlDbType.DateTime),
                    new SqlParameter("@Lid", SqlDbType.Int,4)};
            parameters[0].Value = model.Lname;
            parameters[1].Value = model.Lcontent;
            parameters[2].Value = model.Lcontentsate;
            parameters[3].Value = model.Llabletypeid;
            parameters[4].Value = model.Llabletypename;
            parameters[5].Value = model.LlableImg;
            parameters[6].Value = model.Llableloopid;
            parameters[7].Value = model.Llableloopname;
            parameters[8].Value = model.LProductid;
            parameters[9].Value = model.Ltime;
            parameters[10].Value = model.Lid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Lid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KlableroleBase ");
            strSql.Append(" where Lid=@Lid");
            SqlParameter[] parameters = {
                    new SqlParameter("@Lid", SqlDbType.Int,4)
            };
            parameters[0].Value = Lid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Lidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KlableroleBase ");
            strSql.Append(" where Lid in (" + Lidlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kit.Model.KlableroleBase GetModel(int Lid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Lid,Lname,Lcontent,Lcontentsate,Llabletypeid,Llabletypename,LlableImg,Llableloopid,Llableloopname,LProductid,Ltime from KlableroleBase ");
            strSql.Append(" where Lid=@Lid");
            SqlParameter[] parameters = {
                    new SqlParameter("@Lid", SqlDbType.Int,4)
            };
            parameters[0].Value = Lid;

            Kit.Model.KlableroleBase model = new Kit.Model.KlableroleBase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kit.Model.KlableroleBase DataRowToModel(DataRow row)
        {
            Kit.Model.KlableroleBase model = new Kit.Model.KlableroleBase();
            if (row != null)
            {
                if (row["Lid"] != null && row["Lid"].ToString() != "")
                {
                    model.Lid = int.Parse(row["Lid"].ToString());
                }
                if (row["Lname"] != null)
                {
                    model.Lname = row["Lname"].ToString();
                }
                if (row["Lcontent"] != null)
                {
                    model.Lcontent = row["Lcontent"].ToString();
                }
                if (row["Lcontentsate"] != null)
                {
                    model.Lcontentsate = row["Lcontentsate"].ToString();
                }
                if (row["Llabletypeid"] != null)
                {
                    model.Llabletypeid = row["Llabletypeid"].ToString();
                }
                if (row["Llabletypename"] != null)
                {
                    model.Llabletypename = row["Llabletypename"].ToString();
                }
                if (row["LlableImg"] != null)
                {
                    model.LlableImg = row["LlableImg"].ToString();
                }
                if (row["Llableloopid"] != null && row["Llableloopid"].ToString() != "")
                {
                    model.Llableloopid = int.Parse(row["Llableloopid"].ToString());
                }
                if (row["Llableloopname"] != null)
                {
                    model.Llableloopname = row["Llableloopname"].ToString();
                }
                if (row["LProductid"] != null && row["LProductid"].ToString() != "")
                {
                    model.LProductid = int.Parse(row["LProductid"].ToString());
                }
                if (row["Ltime"] != null && row["Ltime"].ToString() != "")
                {
                    model.Ltime = DateTime.Parse(row["Ltime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Lid,Lname,Lcontent,Lcontentsate,Llabletypeid,Llabletypename,LlableImg,Llableloopid,Llableloopname,LProductid,Ltime ");
            strSql.Append(" FROM KlableroleBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Lid,Lname,Lcontent,Lcontentsate,Llabletypeid,Llabletypename,LlableImg,Llableloopid,Llableloopname,LProductid,Ltime ");
            strSql.Append(" FROM KlableroleBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM KlableroleBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Lid desc");
            }
            strSql.Append(")AS Row, T.*  from KlableroleBase T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "KlableroleBase";
			parameters[1].Value = "Lid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

