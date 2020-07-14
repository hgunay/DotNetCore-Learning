# Exception Handling (Hata Yakalama)

Bir program çalışırken istisnai durumlarda hata vererek durmasına sebep olabilir. Bu hatalar bir çok sebepten dolayı olabilir ve böyle kötü durumların yaşanıp programın çökmemesi için onları yakalamak ve müdahele etmek gerekir.
İşte bu durumları yakalamak için ise **try-catch** bloğunu kullanırız. Peki nedir bu try-catch ve nasıl çalışır?

## try-catch

**try** bloğu içerisinde çalıştırdığımız kodumuz o an da bir hataya düşerse **catch** ile yakalanmış ve müdahele etmemize olanak sağlamış olacaktır.

Kullanımı;

``` csharp
try
{
    // Çalıştıracağımız kod bloğu...
}
catch (Exception ex)
{
    // Hataya düşme durumunda alınacak aksiyon...
}
```

Örnek;
Hata örneğini görebilmek amacıyla CustomerService'imizi null olarak set edelim.

``` csharp
try
{
    CustomerService customerService = null;
    var customerData = customerService.GetCustomerById(1);

    if(customerData == null)
    {
        Console.WriteLine("Müşteri bilgileri bulunamadı.");
    }
    else
    {
        Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Hata oluştu! Hata : {ex}");
}
```

Sonuç;

``` shell
Exception thrown: 'System.NullReferenceException' in CustomerApp.dll
Hata oluştu! Hata : System.NullReferenceException: Object reference not set to an instance of an object.
```

Yukarıdaki örneği incelediğimiz zaman müşteri bilgilerini alacak olan kod bloğunun try içerisinde işlendiğini görebilirsiniz. Peki bu durum bize ne yarar sağlayacaktır?

CustomerService sınıfının bu esnada oluşturulamadığını ya da oluşturabildiğini ancak GetCustomerById methodunu çağırdığımız zaman bir şekilde hata aldığımızı varsayalım. Haliyle bu iki durum yaşandığı zaman uygulamamız hataya düşecektir. Hataya düştüğün zaman ise catch ile bu hata yakalanmış olacak ve uyarı olarak ekrana yazacaktır.

Tabii bu gibi durumlarda büyük sistemlerde log mekanizmaları, uygulamanın çalışmaya devam edebilmesi için yazılmış uygun kodlar vs. yazılır :)

## try-catch-finally

try-catch bloğunu yazarken isterseniz **finally** bloğunuda ekleyebilirsiniz. Ancak bunun herhangi bir zorunluluğu yoktur. Kodda hata oluşsun ya da oluşmasın finally bloğu her durumda çalışacaktır.

Kullanımı;

``` csharp
try
{
    // Çalıştıracağımız kod bloğu...
}
catch (Exception ex)
{
    // Hataya düşme durumunda alınacak aksiyon...
}
finally{
    // Her durumda çalışacak olan kod...
}
```

Örnek;

``` csharp
try
{
    var customerService = new CustomerService();
    var customerData = customerService.GetCustomerById(1);

    if (customerData == null)
    {
        Console.WriteLine("Müşteri bilgileri bulunamadı.");
    }
    else
    {
        Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Hata oluştu! Hata : {ex}");
}
finally
{
    Console.WriteLine("İşlem tamamlandı.");
}
```

Sonuç;

``` shell
Anakin Skywalker - anakin@skywalker.com
İşlem tamamlandı.
```

## throw

**throw** ile özel bir durum ifade edilir. Örneğimize baktığımız zaman diğer hata ayıklama modelinden farklı olarak try içerisinde müşteri bilgisinin boş kayıt dönmesi sonucunda oluşan NullReferenceException hatasını ayıklamaya yönelik bir aksiyon alınmıştır. Burada özel olarak yazılan hata kodu catch bloğuna düştüğü zaman bizim yazdığımız şekilde gözükecektir.

Örnek;

``` csharp
try
{
    var customerService = new CustomerService();
    var customerData = customerService.GetCustomerById(0);

    if (customerData == null)
    {
        throw new NullReferenceException("Hata Kodu : 01 - NullRef hatası oluştu.");
    }
    else
    {
        Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Hata oluştu! Hata : {ex.Message}");
}
```

Sonuç;

``` shell
Hata oluştu! Hata : Hata Kodu : 01 - NullRef hatası oluştu.
```

## Exception Sınıfları

| Exception                             | Açıklama |
| ----                                  | ---      |
| `System.ArithmeticException`          | Aritmetik işlemler esnasında oluşan hataları yakalar. DividedByZero ve OverflowException gibi... |
| `System.ArrayTypeMismatchException`   | Bir dizinin türü ona atanacak verinin türü ile uyuşmadığı zamanlarda bu hata meydana gelir. |
| `System.DivideByZeroException`        | Sıfıra bölme hatasıdır. |
| `System.IndexOutOfRangeException`     | Index değeri sıfırdan küçük olunca ya da dizi içerisinde olmadığı durumlarda bu hatayı verir.  |
| `System.InvalidCastException`         | Bir türün başka bir türe dönüştürülmesi anında meydana gelir. Geçersiz tür dönüşümü meydana gelmiştir. |
| `System.NullReferenceException`       | Değeri null olan bir nesne ya da değişken kullanılmaya çalışıldığında bu hata oluşur.  |
| `System.OutOfMemoryException`         | Programın çalışması esnasında yeterli bellek kalmadığı durumda oluşur. |
| `System.OverflowException`            | Bir veri türüne kapasitesinden daha büyük bir veri ataması yapılmaya çalışılduğu durumlarda oluşan hatadır. |
| `System.StackOverflowException`       | Bir metod hatalı şekilde kendi kendini kısır döngüye girerek çağırmaya devam ederse taşma meydana gelir ve bu hatayı üretir.  |
| `System.TypeInitializationException`  | Bu hata static constructor da bir hata olduğu zaman meydana gelir. |