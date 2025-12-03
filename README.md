# KulturTravelMVC - ASP.NET MVC 5 Web Application

Bu proje ASP.NET MVC 5 Web Application olarak geliştirilmiştir.

## Gereksinimler

- Visual Studio 2019 veya üzeri (Windows için)
- .NET Framework 4.8
- SQL Server LocalDB veya SQL Server Express
- NuGet paketleri (proje açıldığında otomatik restore edilecektir)

## Kurulum

1. Projeyi Visual Studio'da açın
2. NuGet paketlerini restore edin (Solution'a sağ tıklayıp "Restore NuGet Packages")
3. Web.config dosyasındaki connection string'i kontrol edin
4. Projeyi çalıştırın (F5)

## Veritabanı

Proje ilk çalıştırıldığında otomatik olarak LocalDB'de veritabanı oluşturulacaktır.

### Test Kullanıcıları

Proje ilk çalıştırıldığında aşağıdaki test kullanıcıları otomatik oluşturulur:

**Admin Kullanıcı:**
- Email: admin@kulturtravel.com
- Şifre: Admin@123
- Rol: Admin

**Normal Kullanıcı:**
- Email: user@kulturtravel.com
- Şifre: User@123
- Rol: User

## Özellikler

1. ✅ ASP.NET MVC 5 Web Application (Full Code)
2. ✅ Tüm Image, CSS ve JavaScript dosyaları projede mevcut
3. ✅ Controller, Model ve View sınıfları hatasız çalışıyor
4. ✅ Local SQL Server veritabanı (Entity Framework Code First)
5. ✅ Test verileri ile doldurulmuş tablolar
6. ✅ Layout yapısı oluşturuldu
7. ✅ Form validasyonları (Data Annotations ile)
8. ✅ Razor helpers ve kodları kullanıldı
9. ✅ Sign in ve Sign up sayfaları (ASP.NET Identity)
10. ✅ Rol tabanlı yetkilendirme (Admin ve User rolleri)

## Sayfalar

- **Anasayfa** (`/Home/Index`) - Herkese açık
- **Hakkımızda** (`/Home/About`) - Herkese açık
- **İletişim** (`/Home/Contact`) - Herkese açık
- **Giriş** (`/Auth/Login`) - Herkese açık
- **Kayıt** (`/Auth/Signup`) - Herkese açık
- **Dashboard** (`/Home/Dashboard`) - Giriş yapmış kullanıcılar
- **Admin Panel** (`/Home/Admin`) - Sadece Admin rolü

## Mac Kullanıcıları İçin Not

ASP.NET MVC 5 .NET Framework üzerinde çalışır ve Windows gerektirir. Mac'te çalıştırmak için:

1. **Visual Studio for Mac** kullanabilirsiniz (sınırlı destek)
2. **Parallels/VMware** ile Windows sanal makine
3. **Boot Camp** ile Windows kurulumu
4. Alternatif olarak, projeyi **ASP.NET Core MVC**'ye dönüştürmek gerekebilir (cross-platform)

## Proje Yapısı

```
KulturTravelMVC/
├── App_Start/          # Route, Bundle, Filter konfigürasyonları
├── Controllers/        # Controller sınıfları
├── Models/            # Model sınıfları ve Entity Framework
├── Views/             # Razor view dosyaları
├── Content/           # CSS dosyaları
├── Scripts/           # JavaScript dosyaları
├── wwwroot/          # Statik dosyalar (images, css, js)
├── Global.asax       # Uygulama başlangıç noktası
└── Web.config        # Web konfigürasyonu
```

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

