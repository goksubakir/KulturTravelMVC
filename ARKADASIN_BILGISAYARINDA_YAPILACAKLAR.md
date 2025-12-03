# Arkadaşının Bilgisayarında Yapılacaklar - Adım Adım Kılavuz

Bu kılavuz, projeyi Windows bilgisayarında çalıştırmak için gerekli adımları içerir.

## Gereksinimler
- Visual Studio 2019 veya üzeri (Community, Professional veya Enterprise)
- .NET Framework 4.8 Developer Pack
- SQL Server LocalDB veya SQL Server Express

---

## ADIM 1: Projeyi İndir ve Aç

1. GitHub'dan projeyi klonla veya ZIP olarak indir
2. Proje klasörünü aç
3. `KulturTravelMVC.sln` dosyasına çift tıkla (Visual Studio açılacak)

---

## ADIM 2: .NET Framework 4.8 Kontrolü

1. Visual Studio'da **Tools** → **Options** menüsünü aç
2. Sol menüden **Projects and Solutions** → **.NET Framework Locations** seç
3. .NET Framework 4.8'in yüklü olduğundan emin ol
4. Eğer yüklü değilse: [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48) indir ve kur

---

## ADIM 3: NuGet Paketlerini Restore Et

### Yöntem 1: Visual Studio GUI ile (Önerilen)

1. **Solution Explorer**'da projeye sağ tıkla
2. **Restore NuGet Packages** seçeneğine tıkla
3. Paketlerin indirilmesini bekle (birkaç dakika sürebilir)
4. Alt kısımdaki **Output** penceresinde "Restore completed successfully" mesajını gör

### Yöntem 2: Package Manager Console ile

1. **Tools** → **NuGet Package Manager** → **Package Manager Console** aç
2. Şu komutu yaz ve Enter'a bas:
   ```
   Update-Package -reinstall
   ```
3. Tüm paketlerin restore edilmesini bekle

### Yöntem 3: Komut Satırı ile (Alternatif)

1. **Command Prompt** veya **PowerShell** aç (Yönetici olarak)
2. Proje klasörüne git:
   ```
   cd C:\path\to\KulturTravelMVC
   ```
3. Şu komutu çalıştır:
   ```
   nuget restore
   ```
   Eğer `nuget` komutu bulunamazsa, [NuGet.exe](https://www.nuget.org/downloads) indir ve PATH'e ekle

---

## ADIM 4: NuGet Kaynaklarını Kontrol Et

Eğer paketler hala indirilemiyorsa:

1. **Tools** → **Options** → **NuGet Package Manager** → **Package Sources**
2. Şu kaynakların aktif olduğundan emin ol:
   - ✅ **nuget.org** (https://api.nuget.org/v3/index.json)
   - ✅ **Microsoft Visual Studio Offline Packages** (varsa)
3. **nuget.org** kaynağının üstte olduğundan emin ol
4. **OK** butonuna tıkla

---

## ADIM 5: Projeyi Build Et

1. **Build** menüsünden **Rebuild Solution** seç
2. Veya **Ctrl+Shift+B** tuşlarına bas
3. **Output** penceresinde hata olup olmadığını kontrol et
4. Eğer hata varsa, hata mesajlarını oku ve gerekirse tekrar **Restore NuGet Packages** yap

---

## ADIM 6: SQL Server LocalDB Kontrolü

1. **Command Prompt** aç
2. Şu komutu çalıştır:
   ```
   sqllocaldb info
   ```
3. Eğer LocalDB yüklü değilse:
   - [SQL Server Express LocalDB](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) indir ve kur
   - Veya Visual Studio Installer'dan **SQL Server Express LocalDB** bileşenini ekle

---

## ADIM 7: Projeyi Çalıştır

1. **F5** tuşuna bas veya **Debug** → **Start Debugging**
2. Tarayıcı otomatik açılacak
3. Eğer hata alırsan, **Error List** penceresini kontrol et

---

## Sık Karşılaşılan Hatalar ve Çözümleri

### Hata: "The referenced component 'X' could not be found"
**Çözüm:** 
- ADIM 3'ü tekrar uygula (NuGet Restore)
- `packages` klasörünün proje klasöründe olduğundan emin ol

### Hata: "Package restore failed"
**Çözüm:**
- İnternet bağlantını kontrol et
- ADIM 4'ü uygula (NuGet kaynaklarını kontrol et)
- Visual Studio'yu yönetici olarak çalıştırmayı dene

### Hata: "Web.config is invalid"
**Çözüm:**
- Projeyi GitHub'dan tekrar çek (düzeltmeler yapıldı)
- Web.config dosyasını kontrol et

### Hata: "LocalDB connection failed"
**Çözüm:**
- ADIM 6'yı uygula
- LocalDB servisinin çalıştığından emin ol:
  ```
  sqllocaldb start MSSQLLocalDB
  ```

---

## Başarı Kontrolü

Proje başarıyla çalıştığında:
- ✅ Tarayıcıda anasayfa açılır
- ✅ `/Auth/Login` sayfasına gidebilirsin
- ✅ `/Auth/Signup` sayfasına gidebilirsin
- ✅ Veritabanı otomatik oluşturulur (ilk çalıştırmada)

---

## Test Kullanıcıları

Proje ilk çalıştırıldığında otomatik oluşturulan test kullanıcıları:

**Admin:**
- Email: `admin@kulturtravel.com`
- Şifre: `Admin@123`

**User:**
- Email: `user@kulturtravel.com`
- Şifre: `User@123`

---

## İletişim

Eğer hala sorun yaşıyorsan, hata mesajlarını ekran görüntüsü ile paylaş.
