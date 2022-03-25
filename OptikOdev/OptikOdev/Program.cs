using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OptikOdev
{
    class Program
    {
        static void Main(string[] args)
        {
            string optikForm = "OptikForm.txt";
            FileStream dosya = new FileStream(optikForm, FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(dosya);
            string[] ogrenciler = new string[File.ReadAllLines(optikForm).Length];
            string kayit = oku.ReadLine(); 
            for (int i = 0; i < ogrenciler.Length; i++)
            {
                if (kayit!=null)
                {
                    ogrenciler[i] = kayit;
                    kayit = oku.ReadLine();
                }
                
            }
            oku.Close();
            dosya.Close();

            string cevapAnahtari = "CevapAnahtari.txt";
            dosya = new FileStream(cevapAnahtari, FileMode.Open, FileAccess.Read);
            oku = new StreamReader(dosya);
            int cvpsayisi = File.ReadLines(cevapAnahtari).Count();
            string[] cvpAnahtari = new string[cvpsayisi];
            string cevaplar = oku.ReadLine();
            for (int i = 0; i < cvpsayisi; i++)
            {
                if (cevaplar != null)
                {
                    cvpAnahtari[i] = cevaplar;
                    cevaplar = oku.ReadLine();
                }
            }
            int[] notlar = new int[ogrenciler.Length];
            int[] dsayisi = new int[ogrenciler.Length];
            int[] ysayisi = new int[ogrenciler.Length];
            int[] bsayisi = new int[ogrenciler.Length];
            for (int i = 0; i < ogrenciler.Length; i++)
            {
                for (int j = 0; j < cvpAnahtari.Length; j++)
                {
                        if (ogrenciler[i].Substring(43, 1) == cvpAnahtari[j].Substring(0, 1))//kitapcik eşitse
                        {
                            for (int z = 0; z < 20; z++)
                            {
                                Console.WriteLine("cevabım :"+ogrenciler[i].Substring(44)[z].ToString());
                                Console.WriteLine("cevap :"+cvpAnahtari[j].Substring(1)[z].ToString());
                                Console.WriteLine("--------");
                                if (ogrenciler[i].Substring(44)[z].ToString() == " ")
                                bsayisi[i] += 1;

                                if (ogrenciler[i].Substring(44)[z].ToString() == cvpAnahtari[j].Substring(1)[z].ToString() || cvpAnahtari[j].Substring(1)[z].ToString() == "*")
                                {
                                    notlar[i] += 5;
                                    dsayisi[i] += 1;
                       
                                }
                            }
                        ysayisi[i] = 20 - dsayisi[i];
                    }      
                    else
                    {
                        continue;
                    }
                    Console.Clear();
                }
            }
            oku.Close();
            dosya.Close();

            using (FileStream fs = File.Create("Sonuc.txt"))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < ogrenciler.Length; i++)
                    {
                            sw.WriteLine(ogrenciler[i].Substring(32, 11) + "," +
                                ogrenciler[i].Substring(0, 16).Trim() + "," +
                                ogrenciler[i].Substring(16, 16).Trim() + "," +
                                dsayisi[i] + "," +
                                ysayisi[i] + "," +
                                bsayisi[i] + "," +
                                notlar[i]);
                    }
                    sw.Close();
                }
            }
            Console.ReadKey();
        }
    }
}
