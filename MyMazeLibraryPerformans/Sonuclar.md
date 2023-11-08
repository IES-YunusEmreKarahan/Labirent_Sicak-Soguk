# Labirent_Sicak-Soguk / Performans Sonucları

### [Proje Dosyaları](https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/tree/main/MyMazeLibraryPerformans)

**By Yunus Emre Karahan**

## Algoritmalar Nasıl Test Edildi?
- Oyuncu labirentin en sol üstüne, çıkış ise labirentin en sağ altına konumlandırıldı.
- Algoritmalara sırası ile 10x10 > 100x100 > 1000x1000 labirentlerde test edildi.
- Algoritmalara her labirent 3 kere çözdürüldü.
- Algoritmalarda herhangi bir performans sorunu yaşamaması için algoritmaya başlama emri verildiğinde 1 saniyelik hazırlık süresi verildi.
- 100x100 ve 1000x1000 labirentler otomatik olarak görünmez yapıldı. (labirentin yazılması ve algoritmanın izlediği yolu yazdırmak fazla performans etkilediği için görünmez yapıldı.)

## Algoritmalar Test Edilirken Kullanılan Sistem
- İşletim Sistemi: Windows 10 64-bit
- CPU (işlemci): Intel(R) Core(TM) i3-5005U CPU @ 2.00GHz
- GPU (Ekran Kartı): Intel(R) HD Graphics 5500
- RAM: 4,00 GB

</br></br>
## Tuşlar
- W, A, S, D (Sırası ile "Yukarı, Sol, Aşağı, Sağ" Yönlerine haraket etmek için kullanılır)
- Spacebar [Boşluk] (Algoritmaların Labirenti çözmesini başlatmak için kullanılır)
- P (Oyuncunun çıkışa ışınlanmasını sağlar)
- Q (oyundan çıkış yapmak için kullanılır)

</br></br>
## Algoritmaların 10x10 İzlediği Yollar
### **A Star**
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Astar1.PNG" alt="resim" width="auto" height="180" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Astar2.PNG" alt="resim" width="auto" height="180" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Astar3.PNG" alt="resim" width="auto" height="180" align="top">

### **Greedy**
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Greedy1.PNG" alt="resim" width="auto" height="180" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Greedy2.PNG" alt="resim" width="auto" height="180" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/Greedy3.PNG" alt="resim" width="auto" height="180" align="top">

### **BFS**
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/BFS1.PNG" alt="resim" width="auto" height="180" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/BFS2.PNG" alt="resim" width="auto" height="180" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/BFS3.PNG" alt="resim" width="auto" height="180" align="top">

## Sonuclar
### **10x10 Labirent Sonucları**
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/10x10Test1.png" alt="resim" width="500" height="auto" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/10x10Test2.png" alt="resim" width="500" height="auto" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/10x10Test3.png" alt="resim" width="500" height="auto" align="top">

### **100x100 Labirent Sonucları**
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/100x100Test1.PNG" alt="resim" width="500" height="auto" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/100x100Test2.PNG" alt="resim" width="500" height="auto" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/100x100Test3.PNG" alt="resim" width="500" height="auto" align="top">

### **1000x1000 Labirent Sonucları**
**Not:** A Star 300x300 ve üstü labirentlerde çözmesi uzun sürüyor veya projenin donmasına sebep oluyor. Bu sebepden dolayı A Star'a 300x300 labirent ve altı çözmesi için sınırlandırma yapılmıştır. 
</br></br> __A Star Tahmini Sonuç = Çalışma süresi: 23.760,000 Milisaniye / Adım Sayısı: 2002__
</br></br>
- 1.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/1000x1000Test1.PNG" alt="resim" width="500" height="auto" align="top">

- 2.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/1000x1000Test2.PNG" alt="resim" width="500" height="auto" align="top">

- 3.Test: <img src="https://github.com/IES-YunusEmreKarahan/Labirent_Sicak-Soguk/blob/main/MyMazeLibraryPerformans/screenshots/1000x1000Test3.PNG" alt="resim" width="500" height="auto" align="top">
