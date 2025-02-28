
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BasitKutuphaneYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            RastgeleKullaniciOlustur();
            KitapListesiOlustur();
            KitaplariRaflaraYerlestir();

            GirisMenu();
            IslemMenu();
        }

        private static void GirisMenu()
        {
            Console.WriteLine("Hoşgeldiniz");
            Console.WriteLine("1- Giriş Yap"); //
            Console.WriteLine("2- Kayıt Ol"); //

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    GirisYap();
                    break;
                case "2":
                    KayitOl();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                    return;
            }
        }

        static List<Kullanici> kayitliKisiler = new List<Kullanici>();
        private static void KayitOl()
        {
            Console.WriteLine("Adınız soyadınız: ");
            string adSoyad = Console.ReadLine();

            var id = kayitliKisiler[kayitliKisiler.Count - 1].Id;

            if (adSoyad != null)
            {
                Kullanici kullanici = new Kullanici 
                { 
                    Id = id + 1,
                    Isim = adSoyad
                };

                kayitliKisiler.Add(kullanici);
            }
            else
            {
                Console.WriteLine("Boş değer girdiniz.");
            }

            string jsonVeri = JsonConvert.SerializeObject(kayitliKisiler, Formatting.Indented);

            File.WriteAllText("Kisiler.json", jsonVeri);
        }
        static Random random = new Random();
        private static void RastgeleKullaniciOlustur()
        {
            string isimlerDosyaYolu = @"C:\Users\TT\source\repos\ProgramlamaGirisProjeleri\BasitKutuphaneYonetimSistemi\KullaniciIsimleri.txt";
            string soyisimlerDosyaYolu = @"C:\Users\TT\source\repos\ProgramlamaGirisProjeleri\BasitKutuphaneYonetimSistemi\KullaniciSoyisimleri.txt";

            List<string> isimler = new List<string>();
            List<string> soyisimler = new List<string>();

            using (StreamReader reader = new StreamReader(isimlerDosyaYolu))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    isimler.Add(line);
                }
            }

            using (StreamReader reader = new StreamReader(soyisimlerDosyaYolu))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    soyisimler.Add(line);
                }
            }

            
            for (int i = 0; i < 10; i++)
            {
                kayitliKisiler.Add(new() // aynı isim varsa eklemesin yeni oluştursun adım geri alsın
                {
                    Id = i + 1,
                    Isim = isimler[random.Next(isimler.Count)] + " " + soyisimler[random.Next(soyisimler.Count)]
                });
            }

        }
        private static void GirisYap()
        {
            KayitliKisilerListesi();

            string jsonVeri = File.ReadAllText("Kisiler.json");
            var kisiler = JsonConvert.DeserializeObject<List<Kullanici>>(jsonVeri);

            Console.WriteLine("Kullanıcı numaranızı giriniz: ");
            int kullaniciNo = int.Parse(Console.ReadLine());

            foreach (var kisi in kisiler)
            {

            }

            if ((kisiler.Count) >= kullaniciNo)
            {
                Console.WriteLine("Giriş başarılı. Hoşgeldin " + kayitliKisiler[kullaniciNo].Isim);
            }
            else
            {
                Console.WriteLine("Bu numarada bir kullanıcı bulunamadı.");
            }

            
        }

        private static void KayitliKisilerListesi()
        {
            Console.WriteLine("Kayıtlı Kişiler Listesi: ");
            foreach (var kisi in kayitliKisiler)
            {
                Console.WriteLine($"{kisi.Id}- {kisi.Isim}");
            }
        }

        private static void IslemMenu()
        {
            Console.WriteLine("Bir işlem seçiniz: ");
            Console.WriteLine("1- Kitap Kirala");
            Console.WriteLine("2- Kitap Teslim Et");
            Console.WriteLine("3- Kitap Bağışla");
            Console.WriteLine("4- Kitap Listesi");
            Console.WriteLine("5- Kiralanabilir Kitap Listesi");
            Console.WriteLine("6- Kiralanan Kitap Listesi");
            Console.WriteLine("7- Kayıtlı Kişiler Listesi");
            Console.WriteLine("8- Çıkış Yap");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    KitapKirala();
                    UcretHesapla();
                    break;
                case "2":
                    KitapTeslimEt(); // kiraladığı kitaplar gelsin.
                    break;
                case "3":
                    KitapBagisla();
                    break;
                case "4":
                    TumKitapListesi(); //
                    break;
                case "5":
                    KiralananKitapListesi();
                    break;
                case "6":

                    break;
                case "7":
                    KayitliKisilerListesi(); //
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                    return;
            }
        }

        private static void KitapKirala()
        {
            throw new NotImplementedException();
        }

        private static void UcretHesapla()
        {
            throw new NotImplementedException();
        }

        private static void KitapTeslimEt()
        {
            throw new NotImplementedException();
        }

        private static void KitapBagisla()
        {
            throw new NotImplementedException();
        }

        static Dictionary<string, List<KeyValuePair<string, string>>> raflarKitaplar = new Dictionary<string, List<KeyValuePair<string, string>>>();
        private static void TumKitapListesi()
        {
            Console.WriteLine("Tüm Kitaplar ve Bulunduğu Raflar: ");

            //foreach (var kitaplar in raflarKitaplar)
            //{
            //    Console.Write($"{kitaplar.Key} - ");

            //    foreach (var kitap in kitaplar.Value)
            //    {
            //        Console.WriteLine($"{kitap.Key} - {kitap.Value}");
            //    }
            //}

            string jsonVeri = File.ReadAllText("RaflarVeKitaplar.json");
            var raflar = JsonConvert.DeserializeObject<Dictionary<string, List<KeyValuePair<string, string>>>>(jsonVeri);

            foreach (var kitaplar in raflar)
            {
                Console.Write($"{kitaplar.Key} - ");

                foreach (var kitap in kitaplar.Value)
                {
                    Console.Write($"{kitap.Key} - {kitap.Value} / ");
                }
            }
        }

        private static void KitaplariRaflaraYerlestir()
        {
            List<string> raflar = new List<string>();

            for (char i = 'A'; i <= 'Z'; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    raflar.Add(i.ToString() + (j + 1));
                }
            }

            for (int i = 0; i < kitaplarYazarlar.Count; i++)
            {
                var kitap = kitaplarYazarlar.ElementAt(i);

                List<KeyValuePair<string, string>> kitaplar = new List<KeyValuePair<string, string>>();
                kitaplar.Add(kitap);

                int randomRaf = random.Next(raflar.Count);

                string gelenRaf = raflar[randomRaf];

                if (!raflarKitaplar.ContainsKey(gelenRaf))
                {
                    raflarKitaplar.Add(gelenRaf, kitaplar);
                }
                else if (raflarKitaplar[gelenRaf].Count < 5)
                {
                    var raftakiKitaplar = raflarKitaplar[gelenRaf];
                    raftakiKitaplar.Add(kitap);
                }
                else if (raflarKitaplar[gelenRaf].Count == 5)
                {
                    i--; // tekrar adımı turla.
                }
                else
                {
                    break;
                }
            }

            string jsonVeri = JsonConvert.SerializeObject(raflarKitaplar, Formatting.Indented);
            File.WriteAllText("RaflarVeKitaplar.json", jsonVeri);
        }
        static Dictionary<string, string> kitaplarYazarlar = new Dictionary<string, string>();
        private static void KitapListesiOlustur()
        {
            kitaplarYazarlar.Add("Suç ve Ceza", "Fyodor Dostoyevski");
            kitaplarYazarlar.Add("1984", "George Orwell");
            kitaplarYazarlar.Add("Büyük Umutlar", "Charles Dickens");
            kitaplarYazarlar.Add("Gurur ve Önyargı", "Jane Austen");
            kitaplarYazarlar.Add("Sefiller", "Victor Hugo");
            kitaplarYazarlar.Add("Don Kişot", "Miguel de Cervantes");
            kitaplarYazarlar.Add("Dönüşüm", "Franz Kafka");
            kitaplarYazarlar.Add("Harry Potter Serisi", "J.K. Rowling");
            kitaplarYazarlar.Add("Yüzüklerin Efendisi", "J.R.R. Tolkien");
            kitaplarYazarlar.Add("Game of Thrones (Buz ve Ateşin Şarkısı Serisi)", "George R.R. Martin");
            kitaplarYazarlar.Add("Açlık Oyunları", "Suzanne Collins");
            kitaplarYazarlar.Add("Kafes", "Josh Malerman");
            kitaplarYazarlar.Add("Beni Asla Bırakma", "Kazuo Ishiguro");
            kitaplarYazarlar.Add("Yeraltı Demiryolu", "Colson Whitehead");
            kitaplarYazarlar.Add("Kürk Mantolu Madonna", "Sabahattin Ali");
            kitaplarYazarlar.Add("Tutunamayanlar", "Oğuz Atay");
            kitaplarYazarlar.Add("Saatleri Ayarlama Enstitüsü", "Ahmet Hamdi Tanpınar");
            kitaplarYazarlar.Add("Şu Çılgın Türkler", "Turgut Özakman");
            kitaplarYazarlar.Add("İnce Mehmed", "Yaşar Kemal");
            kitaplarYazarlar.Add("Huzur", "Ahmet Hamdi Tanpınar");
            kitaplarYazarlar.Add("Aşk", "Elif Şafak");
            kitaplarYazarlar.Add("Atomik Alışkanlıklar", "James Clear");
            kitaplarYazarlar.Add("İnsanın Anlam Arayışı", "Viktor E. Frankl");
            kitaplarYazarlar.Add("Bilinçaltının Gücü", "Joseph Murphy");
            kitaplarYazarlar.Add("Düşün ve Zengin Ol", "Napoleon Hill");
            kitaplarYazarlar.Add("Akıllı Yatırımcı", "Benjamin Graham");
        }
        private static void KiralananKitapListesi()
        {
            throw new NotImplementedException();
        }
    }

    public class Kullanici
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public Dictionary<string, int> KiralananKitaplar { get; set; }
        public double Borc { get; set; }

    }
}
