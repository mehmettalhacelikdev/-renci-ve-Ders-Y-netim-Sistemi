
namespace OgrenciDersYonetim
{
    public abstract class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public abstract void BilgiGoster();
    }

    public interface ILogin
    {
        bool Login(string kullaniciAdi, string sifre);
    }

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
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static List<OgretimGorevlisi> ogretimGorevlileri = new List<OgretimGorevlisi>();
        static List<Ders> dersler = new List<Ders>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Öğrenci ve Ders Yönetim Sistemi ===");
                Console.WriteLine("1. Öğrenci Ekle");
                Console.WriteLine("2. Öğretim Görevlisi Ekle");
                Console.WriteLine("3. Ders Ekle");
                Console.WriteLine("4. Derse Öğrenci Kaydet");
                Console.WriteLine("5. Ders Bilgisi Göster");
                Console.WriteLine("6. Öğrencileri Listele");
                Console.WriteLine("7. Öğretim Görevlilerini Listele");
                Console.WriteLine("8. Çıkış");
                Console.Write("Seçiminizi yapınız: ");
                string secim = Console.ReadLine();

                try
                {
                    switch (secim)
                    {
                        case "1":
                            OgrenciEkle();
                            break;
                        case "2":
                            OgretimGorevlisiEkle();
                            break;
                        case "3":
                            DersEkle();
                            break;
                        case "4":
                            DerseOgrenciKaydet();
                            break;
                        case "5":
                            DersBilgisiGoster();
                            break;
                        case "6":
                            OgrencileriListele();
                            break;
                        case "7":
                            OgretimGorevlileriniListele();
                            break;
                        case "8":
                            Console.WriteLine("Çıkış yapılıyor...");
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçim! Lütfen 1-8 arasında bir değer girin.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                }
            }
        }

        static void OgrenciEkle()
        {
            Console.Write("Öğrenci Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Öğrenci Soyadı: ");
            string soyad = Console.ReadLine();
            Console.Write("Öğrenci Numarası: ");
            if (int.TryParse(Console.ReadLine(), out int numara))
            {
                var ogrenci = new Ogrenci
                {
                    Id = ogrenciler.Count + 1,
                    Ad = ad,
                    Soyad = soyad,
                    Numara = numara
                };

                ogrenciler.Add(ogrenci);
                Console.WriteLine($"Öğrenci {ad} {soyad} sisteme eklendi.");
            }
            else
            {
                Console.WriteLine("Hatalı numara girdiniz! İşlem iptal edildi.");
            }
        }

        static void OgretimGorevlisiEkle()
        {
            Console.Write("Öğretim Görevlisi Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Öğretim Görevlisi Soyadı: ");
            string soyad = Console.ReadLine();
            Console.Write("Ünvan: ");
            string unvan = Console.ReadLine();

            var ogretimGorevlisi = new OgretimGorevlisi
            {
                Id = ogretimGorevlileri.Count + 1,
                Ad = ad,
                Soyad = soyad,
                Unvan = unvan
            };

            ogretimGorevlileri.Add(ogretimGorevlisi);
            Console.WriteLine($"Öğretim Görevlisi {ad} {soyad} sisteme eklendi.");
        }

        static void DersEkle()
        {
            Console.Write("Ders Adı: ");
            string dersAdi = Console.ReadLine();
            Console.Write("Kredi: ");
            if (int.TryParse(Console.ReadLine(), out int kredi))
            {
                if (ogretimGorevlileri.Count == 0)
                {
                    Console.WriteLine("Hiç öğretim görevlisi yok! Önce bir öğretim görevlisi ekleyin.");
                    return;
                }

                Console.WriteLine("Mevcut Öğretim Görevlileri:");
                for (int i = 0; i < ogretimGorevlileri.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ogretimGorevlileri[i].Ad} {ogretimGorevlileri[i].Soyad}");
                }
                Console.Write("Öğretim Görevlisi Seçin: ");
                if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= ogretimGorevlileri.Count)
                {
                    var ders = new Ders
                    {
                        DersAdi = dersAdi,
                        Kredi = kredi,
                        OgretimGorevlisi = ogretimGorevlileri[secim - 1]
                    };

                    dersler.Add(ders);
                    Console.WriteLine($"Ders {dersAdi} sisteme eklendi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim! İşlem iptal edildi.");
                }
            }
            else
            {
                Console.WriteLine("Hatalı kredi girdiniz! İşlem iptal edildi.");
            }
        }

        static void DerseOgrenciKaydet()
        {
            if (dersler.Count == 0)
            {
                Console.WriteLine("Hiç ders yok! Önce bir ders ekleyin.");
                return;
            }

            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Hiç öğrenci yok! Önce bir öğrenci ekleyin.");
                return;
            }

            Console.WriteLine("Mevcut Dersler:");
            for (int i = 0; i < dersler.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dersler[i].DersAdi}");
            }
            Console.Write("Ders Seçin: ");
            if (int.TryParse(Console.ReadLine(), out int dersSecim) && dersSecim > 0 && dersSecim <= dersler.Count)
            {
                Console.WriteLine("Mevcut Öğrenciler:");
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ogrenciler[i].Ad} {ogrenciler[i].Soyad}");
                }
                Console.Write("Öğrenci Seçin: ");
                if (int.TryParse(Console.ReadLine(), out int ogrenciSecim) && ogrenciSecim > 0 && ogrenciSecim <= ogrenciler.Count)
                {
                    dersler[dersSecim - 1].KayitliOgrenciler.Add(ogrenciler[ogrenciSecim - 1]);
                    ogrenciler[ogrenciSecim - 1].AlinanDersler.Add(dersler[dersSecim - 1]);
                    Console.WriteLine($"{ogrenciler[ogrenciSecim - 1].Ad} {ogrenciler[ogrenciSecim - 1].Soyad}, {dersler[dersSecim - 1].DersAdi} dersine kaydedildi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz öğrenci seçimi! İşlem iptal edildi.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz ders seçimi! İşlem iptal edildi.");
            }
        }

        static void DersBilgisiGoster()
        {
            if (dersler.Count == 0)
            {
                Console.WriteLine("Hiç ders yok! Önce bir ders ekleyin.");
                return;
            }

            Console.WriteLine("Mevcut Dersler:");
            for (int i = 0; i < dersler.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dersler[i].DersAdi}");
            }
            Console.Write("Ders Seçin: ");
            if (int.TryParse(Console.ReadLine(), out int dersSecim) && dersSecim > 0 && dersSecim <= dersler.Count)
            {
                dersler[dersSecim - 1].DersBilgisiGoster();
            }
            else
            {
                Console.WriteLine("Geçersiz ders seçimi! İşlem iptal edildi.");
            }
        }

        static void OgrencileriListele()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Hiç öğrenci yok!");
                return;
            }

            Console.WriteLine("=== Mevcut Öğrenciler ===");
            foreach (var ogrenci in ogrenciler)
            {
                ogrenci.BilgiGoster();
            }
        }

        static void OgretimGorevlileriniListele()
        {
            if (ogretimGorevlileri.Count == 0)
            {
                Console.WriteLine("Hiç öğretim görevlisi yok!");
                return;
            }

            Console.WriteLine("=== Mevcut Öğretim Görevlileri ===");
            foreach (var ogretimGorevlisi in ogretimGorevlileri)
            {
                ogretimGorevlisi.BilgiGoster();
            }
        }
    }
}
