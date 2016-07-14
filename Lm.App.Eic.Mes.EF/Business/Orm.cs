using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lm.App.Eic.Mes.EF.Business
{
    public abstract class Orm<TEntity> : IDisposable where TEntity : class
    {
        #region Global Variable

        /// <summary>
        /// 构造函数 初始化基类
        /// </summary>
        /// <param name="db"></param>
        public Orm(DbContext db)
        {
            this.Db = db;
            DbTab = Db.Set<TEntity>();
        }

        //BMK 数据集
        private DbContext Db;

        //表
        private DbSet<TEntity> DbTab;

        /// <summary>
        /// 列表基类
        /// </summary>
        public class ModelList_obs : ObservableCollection<TEntity>
        {
            public ModelList_obs()
            {
            }

            public ModelList_obs(List<TEntity> list) : base(list)
            {
            }

            public void Add(List<TEntity> list)
            {
                foreach (var tem in list)
                    this.Add(tem);
            }
        }

        #endregion Global Variable

        #region Parameter

        /// <summary>
        /// 数据模型
        /// </summary>
        abstract public TEntity Detailed { get; set; }

        /// <summary>
        /// 数据模型列表
        /// </summary>
        public ModelList_obs ModelList { get; set; }

        #endregion Parameter

        #region Public Method

        /// <summary>
        /// 实体类是否为空
        /// </summary>
        public bool IsNull
        {
            get { return Detailed == null ? true : false; }
        }

        /// <summary>
        /// 添加一个数据模型到数据库
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public bool Add(TEntity model)
        {
            DbTab.Add(model);
            return Db.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// 添加列表中的数据模型到数据中
        /// </summary>
        /// <param name="list_obs"></param>
        /// <returns></returns>
        public int Add(ModelList_obs list_obs)
        {
            foreach (var tem in list_obs)
                DbTab.Add(tem);
            return Db.SaveChanges();
        }

        /// <summary>
        /// 添加一个数据模型到列表
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="list_obs">列表</param>
        public void Add(TEntity model, ModelList_obs list_obs)
        {
            list_obs.Add(model);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> GetModelList(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return DbTab.Where(predicate)?.ToList();
            }
            catch (Exception e)
            {
                //ZhuiFengLib.Message.Message.MessageInfo($"获取模板失败！\r\n{e.Message}");
                
                return null;
            }
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity GetModel(Expression<Func<TEntity, bool>> predicate)
        {
            var tList = GetModelList(predicate);
            return tList.Count > 0 ? tList[0] : null;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            try
            {
                var set = Db.Set<TEntity>();
                set.Attach(entity);
                Db.Entry(entity).State = EntityState.Modified;
                Db.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                throw new RepoitoryException("更新实体失败", e);
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            try
            {
                Db.Set<TEntity>().Attach(entity);
                Db.Set<TEntity>().Remove(entity);
                Db.SaveChanges();
                //context.Entry<T>(entity).State = EntityState.Deleted;
                //context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new RepoitoryException("删除实体失败", e);
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<TEntity, bool>> delWhere)
        {
            //查询要删除的数据
            List<TEntity> listDeleting = Db.Set<TEntity>().Where(delWhere).ToList();
            //将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                Db.Set<TEntity>().Attach(u);//先附加到 EF容器
                Db.Set<TEntity>().Remove(u);//标识为 删除 状态
            });
            //一次性 生成sql语句到数据库执行删除
            return Db.SaveChanges();
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new RepoitoryException("保存至数据库失败", e);
            }
        }

        /// <summary>
        /// 释放内存
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
        }

        #endregion Public Method
    }
}
