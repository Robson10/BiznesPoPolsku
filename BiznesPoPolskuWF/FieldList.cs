using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiznesPoPolskuWF.Properties;
namespace BiznesPoPolskuWF
{
    public class pole
    {
        public string nazwa_pola, czyje;
        public int cena, upgrade_cena, zastaw_cena, upgrade_lv, dochod, index_pola, kara;
        public bool czy_zastaw;
        public PictureBox Pole;
        private string[] p_nazwa_pola = new string[]
        {
             "Start","Zawód Nauczyciel","Posterunek Policji","Szkoła Prywatna","Budka z Hot-Dogami","Zawód Lekarz","Partia polityczna","Kiosk ruchu","Los","Zakład Szklarski",
             "Agencja Detektywistyczna","Szpital","Hotel Wypoczynkowy","Zakład Fryzjerski","Kurczak z Rożna","Radny Rady Miasta","Wypożyczalnia Kaset Video","Stragan z Warzywami","Zakład Fotograficzny","Autokomis",
             "Urząd Skarbowy","Zawód Elektryk","Lumpex","Więzienie","Poseł","Auto-bar","Kiełbaski z Rożna","Lombard","Kantor Wymiany Walut","Zawód Policjant",
             "Naprawa RTV","Niespodzianka","Senator","Agencja Ochrony","Taksówka","Firma Remontowa","Radiesteta","Zawód Księgowy","Sklep Spożywczy","Siłownia i Fitness Club"
        };
        private int[] p_cena = new int[]
        {
                -1,0,-1,2800,700,                0,300,1000,-1,1300,
                1500,-1,-1,1600,700,             1800,900,900,4000,1800,
                -1,0,1200,-1,3000,               800,500,800,1000,0,
                1500,-1,2800,2600,2500,          1400,500,0,3800,2500
        };//za ile kupi sie pole
        private int[] p_upgrade_cena = new int[]
            {
                 -1,-1,-1,800,300,                 -1,-1,400,-1,600,
                 800,-1,-1,600,300,                -1,450,400,900,700,
                 -1,-1,600,-1,-1,                  300,300,1000,1500,-1,
                 800,-1,-1,700,600,                1300,500,-1,1500,900
            };
        //koszty budynku
        private int[] p_zastaw_cena = new int[]
        {
            -1,-1,-1,1400,350,            -1,-1,500,-1,650,
            750,-1,-1,800,350,            -1,450,450,2000,900,
            -1,-1,600,-1,-1,              400,250,400,500,-1,
            750,-1,-1,1300,1250,          700,250,-1,1900,1250
        };

        private bool[] p_czy_zastaw = new bool[]
        {
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false
        }; // tak nie
        private string[] p_czyje = new string[]
        {
            null,null,null,null,null,null,null,null,null,null,
            null,null,null,null,null,null,null,null,null,null,
            null,null,null,null,null,null,null,null,null,null,
            null,null,null,null,null,null,null,null,null,null
        };

        private int[] p_upgrade_lv = new int[]
        {
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0
        };
        private int[] p_dochod = new int[]
        {
            0,1400,0,0,0,            1600,0,0,0,0,
            0,0,0,0,0,               0,0,0,0,0,
            0,2200,0,0,0,            0,0,0,0,1800,
            0,0,0,0,0,               0,0,2000,0,0
        };
        private int[] p_index_pola = new int[]
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40
        };
        private int[,] p_kara = new int[,]
        {
        /*1*/{300,300,300,300,300,300},        {600,600,600,600,600,600},        {0,0,0,0,0,0},                  {150,300,900,1800,3000,5400},     {20,90,200,500,1000,2100},
             {700,700,700,700,700,700},        {300,300,300,300,300,300},        {30,100,300,700,1300,2200},     {-100,-100,-100,-100,-100,-100},  {100,500,950,1600,2200,3500},
       /*11*/{120,550,1000,1500,2400,4100},    {-200,-200,-200,-200,-200,-200},  {-100,-100,-100,-100,-100,-100},{20,110,300,700,1400,3000},       {20,100,200,400,800,1600},
             {500,500,500,500,500,500},        {10,50,100,350,800,2200},         {30,120,240,500,1400,2800},     {120,600,1200,2500,3800,6600},    {180,800,1600,3000,4100,5500},         
       /*21*/{-800,-800,-800,-800,-800,-800},  {800,800,800,800,800,800},        {50,250,500,1000,2100,4200},    {0,0,0,0,0,0},                    {1000,1000,1000,1000,1000,1000},
             {40,200,400,800,1500,2500},       {30,150,350,700,1300,2500},       {100,500,900,1700,2800,3600},   {300,1400,2500,3800,4600,6500},   {600,600,600,600,600,600},        
       /*31*/{80,320,700,1400,2600,3800},      {0,0,0,0,0,0},                    {900,900,900,900,900,900},      {100,400,800,1600,3200,5600},     {40,160,320,700,1500,3000},
             {190,700,1400,2500,4000,8400},    {80,400,700,1400,2000,3100},      {700,700,700,700,700,700},      {200,900,1800,3100,5000,9000},    {120,600,1000,2100,3200,5000}
       };
        private Image[] p_images = new Image[]
            {Resources._1,Resources._2,Resources._3,Resources._4,Resources._5,Resources._6,Resources._7,Resources._8,Resources._9,Resources._10,
Resources._11,Resources._12,Resources._13,Resources._14,Resources._15,Resources._16,Resources._17,Resources._18,Resources._19,Resources._20,
Resources._21,Resources._22,Resources._23,Resources._24,Resources._25,Resources._26,Resources._27,Resources._28,Resources._29,Resources._30,
Resources._31,Resources._32,Resources._33,Resources._34,Resources._35,Resources._36,Resources._37,Resources._38,Resources._39,Resources._40,
            };
        //konstruktor
        public pole(int _index)
        {
            nazwa_pola = p_nazwa_pola[_index];
            czyje = p_czyje[_index];
            cena = p_cena[_index];
            upgrade_cena = p_upgrade_cena[_index];
            zastaw_cena = p_zastaw_cena[_index];
            upgrade_lv = p_upgrade_lv[_index];
            dochod = p_dochod[_index];
            index_pola = p_index_pola[_index];
            kara = p_kara[_index, upgrade_lv];
            czy_zastaw = p_czy_zastaw[_index];
            Pole = new PictureBox() { Image = p_images[_index], SizeMode= PictureBoxSizeMode.StretchImage };
        }

        public int pole_upgrade(pole x)
        {
            return x.kara = p_kara[x.index_pola, x.upgrade_lv + 1];
        }
        public int kara_upgrade(pole x)
        {
            return p_kara[x.index_pola, x.upgrade_lv + 1];
        }



    }
    //public class FieldList:List<FieldItem>
    //{
    //    FieldList()
    //    {
    //        GenerateAll();
    //    }
    //    private void GenerateAll()
    //    {
    //        this.Add(new FieldItem(Resources._1, new Point(), new Size(), 0, "Start", false, 0, 0, null, Enum.FieldType.Start));
    //        this.Add(new FieldItem(Resources._2, new Point(), new Size(), 0, "Zawód Nauczyciel", true, 0, 0, new List<int>() { 1400 }, new List<int>() { 600 },Enum.FieldType.Work));
    //        this.Add(new FieldItem(Resources._3, new Point(), new Size(), 0, "Posterunek Policji", false, 0, 0, null, null,Enum.FieldType.Functional));
    //        this.Add(new FieldItem(Resources._4, new Point(), new Size(), 0, "Szkola", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._5, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._6, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._7, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._8, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._9, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._10, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._11, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._12, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._13, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._14, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._15, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._16, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._17, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._18, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._19, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._20, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._21, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._22, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._23, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._24, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._25, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._26, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._27, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._28, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._29, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._30, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._31, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._32, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._33, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._34, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._35, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));

    //        this.Add(new FieldItem(Resources._36, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._37, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._38, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._39, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //        this.Add(new FieldItem(Resources._40, new Point(), new Size(), 0, "Start", false, 0, false, 0, null, false, false, false));
    //    }
    //}
    //public class FieldItem
    //{
    //    public FieldItem(Image pPicture,Point pLocation, Size pSize,int pNumber,string pName,bool pIsBuyAble,int pBuyCost,int pUpgradeCost,
    //    List<int> pIncome,List<int>pPayment,Enum.FieldType pType )
    //    {
    //        Image = pPicture;
    //        Location = pLocation;
    //        Size = pSize;
    //        Number = pNumber;
    //        Name = pName;
    //        IsBuyAble = pIsBuyAble;
    //        BuyCost = pBuyCost;
    //        UpgradeCost = pUpgradeCost;
    //        Income = pIncome;
    //        Type = pType;
    //    }
    //    public Image Image{ get; }
    //    public Point Location { get; set; }
    //    public Size Size { get; set; }
    //    public int Number { get; }
    //    public string Name { get; }
    //    public string Who { get; set; } = "";
    //    public bool IsBuyAble { get; }
    //    public int BuyCost { get; }
    //    public bool IsUpgradeAble { get; }
    //    public int UpgradeCost { get; }
    //    public int UpgradeLevel { get; set; } = 0;
    //    List<int> Income { get; }
    //    List<int> Payment { get; }
    //    public int NowIncome { get { return Income[UpgradeLevel]; } }
    //    public Enum.FieldType Type { get; }

    //}
    //public static class Enum
    //{ 
    //    public enum FieldType
    //    {
    //        Start=0,
    //        Work=1,
    //        Property=2,//isUpgradeAble
    //        Surprise=3,
    //        Functional=4
    //    }
    //}
}
