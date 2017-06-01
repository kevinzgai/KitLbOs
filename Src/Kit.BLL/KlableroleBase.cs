using System;
using System.Data;
using System.Collections.Generic;
using Kit.Model;
using Kit.Common;
namespace Kit.BLL
{
    /// <summary>
    /// KlableroleBase
    /// </summary>
    public partial class KlableroleBase
    {
        private readonly Kit.DAL.KlableroleBase dal = new Kit.DAL.KlableroleBase();
        public KlableroleBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Lid)
        {
            return dal.Exists(Lid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Kit.Model.KlableroleBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Kit.Model.KlableroleBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Lid)
        {

            return dal.Delete(Lid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Lidlist)
        {
            return dal.DeleteList(Kit.Common.PageValidate.SafeLongFilter(Lidlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Kit.Model.KlableroleBase GetModel(int Lid)
        {

            return dal.GetModel(Lid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Kit.Model.KlableroleBase GetModelByCache(int Lid)
        {

            string CacheKey = "KlableroleBaseModel-" + Lid;
            object objModel = Kit.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Lid);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Kit.Model.KlableroleBase)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Kit.Model.KlableroleBase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Kit.Model.KlableroleBase> DataTableToList(DataTable dt)
        {
            List<Kit.Model.KlableroleBase> modelList = new List<Kit.Model.KlableroleBase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Kit.Model.KlableroleBase model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

