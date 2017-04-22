using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTMTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(@"D:\QTMTest0903.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);



            //level 9
            float P = (float)Math.Pow(4, 9);
            float I = 512;

            //level 3
            //float P = Math.Pow(4, 3);
            //float I = 56;

            //level 3
            //float P = (float)Math.Pow(4, 2);//一个oct 的单元数
            //float I = 4;//行数

            //for (int N=0;N<262144*8;N++)
            for (int N = 0; N < P * 8; N++)
            {

                float K = N - (int)(N / P) * P;

                float i = (int)(Math.Pow(K, 0.5));
                float j = K - i * i;

                float lon=0;
                float lat=0;

                float Lon=0;
                float Lat=0;

                float A=(int)(j/2);
                float B=(int)((j+1)/2);

                float C=(float )(90-(i/I)*90);
                float D=(float )(90-((i+1)/I)*90);

                if ((j % 2 == 1) ? true : false)
                {
                    lon = ((float )1/3 )*((90 / i) * A + (90 / (i+1)) * A + (90 / (i+1)) * B);
                    lat=(2*C+D)*((float )1/3);
                }
                else
                {
                    lon = (((float)1 / 3) * ((90 / i) * A + (90 / i) * B + (90 / (i + 1)) * B));
                    lat = ((float)1 / 3) * (C + 2 * D);

                }


            if (0 <= N&&N < P * 1)
            {
                if (double.IsNaN(lon))
                {
                    lon = 0;
                }
                Lon=lon;
                Lat=lat;


            }
            else if (P * 1 <= N && N < P * 2)
            {
                if (double.IsNaN(lon))
                {
                    lon = 90;
                }
                Lon=lon+90;
                Lat=lat;

            }
            else if (P * 2 <= N && N < P * 3)
            {
                if (double.IsNaN(lon))
                {
                    lon = -180;
                }

                                Lon=lon-180;
                Lat=lat;

            }
            else if (P * 3 <= N && N < P * 4)
            {
                if (double.IsNaN(lon))
                {
                    lon = -90;
                }
                Lon=lon-90;
                Lat=lat;


            }
            else if (P * 4 <= N && N < P * 5)
            {
                //if (double.IsNaN(lon))
                //{
                //    lon = 0;
                //}

                                Lon=90-lon;
                Lat=-lat;

            }
            else if (P * 5 <= N && N < P * 6)
            {
                //if (double.IsNaN(lon))
                //{
                //    lon = 90;
                //}
                                                Lon=180-lon;
                Lat=-lat;

            }
            else if (P * 6 <= N && N < P *7)
            {
                //if (double.IsNaN(lon))
                //{
                //    lon = -180;
                //}
                                                Lon=-90-lon;
                Lat=-lat;


            }
            else if (P * 7 <= N && N < P * 8)
            {
                //if (double.IsNaN(lon))
                //{
                //    lon = -90;
                //}
                                                Lon=-lon;
                Lat=-lat;


            }


 

            //开始写入
            //sw.WriteLine(N.ToString() + " " + Lon.ToString() + " " + Lat.ToString());
            sw.WriteLine(N.ToString() + " " + Lon.ToString() + " " + Lat.ToString() + " ");


            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();

            fs.Close();


        }
        public void GenerateQTMCode()
    {

    }

    }
}
