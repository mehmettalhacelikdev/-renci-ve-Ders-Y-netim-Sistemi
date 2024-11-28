Öğrenci ve Ders Yönetim Sistemi
Bu proje, Nesne Yönelimli Programlama (OOP) ilkelerini kullanarak bir Öğrenci ve Ders Yönetim Sistemi geliştirilmesi amacıyla hazırlanmıştır. Proje, öğrencilerin derslere kayıt olabileceği, derslerin öğretim görevlileri tarafından yönetilebileceği ve tüm bu bilgilerin bir konsol uygulaması üzerinden görüntülenebileceği bir sistemdir.

Özellikler
1. Sınıflar
BaseEntity: Öğrenci ve öğretim görevlisi için ortak özellikler ve davranışları barındıran temel sınıf.
Ogrenci: Sisteme kayıtlı öğrencileri temsil eder.
OgretimGorevlisi: Öğretim görevlilerini temsil eder.
Ders: Ders bilgilerini (adı, kredisi, öğretim görevlisi ve kayıtlı öğrenciler) içerir.
2. Polymorphism (Çok Biçimlilik)
Tüm sınıflar, BaseEntity sınıfındaki BilgiGoster() metodunu kendi ihtiyaçlarına göre override eder.
3. Interface Kullanımı
ILogin Interface'i: Öğrenci ve öğretim görevlilerinin sisteme giriş yapabilmesi için gerekli metotları zorunlu kılar.
4. Sistemin Sağladığı İşlemler
Yeni öğrenci, öğretim görevlisi ve ders tanımlamaları yapılabilir.
Bir dersin adı, kredisi, öğretim görevlisi ve kayıtlı öğrenciler listelenebilir.
