# Labirent_Sicak-Soguk / Performans Sonucları

### [Proje Dosyaları](#)

**By Yunus Emre Karahan**

## Algoritmalar Nasıl Test Edildi?
- Oyuncu labirentin en sol üstüne, çıkış ise labirentin en sağ altına konumlandırıldı.
- Algoritmalara sırası ile 10x10 > 100x100 > 1000x1000 labirentlerde test edildi.
- Algoritmalara her labirent 3 kere çözdürüldü.
- Algoritmalarda herhangi bir performans sorunu yaşamaması için algoritmaya başlama emri verildiğinde 1 saniyelik hazırlık süresi verildi.
- 100x100 ve 1000x1000 labirentler otomatik olarak görünmez yapıldı. (labirentin yazılması ve algoritmanın izlediği yolu yazdırmak fazla performans etkilediği için görünmez yapıldı.)

## Tuşlar
- W, A, S, D (Sırası ile "Yukarı, Sol, Aşağı, Sağ" Yönlerine haraket etmek için kullanılır)
- Spacebar [Boşluk] (Algoritmaların Labirenti çözmesini başlatmak için kullanılır)
- P (Oyuncunun çıkışa ışınlanmasını sağlar)
- Q (oyundan çıkış yapmak için kullanılır)

## 10x10 Labirent Sonucları
**1. Test A* (A Star)**
- <img src="screenshots/Astar1.png" alt="alt text" width="320" height="180">
- <img src="screenshots/Astar2.png" alt="alt text" width="320" height="180">
- <img src="screenshots/Astar3.png" alt="alt text" width="320" height="180">
**2. Test Greedy**
- <img src="screenshots/Greedy1.png" alt="alt text" width="320" height="180">
- <img src="screenshots/Greedy2.png" alt="alt text" width="320" height="180">
- <img src="screenshots/Greedy3.png" alt="alt text" width="320" height="180">
**3.Test BFS**
- <img src="screenshots/BFS1.png" alt="alt text" width="320" height="180">
- <img src="screenshots/BFS2.png" alt="alt text" width="320" height="180">
- <img src="screenshots/BFS3.png" alt="alt text" width="320" height="180">
