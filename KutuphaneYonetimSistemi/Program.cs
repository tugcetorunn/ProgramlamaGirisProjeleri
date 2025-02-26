using System.ComponentModel.Design;

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

            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Bir işlem seçiniz: ");
            Console.WriteLine("1- Giriş Yap");
            Console.WriteLine("2- Kayıt Ol");
        }
    }
}
