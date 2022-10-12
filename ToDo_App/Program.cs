using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDo_App.Buyuklukler;
using static ToDo_App.Kolonlar;

namespace ToDo_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kart> kartlar = new List<Kart>();
            Kart kart1 = new Kart("Spor", "Germe", Buyukluk.XS, new Kisi(1,"Yunus"), Kolon.ToDo);
            kartlar.Add(kart1);
            Kart kart2 = new Kart("Eğitim", "İngilizce", Buyukluk.L, new Kisi(2,"Emre"), Kolon.InProgress);
            kartlar.Add(kart2);
            Kart kart3 = new Kart("Sağlık", "Diş Bakımı", Buyukluk.XL, new Kisi(5,"Eylül"), Kolon.Done);
            kartlar.Add(kart3);
            BASA_DON:
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz.\n" +
                "********************************************************\n" +
                "(1) Board Listelemek\n" +
                "(2) Board'a Kart Eklemek\n" +
                "(3) Board'dan Kart Silmek\n" +
                "(4) Kart Taşımak");
            int secenek = Convert.ToInt32(Console.ReadLine());
            switch (secenek)
            {
                case 1:
                    Listele:
                    Console.WriteLine("TODO LINE\n*************************************");
                    foreach(Kart kart in kartlar)
                    {
                        if(kart.Kolon.ToString() == "ToDo")
                        {
                            Console.WriteLine("Başlık : "+kart.Baslik);
                            Console.WriteLine("İçerik : "+kart.Icerik);
                            Console.WriteLine("Atanan Kişi : "+kart.Kisi.Name);
                            Console.WriteLine("Büyüklük : "+kart.Buyukluk);
                            Console.WriteLine("-");
                        }
                    }

                    Console.WriteLine("IN PROGRESS LINE\n*************************************");
                    foreach (Kart kart in kartlar)
                    {
                        if (kart.Kolon.ToString() == "InProgress")
                        {
                            Console.WriteLine("Başlık : " + kart.Baslik);
                            Console.WriteLine("İçerik : " + kart.Icerik);
                            Console.WriteLine("Atanan Kişi : " + kart.Kisi.Name);
                            Console.WriteLine("Büyüklük : " + kart.Buyukluk);
                            Console.WriteLine("-");
                        }
                    }

                    Console.WriteLine("DONE LINE\n*************************************");
                    foreach (Kart kart in kartlar)
                    {
                        if (kart.Kolon.ToString() == "Done")
                        {
                            Console.WriteLine("Başlık : " + kart.Baslik);
                            Console.WriteLine("İçerik : " + kart.Icerik);
                            Console.WriteLine("Atanan Kişi : " + kart.Kisi.Name);
                            Console.WriteLine("Büyüklük : " + kart.Buyukluk);
                            Console.WriteLine("-");
                        }
                    }
                    goto BASA_DON;

                case 2:
                    try
                    {
                        Console.Write("Başlık Giriniz : ");
                        string basliginiz = Console.ReadLine();
                        Console.Write("İçerik Giriniz : ");
                        string iceriginiz = Console.ReadLine();
                        Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5) : ");
                        Buyukluk buyuklugunuz = (Buyukluk)Convert.ToInt32(Console.ReadLine());
                        ID_DON:
                        Console.Write("Lütfen ID Giriniz : ");
                        int idiniz = Convert.ToInt32(Console.ReadLine());
                        foreach (Kart kart in kartlar)
                        {
                            if(idiniz == kart.Kisi.Id)
                            {
                                Console.WriteLine("Aynı ID'ye sahip bir kişi zaten var ! Lütfen başka bir ID giriniz.");
                                goto ID_DON;
                            }
                        }
                        Console.Write("Lütfen İsim Giriniz : ");
                        string isim = Console.ReadLine();
                        Console.Write("Kolon seciniz : TODO(1), IN PROGRESS(2), DONE(3) : ");
                        Kolon kolonunuz = (Kolon)Convert.ToInt32(Console.ReadLine());
                        kartlar.Add(new Kart(basliginiz, iceriginiz, buyuklugunuz, new Kisi(idiniz, isim), kolonunuz));

                        Console.WriteLine("Yeni Kart Eklendi !");
                        goto BASA_DON;
                       
                    }
                    catch (Exception e)
                    {

                        throw new Exception("Hatalı giriş veya girişler yaptınız!");
                    }

                case 3:
                    BASLIGA_DON:
                    Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını giriniz : ");
                    string g_baslik = Console.ReadLine();
                    bool bulundu_mu = false;
                    
                    for(int i = 0; i < kartlar.Count; i++)
                    {
                        if (kartlar[i].Baslik == g_baslik)
                        {
                            bulundu_mu = true;
                            kartlar.Remove(kartlar[i]);
                            Console.WriteLine("İşlem tamamlandı !");
                        }
                    }

                    if(bulundu_mu == false)
                    {
                        Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n" +
                            "* Silmeyi sonlandırmak için : (1)\n" +
                            "* Yeniden denemek için : (2)");
                        int secim = Convert.ToInt32(Console.ReadLine());
                        if(secim == 1)
                        {
                            Console.WriteLine("İşlem sonlandırıldı.");
                            goto BASA_DON;
                        }else if(secim == 2)
                        {
                            goto BASLIGA_DON;
                        }
                        
                        
                    }
                    goto BASA_DON;

                case 4:
                    ARAMAYA_DON:
                    Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\n" +
                        "Lütfen taşınacak kişinin ID'sini yazınız.");
                    int aranacak_id = Convert.ToInt32(Console.ReadLine());
                    bool bulundu = false;

                    for (int i = 0; i < kartlar.Count; i++)
                    {
                        if (kartlar[i].Kisi.Id == aranacak_id)
                        {
                            bulundu = true;
                            Console.WriteLine("Bulunan Kart Bilgileri\n" +
                                "**************************************");
                            Console.WriteLine("Başlık : " + kartlar[i].Baslik);
                            Console.WriteLine("İçerik : " + kartlar[i].Icerik);
                            Console.WriteLine("Atanan Kişi : " + kartlar[i].Kisi.Name);
                            Console.WriteLine("Büyüklük : " + kartlar[i].Buyukluk);
                            Console.WriteLine("Line : " + kartlar[i].Kolon);
                            Console.WriteLine("");
                            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz.\n" +
                                "(1) TODO\n" +
                                "(2) IN PROGRESS\n" +
                                "(3) DONE");
                            int sık = Convert.ToInt32(Console.ReadLine());
                            if(sık == 1)
                            {
                                kartlar[i].Kolon = Kolon.ToDo;
                                Console.WriteLine("İşlem Başarılı !");
                                goto Listele;

                            }else if(sık == 2)
                            {
                                kartlar[i].Kolon = Kolon.InProgress;
                                Console.WriteLine("İşlem Başarılı !");
                                goto Listele;
                            }
                            else if(sık == 3)
                            {
                                kartlar[i].Kolon = Kolon.Done;
                                Console.WriteLine("İşlem Başarılı !");
                                goto Listele;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı seçim yaptınız !");
                                goto BASA_DON;
                            }
                        }
                    }

                    if(bulundu == false)
                    {
                        Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n" +
                            " * İşlemi sonlandırmak için : (1)\n" +
                            " * Yeniden denemek için : (2)");
                        int cvp = Convert.ToInt32(Console.ReadLine());
                        if(cvp == 1)
                        {
                            goto BASA_DON;

                        }else if(cvp == 2)
                        {
                            goto ARAMAYA_DON;
                        }
                    }

                    break;

                
            }
        }
    }
}
