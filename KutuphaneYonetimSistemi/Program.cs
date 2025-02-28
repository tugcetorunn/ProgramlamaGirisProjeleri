using System.ComponentModel.Design;
using System.Linq;

namespace KutuphaneYonetimSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            // menü - işlem seçiniz
            // kullanıcı giriş id - name dictionary
            // yeni kayıt
            // kitap kirala
            // kitap teslim
            // kitap bağışlama
            // kitaplar listesi -> map -> dictionary (raf no - isim, yazar)
            // kiralanan kitaplar listesi
            // rafa kitap yerleştirme -> raf no - list<kitaplar>

            // raflar enum - a, b, c, d, ...
            // dictionary<string, list<kitaplar>> - {a1-a10/z1-z10}, kitaplar[0]...[299] kapasite 300
            // alfabetik sırala raflara öyle yerleştir

            // kitaplar generate

            //int rafSayisi = 0;
            KitaplariListeyeAta();
            RafOlustur();
            //rafSayisi = _rafSayisi;

            
            KitaplariRaflaraYerlestir();
            KiralanabilirKitaplarListesi();
            // yeni kitap eklendiğinde random yerleştir.

            GirisMenu();
            IslemMenu();
        }

        private static void GirisMenu()
        {
            Console.WriteLine("Hoşgeldiniz");
            Console.WriteLine("1- Giriş Yap");
            Console.WriteLine("2- Kayıt Ol");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    GirisYap();
                    break;
                case "2":
                    KayitOl(); //
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim yaptınız.");
                    return;
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
                    TumKitapListesi();
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

        private static void UcretHesapla()
        {
            throw new NotImplementedException();
        }

        // todo: kişiler 10 tane random gelsin
        static Dictionary<int, string> kayitliKisiler = new Dictionary<int, string>();
        private static void KayitliKisilerListesi()
        {
            Console.WriteLine("Kayıtlı Kişiler Listesi: ");
            foreach (var kisi in kayitliKisiler)
            {
                Console.WriteLine($"{kisi.Key}- {kisi.Value}");
            }
        }

        static Dictionary<string, Dictionary<string, string>> kiralananKitaplar = new Dictionary<string, Dictionary<string, string>>();
        private static void KiralananKitapListesi()
        {
            Console.WriteLine("Kiralanan Kitap Listesi: ");

            var kiralananKitaplarValues = kiralananKitaplar.Values.ToList(); // ToDictionary(new Dictionary<string, string>())
            var kiralananKitaplarKeys = kiralananKitaplar.Keys.ToList();


            for (int i = 0; i < kiralananKitaplar.Count; i++)
            {
                Console.WriteLine($"{kiralananKitaplarKeys[i]} - {kiralananKitaplarValues[i]}");
            }
        }

        //static string[,] raflar; // {{"A1", "A2"},{"B1", "B2"}}
        static List<string> raflar = new List<string>(); // {"A1", "A5",..., "Z1", "Z5"}
        //static Dictionary<string, string> harfBazliKitaplar = new Dictionary<string, string>();
        private static void RafOlustur()
        {

            for (char i = 'A'; i <= 'Z'; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    raflar.Add(i.ToString() + (j + 1));
                }

                //foreach (var kitap in kitaplarYazarlar)
                //{
                //    if (kitap.Key.StartsWith(i))
                //    {
                //        harfBazliKitaplar.Add(kitap.Key, kitap.Value);
                //    }
                //}
            }

            //foreach (var raf in raflar)
            //{
            //    Console.WriteLine(raf);
            //}
        }

        static Dictionary<string, string> kitaplarYazarlar = new Dictionary<string, string>();
        static Dictionary<string, List<KeyValuePair<string, string>>> rafBazliKitaplar = new Dictionary<string, List<KeyValuePair<string, string>>>(); // rafIsimleri - dict<> kitaplarYazarlar
        static Random random = new Random();
        private static void KitaplariRaflaraYerlestir()
        {
            List<string> kullanilanRaflar = new List<string>();

            foreach (var kitap in kitaplarYazarlar)
            {
                string randomRaf;

                if (kullanilanRaflar.Count == raflar.Count)
                {
                    randomRaf = rafBazliKitaplar.OrderBy(r => r.Value.Count).First().Key;
                }
                else
                {
                    do
                    {
                        randomRaf = raflar[random.Next(raflar.Count)];
                    } while (kullanilanRaflar.Contains(randomRaf) && kullanilanRaflar.Count < raflar.Count);

                    if (!kullanilanRaflar.Contains(randomRaf))
                    {
                        kullanilanRaflar.Add(randomRaf);
                    }
                }

                if (!rafBazliKitaplar.ContainsKey(randomRaf))
                {
                    var rafIcindekiler = rafBazliKitaplar[randomRaf];
                    rafIcindekiler.Add(kitap);
                    //var value = new List<KeyValuePair<string, string>>();
                    //value.Add(kitap);
                    //rafBazliKitaplar.Add(randomRaf, value);
                }
            }
        }

        private static void KitaplariListeyeAta()
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

        private static void TumKitapListesi()
        {
            Console.WriteLine("Tüm Kitap Hazinemiz: ");

            var kitaplarList = kitaplarYazarlar.ToList();

            for (int i = 0; i < kitaplarYazarlar.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {kitaplarList[i]}");
            }
        }

        // kitaplarYazarlar listesine mi raftaki kitaplar listesine mi eklenecek? ikisine de ayrı ayrı eklenmesi basit yol, kitaplarYazarlar a eklenip rafaYerlestir metodu uzun yol yapılabilir
        private static void KitapBagisla()
        {
            throw new NotImplementedException();
        }

        private static void KitapTeslimEt()
        {
            throw new NotImplementedException();
        }

        // kiraalananları getirmemesi lazım.
        private static void KitapKirala()
        {
            throw new NotImplementedException();
        }

        static Dictionary<string, Dictionary<string, string>> kiralanabilirKitaplar = new Dictionary<string, Dictionary<string, string>>();
        private static void KiralanabilirKitaplarListesi()
        {
            var tumKitaplarValues = rafBazliKitaplar.Values.ToList(); // ToDictionary(new Dictionary<string, string>())

            for (int i = 0; i < 3; i++)
            {
                //kiralanabilirKitaplar.Add(raflar[], tumKitaplarValues[i]);
            }
        }
        private static void KayitOl()
        {
            Console.WriteLine("Adınız soyadınız: ");
            string adSoyad = Console.ReadLine();

            if (adSoyad != null)
            {
                int sonKey = kayitliKisiler.Keys.Max();
                kayitliKisiler.Add(sonKey + 1, adSoyad);
            }
            else
            {
                Console.WriteLine("Boş değer girniz.");
            }
        }

        private static void GirisYap()
        {
            KayitliKisilerListesi();

            Console.WriteLine("Kullanıcı numaranızı giriniz: ");
            int kullaniciNo = int.Parse(Console.ReadLine());

            if (true)
            {

            }
        }
    }
}
