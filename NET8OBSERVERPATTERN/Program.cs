
// Kullanım örneği:
var samsung = new Product("Samsung", 1000); // İzlenecek ürün oluşturulur.

var observer1 = new ProductObserver(); // Gözlemci oluşturulur.

var amazon = new Amazon(); // Amazon sistemi oluşturulur.

amazon.Register(observer1, samsung); // Gözlemci Amazon'a kaydedilir.

amazon.Notify(new Product("Samsung", 1200)); // Samsung ürününün fiyatı güncellendiğinde gözlemcilere bildirim yapılır.

// Subject (İzlenecek nesne): Değişiklikleri gözlemleyen nesnedir. Burada Product sınıfı bir subject olarak kullanılıyor.
record Product(string Name, decimal Price);

// Observer Interface (Gözlemci Arayüzü): Gözlemcilerin (observer) uygulaması gereken yöntemleri içerir.
interface IObserver
{
    void Update(Product product); // Gözlemcilere bildirim yapacak yöntem.
}

// Concrete Observer (Somut Gözlemci): Gözlemci arayüzünü uygular ve güncelleme (update) bildirimini alır.
class ProductObserver : IObserver
{
    public void Update(Product product)
    {
        Console.WriteLine($"Product {product.Name} price is {product.Price}"); // Ürünün güncellenmiş fiyatını konsola yazdırır.
    }
}

// Concrete Subject (Somut İzlenecek Nesne): Gözlemcilere (observer) bildirim gönderir ve onları yönetir.
class Amazon
{
    private Dictionary<IObserver, Product> _observers = new();

    // Gözlemciyi (observer) kaydeder ve izlenecek ürünü (subject) ilişkilendirir.
    public void Register(IObserver observer, Product product)
    {
        _observers.Add(observer, product);
    }

    // Gözlemciyi (observer) kayıttan kaldırır.
    public void UnRegister(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // Tüm gözlemcilere (observer) bir ürün güncellemesi (update) bildirimi gönderir.
    public void Notify(Product updatedProduct)
    {
        foreach (var observer in _observers)
        {
            observer.Key.Update(updatedProduct); // Her gözlemciye güncellenmiş ürün bilgisini iletir.
        }
    }
}

