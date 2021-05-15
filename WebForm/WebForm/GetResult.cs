using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Web.UI;
using System.Data;
using DevExpress.XtraPrinting;
using WebForm;
using System.Windows.Forms;

/// <summary>
/// Summary description for GetResult
/// </summary>
public class GetResult : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private DevExpress.Xpo.XPDataView xpDataView1;
    private DevExpress.Utils.SharedImageCollection sharedImageCollection1;
    private XRTable TableData;
    private XRPictureBox xrPictureBox1;
    private XRLabel lbTitle;
    protected DevExpress.Persistent.Base.ReportsV2.ViewDataSource viewDataSource1;
    private DevExpress.Utils.VisualEffects.AdornerUIManager adornerUIManager1;

    SizeF addSize = new SizeF(1000.5F, 50.8F);
    SizeF addSizeCell = new SizeF(150F, 50.8F);


    /// <summary>
    /// Required designer variable.
    /// </summary>
    public GetResult()
    {
        InitializeComponent();
        makeReport();

    }
    public void makeReport()
    {
        //TẠO CỘT ĐẦU TIÊN
        XRTableRow rowt1 = new XRTableRow();
        DataTable dataTable = KetNoi.QueryDataTable();


        //Tạo các cột theo data
        foreach (ObjectQuery ob in KetNoi.ObjectQueryList)
        {
            XRTableCell at1 = new XRTableCell();
            at1.Font = new Font("Arial", 12, FontStyle.Bold);
            at1.ForeColor = Color.DarkGreen;
            rowt1.SizeF = addSize;
            at1.Text = ob.attributeName;
            at1.TextAlignment = TextAlignment.MiddleCenter;
            at1.BackColor = System.Drawing.Color.Khaki;
            at1.SizeF = addSizeCell;
            rowt1.Cells.Add(at1);
        }
        this.TableData.Controls.Add(rowt1);

        foreach (DataRow row in dataTable.Rows)
        {
            XRTableRow row1 = new XRTableRow();
            foreach (ObjectQuery ob in KetNoi.ObjectQueryList)
            {
                XRTableCell a1 = new XRTableCell();
                string attribute = row[ob.attributeName].ToString();
                a1.SizeF = addSizeCell;
                a1.Text = attribute;
                a1.TextAlignment = TextAlignment.MiddleCenter;
                row1.Cells.Add(a1);
            }

            row1.SizeF = addSize;
            this.TableData.Controls.Add(row1);
        }

    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    public static XtraReport create()
    {
        XtraReport report = new XtraReport()
        {
            Name = "SimpleStaticReport",
            DisplayName = "Simple Static Report",
            PaperKind = PaperKind.Letter,
            Margins = new Margins(100, 100, 100, 100)
        };

        DetailBand detailBand = new DetailBand()
        {
            HeightF = 25
        };
        report.Bands.Add(detailBand);

        XRLabel helloWordLabel = new XRLabel()
        {
            Text = "Hello, World!",
            Font = new Font("Tahoma", 20f, FontStyle.Bold),
            BoundsF = new RectangleF(0, 0, 250, 50),
        };
        detailBand.Controls.Add(helloWordLabel);

        return report;
    }


    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetResult));
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.TableData = new DevExpress.XtraReports.UI.XRTable();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.lbTitle = new DevExpress.XtraReports.UI.XRLabel();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xpDataView1 = new DevExpress.Xpo.XPDataView(this.components);
        this.adornerUIManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
        this.sharedImageCollection1 = new DevExpress.Utils.SharedImageCollection(this.components);
        this.viewDataSource1 = new DevExpress.Persistent.Base.ReportsV2.ViewDataSource();
        ((System.ComponentModel.ISupportInitialize)(this.TableData)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xpDataView1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.viewDataSource1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TableData});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 556.6666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // TableData
        // 
        this.TableData.BorderColor = System.Drawing.Color.LightGray;
        this.TableData.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.TableData.BorderWidth = 3F;
        this.TableData.Dpi = 200F;
        this.TableData.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.TableData.Name = "TableData";
        this.TableData.SizeF = new System.Drawing.SizeF(1200F, 600F);
        this.TableData.AdjustSize();
        this.TableData.StylePriority.UseBorderColor = false;
        this.TableData.StylePriority.UseBorders = false;
        this.TableData.StylePriority.UseBorderWidth = false;
        // 
        // TopMargin
        // 
        this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.lbTitle});
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 319.6666F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPictureBox1
        // 
        this.xrPictureBox1.Dpi = 100F;
        this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
        this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.SizeF = new System.Drawing.SizeF(224.1667F, 213.8334F);
        this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        // 
        // lbTitle
        // 
        this.lbTitle.Dpi = 100F;
        this.lbTitle.Font = new System.Drawing.Font("Vinhan", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lbTitle.LocationFloat = new DevExpress.Utils.PointFloat(110.8333F, 173.8334F);
        this.lbTitle.Multiline = true;
        this.lbTitle.Name = "lbTitle";
        this.lbTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lbTitle.SizeF = new System.Drawing.SizeF(584.1666F, 125.5F);
        this.lbTitle.StylePriority.UseFont = false;
        this.lbTitle.StylePriority.UseForeColor = false;
        this.lbTitle.Text = "AUTOMATIC REPORT\r\n";
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 100F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 

        // 
        // sharedImageCollection1
        // 
        // 
        // 
        // 
        this.sharedImageCollection1.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("sharedImageCollection1.ImageSource.ImageStream")));
        this.sharedImageCollection1.ParentControl = null;
        // 
        // viewDataSource1
        // 
        this.viewDataSource1.Name = "viewDataSource1";
        this.viewDataSource1.ObjectTypeName = null;
        this.viewDataSource1.TopReturnedRecords = 0;
        // 
        // GetResult
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.viewDataSource1});
        this.DataSource = this.xpDataView1;
        this.Margins = new System.Drawing.Printing.Margins(100, 100, 320, 100);
        this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        this.RollPaper = true;
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this.TableData)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xpDataView1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.adornerUIManager1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.viewDataSource1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
