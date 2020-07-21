# Methods (Metotlar)

Metot, bir program içerisinde belirli görev/görevleri yerine getirmek için yazılmış kod bloklarıdır. Her C# programının en az bir tane metodu vardır ve göz önünde olanı Main metodudur.

- Metodlar çağırılmadıkları sürece çalışmazlar.
- Aynı kodların tekrar tekrar yazılmasını engeller.
- Okunabilirliği ve yazılabilirliği arttırırlar.

## Metot Nasıl Tanımlanır?

Metotlar siz hangi isimi verirseniz o isim ile çağırılırlar, parametre alabilir ya da almayabilirler.

- Bir `class` ya da `struct` içerisinde tanımlanırlar.
- `public`, `private`, `protected` olabilirler.
- Dönüş değerini `void` olarak tanımlarsanız çağırıldığı yere herhangi bir değer dönmezler.

Yapısı;

``` csharp
<Access Specifier> <Return Type> <Method Name>(Parameter List)
{
   // Çalıştırılacak kodlar
}
```

**Access Specifier (Erişim Belirleyici)**
`public`, `private`, `protected` olarka tanımlanarak başka bir sınıftan erişilip erişlemeyeceğini berlirler.

**Return Type (Dönüş Değeri)**
`void` olarak tanımlanan dönüş değerinin herhangi bir değeri olmaz. Hangi veri tipi dönülecekse o yazılır. Bu int, string, list, dictionary gibi tipler olabilir.

**Method Name (Metod Adı)**
Metotunuza verdiğiniz ve çağırırken kullanacağınız ismidir.

**Parameter List (Parametre)**
Parametre tanımlama opsiyoneldir. Eğer metotunuza herhangi bir değer göndermeniz gerekiyor ve bu değer üzerinden işlem yapmanız gerekiyorsa o değeri parametre olarak göndermeniz gerekir.

Örnek;

``` csharp
// <Access Specifier>   : Public
// <Return Type>        : Customer
// <Method Name>        : GetCustomerById
// (Parameter List)     : int id
public Customer GetCustomerById(int id)
{
    if(id <= 0)
    {
        return null;
    }

    var customer = new Customer(id);

    if(id == 1)
    {
        customer.FirstName = "Anakin";
        customer.LastName = "Skywalker";
        customer.EmailAddress = "anakin@skywalker.com";

        return customer;
    }

    return null;
}
```

Çağırma;

``` csharp
var customerService = new CustomerService();
var customerData = customerService.GetCustomerById(1);
```

## Recursive Methods (Kendini Çağıran Metodlar)

Bir metot kendi kendini çağırabilir ve buna recursion (özyenileme) denir.

Peki neden bir method recursive olarak kullanılır?
Bazı durumlarda tekrarlayan bir işlemi yapabilmek için döngüler kullanmak yerine recursive methotlar kullanırız. Bu methodlar içerisine yazılan bir şart gerçekleştirilene kadar işlemlerine devam eder.

En basit haliyle fibonacci dizisini düşünelim ve bunu önce bir döngü ile daha sonra recursive method ile yazalım.

``` csharp
Console.WriteLine("Loop içinde Fibonacci...");
Console.WriteLine("------------------------");

int x = 0, y = 1, z = 0;

Console.Write($"{x} {y}");

int count = 10;
for (int i = 2; i < count; i++)
{
    z = x + y;
    Console.Write($" {z}");

    x = y;
    y = z;
}
```

Sonuç;

``` shell
Loop içinde Fibonacci...
------------------------
0 1 1 2 3 5 8 13 21 34
```

Şimdi yazdığımız kodu recursive methot ile yazalım.

``` csharp
static void Main(string[] args)
{
    Console.WriteLine("Recursive methot içinde Fibonacci...");
    Console.WriteLine("------------------------------------");
    FibonacciRecursiveCalc(0, 1, 1, 10);
}

// Fibonacci dizisini oluşturacak methodumuz.
private static void FibonacciRecursiveCalc(int x, int y, int count, int length)  
{  
    if (count <= length)  
    {  
        Console.Write("{0} ", x);  
        FibonacciRecursiveCalc(y, x + y, count + 1, length);  
    }  
}
```

Sonuç;

``` shell
Recursive methot içinde Fibonacci...
------------------------------------
0 1 1 2 3 5 8 13 21 34
```

## Method Overloading (Aşırı Yükleme)

Bir method'un aynı isimde ancak farklı parametrelerde farklı versiyonlarının olmasıdır.

Aşağıdaki örnekte GetCustomerInfo methodumuzun iki farklı versiyonu olup ikiside farklı parametreler almıştır.

``` csharp
public Customer GetCustomerInfo(int id)
{
    // Çalıştırılacak kodlar
}

public Customer GetCustomerInfo(string firstName, string lastName)
{
    // Çalıştırılacak kodlar
}
```

## Parameters (Parametreler)

Yazdığımız methodlar bazı durumlarda çalışmak için dışarıdan verilere ihtiyaç duyabilirler.
Methodlar 3 tip parametre alabilirler;

**1. Value Parameters**
Çağırdığımız methoda beklediği türde parametrelerin geçilmesini sağlarlar.

``` csharp
// Buradaki parametre geçme yöntemi standart yöntemdir.
public Customer GetCustomerInfo(string firstName, string lastName)
{
    // Çalıştırılacak kodlar
}
```

**2. Reference Parameters**
Referans parametreler, value parametrelerden farklı olarak bellekte bir değişken olarak saklanırlar.
Bu parametrelerin değerlerinde yapılacak bir değişiklik parametrenin orjinal değerinide güncelleyecektir. Value parametrelerde böyle bir durum söz konusu değildir, orjinal değer olduğu gibi korunur.

Aşağıdaki örnekte `value` değişkeninin hem orjinal değerini hem de `ref` parametre olarak bir method'a gönderilip işlendiği zaman nasıl değiştiğini görebilirsiniz.

Örnek;

``` csharp
static void Main(string[] args)
{
    var value = 5;
    Console.WriteLine($"Orjinal Değer : {value}");

    SumValues(10, 15, ref value);
    Console.WriteLine($"Güncel Değer : {value}");
}

private static void SumValues(int x, int y, ref int z)
{
    z = x + y + z;
}
```

Sonuç;

``` shell
Orjinal Değer : 5
Güncel Değer : 30
```

**3. Output Parameters**
Output parametrelerde reference parametreler gibi benzer kullanıma sahiptir. Ayrıca bir methoda hem dönüş değeri vererek hem de output parametre tanımlayarak iki dönüş değeri elde edilebilir.

Aşağıdaki örnekte `SumAndReturnValues` methodumuza x ve y olmak üzere iki adet parametre geçiyor ve bir tane output parametresi ekliyoruz. Methodumuz içerisinde x ve y değerlerinin toplamlarını return değeri ile dönüyoruz. Output olarak belirlediğimiz z değerini ise methot içerisinde belirleyip dönüyoruz.

Örnek;

``` csharp
static void Main(string[] args)
{
    int outputValue;
    var returnValue = SumAndReturnValues(15, 25, out outputValue);

    Console.WriteLine($"Dönüş Değeri : {returnValue}");
    Console.WriteLine($"Output Değeri : {outputValue}");
}

private static int SumAndReturnValues(int x, int y, out int z){
    z = 15;
    return x + y;
}
```

Sonuç;

``` shell
Dönüş Değeri : 40
Output Değeri : 15
```
