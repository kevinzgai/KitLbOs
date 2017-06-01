using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;//Please add references
namespace Kit.DAL
{
	/// <summary>
	/// 数据访问类:Kuser
	/// </summary>
	public partial class Kuser
	{
		public Kuser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Uid", "Kuser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Kuser");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Kit.Model.Kuser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Kuser(");
			strSql.Append("UEmail,Upwd,Ulang,Urole,Spare1,Spare2,Spare3)");
			strSql.Append(" values (");
			strSql.Append("@UEmail,@Upwd,@Ulang,@Urole,@Spare1,@Spare2,@Spare3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,150),
					new SqlParameter("@Ulang", SqlDbType.Char,10),
					new SqlParameter("@Urole", SqlDbType.Char,10),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.UEmail;
			parameters[1].Value = model.Upwd;
			parameters[2].Value = model.Ulang;
			parameters[3].Value = model.Urole;
			parameters[4].Value = model.Spare1;
			parameters[5].Value = model.Spare2;
			parameters[6].Value = model.Spare3;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Kit.Model.Kuser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Kuser set ");
			strSql.Append("UEmail=@UEmail,");
			strSql.Append("Upwd=@Upwd,");
			strSql.Append("Ulang=@Ulang,");
			strSql.Append("Urole=@Urole,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@UEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,150),
					new SqlParameter("@Ulang", SqlDbType.Char,10),
					new SqlParameter("@Urole", SqlDbType.Char,10),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
			parameters[0].Value = model.UEmail;
			parameters[1].Value = model.Upwd;
			parameters[2].Value = model.Ulang;
			parameters[3].Value = model.Urole;
			parameters[4].Value = model.Spare1;
			parameters[5].Value = model.Spare2;
			parameters[6].Value = model.Spare3;
			parameters[7].Value = model.Uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Kuser ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Kuser ");
			strSql.Append(" where Uid in ("+Uidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Kit.Model.Kuser GetModel(int Uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Uid,UEmail,Upwd,Ulang,Urole,Spare1,Spare2,Spare3 from Kuser ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			Kit.Model.Kuser model=new Kit.Model.Kuser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Kit.Model.Kuser DataRowToModel(DataRow row)
		{
			Kit.Model.Kuser model=new Kit.Model.Kuser();
			if (row != null)
			{
				if(row["Uid"]!=null && row["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(row["Uid"].ToString());
				}
				if(row["UEmail"]!=null)
				{
					model.UEmail=row["UEmail"].ToString();
				}
				if(row["Upwd"]!=null)
				{
					model.Upwd=row["Upwd"].ToString();
				}
				if(row["Ulang"]!=null)
				{
					model.Ulang=row["Ulang"].ToString();
				}
				if(row["Urole"]!=null)
				{
					model.Urole=row["Urole"].ToString();
				}
				if(row["Spare1"]!=null)
				{
					model.Spare1=row["Spare1"].ToString();
				}
				if(row["Spare2"]!=null)
				{
					model.Spare2=row["Spare2"].ToString();
				}
				if(row["Spare3"]!=null)
				{
					model.Spare3=row["Spare3"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Uid,UEmail,Upwd,Ulang,Urole,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Kuser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Uid,UEmail,Upwd,Ulang,Urole,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Kuser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Kuser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Uid desc");
			}
			strSql.Append(")AS Row, T.*  from Kuser T ");
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
			parameters[0].Value = "Kuser";
			parameters[1].Value = "Uid";
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

