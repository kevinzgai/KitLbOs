using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Kit.DBUtility;//Please add references
namespace Kit.DAL
{
	/// <summary>
	/// 数据访问类:Rrecord
	/// </summary>
	public partial class Rrecord
	{
		public Rrecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Rid", "Rrecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Rid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Rrecord");
			strSql.Append(" where Rid=@Rid");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4)
			};
			parameters[0].Value = Rid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Kit.Model.Rrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Rrecord(");
			strSql.Append("Pid,Lid,Rstartnumber,Rendnumber,Rprintnum,Rdatetime,Uid,Spare1,Spare2,Spare3)");
			strSql.Append(" values (");
			strSql.Append("@Pid,@Lid,@Rstartnumber,@Rendnumber,@Rprintnum,@Rdatetime,@Uid,@Spare1,@Spare2,@Spare3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Lid", SqlDbType.Int,4),
					new SqlParameter("@Rstartnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Rendnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Rprintnum", SqlDbType.Int,4),
					new SqlParameter("@Rdatetime", SqlDbType.DateTime),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.Pid;
			parameters[1].Value = model.Lid;
			parameters[2].Value = model.Rstartnumber;
			parameters[3].Value = model.Rendnumber;
			parameters[4].Value = model.Rprintnum;
			parameters[5].Value = model.Rdatetime;
			parameters[6].Value = model.Uid;
			parameters[7].Value = model.Spare1;
			parameters[8].Value = model.Spare2;
			parameters[9].Value = model.Spare3;

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
		public bool Update(Kit.Model.Rrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Rrecord set ");
			strSql.Append("Pid=@Pid,");
			strSql.Append("Lid=@Lid,");
			strSql.Append("Rstartnumber=@Rstartnumber,");
			strSql.Append("Rendnumber=@Rendnumber,");
			strSql.Append("Rprintnum=@Rprintnum,");
			strSql.Append("Rdatetime=@Rdatetime,");
			strSql.Append("Uid=@Uid,");
			strSql.Append("Spare1=@Spare1,");
			strSql.Append("Spare2=@Spare2,");
			strSql.Append("Spare3=@Spare3");
			strSql.Append(" where Rid=@Rid");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Lid", SqlDbType.Int,4),
					new SqlParameter("@Rstartnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Rendnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Rprintnum", SqlDbType.Int,4),
					new SqlParameter("@Rdatetime", SqlDbType.DateTime),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Spare1", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare2", SqlDbType.NVarChar,200),
					new SqlParameter("@Spare3", SqlDbType.NVarChar,200),
					new SqlParameter("@Rid", SqlDbType.Int,4)};
			parameters[0].Value = model.Pid;
			parameters[1].Value = model.Lid;
			parameters[2].Value = model.Rstartnumber;
			parameters[3].Value = model.Rendnumber;
			parameters[4].Value = model.Rprintnum;
			parameters[5].Value = model.Rdatetime;
			parameters[6].Value = model.Uid;
			parameters[7].Value = model.Spare1;
			parameters[8].Value = model.Spare2;
			parameters[9].Value = model.Spare3;
			parameters[10].Value = model.Rid;

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
		public bool Delete(int Rid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Rrecord ");
			strSql.Append(" where Rid=@Rid");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4)
			};
			parameters[0].Value = Rid;

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
		public bool DeleteList(string Ridlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Rrecord ");
			strSql.Append(" where Rid in ("+Ridlist + ")  ");
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
		public Kit.Model.Rrecord GetModel(int Rid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Rid,Pid,Lid,Rstartnumber,Rendnumber,Rprintnum,Rdatetime,Uid,Spare1,Spare2,Spare3 from Rrecord ");
			strSql.Append(" where Rid=@Rid");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4)
			};
			parameters[0].Value = Rid;

			Kit.Model.Rrecord model=new Kit.Model.Rrecord();
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
		public Kit.Model.Rrecord DataRowToModel(DataRow row)
		{
			Kit.Model.Rrecord model=new Kit.Model.Rrecord();
			if (row != null)
			{
				if(row["Rid"]!=null && row["Rid"].ToString()!="")
				{
					model.Rid=int.Parse(row["Rid"].ToString());
				}
				if(row["Pid"]!=null && row["Pid"].ToString()!="")
				{
					model.Pid=int.Parse(row["Pid"].ToString());
				}
				if(row["Lid"]!=null && row["Lid"].ToString()!="")
				{
					model.Lid=int.Parse(row["Lid"].ToString());
				}
				if(row["Rstartnumber"]!=null)
				{
					model.Rstartnumber=row["Rstartnumber"].ToString();
				}
				if(row["Rendnumber"]!=null)
				{
					model.Rendnumber=row["Rendnumber"].ToString();
				}
				if(row["Rprintnum"]!=null && row["Rprintnum"].ToString()!="")
				{
					model.Rprintnum=int.Parse(row["Rprintnum"].ToString());
				}
				if(row["Rdatetime"]!=null && row["Rdatetime"].ToString()!="")
				{
					model.Rdatetime=DateTime.Parse(row["Rdatetime"].ToString());
				}
				if(row["Uid"]!=null && row["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(row["Uid"].ToString());
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
			strSql.Append("select Rid,Pid,Lid,Rstartnumber,Rendnumber,Rprintnum,Rdatetime,Uid,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Rrecord ");
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
			strSql.Append(" Rid,Pid,Lid,Rstartnumber,Rendnumber,Rprintnum,Rdatetime,Uid,Spare1,Spare2,Spare3 ");
			strSql.Append(" FROM Rrecord ");
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
			strSql.Append("select count(1) FROM Rrecord ");
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
				strSql.Append("order by T.Rid desc");
			}
			strSql.Append(")AS Row, T.*  from Rrecord T ");
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
			parameters[0].Value = "Rrecord";
			parameters[1].Value = "Rid";
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

