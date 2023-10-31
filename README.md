# Labirent_Sicak-Soguk

### [Proje Dosyaları](#)

**By Yunus Emre Karahan**

## Tuşlar
- W, A, S, D (Sırası ile "Yukarı, Sol, Aşağı, Sağ" Yönlerine haraket etmek için kullanılır)
- L (oyun modunu değiştirmek için kullanılır Labirent/Sıcak-Soğuk)
- İ (ipucu almak için kullanılır)
- Q (oyundan çıkış yapmak için kullanılır)

## Algoritma
algoritma olarak A* (A Star) kullandım daha önceden C# programlama dili ile hiç algoritma kullanmadığım için ChatGPT'den yardım aldım. Algoritma nasıl çalışıyor :

- **Başlangıç ve Hedef Noktaları Seçme:** Oyununuzdaki labirentte başlangıç ve hedef noktaları seçilir. Başlangıç noktası (oyuncu) ve hedef noktası (çıkış) belirlenir. örnek:
```C#
List<Node> shortestPath = AStar(Maze, new Position(playerLine, playerColumn), new Position(exitLine, exitColumn));
```

- **`A*` Algoritması, iki liste kullanır:** "Open List" ve "Closed List". "Open List", keşfedilmeyi bekleyen düğümlerin listesini içerirken, "Closed List" zaten ziyaret edilen düğümlerin listesini içerir.

- **Manhattan Mesafesi Hesaplama:** Her iki düğüm arasındaki tahmini maliyeti hesaplamak için Manhattan mesafesi kullanılır. Bu mesafe, düşey ve yatay adımları toplayarak hesaplanır ve genellikle iki düğüm arasındaki en kısa yolun yaklaşık maliyetini tahmin etmek için kullanılır.

- **Araştırma ve Adayları Değerlendirme:** A* algoritması, açık listeden en düşük tahmini maliyete sahip düğümü seçer ve bunu işler. Bu düğümün komşuları incelenir ve maliyetleri hesaplanır. Daha sonra bu komşular "Open List" veya "Closed List" e eklenir.

- **Yolu Geri İzleme:** Algoritma hedef düğüme ulaştığında, hedef düğümden başlayarak başlangıç düğümüne kadar olan yolu geri izler. Bu yoldaki düğümler "en kısa yol" olarak kabul edilir.

- **Optimal Yolu Bulma:** A* algoritması, başlangıç noktasından hedef noktasına giden en kısa yolu bulur. Bu yol, en düşük toplam maliyete sahip olan yoldur ve genellikle labirent veya harita çözümü gibi uygulamalarda kullanılır.

- **Çalışma Süresi ve İşleyiş:** A* algoritması, açık ve kapalı listeler üzerinde çalışırken her adımda mevcut düğümü seçer ve komşularını değerlendirir. Bu işlem, hedefe ulaşılıncaya veya çözüm bulununcaya kadar devam eder.

- **Sonuçları Görselleştirme:** Algoritma sonuçları görselleştirilir ve kullanıcıya sunulur. Bu durumda, kullanıcılara labirentin çözümü ve yolun uzunluğu sunulur.

## Algoritma Performans Ölçümü
Birden fazla algoritma karşılaştırması: [Proje Dosyaları (Yakında)](#) **(farklı bir proje olarak teslim edeceğim şu anda üzerinde çalışıyorum ve farklı algoritmalar arıyorum proje yi tamamladığım zaman bu kısma karşılaştırma projesinin linkini bırakacağım.)**