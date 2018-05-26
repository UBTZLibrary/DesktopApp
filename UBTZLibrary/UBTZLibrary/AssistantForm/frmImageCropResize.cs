using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace UBTZLibrary.AssistantForm
{
    public partial class frmImageCropResize : DevExpress.XtraEditors.XtraForm
    {
        #region [Declarations...]
        public Bitmap returnObject;
        public bool isEdit = true;
        Image tempObj;
        Rectangle CropRect;
        Rectangle rcLT, rcRT, rcLB, rcRB;
        Rectangle rcOld, rcNew;
        Rectangle rcOriginal;
        Rectangle rcBegin;
        SolidBrush BrushRect;
        HatchBrush BrushRectSmall;
        Color BrushColor;

        int AlphaBlend;
        int nSize;
        int nWd;
        int nHt;
        int nResizeRT;
        int nResizeBL;
        int nResizeLT;
        int nResizeRB;
        int nThatsIt;
        int nCropRect;
        int CropWidth;

        int imageWidth;
        int imageHeight;
        int HeightOffset;

        double CropAspectRatio;
        double ImageAspectRatio;
        double ZoomedRatio;

        Point ptOld;
        Point ptNew;

        string filename;
        #endregion

        #region [Constructors...]

        public frmImageCropResize()
        {
            InitializeComponent();

            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true);

            CropWidth = 300;

            HeightOffset = panel1.Height + SystemInformation.CaptionHeight + (SystemInformation.BorderSize.Height * 2);

            UpdateAspectRatio();
            InitializeCropRectangle();
        }
        public frmImageCropResize(Image obj)
        {
            InitializeComponent();
            tempObj = obj;
            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true);

            CropWidth = 300;

            HeightOffset = panel1.Height + SystemInformation.CaptionHeight + (SystemInformation.BorderSize.Height * 2);

            UpdateAspectRatio();
            InitializeCropRectangle();
        }
        #endregion

        #region [ControlEvents...]

        private void frmImageCropResize_Load(object sender, EventArgs e)
        {
            if (tempObj != null)
            {
                LoadImage(tempObj);
                btnRotateImage.Enabled = true;
                btnOK.Enabled = true;
                btnCancel.Enabled = true;
                CenterCropBox();
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpeg Image*.jpg|*.jpg|Gif Image *.gif|*.gif|BMP Image*.bmp|*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                LoadImage(filename);
                btnRotateImage.Enabled = true;
                btnOK.Enabled = true;
                btnCancel.Enabled = true;
                CenterCropBox();
            }
            else
            {
                this.Close();
            }
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (ImageAspectRatio == 0)
                return;

            this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;
            UpdateAspectRatio();
            this.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            double x, imageHeight, imageWidth, boxHeight, boxWidth;
            boxHeight = pictureEdit1.Height;
            boxWidth = pictureEdit1.Width;
            imageHeight = pictureEdit1.Image.Height;
            imageWidth = pictureEdit1.Image.Width;

            x = (boxWidth / 2) - ((imageWidth / (imageHeight / boxHeight)) / 2);
            if (x < 30)
            {
                x = 0;
            }
            Rectangle ScaledCropRect = new Rectangle();
            ScaledCropRect.X = (int)(CropRect.X - x);
            if (ScaledCropRect.X < 0)
                ScaledCropRect.X = 0;
            ScaledCropRect.X = (int)(ScaledCropRect.X * (imageHeight / boxHeight));
            ScaledCropRect.Y = (int)(CropRect.Y * (imageHeight / boxHeight));
            ScaledCropRect.Width = (int)(CropRect.Width * (imageHeight / boxHeight));
            if (ScaledCropRect.Width > (int)imageWidth)
                ScaledCropRect.Width = (int)imageWidth;
            ScaledCropRect.Height = (int)(CropRect.Height * (imageHeight / boxHeight));
            if (ScaledCropRect.Height > (int)imageHeight)
                ScaledCropRect.Height = (int)imageHeight;
            bmp = (Bitmap)CropImage(pictureEdit1.Image, ScaledCropRect);
            returnObject = bmp;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isEdit = false;
            this.Close();
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureEdit1.Image == null)
                return;

            Point pt = new Point(e.X, e.Y);

            if (rcLT.Contains(pt))
                Cursor = Cursors.SizeNWSE;
            else
                if (rcRT.Contains(pt))
                    Cursor = Cursors.SizeNESW;
                else
                    if (rcLB.Contains(pt))
                        Cursor = Cursors.SizeNESW;
                    else
                        if (rcRB.Contains(pt))
                            Cursor = Cursors.SizeNWSE;
                        else
                            if (CropRect.Contains(pt))
                                Cursor = Cursors.SizeAll;
                            else
                                Cursor = Cursors.Default;


            if (e.Button == MouseButtons.Left)
            {
                if (nResizeRB == 1)
                {
                    rcNew.X = CropRect.X;
                    rcNew.Y = CropRect.Y;
                    rcNew.Width = pt.X - rcNew.Left;
                    rcNew.Height = pt.Y - rcNew.Top;

                    if (rcNew.X > rcNew.Right)
                    {
                        rcNew.Offset(-nWd, 0);
                        if (rcNew.X < 0)
                            rcNew.X = 0;
                    }
                    if (rcNew.Y > rcNew.Bottom)
                    {
                        rcNew.Offset(0, -nHt);
                        if (rcNew.Y < 0)
                            rcNew.Y = 0;
                    }

                    DrawDragRect(e);
                    rcOld = CropRect = rcNew;
                    Cursor = Cursors.SizeNWSE;
                }
                else
                    if (nResizeBL == 1)
                    {
                        rcNew.X = pt.X;
                        rcNew.Y = CropRect.Y;
                        rcNew.Width = CropRect.Right - pt.X;
                        rcNew.Height = pt.Y - rcNew.Top;

                        if (rcNew.X > rcNew.Right)
                        {
                            rcNew.Offset(nWd, 0);
                            if (rcNew.Right > ClientRectangle.Width)
                                rcNew.Width = ClientRectangle.Width - rcNew.X;
                        }
                        if (rcNew.Y > rcNew.Bottom)
                        {
                            rcNew.Offset(0, -nHt);
                            if (rcNew.Y < 0)
                                rcNew.Y = 0;
                        }

                        DrawDragRect(e);
                        rcOld = CropRect = rcNew;
                        Cursor = Cursors.SizeNESW;
                    }
                    else
                        if (nResizeRT == 1)
                        {
                            rcNew.X = CropRect.X;
                            rcNew.Y = pt.Y;
                            rcNew.Width = pt.X - rcNew.Left;
                            rcNew.Height = CropRect.Bottom - pt.Y;

                            if (rcNew.X > rcNew.Right)
                            {
                                rcNew.Offset(-nWd, 0);
                                if (rcNew.X < 0)
                                    rcNew.X = 0;
                            }
                            if (rcNew.Y > rcNew.Bottom)
                            {
                                rcNew.Offset(0, nHt);
                                if (rcNew.Bottom > ClientRectangle.Height)
                                    rcNew.Y = ClientRectangle.Height - rcNew.Height;
                            }

                            DrawDragRect(e);
                            rcOld = CropRect = rcNew;
                            Cursor = Cursors.SizeNESW;
                        }
                        else
                            if (nResizeLT == 1)
                            {
                                rcNew.X = pt.X;
                                rcNew.Y = pt.Y;
                                rcNew.Width = CropRect.Right - pt.X;
                                rcNew.Height = CropRect.Bottom - pt.Y;

                                if (rcNew.X > rcNew.Right)
                                {
                                    rcNew.Offset(nWd, 0);
                                    if (rcNew.Right > ClientRectangle.Width)
                                        rcNew.Width = ClientRectangle.Width - rcNew.X;
                                }
                                if (rcNew.Y > rcNew.Bottom)
                                {
                                    rcNew.Offset(0, nHt);
                                    if (rcNew.Bottom > ClientRectangle.Height)
                                        rcNew.Height = ClientRectangle.Height - rcNew.Y;
                                }

                                DrawDragRect(e);
                                rcOld = CropRect = rcNew;
                                Cursor = Cursors.SizeNWSE;
                            }
                            else
                                if (nCropRect == 1)
                                {
                                    ptNew = pt;
                                    int dx = ptNew.X - ptOld.X;
                                    int dy = ptNew.Y - ptOld.Y;
                                    CropRect.Offset(dx, dy);
                                    rcNew = CropRect;
                                    DrawDragRect(e);
                                    ptOld = ptNew;
                                }

                AdjustResizeRects();
                pictureEdit1.Update();
            }

            base.OnMouseMove(e);
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            rcOriginal = CropRect;
            rcBegin = CropRect;

            if (rcRB.Contains(pt))
            {
                rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                rcNew = rcOld;
                nResizeRB = 1;
            }
            else
                if (rcLB.Contains(pt))
                {
                    rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                    rcNew = rcOld;
                    nResizeBL = 1;
                }
                else
                    if (rcRT.Contains(pt))
                    {
                        rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                        rcNew = rcOld;
                        nResizeRT = 1;
                    }
                    else
                        if (rcLT.Contains(pt))
                        {
                            rcOld = new Rectangle(CropRect.X, CropRect.Y, CropRect.Width, CropRect.Height);
                            rcNew = rcOld;
                            nResizeLT = 1;
                        }
                        else
                            if (CropRect.Contains(pt))
                            {
                                nResizeBL = nResizeLT = nResizeRB = nResizeRT = 0;
                                nCropRect = 1;
                                ptNew = ptOld = pt;
                            }
            nThatsIt = 1;
            base.OnMouseDown(e);
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (nThatsIt == 0)
                return;

            nCropRect = 0;
            nResizeRB = 0;
            nResizeBL = 0;
            nResizeRT = 0;
            nResizeLT = 0;

            if (CropRect.Width <= 0 || CropRect.Height <= 0)
                CropRect = rcOriginal;

            if (CropRect.X < 0)
                CropRect.X = 0;

            if (CropRect.Y < 0)
                CropRect.Y = 0;

            if (CropRect.Width > CropRect.Height)
            {
                CropRect.Height = (int)(CropRect.Width / CropAspectRatio);
            }
            else
            {
                CropRect.Width = (int)(CropRect.Height * CropAspectRatio);
            }

            if (pictureEdit1.Width < CropRect.Width)
            {
                CropRect.Width = pictureEdit1.Width;
            }
            if (pictureEdit1.Height < CropRect.Height)
            {
                CropRect.Height = pictureEdit1.Height;
            }
            Rectangle tempCropRect = CropRect;

            Rectangle tempRectangle = new Rectangle(0, 0, pictureEdit1.Width, pictureEdit1.Height);

            if (!tempRectangle.Contains(CropRect.Width + CropRect.X, pictureEdit1.Height / 2) && !tempRectangle.Contains(pictureEdit1.Width / 2, CropRect.Height + CropRect.Y))
            {
                CropRect.Y = pictureEdit1.Height - CropRect.Height;
                CropRect.X = pictureEdit1.Width - CropRect.Width;
            }
            else if (!tempRectangle.Contains(CropRect.Width + CropRect.X, pictureEdit1.Height / 2))
            {
                CropRect.X = pictureEdit1.Width - CropRect.Width;
            }
            else if (!tempRectangle.Contains(pictureEdit1.Width / 2, CropRect.Height + CropRect.Y))
            {
                CropRect.Y = pictureEdit1.Height - CropRect.Height;
            }
            AdjustResizeRects();
            pictureEdit1.Refresh();

            base.OnMouseUp(e);

            nWd = rcNew.Width;
            nHt = rcNew.Height;
            rcBegin = rcNew;
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void btnRotateImage_Click(object sender, EventArgs e)
        {
            Image temp = pictureEdit1.Image;
            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            LoadImage(temp);
        }

        private void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureEdit1.Image == null)
            {
                bool xGrayBox = true;
                int backgroundX = 0;
                while (backgroundX < pictureEdit1.Width)
                {
                    int backgroundY = 0;
                    bool yGrayBox = xGrayBox;
                    while (backgroundY < pictureEdit1.Height)
                    {
                        int recWidth = (int)((backgroundX + 50 > pictureEdit1.Width) ? pictureEdit1.Width - backgroundX : 50);
                        int recHeight = (int)((backgroundY + 50 > pictureEdit1.Height) ? pictureEdit1.Height - backgroundY : 50);
                        e.Graphics.FillRectangle(((Brush)(yGrayBox ? Brushes.LightGray : Brushes.Gainsboro)), backgroundX, backgroundY, recWidth + 2, recHeight + 2);
                        backgroundY += 50;
                        yGrayBox = !yGrayBox;
                    }
                    backgroundX += 50;
                    xGrayBox = !xGrayBox;
                }
            }
            else
            {
                e.Graphics.FillRectangle((BrushRect), CropRect);
                e.Graphics.FillRectangle((BrushRectSmall), rcLT);
                e.Graphics.FillRectangle((BrushRectSmall), rcRT);
                e.Graphics.FillRectangle((BrushRectSmall), rcLB);
                e.Graphics.FillRectangle((BrushRectSmall), rcRB);

                AdjustResizeRects();

            }
            base.OnPaint(e);
        }

        #endregion

        #region [Operations...]

        private void CenterCropBox()
        {
            UpdateAspectRatio();

            CropRect.X = (pictureEdit1.ClientRectangle.Width - CropRect.Width) / 2;
            CropRect.Y = (pictureEdit1.ClientRectangle.Height - CropRect.Height) / 2;

            AdjustResizeRects();
            pictureEdit1.Refresh();
        }

        void InitializeCropRectangle()
        {
            AlphaBlend = 48;

            nSize = 8;
            nWd = CropWidth = 300;
            nHt = 1;

            nThatsIt = 0;
            nResizeRT = 0;
            nResizeBL = 0;
            nResizeLT = 0;
            nResizeRB = 0;

            CropAspectRatio = 1.0;

            BrushColor = Color.White;
            BrushRect = new SolidBrush(Color.FromArgb(AlphaBlend, BrushColor.R, BrushColor.G, BrushColor.B));

            BrushColor = Color.Yellow;
            BrushRectSmall = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(192, BrushColor.R, BrushColor.G, BrushColor.B));

            ptOld = new Point(0, 0);
            rcBegin = new Rectangle();
            rcOriginal = new Rectangle(0, 0, 0, 0);
            rcLT = new Rectangle(0, 0, nSize, nSize);
            rcRT = new Rectangle(0, 0, nSize, nSize);
            rcLB = new Rectangle(0, 0, nSize, nSize);
            rcRB = new Rectangle(0, 0, nSize, nSize);
            rcOld = CropRect = new Rectangle(0, 0, nWd, nHt);

            AdjustResizeRects();
        }

        private void LoadImage(string file)
        {
            Cursor = Cursors.AppStarting;

            pictureEdit1.Image = Image.FromFile(file);

            if (pictureEdit1.Image.Height > 550 || pictureEdit1.Image.Width > 550)
            {
                Bitmap objBitmap;
                if (pictureEdit1.Image.Height > pictureEdit1.Image.Width)
                    objBitmap = new Bitmap(pictureEdit1.Image, new Size(pictureEdit1.Image.Width * 500 / pictureEdit1.Image.Height, 500));
                else
                    objBitmap = new Bitmap(pictureEdit1.Image, new Size(500, pictureEdit1.Image.Height * 500 / pictureEdit1.Image.Width));
                pictureEdit1.Image = objBitmap;
            }
            imageWidth = pictureEdit1.Image.Width;
            imageHeight = pictureEdit1.Image.Height;
            CropBoxSize(imageWidth / 2);

            if (imageWidth > imageHeight)
            {
                ImageAspectRatio = (double)imageWidth / (double)imageHeight;
                this.Width = 800 + (SystemInformation.BorderSize.Width * 2);
                this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;
            }
            else
            {
                ImageAspectRatio = (double)imageHeight / (double)imageWidth;
                this.Height = 800;
                this.Width = (int)((this.Height / ImageAspectRatio)) + HeightOffset;
            }

            CenterCropBox();
            Form1_ResizeEnd(null, null);
            CenterScreenWin();
            Cursor = Cursors.Default;
        }

        private void LoadImage(Image value)
        {
            Cursor = Cursors.AppStarting;

            pictureEdit1.Image = value;

            if (pictureEdit1.Image.Height > 550 || pictureEdit1.Image.Width > 550)
            {
                Bitmap objBitmap;
                if (pictureEdit1.Image.Height > pictureEdit1.Image.Width)
                    objBitmap = new Bitmap(pictureEdit1.Image, new Size(pictureEdit1.Image.Width * 500 / pictureEdit1.Image.Height, 500));
                else
                    objBitmap = new Bitmap(pictureEdit1.Image, new Size(500, pictureEdit1.Image.Height * 500 / pictureEdit1.Image.Width));
                pictureEdit1.Image = objBitmap;
            }

            imageWidth = pictureEdit1.Image.Width;
            imageHeight = pictureEdit1.Image.Height;
            CropBoxSize(imageWidth / 2);

            if (imageWidth > imageHeight)
            {
                ImageAspectRatio = (double)imageWidth / (double)imageHeight;
                this.Width = 800 + (SystemInformation.BorderSize.Width * 2);
                this.Height = (int)((this.Width / ImageAspectRatio)) + HeightOffset;
            }
            else
            {
                ImageAspectRatio = (double)imageHeight / (double)imageWidth;
                this.Height = 800;
                this.Width = (int)((this.Height / ImageAspectRatio)) + HeightOffset;
            }

            CenterCropBox();
            Form1_ResizeEnd(null, null);
            CenterScreenWin();
            Cursor = Cursors.Default;
        }

        #region [CenterScreenWin...]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);

        private void CenterScreenWin()
        {
            CentreWindow(Handle, GetMonitorDimensions());
        }

        private void CentreWindow(IntPtr handle, Size monitorDimensions)
        {
            RECT rect;
            GetWindowRect(new HandleRef(this, handle), out rect);

            var x1Pos = monitorDimensions.Width / 2 - (rect.Right - rect.Left) / 2;
            var x2Pos = rect.Right - rect.Left;
            var y1Pos = monitorDimensions.Height / 2 - (rect.Bottom - rect.Top) / 2;
            var y2Pos = rect.Bottom - rect.Top;

            SetWindowPos(handle, 0, x1Pos, y1Pos, x2Pos, y2Pos, 0);
        }

        private Size GetMonitorDimensions()
        {
            return SystemInformation.PrimaryMonitorSize;
        }

        #endregion

        private void CropBoxSize(int value)
        {
            CropWidth = value;
            CropRect.X = 0;
            CropRect.Y = 0;
            UpdateAspectRatio();
        }

        public void AdjustResizeRects()
        {
            rcLT.X = CropRect.Left;
            rcLT.Y = CropRect.Top;

            rcRT.X = CropRect.Right - rcRT.Width;
            rcRT.Y = CropRect.Top;

            rcLB.X = CropRect.Left;
            rcLB.Y = CropRect.Bottom - rcLB.Height;

            rcRB.X = CropRect.Right - rcRB.Width;
            rcRB.Y = CropRect.Bottom - rcRB.Height;
        }

        private void DrawDragRect(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AdjustResizeRects();
                pictureEdit1.Invalidate();
            }
        }

        private void UpdateAspectRatio()
        {
            CropAspectRatio = 1.0;
            int CropHeight = (int)((CropWidth / CropAspectRatio));

            try
            {
                ZoomedRatio = pictureEdit1.ClientRectangle.Width / (double)imageWidth;
            }
            catch
            {
                ZoomedRatio = 1.0;
            }
            CropRect.Width = (int)((double)CropWidth * ZoomedRatio);
            CropRect.Height = (int)((double)CropHeight * ZoomedRatio);

            nThatsIt = 1;
            pictureEdit1_MouseUp(null, null);
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            try
            {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            return null;
        }

        #endregion

    }
}