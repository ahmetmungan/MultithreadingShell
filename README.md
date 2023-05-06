# MultithreadingShell Projesi

Bu proje, cmd ve bash üzerinde çalışan komutların multithreading (çok iş parçacıklı) olarak çalışmasını sağlamaktadır. Özellikle zaman kısıtlı işlemlerde zamandan tasarruf sağlamak, işlem süreçlerinin etkinliğini artırmak, yerel ve güvenli logging sisteminde ekleme/güncelleme/silme yapmak,  amaçlanmıştır.

## İçindekiler

1. [Başlangıç](#başlangıç)
2. [Kurulum](#kurulum)
3. [Kullanım](#kullanım)
4. [Özellikler](#özellikler)
5. [Gelecek Planları](#gelecek-planları)
6. [Lisans](#lisans)

## Başlangıç

Projede cmd ve bash üzerinde çalışan komutların multithreading özelliklerini kullanarak, çok işlemcili sistemlerde işlemleri aynı anda çalıştırarak daha hızlı sonuçlar almak ve zamandan tasarruf etmek hedeflenmektedir.

## Kurulum

1. Projeyi GitHub'dan klonlayın veya indirin.
2. Gerekli paketleri ve bağımlılıkları; NuGet paket yöneticisi veya Visual Studio içerisinde komut istemi satırıyla yükleyin.
3. Projeyi çalıştırmak `MultithreadingShell.Console` katmanını başlangıç projesi olarak belirleyin.

## Kullanım

Projeyi kullanmak için aşağıdaki adımları izleyin:

1. Programı çalıştırın.
2. Çalıştırmak istediğiniz komutu/komutları girin. Çoklu komut girişinde varsayılan kabuk operatörlerini kullanın.
3. Çıktıları inceleyin, doğruluğunu test edin. 
4. `BashLogger.txt` ve `CMDLogger.txt` dosyalarını kontrol edin. Yerel çalışan programlar için adres yolunu doğru tespit edin.

## Özellikler

- Multithreading (çok iş parçacıklı) işlemleri destekler.
- Zaman tasarrufu sağlar ve işlem süreçlerinin etkinliğini artırır.
- Cmd ve bash üzerinde çalışan komutlar için uygundur.
- Logging işlemleri için ayrılmış log dosyaları (Bash/CMD) mevcuttur.
- Ağ ve alt yapı kısıtlamalarından etkilenir.
- İşlemci ailesine göre değişkenlik gösterebilir. (Varsayılan işlemci ailesi: Intel I7 10. Nesil)
- `MultithreadingShell.Bussiness` katmanındaki bazı sınıf, arayüz yapıları güvenlik ve gizlilik sebebiyle kaldırılmıştır.

## Gelecek Planları

- Performans iyileştirmeleri yapılması. 
- `git` komutlarının özelleştirilmesi.
- Desteklenen kabuk sistemlerinin genişletilmesi, powershell gibi daha gelişmiş platformlar için kullanıma açılması.

## Lisans

Bu projenin tüm hak ve fikirleri Ahmet MUNGAN'a aittir. Maddi çıkarlar haricinde kullanımı serbest ve izinlidir.
