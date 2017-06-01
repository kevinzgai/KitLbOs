using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;//Please add references
namespace Kit.DAL
{
	/// <summary>
	/// 数据访问类:KProduce
	/// </summary>
	public partial class KProduce
	{
		public KProduce()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Pid", "KProduce"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Pid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KProduce");
			strSql.Append(" where Pid=@Pid");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)
			};
			parameters[0].Value = Pid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Kit.Model.KProduce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KProduce(");
			strSql.Append("Pname,Pnumber,Pimg,Spare1,Spare2,Spare3)");
			strSql.Append(" values (");
			strSql.Append("@Pname,@Pnumber,@Pimg,@Spare1,@Spare2,@Spare3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Pname", SqlDbType.NVarChar,250),
					new SqlParameter("@Pnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Pimg", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.Pname;
			parameters[1].Value = model.Pnumber;
			parameters[2].Value = model.Pimg;
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
		public bool Update(Kit.Model.KProduce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KProduce set ");
			strSql.Append("Pname=@Pname,");
			strSql.Append("Pnumber=@Pnumber,");
			strSql.Append("Pimg=@Pimg,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3");
			strSql.Append(" where Pid=@Pid");
			SqlParameter[] parameters = {
					new SqlParameter("@Pname", SqlDbType.NVarChar,250),
					new SqlParameter("@Pnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Pimg", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,500),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,500),
					new SqlParameter("@Pid", SqlDbType.Int,4)};
			parameters[0].Value = model.Pname;
			parameters[1].Value = model.Pnumber;
			parameters[2].Value = model.Pimg;
			parameters[3].Value = model.Spare1;
			parameters[4].Value = model.Spare2;
			parameters[5].Value = model.Spare3;
			parameters[6].Value = model.Pid;

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
		public bool Delete(int Pid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KProduce ");
			strSql.Append(" where Pid=@Pid");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)
			};
			parameters[0].Value = Pid;

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
		public bool DeleteList(string Pidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KProduce ");
			strSql.Append(" where Pid in ("+Pidlist + ")  ");
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
		public Kit.Model.KProduce GetModel(int Pid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Pid,Pname,Pnumber,Pimg,Spare1,Spare2,Spare3 from KProduce ");
			strSql.Append(" where Pid=@Pid");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)
			};
			parameters[0].Value = Pid;

			Kit.Model.KProduce model=new Kit.Model.KProduce();
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
		public Kit.Model.KProduce DataRowToModel(DataRow row)
		{
			Kit.Model.KProduce model=new Kit.Model.KProduce();
			if (row != null)
			{
				if(row["Pid"]!=null && row["Pid"].ToString()!="")
				{
					model.Pid=int.Parse(row["Pid"].ToString());
				}
				if(row["Pname"]!=null)
				{
					model.Pname=row["Pname"].ToString();
				}
				if(row["Pnumber"]!=null)
				{
					model.Pnumber=row["Pnumber"].ToString();
				}
				if(row["Pimg"]!=null)
				{
					model.Pimg=row["Pimg"].ToString();
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
			strSql.Append("select Pid,Pname,Pnumber,Pimg,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM KProduce ");
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
			strSql.Append(" Pid,Pname,Pnumber,Pimg,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM KProduce ");
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
			strSql.Append("select count(1) FROM KProduce ");
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
				strSql.Append("order by T.Pid desc");
			}
			strSql.Append(")AS Row, T.*  from KProduce T ");
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
			parameters[0].Value = "KProduce";
			parameters[1].Value = "Pid";
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

