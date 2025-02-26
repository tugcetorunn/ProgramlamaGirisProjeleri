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

            KiralanabilirKitaplarListesi();

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
                    break;
                case "2":
                    KitapTeslimEt();
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

        static Dictionary<string, Dictionary<string, string>> rafBazliKitaplar = new Dictionary<string, Dictionary<string, string>>(); // rafIsimleri - dict<> kitaplarYazarlar
        static Dictionary<string, string> kitaplarYazarlar = new Dictionary<string, string>();
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
            var tumKitaplarKeys = rafBazliKitaplar.Keys.ToList();

            for (int i = 0; i < rafBazliKitaplar.Count; i++)
            {
                kiralanabilirKitaplar.Add(tumKitaplarKeys[i], tumKitaplarValues[i]);
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
