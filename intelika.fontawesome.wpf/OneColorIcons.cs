using intelika.fontawesome.wpf;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace intelika.fontawesome
{
    public class OneColorIcons
    {
        public static iconStyle IconStyle { get; set; }
        public class Properties
        {
            /// <summary>
            /// Image square size in pixels
            /// </summary>
            public int? Size { get; set; }
            /// <summary>
            /// Position of image
            /// </summary>
            public System.Drawing.Point? Location { get; set; }
            /// <summary>
            /// Color of image
            /// </summary>public Color ForeColor { get; set; }
            public System.Drawing.Color ForeColor { get; set; }
            /// <summary>
            /// Color of image
            /// </summary>public Color ForeColor { get; set; }
            public System.Drawing.Color? ForeColorAccent { get; set; }
            /// <summary>
            /// Background color of image
            /// </summary>
            public System.Drawing.Color? BackColor { get; set; }
            /// <summary>
            /// Border of image color
            /// </summary>
            public System.Drawing.Color? BorderColor { get; set; }
            /// <summary>
            /// Visible Border or not
            /// </summary>
            public bool? ShowBorder { get; set; }
            /// <summary>
            /// Image/icon type
            /// </summary>
            public NormalIconType Type { get; set; }
            public NormalIconType? Type2 { get; set; }
            public NormalIconType? Type3 { get; set; }

            private Properties()
            {
                Size = 32;
                Location = new System.Drawing.Point(0, 0);
                ForeColor = System.Drawing.Color.Black;
                BackColor = System.Drawing.Color.Transparent;
                BorderColor = System.Drawing.Color.Gray;
                ShowBorder = false;
            }

            public Properties(Properties iconProperty)
            {
                Size = iconProperty.Size == null ? Default.Size : iconProperty.Size;
                Location = iconProperty.Location == null ? Default.Location : iconProperty.Location;
                ForeColor = iconProperty.ForeColor;
                BackColor = iconProperty.BackColor == null ? Default.BackColor : iconProperty.BackColor;
                ForeColorAccent=iconProperty.ForeColorAccent == null ? Default.BackColor : iconProperty.ForeColorAccent;
                BorderColor = iconProperty.BorderColor == null ? Default.BorderColor : iconProperty.BorderColor;
                ShowBorder = iconProperty.ShowBorder == null ? Default.ShowBorder : iconProperty.ShowBorder;
                Type = iconProperty.Type;
                Type2 = iconProperty.Type2;
                Type3 = iconProperty.Type3;
            }
            public Properties(NormalIconType type, System.Drawing.Color color, System.Drawing.Color? accentColor, int size, NormalIconType? type2, NormalIconType? type3)
            {
                Size = size;
                Location = new System.Drawing.Point(0, 0);
                ForeColor =  color;
                ForeColorAccent = accentColor;
                BackColor = System.Drawing.Color.Transparent;
                BorderColor = System.Drawing.Color.Gray;
                ShowBorder = false;
                Type = type;
                Type2 = type2;
                Type3 = type3;
            }

            private static Properties _default;
            public static Properties Default
            {
                get
                {
                    _default ??= new Properties();
                    return _default;
                }
                internal set
                {
                    _default = value;
                }
            }

        }
        private readonly PrivateFontCollection _fonts = new();
        public enum iconStyle
        {
            regular,
            light,
            thin,
            solid,
            duotone
        }
        internal OneColorIcons(iconStyle style)
        {
            LoadFont(style);
        }
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        public void AddMemoryFont(byte[] fontResource)
        {
            IntPtr p;
            uint c = 0;

            p = Marshal.AllocCoTaskMem(fontResource.Length);
            Marshal.Copy(fontResource, 0, p, fontResource.Length);
            AddFontMemResourceEx(p, (uint)fontResource.Length, IntPtr.Zero, ref c);
            _fonts.AddMemoryFont(p, fontResource.Length);
            Marshal.FreeCoTaskMem(p);
        }
        /// <summary>
        /// Download (if neccessary) and load the font file.
        /// </summary>
        private void LoadFont(iconStyle style)
        {
            switch (style)
            {
                case iconStyle.regular:
                    AddMemoryFont(fontawesome.wpf.Properties.Resources.fa_regular_400);
                    break;
                case iconStyle.light:
                    AddMemoryFont(fontawesome.wpf.Properties.Resources.fa_light_300);
                    break;
                case iconStyle.thin:
                    AddMemoryFont(fontawesome.wpf.Properties.Resources.fa_thin_100);
                    break;
                case iconStyle.solid:
                    AddMemoryFont(fontawesome.wpf.Properties.Resources.fa_solid_900);
                    break;
                case iconStyle.duotone:
                    AddMemoryFont(fontawesome.wpf.Properties.Resources.fa_duotone_900);
                    break;
                default:
                    break;
            }
        }
        private static OneColorIcons _regularInstance;
        private static OneColorIcons _lightInstance;
        private static OneColorIcons _thinInstance;
        private static OneColorIcons _solidInstance;
        private static OneColorIcons _duotoneInstance;
        public static OneColorIcons RegularInstance
        {
            get
            {
                if (_regularInstance == null)
                {
                    Initialize(iconStyle.regular);
                }
                return _regularInstance;
            }
        }
        public static OneColorIcons LightInstance
        {
            get
            {
                if (_lightInstance == null)
                {
                    Initialize(iconStyle.light);
                }
                return _lightInstance;
            }
        }
        public static OneColorIcons ThinInstance
        {
            get
            {
                if (_thinInstance == null)
                {
                    Initialize(iconStyle.thin);
                }
                return _thinInstance;
            }
        }
        public static OneColorIcons SolidInstance
        {
            get
            {
                if (_solidInstance == null)
                {
                    Initialize(iconStyle.solid);
                }
                return _solidInstance;
            }
        }
        public static OneColorIcons DuotoneInstancee
        {
            get
            {
                if (_duotoneInstance == null)
                {
                    Initialize(iconStyle.duotone);
                }
                return _duotoneInstance;
            }
        }
        public static void Initialize(iconStyle style)
        {
            //load font to memory
            switch (style)
            {
                case iconStyle.regular:
                    _regularInstance ??= new OneColorIcons(style);
                    IconStyle = style;
                    break;
                case iconStyle.light:
                    _lightInstance ??= new OneColorIcons(style);
                    IconStyle = style;
                    break;
                case iconStyle.thin:
                    _thinInstance ??= new OneColorIcons(style);
                    IconStyle = style;
                    break;
                case iconStyle.solid:
                    _solidInstance ??= new OneColorIcons(style);
                    IconStyle = style;
                    break;
                case iconStyle.duotone:
                    _duotoneInstance ??= new OneColorIcons(style);
                    IconStyle = style;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="props">The props.</param>
        /// <returns></returns>
        public Icon GetIcon(NormalIconType type, System.Drawing.Color? color, int size = 16)
        {
            System.Drawing.Color iconColor = color == null ? System.Drawing.Color.Black : (System.Drawing.Color)color;
            var props = new Properties(type, iconColor,null, size, type2: null, type3: null);
            var img = GetImage(props);
            return Icon.FromHandle(img.GetHicon());
        }
        public ImageSource GetIconAsImageSource(NormalIconType type, System.Drawing.Color color, System.Drawing.Color? accentColor, int size = 32)
        {
            return ConvertBitmapToImageSource(GetImage(type, color,accentColor, size));
        }
        private ImageSource ConvertBitmapToImageSource(Bitmap bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            memory.Position = 0;

            var decoder = new PngBitmapDecoder(memory, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            return decoder.Frames[0];
        }
        // public Geometry GetIconAsGeometry(NormalIconType type);
        // public DrawingBrush GetIconAsBrush(NormalIconType type, System.Drawing.Color? color, int size = 32);
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="props">The props.</param>
        /// <returns></returns>
        public Bitmap GetImage(Properties iconProperty)
        {
            var props = new Properties(iconProperty);
            return GetImageInternal(props, IconStyle, null);
        }
        public Bitmap GetImage(NormalIconType type, System.Drawing.Color color, System.Drawing.Color? accentColor, int size = 32)
        {
            System.Drawing.Color iconColor = color;
            var props = new Properties(type, iconColor,accentColor, size, type2: null, type3: null);
            return GetImageInternal(props, IconStyle, null);
        }
        public Bitmap GetNumber(int number, System.Drawing.Color? color, System.Drawing.Color? backGround, int size = 32)
        {
            System.Drawing.Color iconColor = color == null ? System.Drawing.Color.Black : (System.Drawing.Color)color;
            if (number.ToString().Length == 1)
            {
                return GetImageInternal(new Properties(GetTypeByNumber(number),
                    iconColor,null, size,
                    type2: null,
                    type3: null),
                    IconStyle, backGround);
            }
            if (number.ToString().Length == 2)
            {
                return GetImageInternal(new Properties(GetTypeByNumber(int.Parse(number.ToString()[..1])),
                    iconColor,null, size,
                    type2: GetTypeByNumber(int.Parse(number.ToString().Substring(1, 1))),
                    type3: null),
                    IconStyle, backGround);
            }
            if (number.ToString().Length == 3)
            {
                return GetImageInternal(new Properties(GetTypeByNumber(int.Parse(number.ToString()[..1])),
                    iconColor,null, size,
                    type2: GetTypeByNumber(int.Parse(number.ToString().Substring(1, 1))),
                    type3: GetTypeByNumber(int.Parse(number.ToString().Substring(2, 1)))),
                    IconStyle, backGround);
            }
            return GetImageInternal(new Properties(NormalIconType.infinity,
                  iconColor,null, size,
                  type2: null,
                  type3: null),
                  IconStyle, backGround);

        }

        private NormalIconType GetTypeByNumber(int number)
        {
            return number switch
            {
                0 => NormalIconType._0,
                1 => NormalIconType._1,
                2 => NormalIconType._2,
                3 => NormalIconType._3,
                4 => NormalIconType._4,
                5 => NormalIconType._5,
                6 => NormalIconType._6,
                7 => NormalIconType._7,
                8 => NormalIconType._8,
                9 => NormalIconType._9,
                _ => NormalIconType.None,
            };
        }

        private System.Drawing.Font GetIconFont(int pixelSize)
        {
            var size = pixelSize / (16f / 12f); //pixel to point conversion rate
                                                //maybe caching would be useful
            var font = new System.Drawing.Font(_fonts.Families[0], size, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            return font;
        }
        private System.Drawing.Size GetFontIconRealSize(int size, int iconIndex)
        {
            var bmpTemp = new Bitmap(size, size);
            using (Graphics g1 = Graphics.FromImage(bmpTemp))
            {
                g1.TextRenderingHint = TextRenderingHint.AntiAlias;
                g1.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var font = GetIconFont(size);
                if (font != null)
                {
                    string character = char.ConvertFromUtf32(iconIndex);
                    var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.Word
                    };

                    var sizeF = g1.MeasureString(character, font, new System.Drawing.Point(0, 0), format);
                    return sizeF.ToSize();
                }
            }
            return new System.Drawing.Size(size, size);
        }
        private Bitmap ResizeImage(Bitmap imgToResize, Properties props)
        {
            var srcWidth = imgToResize.Width;
            var srcHeight = imgToResize.Height;

            float ratio = (srcWidth > srcHeight) ? (srcWidth / (float)srcHeight) : (srcHeight / (float)srcWidth);

            var dstWidth = (int)Math.Ceiling(srcWidth / ratio);
            var dstHeight = (int)Math.Ceiling(srcHeight / ratio);

            var x = (int)Math.Round(((int)props.Size - dstWidth) / 2f, 0);
            var y = (int)(1 + Math.Round(((int)props.Size - dstHeight) / 2f, 0));

            Bitmap b = new((int)props.Size + ((System.Drawing.Point)props.Location).X, (int)props.Size + ((System.Drawing.Point)props.Location).Y);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)b))
            {
                g.Clear((System.Drawing.Color)props.BackColor);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(imgToResize, x + ((System.Drawing.Point)props.Location).X, y + ((System.Drawing.Point)props.Location).Y, dstWidth, dstHeight);
            }
            return b;
        }
        private Bitmap GetImageInternal(Properties props, iconStyle style, System.Drawing.Color? backGroundColor)
        {
            var size1 = GetFontIconRealSize((int)props.Size, (int)props.Type);
            var size2 = props.Type2 != null ? GetFontIconRealSize((int)props.Size, (int)props.Type2) : new System.Drawing.Size(0, 0);
            var size3 = props.Type3 != null ? GetFontIconRealSize((int)props.Size, (int)props.Type3) : new System.Drawing.Size(0, 0);
            var size = new System.Drawing.Size(size1.Width + size2.Width + size3.Width, size1.Height);
            var bmpTemp = new Bitmap(size.Width, size.Height);
            using (Graphics g1 = Graphics.FromImage(bmpTemp))
            {
                g1.TextRenderingHint = TextRenderingHint.AntiAlias;
                g1.Clear(backGroundColor==null? System.Drawing.Color.Transparent:(System.Drawing.Color)backGroundColor);
                var font = GetIconFont((int)props.Size);
                if (font != null)
                {
                    string character = char.ConvertFromUtf32((int)props.Type);
                    string characterOne = props.Type2 != null ? char.ConvertFromUtf32((int)props.Type2) : "";
                    string characterTwo = props.Type3 != null ? char.ConvertFromUtf32((int)props.Type3) : "";
                    //var format = new StringFormat()
                    //{
                    //    Alignment = StringAlignment.Center,
                    //    LineAlignment = StringAlignment.Center,
                    //    Trimming = StringTrimming.Character
                    //};
                    g1.DrawString(character, font, new SolidBrush((System.Drawing.Color)props.ForeColor), 0, 0);
                    if (characterOne != "")
                    {
                        g1.DrawString(characterOne, font, new SolidBrush((System.Drawing.Color)props.ForeColor), size1.Width, 0);
                    }
                    if (characterTwo != "")
                    {
                        g1.DrawString(characterTwo, font, new SolidBrush((System.Drawing.Color)props.ForeColor), size1.Width + size2.Width, 0);
                    }

                    if (style == iconStyle.duotone)
                    {
                        string character1 = char.ConvertFromUtf32(((int)props.Type) + 1048576);
                        System.Drawing.Color secendColor = props.ForeColorAccent!=null? (System.Drawing.Color)(System.Drawing.Color)props.ForeColorAccent: (System.Drawing.Color)props.ForeColor;
                        g1.DrawString(character1, font, new SolidBrush(secendColor), 0, 0);
                    }
                    g1.DrawImage(bmpTemp, 0, 0);
                }
            }

            var bmp = ResizeImage(bmpTemp, props);
            if ((bool)props.ShowBorder)
            {
                using Graphics g2 = Graphics.FromImage(bmp);
                var pen = new System.Drawing.Pen((System.Drawing.Color)props.BorderColor, 1);
                var borderRect = new Rectangle(0, 0, (int)(props.Size - pen.Width), (int)(props.Size - pen.Width));
                g2.DrawRectangle(pen, borderRect);
            }
            return bmp;
        }
    }
}
