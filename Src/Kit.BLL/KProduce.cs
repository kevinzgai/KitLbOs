using System;
using System.Data;
using System.Collections.Generic;
using Kit.Common;
using Kit.Model;
namespace Kit.BLL
{
	/// <summary>
	/// KProduce
	/// </summary>
	public partial class KProduce
	{
		private readonly Kit.DAL.KProduce dal=new Kit.DAL.KProduce();
		public KProduce()
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
		public bool Exists(int Pid)
		{
			return dal.Exists(Pid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Kit.Model.KProduce model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Kit.Model.KProduce model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Pid)
		{
			
			return dal.Delete(Pid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Pidlist )
		{
			return dal.DeleteList(Kit.Common.PageValidate.SafeLongFilter(Pidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Kit.Model.KProduce GetModel(int Pid)
		{
			
			return dal.GetModel(Pid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Kit.Model.KProduce GetModelByCache(int Pid)
		{
			
			string CacheKey = "KProduceModel-" + Pid;
			object objModel = Kit.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Pid);
					if (objModel != null)
					{
						int ModelCache = Kit.Common.ConfigHelper.GetConfigInt("ModelCache");
						Kit.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Kit.Model.KProduce)objModel;
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
		public List<Kit.Model.KProduce> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Kit.Model.KProduce> DataTableToList(DataTable dt)
		{
			List<Kit.Model.KProduce> modelList = new List<Kit.Model.KProduce>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Kit.Model.KProduce model;
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

