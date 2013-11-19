using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QM.Web.WCF;
using QM.Entity.ParaSet;

namespace QM.Web.WPFDA
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBottomDA”。
    [ServiceContract]
    public interface IBottomDA
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// 查询一个按钮信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        QhandyOR GetABottom(string id);

        /// <summary>
        /// 根据一个网点选择按钮
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        List<QhandyOR> GetBottomList(string id, string pagewindID);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool Insert(QhandyOR obj);

        /// <summary>
        /// 更新窗口中的按钮
        /// </summary>
        /// <param name="OpList"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateBottom(List<ButtomControl> OpList);

        /// <summary>
        /// 查询一个网点中的业务
        /// </summary>
        /// <param name="wdbh"></param>
        /// <returns></returns>
        [OperationContract]
        List<YWOR> GetYWList(string wdbh);

        /// <summary>
        /// 获取窗口
        /// </summary>
        /// <param name="wdbh"></param>
        /// <returns></returns>
        [OperationContract]
        List<PageWinOR> GetPageWinS(string wdbh);

        /// <summary>
        /// 插入窗口信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool InsertPageWin(PageWinOR obj);

        /// <summary>
        /// 修改窗口信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdatePageWin(PageWinOR obj);

        /// <summary>
        /// 删除窗口信息
        /// </summary>
        /// <param name="mID"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeletepageWin(string mID);
    }
}
