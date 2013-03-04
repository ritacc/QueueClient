using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class QhandyMySqlDA : DALBase
    {
        #region 更新
        public void UpdateQhandy(List<QhandyOR> listqhandy)
        {
            string sql = "truncate table t_Qhandy";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (QhandyOR obj in listqhandy)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(QhandyOR qhandy)
        {
            string sql = @"insert into t_Qhandy (ID,OrgBH,LABEL_IDX,LABEL_VISIBLE,LABEL_CAPTION,
LABEL_FONTCOLOR,LABEL_FONTNAME,LABEL_FONTUNDERLINE,LABEL_FONTITALIC,LABEL_FONTBOLD,
LABEL_FONTSIZE,LABEL_TOP,LABEL_LEFT,LABEL_JOBNO,LABEL_JOBNAME,
LABEL_PRINTSTR,LABEL_SHADE,TAG_VISIBLE,TAG_CAPTION,TAG_FONTCOLOR,
TAG_FONTNAME,TAG_FONTUNDERLINE,TAG_FONTITALIC,TAG_FONTBOLD,TAG_FONTSIZE,
TAG_TOPOFFSET,TAG_LEFTOFFSET,LABEL_TYPE,ENLABEL_VISIBLE,ENLABEL_CAPTION,
ENLABEL_FONTCOLOR,ENLABEL_FONTNAME,ENLABEL_FONTITALIC,ENLABEL_FONTUNDERLINE,ENLABEL_FONTBOLD,
ENLABEL_FONTSIZE,SCREENTYPE,ENLABEL_LEFTOFFSET,ENLABEL_TOPOFFSET,ButtomType,
windowOnID,windowID)
values ('@ID','@OrgBH',@LABEL_IDX,@LABEL_VISIBLE,'@LABEL_CAPTION',
@LABEL_FONTCOLOR,'@LABEL_FONTNAME',@LABEL_FONTUNDERLINE,@LABEL_FONTITALIC,@LABEL_FONTBOLD,
@LABEL_FONTSIZE,@LABEL_TOP,@LABEL_LEFT,'@LABEL_JOBNO','@LABEL_JOBNAME',
'@LABEL_PRINTSTR',@LABEL_SHADE,@TAG_VISIBLE,'@TAG_CAPTION',@TAG_FONTCOLOR,
'@TAG_FONTNAME',@TAG_FONTUNDERLINE,@TAG_FONTITALIC,@TAG_FONTBOLD,@TAG_FONTSIZE,
@TAG_TOPOFFSET,@TAG_LEFTOFFSET,'@LABEL_TYPE',@ENLABEL_VISIBLE,'@ENLABEL_CAPTION',
@ENLABEL_FONTCOLOR,'@ENLABEL_FONTNAME',@ENLABEL_FONTITALIC,@ENLABEL_FONTUNDERLINE,@ENLABEL_FONTBOLD,
@ENLABEL_FONTSIZE,@SCREENTYPE,@ENLABEL_LEFTOFFSET,@ENLABEL_TOPOFFSET,@ButtomType,
'@windowOnID','@windowID')";
            sql = sql.Replace("@ID", qhandy.Id);	//
            sql = sql.Replace("@OrgBH", qhandy.Orgbh);	//
            sql = sql.Replace("@LABEL_IDX", qhandy.LabelIdx.ToString());	//
            sql = sql.Replace("@LABEL_VISIBLE", boolGetFlag(qhandy.LabelVisible));	//标签是否显示
            sql = sql.Replace("@LABEL_CAPTION", qhandy.LabelCaption);	//标签显示内容
            sql = sql.Replace("@LABEL_FONTCOLOR", qhandy.LabelFontcolor.ToString());	//标签颜色
            sql = sql.Replace("@LABEL_FONTNAME", qhandy.LabelFontname);	//标签字体名称
            sql = sql.Replace("@LABEL_FONTUNDERLINE", boolGetFlag(qhandy.LabelFontunderline));	//标签下划线
            sql = sql.Replace("@LABEL_FONTITALIC", boolGetFlag(qhandy.LabelFontitalic));	//标签是否斜体
            sql = sql.Replace("@LABEL_FONTBOLD", boolGetFlag(qhandy.LabelFontbold));	//标签是否加粗
            sql = sql.Replace("@LABEL_FONTSIZE", qhandy.LabelFontsize.ToString());	//标签字体大小
            sql = sql.Replace("@LABEL_TOP", qhandy.LabelTop.ToString());	//
            sql = sql.Replace("@LABEL_LEFT", qhandy.LabelLeft.ToString());	//
            sql = sql.Replace("@LABEL_JOBNO", qhandy.LabelJobno);	//标签业务No
            sql = sql.Replace("@LABEL_JOBNAME", qhandy.LabelJobname);	//标签业务名称
            sql = sql.Replace("@LABEL_PRINTSTR", qhandy.LabelPrintstr);	//标签打印字字符串
            sql = sql.Replace("@LABEL_SHADE", boolGetFlag(qhandy.LabelShade));	//标签是否显示边框
            sql = sql.Replace("@TAG_VISIBLE", boolGetFlag(qhandy.TagVisible));	//Tag是否显示
            sql = sql.Replace("@TAG_CAPTION", qhandy.TagCaption);	//Tag显示内容
            sql = sql.Replace("@TAG_FONTCOLOR", qhandy.TagFontcolor.ToString());	//Tag字体颜色
            sql = sql.Replace("@TAG_FONTNAME", qhandy.TagFontname);	//Tag字体
            sql = sql.Replace("@TAG_FONTUNDERLINE", boolGetFlag(qhandy.TagFontunderline));	//Tag下划线
            sql = sql.Replace("@TAG_FONTITALIC", boolGetFlag(qhandy.TagFontitalic));	//Tag是否斜体
            sql = sql.Replace("@TAG_FONTBOLD", boolGetFlag(qhandy.TagFontbold));	//Tag是否加粗
            sql = sql.Replace("@TAG_FONTSIZE", qhandy.TagFontsize.ToString());	//Tag字体大小
            sql = sql.Replace("@TAG_TOPOFFSET", qhandy.TagTopoffset.ToString());	//
            sql = sql.Replace("@TAG_LEFTOFFSET", qhandy.TagLeftoffset.ToString());	//
            sql = sql.Replace("@LABEL_TYPE", qhandy.LabelType);	//类型
            sql = sql.Replace("@ENLABEL_VISIBLE", boolGetFlag(qhandy.EnlabelVisible));	//英文标签是否显示
            sql = sql.Replace("@ENLABEL_CAPTION", qhandy.EnlabelCaption);	//英文标签显示内容
            sql = sql.Replace("@ENLABEL_FONTCOLOR", qhandy.EnlabelFontcolor.ToString());	//英文标签颜色
            sql = sql.Replace("@ENLABEL_FONTNAME", qhandy.EnlabelFontname);	//英文标签字体名称
            sql = sql.Replace("@ENLABEL_FONTITALIC", boolGetFlag(qhandy.EnlabelFontitalic));	//英文标签是否斜体
            sql = sql.Replace("@ENLABEL_FONTUNDERLINE", boolGetFlag(qhandy.EnlabelFontunderline));	//英文标签下划线
            sql = sql.Replace("@ENLABEL_FONTBOLD", boolGetFlag(qhandy.EnlabelFontbold));	//英文标签是否加粗
            sql = sql.Replace("@ENLABEL_FONTSIZE", qhandy.EnlabelFontsize.ToString());	//英文标签字体大小
            sql = sql.Replace("@SCREENTYPE", qhandy.Screentype.ToString());	//
            sql = sql.Replace("@ENLABEL_LEFTOFFSET", qhandy.EnlabelLeftoffset.ToString());	//
            sql = sql.Replace("@ENLABEL_TOPOFFSET", qhandy.EnlabelTopoffset.ToString());	//
            sql = sql.Replace("@ButtomType", boolGetFlag(qhandy.Buttomtype));	//按钮类型，0功能按钮，1 页窗口按钮。
            sql = sql.Replace("@windowOnID", qhandy.Windowonid);	//按钮关联窗口ID
            sql = sql.Replace("@windowID", qhandy.Windowid);	//窗口ID

            return sql;
        }
        #endregion


        public PageWinOR GetPageWinId(string id)
        {
            var sql = string.Format("SELECT * FROM T_PAGEWIN WHERE ID = '{0}'", id);
            var dt = dbMySql.ExecuteQuery(sql);
            if (null != dt && dt.Rows.Count > 0)
            {
                return new PageWinOR(dt.Rows[0]);
            }
            return null;
        }

        public List<QhandyOR> GetButtonsByPageWinId(string windowID)
        {
            var result = new List<QhandyOR>();
            var sql = string.Format("SELECT * FROM t_qhandy WHERE windowID = '{0}'", windowID);
            var dt = dbMySql.ExecuteQuery(sql);
            if (null != dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    result.Add(new QhandyOR(row));
                }
            }
            return result;
        }

    }
}

