﻿using intelika.fontAwesome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Icons.LightIcon.GetIcon(NormalIconType.waveform,Color.Red);
            
        }
        public Color iconColor { get; set; }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // getIcons();
        }
        void getIcons()
        {
            if (comboBox1.SelectedIndex > 0)
            {
                int total = 0;
                int failed = 0;
                int accept = 0;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Regular":
                        { 
                        flowLayoutPanel1.Controls.Clear();
                        StringBuilder sb = new StringBuilder();
                        //foreach (NormalIconType icon in Enum.GetValues(typeof(NormalIconType)))
                        //{
                        //    ++total;
                        //    if (total>=400)
                        //    {
                        //        continue;
                        //    }
                        //    PictureBox pictureBox = new PictureBox();
                        //    var currentIcon = Icons.RegularIcon.GetImage(type: icon, color: iconColor);
                        //        pictureBox.Image = currentIcon;
                        //        pictureBox.Tag = icon;
                        //        pictureBox.Click += PictureBox_Click;
                        //        flowLayoutPanel1.Controls.Add(pictureBox);
                        //        ++accept;                           
                        //}
                        PictureBox pictureBox = new PictureBox();
                        var currentIcon = Icons.RegularIcon.GetImage(type: NormalIconType.person_carry, color: iconColor);
                        pictureBox.Image = currentIcon;
                        pictureBox.Tag = NormalIconType.refresh;
                        pictureBox.Click += PictureBox_Click;
                        flowLayoutPanel1.Controls.Add(pictureBox);
                        Refresh();
                }
                        break;
                    case "Light":
                        flowLayoutPanel1.Controls.Clear();
                        foreach (NormalIconType icon in Enum.GetValues(typeof(NormalIconType)))
                        {
                            ++total;
                            if (total >= 400)
                            {
                                continue;
                            }
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.LightIcon.GetImage(type: icon, color: iconColor);

                                pictureBox.Image = currentIcon;
                                pictureBox.Tag = icon;
                                pictureBox.Click += PictureBox_Click;
                                flowLayoutPanel1.Controls.Add(pictureBox);
                                ++accept;                           
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;

                    case "Thin":
                        flowLayoutPanel1.Controls.Clear();
                        foreach (NormalIconType icon in Enum.GetValues(typeof(NormalIconType)))
                        {
                            ++total;
                            if (total >= 400)
                            {
                                continue;
                            }
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.ThinIcon.GetImage(type: icon, color: iconColor);

                                pictureBox.Image = currentIcon;
                                pictureBox.Tag = icon;
                                pictureBox.Click += PictureBox_Click;
                                flowLayoutPanel1.Controls.Add(pictureBox);
                                ++accept;                          
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    case "Solid":
                        flowLayoutPanel1.Controls.Clear();

                        foreach (NormalIconType icon in Enum.GetValues(typeof(NormalIconType)))
                        {
                            ++total;
                            if (total >= 400)
                            {
                                continue;
                            }
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.SolidIcon.GetImage(type: icon, color: iconColor);

                                pictureBox.Image = currentIcon;
                                pictureBox.Tag = icon;
                                pictureBox.Click += PictureBox_Click;
                                flowLayoutPanel1.Controls.Add(pictureBox);
                                ++accept;
                          
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    case "Duotone":
                        flowLayoutPanel1.Controls.Clear();

                        foreach (NormalIconType icon in Enum.GetValues(typeof(NormalIconType)))
                        {
                            ++total;
                            if (total >= 400)
                            {
                                continue;
                            }
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.DuotoneIcons.GetImage(type: icon, color: iconColor);

                            pictureBox.Image = currentIcon;
                            pictureBox.Tag = icon;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                            ++accept;

                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    default:
                        break;
                }
                lblTotal.Text=total.ToString();
                lblFailed.Text = failed.ToString();
                lblAccept.Text=accept.ToString();
            }
        }
        void getNumbers()
        {
            if (comboBox1.SelectedIndex > 0)
            {
                int total = 0;
                int failed = 0;
                int accept = 0;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Regular":

                        flowLayoutPanel1.Controls.Clear();
                        for (int i = 0; i < 1010; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.RegularIcon.GetNumber(i, color: Color.White, null);
                            pictureBox.Image = currentIcon;
                            pictureBox.BackColor = iconColor;
                            pictureBox.Tag = i;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }                        
                        Refresh();
                        break;
                    case "Light":
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Clear();
                        for (int i = 0; i < 1010; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.LightIcon.GetNumber(i, color: Color.White, iconColor);
                            pictureBox.Image = currentIcon;
                            pictureBox.Tag = i;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;

                    case "Thin":
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Clear();
                        for (int i = 0; i < 1010; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.ThinIcon.GetNumber(i, color: Color.White, iconColor);
                            pictureBox.Image = currentIcon;
                            pictureBox.Tag = i;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    case "Solid":
                        flowLayoutPanel1.Controls.Clear();

                        flowLayoutPanel1.Controls.Clear();
                        for (int i = 0; i < 1010; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.SolidIcon.GetNumber(i, color: Color.White, iconColor);
                            pictureBox.Image = currentIcon;
                            pictureBox.Tag = i;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    case "Duotone":
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Clear();
                        for (int i = 0; i < 1010; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            var currentIcon = Icons.DuotoneIcons.GetNumber(i, color: Color.White, iconColor);
                            pictureBox.Image = currentIcon;
                            pictureBox.Tag = i;
                            pictureBox.Click += PictureBox_Click;
                            flowLayoutPanel1.Controls.Add(pictureBox);
                        }
                        Refresh();
                        break;
                    default:
                        break;
                }
                lblTotal.Text = total.ToString();
                lblFailed.Text = failed.ToString();
                lblAccept.Text = accept.ToString();
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            MessageBox.Show($"{pb.Tag}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iconColor = Color.Black;
            button1.BackColor = iconColor;
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                iconColor = colorDialog1.Color;
                button1.BackColor = iconColor;
                getIcons();
            }
        }
        public static bool CompareBitmapsFast(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }
        int a=0;
        private void button2_Click(object sender, EventArgs e)
        {
            switch (a)
            {
                case 0:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.abacus, Color.Red);
                    ++a;
                    break;
                case 1:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.acorn, Color.Red);
                    ++a;
                    break;
                case 2:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.ad, Color.Red);
                    ++a;
                    break;
                case 3:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.address_card, Color.Green);
                    ++a;
                    break;
                case 4:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.alarm_clock, Color.GreenYellow);
                    ++a;
                    break;
                case 5:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.abacus, Color.Red);
                    ++a;
                    break;
                case 6:
                    this.Icon = Icons.LightIcon.GetIcon(NormalIconType.abacus, Color.Red);
                    ++a;
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //getNumbers();
            getIcons();
        }
    }
}
