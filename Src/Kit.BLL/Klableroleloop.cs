using System;
using System.Data;
using System.Collections.Generic;
using Kit.Common;
using Kit.Model;
namespace Kit.BLL
{
	/// <summary>
	/// Klableroleloop
	/// </summary>
	public partial class Klableroleloop
	{
		private readonly Kit.DAL.Klableroleloop dal=new Kit.DAL.Klableroleloop();
		public Klableroleloop()
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
		public bool Exists(int Tid)
		{
			return dal.Exists(Tid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Kit.Model.Klableroleloop model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Kit.Model.Klableroleloop model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Tid)
		{
			
			return dal.Delete(Tid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Tidlist )
		{
			return dal.DeleteList(Kit.Common.PageValidate.SafeLongFilter(Tidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Kit.Model.Klableroleloop GetModel(int Tid)
		{
			
			return dal.GetModel(Tid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Kit.Model.Klableroleloop GetModelByCache(int Tid)
		{
			
			string CacheKey = "KlableroleloopModel-" + Tid;
			object objModel = Kit.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Tid);
					if (objModel != null)
					{
						int ModelCache = Kit.Common.ConfigHelper.GetConfigInt("ModelCache");
						Kit.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Kit.Model.Klableroleloop)objModel;
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
		public List<Kit.Model.Klableroleloop> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Kit.Model.Klableroleloop> DataTableToList(DataTable dt)
		{
			List<Kit.Model.Klableroleloop> modelList = new List<Kit.Model.Klableroleloop>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Kit.Model.Klableroleloop model;
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

