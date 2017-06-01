using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;//Please add references
namespace Kit.DAL
{
    /// <summary>
    /// 数据访问类:Ksystemset
    /// </summary>
    public partial class Ksystemset
    {
        public Ksystemset()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ksystemset");
            strSql.Append(" where Sid=@Sid");
            SqlParameter[] parameters = {
                new SqlParameter("@Sid", SqlDbType.Int,4)
            };
            parameters[0].Value = Sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kit.Model.Ksystemset model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ksystemset(");
            strSql.Append("Stype,Sname,Svalue,Skey1,Skey2)");
            strSql.Append(" values (");
            strSql.Append("@Stype,@Sname,@Svalue,@Skey1,@Skey2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@Stype", SqlDbType.NChar,10),
                new SqlParameter("@Sname", SqlDbType.NVarChar,50),
                new SqlParameter("@Svalue", SqlDbType.NVarChar,250),
                new SqlParameter("@Skey1", SqlDbType.NVarChar,250),
                new SqlParameter("@Skey2", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.Stype;
            parameters[1].Value = model.Sname;
            parameters[2].Value = model.Svalue;
            parameters[3].Value = model.Skey1;
            parameters[4].Value = model.Skey2;

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
        public bool Update(Kit.Model.Ksystemset model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ksystemset set ");
            strSql.Append("Stype=@Stype,");
            strSql.Append("Sname=@Sname,");
            strSql.Append("Svalue=@Svalue,");
            strSql.Append("Skey1=@Skey1,");
            strSql.Append("Skey2=@Skey2");
            strSql.Append(" where Sid=@Sid");
            SqlParameter[] parameters = {
                new SqlParameter("@Stype", SqlDbType.NChar,10),
                new SqlParameter("@Sname", SqlDbType.NVarChar,50),
                new SqlParameter("@Svalue", SqlDbType.NVarChar,250),
                new SqlParameter("@Skey1", SqlDbType.NVarChar,250),
                new SqlParameter("@Skey2", SqlDbType.NVarChar,250),
                new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = model.Stype;
            parameters[1].Value = model.Sname;
            parameters[2].Value = model.Svalue;
            parameters[3].Value = model.Skey1;
            parameters[4].Value = model.Skey2;
            parameters[5].Value = model.Sid;

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
        public bool Delete(int Sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ksystemset ");
            strSql.Append(" where Sid=@Sid");
            SqlParameter[] parameters = {
                new SqlParameter("@Sid", SqlDbType.Int,4)
            };
            parameters[0].Value = Sid;

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
        public bool DeleteList(string Sidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ksystemset ");
            strSql.Append(" where Sid in (" + Sidlist + ")  ");
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
        public Kit.Model.Ksystemset GetModel(int Sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Sid,Stype,Sname,Svalue,Skey1,Skey2 from Ksystemset ");
            strSql.Append(" where Sid=@Sid");
            SqlParameter[] parameters = {
                new SqlParameter("@Sid", SqlDbType.Int,4)
            };
            parameters[0].Value = Sid;

            Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
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
        public Kit.Model.Ksystemset DataRowToModel(DataRow row)
        {
            Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
            if (row != null)
            {
                if (row["Sid"] != null && row["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(row["Sid"].ToString());
                }
                if (row["Stype"] != null)
                {
                    model.Stype = row["Stype"].ToString();
                }
                if (row["Sname"] != null)
                {
                    model.Sname = row["Sname"].ToString();
                }
                if (row["Svalue"] != null)
                {
                    model.Svalue = row["Svalue"].ToString();
                }
                if (row["Skey1"] != null)
                {
                    model.Skey1 = row["Skey1"].ToString();
                }
                if (row["Skey2"] != null)
                {
                    model.Skey2 = row["Skey2"].ToString();
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
            strSql.Append("select Sid,Stype,Sname,Svalue,Skey1,Skey2 ");
            strSql.Append(" FROM Ksystemset ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表(字段排序)
        /// </summary>
        public DataSet GetList(string strWhere,string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Sid,Stype,Sname,Svalue,Skey1,Skey2 ");
            strSql.Append(" FROM Ksystemset ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + orderby);
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
            strSql.Append(" Sid,Stype,Sname,Svalue,Skey1,Skey2 ");
            strSql.Append(" FROM Ksystemset ");
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
            strSql.Append("select count(1) FROM Ksystemset ");
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
                strSql.Append("order by T.Sid desc");
            }
            strSql.Append(")AS Row, T.*  from Ksystemset T ");
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
			parameters[0].Value = "Ksystemset";
			parameters[1].Value = "Sid";
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

