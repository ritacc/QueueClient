using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using QM.Entity.ParaSet;

namespace QM.DAL.ParaSet
{
    public class QhandyDA : DALBase
    {
        #region 查询
        public DataTable selectAllDate(string strWdbh, string PageWindowID)
        {
            string sql = string.Format("select * from T_QHANDY where orgbh='{0}' and windowID='{1}'", strWdbh, PageWindowID);

            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public QhandyOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_QHANDY where string id='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            QhandyOR m_QHAN = new QhandyOR(dr);
            return m_QHAN;

        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入T_QhandyOR
        /// </summary>
        public virtual bool Insert(QhandyOR qhandy)
        {
            string sql = @"insert into t_Qhandy (ID, OrgBH,  LABEL_VISIBLE, LABEL_CAPTION, LABEL_FONTCOLOR, LABEL_FONTNAME, LABEL_FONTUNDERLINE,
LABEL_FONTITALIC, LABEL_FONTBOLD, LABEL_FONTSIZE, LABEL_TOP, LABEL_LEFT, LABEL_JOBNO, LABEL_JOBNAME, LABEL_PRINTSTR, LABEL_SHADE, TAG_VISIBLE,
TAG_CAPTION, TAG_FONTCOLOR, TAG_FONTNAME, TAG_FONTUNDERLINE, TAG_FONTITALIC, TAG_FONTBOLD, TAG_FONTSIZE, TAG_TOPOFFSET, TAG_LEFTOFFSET, LABEL_TYPE,
ENLABEL_VISIBLE, ENLABEL_CAPTION, ENLABEL_FONTCOLOR, ENLABEL_FONTNAME, ENLABEL_FONTITALIC, ENLABEL_FONTUNDERLINE, ENLABEL_FONTBOLD, ENLABEL_FONTSIZE, 
SCREENTYPE, ENLABEL_LEFTOFFSET, ENLABEL_TOPOFFSET,ButtomType, windowOnID, windowID
,LABEL_Height,LABEL_Width,LABEL_BG) 
values (@ID, @OrgBH, @LABEL_VISIBLE, @LABEL_CAPTION, @LABEL_FONTCOLOR, @LABEL_FONTNAME, @LABEL_FONTUNDERLINE, @LABEL_FONTITALIC, @LABEL_FONTBOLD, @LABEL_FONTSIZE,
@LABEL_TOP, @LABEL_LEFT, @LABEL_JOBNO, @LABEL_JOBNAME, @LABEL_PRINTSTR, @LABEL_SHADE, @TAG_VISIBLE, @TAG_CAPTION, @TAG_FONTCOLOR, @TAG_FONTNAME, @TAG_FONTUNDERLINE, 
@TAG_FONTITALIC, @TAG_FONTBOLD, @TAG_FONTSIZE, @TAG_TOPOFFSET, @TAG_LEFTOFFSET, @LABEL_TYPE, @ENLABEL_VISIBLE, @ENLABEL_CAPTION, @ENLABEL_FONTCOLOR,
@ENLABEL_FONTNAME, @ENLABEL_FONTITALIC, @ENLABEL_FONTUNDERLINE, @ENLABEL_FONTBOLD, @ENLABEL_FONTSIZE, @SCREENTYPE, @ENLABEL_LEFTOFFSET, 
@ENLABEL_TOPOFFSET,@ButtomType, @windowOnID, @windowID
,@LABEL_Height,@LABEL_Width,@LABEL_BG)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, qhandy.Id),
				new SqlParameter("@OrgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "OrgBH", DataRowVersion.Default, qhandy.Orgbh),
				//new SqlParameter("@LABEL_IDX", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_IDX", DataRowVersion.Default, qhandy.LabelIdx),
				new SqlParameter("@LABEL_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_VISIBLE", DataRowVersion.Default, qhandy.LabelVisible),
				new SqlParameter("@LABEL_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "LABEL_CAPTION", DataRowVersion.Default, qhandy.LabelCaption),
				new SqlParameter("@LABEL_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_FONTCOLOR", DataRowVersion.Default, qhandy.LabelFontcolor),
				new SqlParameter("@LABEL_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "LABEL_FONTNAME", DataRowVersion.Default, qhandy.LabelFontname),
				new SqlParameter("@LABEL_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTUNDERLINE", DataRowVersion.Default, qhandy.LabelFontunderline),
				new SqlParameter("@LABEL_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTITALIC", DataRowVersion.Default, qhandy.LabelFontitalic),
				new SqlParameter("@LABEL_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTBOLD", DataRowVersion.Default, qhandy.LabelFontbold),
				new SqlParameter("@LABEL_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_FONTSIZE", DataRowVersion.Default, qhandy.LabelFontsize),
				new SqlParameter("@LABEL_TOP", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_TOP", DataRowVersion.Default, qhandy.LabelTop),
				new SqlParameter("@LABEL_LEFT", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_LEFT", DataRowVersion.Default, qhandy.LabelLeft),
				new SqlParameter("@LABEL_JOBNO", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_JOBNO", DataRowVersion.Default, qhandy.LabelJobno),
				new SqlParameter("@LABEL_JOBNAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_JOBNAME", DataRowVersion.Default, qhandy.LabelJobname),
				new SqlParameter("@LABEL_PRINTSTR", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_PRINTSTR", DataRowVersion.Default, qhandy.LabelPrintstr),
				new SqlParameter("@LABEL_SHADE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_SHADE", DataRowVersion.Default, qhandy.LabelShade),
				new SqlParameter("@TAG_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_VISIBLE", DataRowVersion.Default, qhandy.TagVisible),
				new SqlParameter("@TAG_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "TAG_CAPTION", DataRowVersion.Default, qhandy.TagCaption),
				new SqlParameter("@TAG_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_FONTCOLOR", DataRowVersion.Default, qhandy.TagFontcolor),
				new SqlParameter("@TAG_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "TAG_FONTNAME", DataRowVersion.Default, qhandy.TagFontname),
				new SqlParameter("@TAG_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTUNDERLINE", DataRowVersion.Default, qhandy.TagFontunderline),
				new SqlParameter("@TAG_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTITALIC", DataRowVersion.Default, qhandy.TagFontitalic),
				new SqlParameter("@TAG_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTBOLD", DataRowVersion.Default, qhandy.TagFontbold),
				new SqlParameter("@TAG_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_FONTSIZE", DataRowVersion.Default, qhandy.TagFontsize),
				new SqlParameter("@TAG_TOPOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_TOPOFFSET", DataRowVersion.Default, qhandy.TagTopoffset),
				new SqlParameter("@TAG_LEFTOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_LEFTOFFSET", DataRowVersion.Default, qhandy.TagLeftoffset),
				new SqlParameter("@LABEL_TYPE", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "LABEL_TYPE", DataRowVersion.Default, qhandy.LabelType),
				new SqlParameter("@ENLABEL_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_VISIBLE", DataRowVersion.Default, qhandy.EnlabelVisible),
				new SqlParameter("@ENLABEL_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ENLABEL_CAPTION", DataRowVersion.Default, qhandy.EnlabelCaption),
				new SqlParameter("@ENLABEL_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTCOLOR", DataRowVersion.Default, qhandy.EnlabelFontcolor),
				new SqlParameter("@ENLABEL_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTNAME", DataRowVersion.Default, qhandy.EnlabelFontname),
				new SqlParameter("@ENLABEL_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTITALIC", DataRowVersion.Default, qhandy.EnlabelFontitalic),
				new SqlParameter("@ENLABEL_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTUNDERLINE", DataRowVersion.Default, qhandy.EnlabelFontunderline),
				new SqlParameter("@ENLABEL_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTBOLD", DataRowVersion.Default, qhandy.EnlabelFontbold),
				new SqlParameter("@ENLABEL_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTSIZE", DataRowVersion.Default, qhandy.EnlabelFontsize),
				new SqlParameter("@SCREENTYPE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "SCREENTYPE", DataRowVersion.Default, qhandy.Screentype),
				new SqlParameter("@ENLABEL_LEFTOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_LEFTOFFSET", DataRowVersion.Default, qhandy.EnlabelLeftoffset),
				new SqlParameter("@ENLABEL_TOPOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_TOPOFFSET", DataRowVersion.Default, qhandy.EnlabelTopoffset),
				new SqlParameter("@ButtomType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ButtomType", DataRowVersion.Default, qhandy.ButtomType),
                new SqlParameter("@windowOnID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "windowOnID", DataRowVersion.Default, qhandy.Windowonid),
				new SqlParameter("@windowID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "windowID", DataRowVersion.Default, qhandy.Windowid),
				
				new SqlParameter("@LABEL_BG", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_BG", DataRowVersion.Default, qhandy.Bg),
				new SqlParameter("@LABEL_Height", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "LABEL_Height", DataRowVersion.Default, qhandy.ButtonHeight),
				new SqlParameter("@LABEL_Width", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "LABEL_Width", DataRowVersion.Default, qhandy.ButtonWidth)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion


        #region 修改
        /// <summary>
        /// 更新t_Qhandy
        /// </summary>
        public virtual bool Update(QhandyOR qhandy)
        {
            string sql = @"update t_Qhandy set LABEL_VISIBLE =@LABEL_VISIBLE,LABEL_CAPTION =@LABEL_CAPTION,LABEL_FONTCOLOR=@LABEL_FONTCOLOR,
LABEL_FONTNAME = @LABEL_FONTNAME,LABEL_FONTUNDERLINE=@LABEL_FONTUNDERLINE,LABEL_FONTITALIC=@LABEL_FONTITALIC,LABEL_FONTBOLD=@LABEL_FONTBOLD,
LABEL_FONTSIZE = @LABEL_FONTSIZE,  LABEL_TOP = @LABEL_TOP,  LABEL_LEFT = @LABEL_LEFT,  LABEL_JOBNO = @LABEL_JOBNO, 
LABEL_JOBNAME = @LABEL_JOBNAME,  LABEL_PRINTSTR = @LABEL_PRINTSTR,  LABEL_SHADE = @LABEL_SHADE,  TAG_VISIBLE = @TAG_VISIBLE,
TAG_CAPTION = @TAG_CAPTION,  TAG_FONTCOLOR = @TAG_FONTCOLOR,  TAG_FONTNAME = @TAG_FONTNAME,  TAG_FONTUNDERLINE = @TAG_FONTUNDERLINE,
TAG_FONTITALIC = @TAG_FONTITALIC,  TAG_FONTBOLD = @TAG_FONTBOLD,  TAG_FONTSIZE = @TAG_FONTSIZE,  TAG_TOPOFFSET = @TAG_TOPOFFSET,
TAG_LEFTOFFSET = @TAG_LEFTOFFSET,  LABEL_TYPE = @LABEL_TYPE,  ENLABEL_VISIBLE = @ENLABEL_VISIBLE,  ENLABEL_CAPTION = @ENLABEL_CAPTION,
ENLABEL_FONTCOLOR = @ENLABEL_FONTCOLOR,  ENLABEL_FONTNAME = @ENLABEL_FONTNAME,  ENLABEL_FONTITALIC = @ENLABEL_FONTITALIC,  
ENLABEL_FONTUNDERLINE = @ENLABEL_FONTUNDERLINE,  ENLABEL_FONTBOLD = @ENLABEL_FONTBOLD,  ENLABEL_FONTSIZE = @ENLABEL_FONTSIZE,  
SCREENTYPE = @SCREENTYPE,  ENLABEL_LEFTOFFSET = @ENLABEL_LEFTOFFSET,  ENLABEL_TOPOFFSET = @ENLABEL_TOPOFFSET,
ButtomType=@ButtomType,windowOnID = @windowOnID,  windowID = @windowID 
,LABEL_Height=@LABEL_Height,LABEL_Width=@LABEL_Width,LABEL_BG=@LABEL_BG
where  ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, qhandy.Id),
                //new SqlParameter("@OrgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "OrgBH", DataRowVersion.Default, qhandy.Orgbh),
                //new SqlParameter("@LABEL_IDX", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_IDX", DataRowVersion.Default, qhandy.LabelIdx),
				new SqlParameter("@LABEL_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_VISIBLE", DataRowVersion.Default, qhandy.LabelVisible),
				new SqlParameter("@LABEL_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "LABEL_CAPTION", DataRowVersion.Default, qhandy.LabelCaption),
				new SqlParameter("@LABEL_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_FONTCOLOR", DataRowVersion.Default, qhandy.LabelFontcolor),
				new SqlParameter("@LABEL_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "LABEL_FONTNAME", DataRowVersion.Default, qhandy.LabelFontname),
				new SqlParameter("@LABEL_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTUNDERLINE", DataRowVersion.Default, qhandy.LabelFontunderline),
				new SqlParameter("@LABEL_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTITALIC", DataRowVersion.Default, qhandy.LabelFontitalic),
				new SqlParameter("@LABEL_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_FONTBOLD", DataRowVersion.Default, qhandy.LabelFontbold),
				new SqlParameter("@LABEL_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_FONTSIZE", DataRowVersion.Default, qhandy.LabelFontsize),
				new SqlParameter("@LABEL_TOP", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_TOP", DataRowVersion.Default, qhandy.LabelTop),
				new SqlParameter("@LABEL_LEFT", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LABEL_LEFT", DataRowVersion.Default, qhandy.LabelLeft),
				new SqlParameter("@LABEL_JOBNO", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_JOBNO", DataRowVersion.Default, qhandy.LabelJobno),
				new SqlParameter("@LABEL_JOBNAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_JOBNAME", DataRowVersion.Default, qhandy.LabelJobname),
				new SqlParameter("@LABEL_PRINTSTR", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_PRINTSTR", DataRowVersion.Default, qhandy.LabelPrintstr),
				new SqlParameter("@LABEL_SHADE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "LABEL_SHADE", DataRowVersion.Default, qhandy.LabelShade),
				new SqlParameter("@TAG_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_VISIBLE", DataRowVersion.Default, qhandy.TagVisible),
				new SqlParameter("@TAG_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "TAG_CAPTION", DataRowVersion.Default, qhandy.TagCaption),
				new SqlParameter("@TAG_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_FONTCOLOR", DataRowVersion.Default, qhandy.TagFontcolor),
				new SqlParameter("@TAG_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "TAG_FONTNAME", DataRowVersion.Default, qhandy.TagFontname),
				new SqlParameter("@TAG_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTUNDERLINE", DataRowVersion.Default, qhandy.TagFontunderline),
				new SqlParameter("@TAG_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTITALIC", DataRowVersion.Default, qhandy.TagFontitalic),
				new SqlParameter("@TAG_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TAG_FONTBOLD", DataRowVersion.Default, qhandy.TagFontbold),
				new SqlParameter("@TAG_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_FONTSIZE", DataRowVersion.Default, qhandy.TagFontsize),
				new SqlParameter("@TAG_TOPOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_TOPOFFSET", DataRowVersion.Default, qhandy.TagTopoffset),
				new SqlParameter("@TAG_LEFTOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TAG_LEFTOFFSET", DataRowVersion.Default, qhandy.TagLeftoffset),
				new SqlParameter("@LABEL_TYPE", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "LABEL_TYPE", DataRowVersion.Default, qhandy.LabelType),
				new SqlParameter("@ENLABEL_VISIBLE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_VISIBLE", DataRowVersion.Default, qhandy.EnlabelVisible),
				new SqlParameter("@ENLABEL_CAPTION", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ENLABEL_CAPTION", DataRowVersion.Default, qhandy.EnlabelCaption),
				new SqlParameter("@ENLABEL_FONTCOLOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTCOLOR", DataRowVersion.Default, qhandy.EnlabelFontcolor),
				new SqlParameter("@ENLABEL_FONTNAME", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTNAME", DataRowVersion.Default, qhandy.EnlabelFontname),
				new SqlParameter("@ENLABEL_FONTITALIC", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTITALIC", DataRowVersion.Default, qhandy.EnlabelFontitalic),
				new SqlParameter("@ENLABEL_FONTUNDERLINE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTUNDERLINE", DataRowVersion.Default, qhandy.EnlabelFontunderline),
				new SqlParameter("@ENLABEL_FONTBOLD", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTBOLD", DataRowVersion.Default, qhandy.EnlabelFontbold),
				new SqlParameter("@ENLABEL_FONTSIZE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_FONTSIZE", DataRowVersion.Default, qhandy.EnlabelFontsize),
				new SqlParameter("@SCREENTYPE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "SCREENTYPE", DataRowVersion.Default, qhandy.Screentype),
				new SqlParameter("@ENLABEL_LEFTOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_LEFTOFFSET", DataRowVersion.Default, qhandy.EnlabelLeftoffset),
				new SqlParameter("@ENLABEL_TOPOFFSET", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ENLABEL_TOPOFFSET", DataRowVersion.Default, qhandy.EnlabelTopoffset),
                new SqlParameter("@ButtomType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ButtomType", DataRowVersion.Default, qhandy.ButtomType),
				new SqlParameter("@windowOnID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "windowOnID", DataRowVersion.Default, qhandy.Windowonid),
				new SqlParameter("@windowID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "windowID", DataRowVersion.Default, qhandy.Windowid),
				new SqlParameter("@LABEL_BG", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "LABEL_BG", DataRowVersion.Default, qhandy.Bg),

				new SqlParameter("@LABEL_Height", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "LABEL_Height", DataRowVersion.Default, qhandy.ButtonHeight),
				new SqlParameter("@LABEL_Width", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "LABEL_Width", DataRowVersion.Default, qhandy.ButtonWidth)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除T_QHANDY
        /// </summary>
        public virtual bool Delete(string strModes)
        {
            string sql = "delete from T_QHANDY where  id = @id";
            SqlParameter parameter = new SqlParameter("@id", strModes);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}
