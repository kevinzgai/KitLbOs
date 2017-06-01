using System;
using System.Data;
using System.Collections.Generic;
using Kit.Common;
using Kit.Model;
namespace Kit.BLL
{
	/// <summary>
	/// Alllog
	/// </summary>
	public partial class Alllog
	{
		private readonly Kit.DAL.Alllog dal=new Kit.DAL.Alllog();
		public Alllog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Aid)
		{
			return dal.Exists(Aid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Kit.Model.Alllog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Kit.Model.Alllog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Aid)
		{
			
			return dal.Delete(Aid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Aidlist )
		{
			return dal.DeleteList(Kit.Common.PageValidate.SafeLongFilter(Aidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Kit.Model.Alllog GetModel(int Aid)
		{
			
			return dal.GetModel(Aid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Kit.Model.Alllog GetModelByCache(int Aid)
		{
			
			string CacheKey = "AlllogModel-" + Aid;
			object objModel = Kit.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Aid);
					if (objModel != null)
					{
						int ModelCache = Kit.Common.ConfigHelper.GetConfigInt("ModelCache");
						Kit.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Kit.Model.Alllog)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Kit.Model.Alllog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Kit.Model.Alllog> DataTableToList(DataTable dt)
		{
			List<Kit.Model.Alllog> modelList = new List<Kit.Model.Alllog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Kit.Model.Alllog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

