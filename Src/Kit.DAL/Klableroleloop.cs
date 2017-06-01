using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;//Please add references
namespace Kit.DAL
{
	/// <summary>
	/// 数据访问类:Klableroleloop
	/// </summary>
	public partial class Klableroleloop
	{
		public Klableroleloop()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tid", "Klableroleloop"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Klableroleloop");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Kit.Model.Klableroleloop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Klableroleloop(");
			strSql.Append("Lid,Tlooprole,Ttime,Spare1,Spare2,Spare3)");
			strSql.Append(" values (");
			strSql.Append("@Lid,@Tlooprole,@Ttime,@Spare1,@Spare2,@Spare3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Lid", SqlDbType.Int,4),
					new SqlParameter("@Tlooprole", SqlDbType.NVarChar,100),
					new SqlParameter("@Ttime", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.Lid;
			parameters[1].Value = model.Tlooprole;
			parameters[2].Value = model.Ttime;
			parameters[3].Value = model.Spare1;
			parameters[4].Value = model.Spare2;
			parameters[5].Value = model.Spare3;

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
		public bool Update(Kit.Model.Klableroleloop model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Klableroleloop set ");
			strSql.Append("Lid=@Lid,");
			strSql.Append("Tlooprole=@Tlooprole,");
			strSql.Append("Ttime=@Ttime,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Lid", SqlDbType.Int,4),
					new SqlParameter("@Tlooprole", SqlDbType.NVarChar,100),
					new SqlParameter("@Ttime", SqlDbType.DateTime),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200),
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = model.Lid;
			parameters[1].Value = model.Tlooprole;
			parameters[2].Value = model.Ttime;
			parameters[3].Value = model.Spare1;
			parameters[4].Value = model.Spare2;
			parameters[5].Value = model.Spare3;
			parameters[6].Value = model.Tid;

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
		public bool Delete(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Klableroleloop ");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tid;

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
		public bool DeleteList(string Tidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Klableroleloop ");
			strSql.Append(" where Tid in ("+Tidlist + ")  ");
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
		public Kit.Model.Klableroleloop GetModel(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tid,Lid,Tlooprole,Ttime,Spare1,Spare2,Spare3 from Klableroleloop ");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)
			};
			parameters[0].Value = Tid;

			Kit.Model.Klableroleloop model=new Kit.Model.Klableroleloop();
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
		public Kit.Model.Klableroleloop DataRowToModel(DataRow row)
		{
			Kit.Model.Klableroleloop model=new Kit.Model.Klableroleloop();
			if (row != null)
			{
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["Lid"]!=null && row["Lid"].ToString()!="")
				{
					model.Lid=int.Parse(row["Lid"].ToString());
				}
				if(row["Tlooprole"]!=null)
				{
					model.Tlooprole=row["Tlooprole"].ToString();
				}
				if(row["Ttime"]!=null && row["Ttime"].ToString()!="")
				{
					model.Ttime=DateTime.Parse(row["Ttime"].ToString());
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
			strSql.Append("select Tid,Lid,Tlooprole,Ttime,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Klableroleloop ");
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
			strSql.Append(" Tid,Lid,Tlooprole,Ttime,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Klableroleloop ");
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
			strSql.Append("select count(1) FROM Klableroleloop ");
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
				strSql.Append("order by T.Tid desc");
			}
			strSql.Append(")AS Row, T.*  from Klableroleloop T ");
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
			parameters[0].Value = "Klableroleloop";
			parameters[1].Value = "Tid";
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

