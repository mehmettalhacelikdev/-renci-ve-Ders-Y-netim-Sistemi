namespace OgrenciDersYonetim
{
    // Base Class
    public abstract class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public abstract void BilgiGoster();
    }

    // Interface
    public interface ILogin
    {
        bool Login(string kullaniciAdi, string sifre);
    }

    // Ogrenci Sınıfı
    public class Ogrenci : Kisi, ILogin
    {
        public int Numara { get; set; }
        public List<Ders> AlinanDersler { get; set; } = new List<Ders>();

        public override void BilgiGoster()
        {
            Console.WriteLine($"Öğrenci: {Ad} {Soyad}, Numara: {Numara}");
        }

        public bool Login(string kullaniciAdi, string sifre)
        {
            return kullaniciAdi == "ogrenci" && sifre == "1234";
        }
    }

    // OgretimGorevlisi Sınıfı
    public class OgretimGorevlisi : Kisi, ILogin
    {
        public string Unvan { get; set; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Öğretim Görevlisi: {Unvan} {Ad} {Soyad}");
        }

        public bool Login(string kullaniciAdi, string sifre)
        {
            return kullaniciAdi == "ogretim" && sifre == "1234";
        }
    }

    // Ders Sınıfı
    public class Ders
    {
        public string DersAdi { get; set; }
        public int Kredi { get; set; }
        public OgretimGorevlisi OgretimGorevlisi { get; set; }
        public List<Ogrenci> KayitliOgrenciler { get; set; } = new List<Ogrenci>();

        public void DersBilgisiGoster()
        {
            Console.WriteLine($"Ders: {DersAdi}, Kredi: {Kredi}, Öğretim Görevlisi: {OgretimGorevlisi.Unvan} {OgretimGorevlisi.Ad} {OgretimGorevlisi.Soyad}");
            Console.WriteLine("Kayıtlı Öğrenciler:");
            foreach (var ogrenci in KayitliOgrenciler)
            {
                Console.WriteLine($" - {ogrenci.Ad} {ogrenci.Soyad}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğretim Görevlisi Tanımlama
            var ogretimGorevlisi = new OgretimGorevlisi
            {
                Id = 1,
                Ad = "Ahmet",
                Soyad = "Yılmaz",
                Unvan = "Doç. Dr."
            };

            // Ders Tanımlama
            var ders = new Ders
            {
                DersAdi = "Nesneye Yönelik Programlama",
                Kredi = 4,
                OgretimGorevlisi = ogretimGorevlisi
            };

            // Öğrenci Tanımlama
            var ogrenci1 = new Ogrenci { Id = 1, Ad = "Ali", Soyad = "Kara", Numara = 1001 };
            var ogrenci2 = new Ogrenci { Id = 2, Ad = "Ayşe", Soyad = "Demir", Numara = 1002 };

            // Ders Kayıtları
            ders.KayitliOgrenciler.Add(ogrenci1);
            ders.KayitliOgrenciler.Add(ogrenci2);

            ogrenci1.AlinanDersler.Add(ders);
            ogrenci2.AlinanDersler.Add(ders);

            // Bilgi Gösterme
            Console.WriteLine("=== Öğretim Görevlisi Bilgisi ===");
            ogretimGorevlisi.BilgiGoster();
            Console.WriteLine();

            Console.WriteLine("=== Öğrenci Bilgileri ===");
            ogrenci1.BilgiGoster();
            ogrenci2.BilgiGoster();
            Console.WriteLine();

            Console.WriteLine("=== Ders Bilgisi ===");
            ders.DersBilgisiGoster();

            Console.WriteLine("\nSistem Sonlandı. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
