# Inheritance (Kalıtım/Miras) ve Polymorphisim (Çok Biçimlilik)

## Inheritance (Kalıtım/Miras) Nedir?

Bir sınıfın başka bir sınıftan türemesine **Inheritance** denir ve OOP'nin üç temel öğesinden birisidir. İlk olarak bu temel öğelerden biri olan [Encapsulation](https://github.com/hgunay/DotNetCore-Learning/tree/master/01_Beginner/08/src/CustomerApp#encapsulation-kaps%C3%BClleme) kavramına değinmiştik.

. Kalıtım ile birlikte hem kod tekrarları engellenmiş olur hem de hiyerariş bir yapı oluşturulması sağlanır.
. Kalıtım alan sınıfa **Derived Class (Türeyen Sınıf)** denir.
. Kalıtım veren sınıfa **Base Class (Türeten Sınıf)** denir.

### Base Class'tan Türetme

Daha önceki konularımızda Customer adında bir class oluşturmuştuk. Şimdi yeni bir class ekleyelim ve adını CustomerAddress koyalım. Base Class'ımız olmadığı zaman yazdığımız class'lar aşağıdaki gibi olacaktır.

``` csharp
/// <summary>
/// Customer Class
/// </summary>
public class Customer
{
    /// <summary>
    /// Müşteri Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Müşteri Adı
    /// </summary>
    public string FirstName { get; set; }

// ....
```

``` csharp
/// <summary>
/// Customer Address Class
/// </summary>
public class CustomerAddress
{
    /// <summary>
    /// Müşteri Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Müşteri ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Adres Alanı
    /// </summary>
    public string Address { get; set; }

// ....
```

Dikkat ederseniz her iki class'ımız içerisinde **Id** property'si tekrar etmekte. Yazığınız projeler büyüdükçe class'larınız içerisinde buna benzer property ve method tekrarları oluşacaktır. İşte bu tekrarları engellemek adına bir Base Class oluşturup class'larınızı bundan türetebilirsiniz. Şimdi bu iki class'ımızı bir base class yazıp bundan türetelim.

Önce her iki class içerisinde ortak olan Id property'sini base class'ımız içerisine alıyoruz.

``` csharp
/// <summary>
/// Base Customer class.
/// </summary>
public class BaseCustomer
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
}
```

Daha sonra bu **BaseCustomer** class'tan türeyecek class'larımızdan Id property'sini çıkartıp bu base class'tan türemelerini sağlıyoruz.

``` csharp
/// <summary>
/// Customer Class
/// </summary>
public class Customer : BaseCustomer
{
    /// <summary>
    /// Müşteri Adı 
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Müşteri Soyadı
    /// </summary>
    public string LastName { get; set; }

// ....
```

``` csharp
/// <summary>
/// Customer Address Class
/// </summary>
public class CustomerAddress : BaseCustomer
{
    /// <summary>
    /// Müşteri ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Adres Alanı
    /// </summary>
    public string Address { get; set; }

// ....
```

> Bir class sadece tek bir class'tan kalıtım alır, ikinci bir class'tan daha kalıtım alamaz!
> Birden fazla kalıtım alması gerektiği durumlar için daha sonra inceleyeceğimiz **Interface** kavramına girmeniz gerekmektedir.
> Base class içerisindeki property ve methodlar türetilen (derived) class içerisine aktarılırlar.

## Polymorphisim (Çok Biçimlilik) Nedir?

OOP'nin bir diğer temel öğeside **Polymorphisim**'dir. Inheritance başlığı altında kalıtım yolu ile property ve methodlarında türetilen class içerisine aktarıldığından bahsetmiştik. Ancak bazı durumlarda bu aktarılan methodlar türetilen class içerisinde işimizi görmeyebilir. İşte bu durumlarda aktarılan methodlara türetilen class içerisinde müdahele edip işinize uygun hale getirebilirsiniz. Buna **Polymorphisim** denir. Şimdi bu kavramı basit bir örnek üzerinden inceleyelim.

BaseCustomer class'ımız içerisinde aşağıdaki methodu ekleyelim.

``` csharp
public virtual void GetCustomerInfo()
{
    Console.WriteLine($"Id : {Id} ");
}
```

Bu method türetildiği class içerisinden çağırıldığı zaman ekrana aşağıdaki gibi bir sonuç satırı yazdıracaktır.

``` console
Id : 28
```

Peki bu methodu türetilen sınıflar içerisinde **override (ezme)** edersek ne olur?

Customer class'ımız içerine `GetCustomerInfo` methodunu override ederek ekliyoruz.

``` csharp
public override void GetCustomerInfo()
{
    Console.WriteLine("Müşteri Bilgileri");
    Console.WriteLine("-----------------");
    base.GetCustomerInfo();
    Console.WriteLine($"Adı - Soyadı : {CustomerFullName} | Telefon No : {PhoneNumber} | E-Posta : {EmailAddress}");
}
```

Gördüğünüz üzere override ettiğimiz methodu `base.GetCustomerInfo();` şeklinde çağırıyoruz.

> Bu şekilde kullanmak zorunda değilsiniz elbette. Override ettikten sonra method içerisinde istediğinizi yapabilirsiniz.

CustomerAddress class'ımız içerisinde de aşağıdaki gibi override ediyoruz.

``` csharp
public override void GetCustomerInfo()
{
    Console.WriteLine("Adres Bilgileri");
    Console.WriteLine("---------------");
    base.GetCustomerInfo();
    Console.WriteLine($"Müşteri Id : {CustomerId} | Adres : {Address} | İl : {City} | İlçe : {County} | Semt : {District}");
}
```

Class'larımıza eklediğimiz methodları class tanımlarımız CustomerService içerisinde olduğu için aşağıdaki gibi çağırıyoruz.

``` csharp
 public void GetCustomerInfo()
{
    customer.GetCustomerInfo();
}

public void GetCustomerAddressInfo()
{
    customerAddress.GetCustomerInfo();
}
```

Ve son olarak sonuçları ekrana yazdıracağımız yerde bu iki servis methodunu çağırıyoruz.

``` csharp
customerService.GetCustomerInfo();
customerService.GetCustomerAddressInfo();
```

Sonuç;

``` console
Müsteri Bilgileri
-----------------
Id : 13 | Adi - Soyadi : Anakin Skywalker | Telefon No : 555 123 45 67 | E-Posta : anakin@skywalker.com
-----------------

Adres Bilgileri
---------------
Id : 88 | Müsteri Id : 13 | Adres : Tatooine | Il : Mos Espa | Ilçe : Spaceport | Semt : ???
---------------

Polymorphisim ile gelen bilgiler...
-----------------------------------
Müsteri Bilgileri
-----------------
Id : 13
Adi - Soyadi : Anakin Skywalker | Telefon No : 555 123 45 67 | E-Posta : anakin@skywalker.com
-----------------

Adres Bilgileri
---------------
Id : 88
Müsteri Id : 13 | Adres : Tatooine | Il : Mos Espa | Ilçe : Spaceport | Semt : ???
---------------

Islem tamamlandi.
```
