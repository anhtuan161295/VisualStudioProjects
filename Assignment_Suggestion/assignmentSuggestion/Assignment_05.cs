using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_05
    {
        static void Main(string[] args)
        {
            string[][] Sun_Valey = new string[6][];
            Sun_Valey[0] = new string[] { "01/01/2011", "08:00", "40", "36", "36", "5" };
            Sun_Valey[1] = new string[] { "01/01/2011", "10:00", "50", "38", "56", "5" };
            Sun_Valey[2] = new string[] { "01/01/2011", "12:00", "50", "25", "56", "6" };
            Sun_Valey[3] = new string[] { "02/01/2011", "08:00", "40", "30", "35", "5" };
            Sun_Valey[4] = new string[] { "02/01/2011", "10:00", "20", "39", "35", "7" };
            Sun_Valey[5] = new string[] { "02/01/2011", "12:00", "450", "46", "56", "5" };

            string[][] PanHandle = new string[6][];
            PanHandle[0] = new string[] { "01/01/2011", "08:00", "40", "36", "76", "5" };
            PanHandle[1] = new string[] { "01/01/2011", "10:00", "70", "39", "36", "6" };
            PanHandle[2] = new string[] { "01/01/2011", "12:00", "30", "35", "46", "5" };
            PanHandle[3] = new string[] { "02/01/2011", "08:00", "50", "30", "56", "5" };
            PanHandle[4] = new string[] { "02/01/2011", "10:00", "60", "39", "36", "7" };
            PanHandle[5] = new string[] { "02/01/2011", "12:00", "39", "39", "39", "5" };

            string[][] McCall = new string[6][];
            McCall[0] = new string[] { "01/01/2011", "08:00", "70", "46", "46", "7" };
            McCall[1] = new string[] { "01/01/2011", "10:00", "70", "39", "56", "6" };
            McCall[2] = new string[] { "01/01/2011", "12:00", "30", "39", "26", "5" };
            McCall[3] = new string[] { "02/01/2011", "08:00", "60", "30", "46", "5" };
            McCall[4] = new string[] { "02/01/2011", "10:00", "60", "49", "96", "7" };
            McCall[5] = new string[] { "02/01/2011", "12:00", "250", "46", "46", "5" };

            //khai bao 3 doi tuong mang chua thong tin(infoArr),ngay(dateArr),gio(timeArr)
            Array infoArr = Array.CreateInstance(typeof(string), 6);
            Array dateArr = Array.CreateInstance(typeof(string), 6);
            Array timeArr = Array.CreateInstance(typeof(string), 6);

            int index = 0;//luu chi muc mang
            string places;//luu chi muc dia danh thoi tiet tot
            bool ok = false;
            int i = 0, k;
            for (i = 0; i < Sun_Valey.GetLength(0); i++)
            {
                ok = false;
                places = " ";
                if (Convert.ToInt16(PanHandle[i][2]) < 40 && Convert.ToInt16(PanHandle[i][3]) < 40 && Convert.ToInt16(PanHandle[i][4]) < 50)
                {
                    ok = true;
                    places += "PanHandle" + " - ";
                }
                if (Convert.ToInt16(Sun_Valey[i][2]) < 40 && Convert.ToInt16(Sun_Valey[i][3]) < 40 && Convert.ToInt16(Sun_Valey[i][4]) < 50)
                {
                    ok = true;
                    places += "Sun Valey" + " - ";
                }
                if (Convert.ToInt16(McCall[i][2]) < 40 && Convert.ToInt16(McCall[i][3]) < 40 && Convert.ToInt16(McCall[i][4]) < 50)
                {
                    ok = true;
                    places += "Mc Call" + " - ";
                }
                //Neu mau tin thoa dieu kien thi add vao infoArr   
                if (ok)
                {
                    infoArr.SetValue(places, index);//lay cac dia danh co thoi tiet tot nhat gan vao mang
                    dateArr.SetValue(Sun_Valey[i][0], index);//lay ngay co thoi tiet tot nhat gan vao mang
                    timeArr.SetValue(Sun_Valey[i][1], index);
                    index++;
                }
            }
            //duyet mang infoArr
            for (i = 0; i < index; i++)
            {
                Console.WriteLine("On[" + dateArr.GetValue(i).ToString() + "] at [" + timeArr.GetValue(i).ToString() + "]");
                Console.WriteLine("\t The ideal weather conditions for skying at:" + infoArr.GetValue(i).ToString());
            }
        }
    }
}
