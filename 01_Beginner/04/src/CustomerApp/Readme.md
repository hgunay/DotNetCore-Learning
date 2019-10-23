# Classes (Sınıflar)

Sınıflar, OOP'in temel yapı taşlarından birisidir. Sınıf olarak tanımladığımız bir tür, başvuru türüdür. Yazdığımız bir sınıfı kodumuz içerisinde kullanmak istediğimiz yerde `new` anahtar kelimesi ile oluştururuz.

``` csharp
var customer = new Customer();
```

<strong>Sınıfları Ne İçin Kullanırız?</strong>

C# ile ilgili bir çok blog ve makalede sınıf kavramının rahatça anlaşılabilmesi için gerçek hayattan örnekler verilmekte. Ben de bu şekilde yapıp 
geleneği bozmayacağım :)

Elimizde bir müşteri portföyümüz olduğunu var sayalım. Müşteri ile ilgili olarak en temel haliyle aşağıdaki bilgileri yer alacaktır;

- Ad
- Soyad
- Telefon
- E-posta
- Adres
- İl
- İlçe
- Semt

Bu bilgileri geliştirmekte olduğumuz proje içerisinde defalarca kullanacağımızı düşünürsek her seferinde bu bilgilere ulaşmamız ya da güncellememiz gereken durumlar olacaktır. Class'lar tam olarak bu noktada devreye girerek bu bilgiler ile ilişkili metodları tekrar tekrar yazmak yerine bir class içerisinde tanımlayarak hem kod kalitesini hem okunabilirliği hem de geliştirme sürecini kolaylaştırır.

## Class Tanımlama

Bir class tanımlanırken aşağıdaki formatta olduğu şekilde tanımlanmalıdır;

``` csharp
public class Customer {
    // ...
}
```

- public > Class için erişim belirticidir (Access Modifier). Aşağıdaki listede belirticiler ve erişim özellikleri yer almaktadır;

1. <strong>public</strong> : Bu class'a her yerden erişilebilir demektir.
2. <strong>private</strong> : Sadece tanımlı olduğu sınıf içerisinden erişilebilir.
3. <strong>protected</strong> : Sadece tanımlı olduğu sınıf ya da bu sınıftan türetilmiş bir sınıftan erişilebilir.
4. <strong>internal</strong> : Sadece tanımlı olduğu proje tarafından erişilebilir.
5. <strong>protected internal</strong> : Tanımlı olduğu proje ya da başka bir projede türetilmiş bir sınıftan erişilebilir.
6. <strong>private protected</strong> : Sadece tanımlı olduğu projede aynı class içerisinden ya da bu sınıftan türetilmiş başka bir sınıftan erişilebilir.

## Class Oluşturma<a name="create-class"></a>

Bir class oluştururken bu class'ı isterseniz yazdığınız kod dosyası içerisinde (bizim için burada Program.cs dosyası) ya da farklı bir dosya içerisinde oluşturabilirsiniz. Aşağıdaki ekran görüntüsünde olduğu gibi VS Explorer'da sağ tıkladığımız zaman açılan menüde yer alan <strong>New C# Class</strong>'a tıklıyoruz.

![new-class](https://user-images.githubusercontent.com/19264860/66589585-80806d00-eb97-11e9-8802-56abb46aae40.png)

<strong>New C# Class</strong>'a tıkladığımız zaman oluşturacağımız yeni class'ımıza hangi ismi vereceğimizi soracak.

![create-a-class](https://user-images.githubusercontent.com/19264860/66589589-824a3080-eb97-11e9-9696-21a28df0588a.png)

Class'ımızın ismini verdik ve yeni class'ımız oluşturuldu.

![show-class](https://user-images.githubusercontent.com/19264860/66589590-8413f400-eb97-11e9-8e6d-e0a434ea0bb3.png)

Şimdi gelelim bu class'ımızı nasıl kullanacağımıza.
Öncelikle Program.cs dosyası içerisine oluşturduğumuz Customer class'ını tanımlayalım;

``` csharp
var customer = new Customer();
```

Customer class'ımızı tanımladıktan sonra kullanmak istediğimiz zaman aşağıda olduğu gibi bu class içerisinde yazmış olduğumuz bir property ya da method olmadığı için listelenmeyecektir. Bu yüzden öncelikle class'ımıza gidip property'lerini ve method'larını tanımlamamız gerekecek.

![use-a-class](https://user-images.githubusercontent.com/19264860/66590491-92fba600-eb99-11e9-8393-82f0a1b3ef3e.png)

Customer class'ımıza property'leri ve basit bir method'u ekledikten sonra tekrar tanımladığımız yerde çağıralım.

![list-class](https://user-images.githubusercontent.com/19264860/66659003-47a1d000-ec4b-11e9-9fc8-65bbbd293b21.png)

## Constructor (Yapıcı Metod) Ekleme

- Constructor bir class oluşturulduğu zaman çağırılan ilk metod'dur.
- Herhangi bir değer dönmezler ve public'tir.
- Bir class içerisinde farklı parametreler alabilen birden fazla consturctor bulunabilir. Eğer constructor'ın parametresi yoksa bu default constructor'dır.
- Constructor'ın adı class'ın adı ile aynı olmak zorundadır.

Aşağıdaki örnek'te iki farklı constructor görebilirsiniz;

``` csharp
/// <summary>
/// Default Constructor
/// </summary>
public Customer()
{

}

/// <summary>
/// Customer Id parametresi alan diğer constructor.
/// </summary>
/// <param name="customerId">Customer Id.</param>
public Customer(int customerId)
{
    this.Id = customerId;
}
```

Parametreli constructor kullanımını yeni bir service class'ı yazarak inceleyelim.

1. Customer class'ımızı ilk oluştururken izlediğimiz adımları izliyoruz ve <strong>CustomerService</strong> adında bir class oluşturuyoruz. Bu service içerisinde bizim <strong>CRUD (Create-Read-Update-Delete)</strong> işlemlerini yapacağımız method'lar yer alacak. Bu service class'ımıza bir <strong>Read</strong> method'u ekleyelim;

``` csharp
public Customer GetCustomerById(int id)
{
    if(id <= 0){
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

2. Program.cs içerisinden CustomerService içerisindeki GetCustomerById method'unu çağıralım;

``` csharp
var customerService = new CustomerService();
var customerData = customerService.GetCustomerById(1);

Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
```

Sonuç;

``` console
Anakin Skywalker - anakin@skywalker.com
```

Peki burada CustomerId parametresine 1 değil de 2 değerini gönderseydik ne olurdu?

Sonuç;

``` console
Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
   at CustomerApp.Program.Main() in c:\Data\GitHub\DotNetCore-Learning\01_Beginner\04\src\CustomerApp\Program.cs:line 12
```

<strong><span style="color:red">Null Reference Exception</span></strong>

Yeni başlayan tüm yazılımcılara uyarı niteliğinde olsun :) Kod yazarken bu hatayı alabileceğiniz her yerde null kontrolü yapın. Deneyimli yazılımcıların bile gözünden kaçabildiği zamanlar oluyor!!!

Ozaman yazdığımız kodu aşağıdaki gibi null kontrolü yaparak güncellersek bu hatadan kurtulmuş oluruz;

``` csharp
if(customerData != null)
{
    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
}
else
{
    Console.WriteLine("Müşteri bilgileri bulunamadı.");
}
```

Sonuç;

``` console
Müşteri bilgileri bulunamadı.
```
