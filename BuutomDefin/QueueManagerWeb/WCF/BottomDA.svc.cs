using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QM.DAL.ParaSet;
using System.Data;
using QM.Web.WCF;

using QM.Entity.ParaSet;


namespace QM.Web.WPFDA
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BottomDA”。
    public class BottomDA : IBottomDA
    {
        public void DoWork()
        {
        }

        QhandyDA m_Qhand = new QhandyDA();
        public QhandyOR GetABottom(string id)
        {
            QhandyOR b = m_Qhand.selectARowDate(id);
            return b;
        }

        public List<QhandyOR> GetBottomList(string wdbh,string pagewindID)
        {
            List<QhandyOR> listBottom = new List<QhandyOR>();

            DataTable dt = m_Qhand.selectAllDate(wdbh,pagewindID);
            foreach (DataRow dr in dt.Rows)
            {
                QhandyOR b = new QhandyOR(dr);
                listBottom.Add(b);
            }
            return listBottom;
        }

        public bool UpdateBottom(List<ButtomControl> OpList)
        {
            
            try
            {
                foreach (ButtomControl bmc in OpList)
                {
                    if (bmc.OpType == 0)
                    {
                        m_Qhand.Insert(bmc.ButtomOR);
                    }
                    else if (bmc.OpType == 1)
                    {
                        m_Qhand.Update(bmc.ButtomOR);
                    }
                    else if (bmc.OpType == 2)
                    {
                        m_Qhand.Delete(bmc.ButtomOR.Id.ToString());
                    }
                }
            }
            catch(Exception Ex)
            {
                return false;
            }
            return true;
        }

        public bool Insert(QhandyOR obj)
        {
            return m_Qhand.Insert(obj);
        }


        //获取业务
        public List<YWOR> GetYWList(string wdbh)
        {
            BussinessDA ywb = new BussinessDA();
            DataTable dt = ywb.SelectYwbByWD(wdbh);
            List<YWOR> listYw = new List<YWOR>();
            foreach (DataRow dr in dt.Rows)
            {
                YWOR obj = new YWOR();
                obj.NO = dr["id"].ToString();
                obj.Name = dr["name"].ToString();
                listYw.Add(obj);
            }
            return listYw;
        }


        public List<PageWinOR> GetPageWinS(string wdbh)
        {
            return new PageWinDA().selectPageWinsByWdbh(wdbh);
        }

        /// <summary>
        /// 修改页窗口
        /// </summary>
        /// <param name="OpList"></param>
        /// <returns></returns>
        public bool UpdatePageWin(PageWinOR obj)
        {           
             return  new  PageWinDA().Update(obj);
        }

        /// <summary>
        /// 添加页窗口
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
       public  bool InsertPageWin(PageWinOR obj)
       {
           return new  PageWinDA().Insert(obj);
       }
        
      public  bool DeletepageWin(string mID)
      {
          return new PageWinDA().Delete(mID);
      }

    }
}
