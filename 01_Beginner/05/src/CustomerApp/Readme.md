# Statements (Deyimler)

## Decision Making Statements (Karar Verme Deyimleri)

Programlama dillerinde, karar verme deyimlerine bakıldığında aslında gerçek hayat ile aynı olduğunu görebilirsiniz. Nasıl ki bir konuda karar vermemiz gerektiği zaman `Bu ya da bu?`, `Eğer bu olursa...` gibi sorularını soruyorsak, programlama dilleri de kod içerinde karar verilmesi gereken durumlarda aynı mekanizma ile bu sorgu işlemlerini gerçekleştirip kodu çalıştırmaya devam eder. Şimdi bu kararları vermek için kullancağımız karar verme deyimlerini inceleyelim ;)

1. if statement
2. if-else statement
3. if-else-if statement
4. Nested if statement
5. switch statement
6. Nested switch statement 

### <strong>if</strong> Statement

if statement verilen bir koşulu kontrol eder ve eğer koşul `true` olarak değerlendirilirse if bloğu içerisindeki yazılan tüm kod çalıştırılır. if statement için basit bir örneği bir önceki bölümde if-else statement kullanarak <strong>Null Reference Exception</strong> hatasını kontrol ederken kullanmıştık. Ancak tekrar hatırlatmakta fayda var :)

Kullanımı;

``` csharp
if(condition)
{
    // eğer koşul true ise çalıştırılacak kod
}
```

Örnek;

``` csharp
if(customerData == null)
{
    Console.WriteLine("Müşteri bilgileri bulunamadı.");
}
```

### <strong>if-else</strong> Statement

if statement sadece `true` olarak değerlendirilidiği zaman içerisindeki kod bloğunu çalıştırırken, if-else statement koşulunun sonucu `false` geldiği zaman else bloğu içerisindeki kod bloğunuda çalıştırır.

Kullanımı;

``` csharp
if(condition)
{
    // eğer koşul true ise çalıştırılacak kod
}
else
{
    // eğer koşul false ise çalıştırılacak kod
}
```

Örnek;

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

### <strong>if-else-if</strong> Statement

if-else-if statement birden fazla koşulun kontrol edilmesi gerektiği durumlarda kullanılır. İlk if statement ile kontrol işlemine başlar ve `true` değerini alıncaya kadar bütün koşulları dener. Bu koşullardan hiçbirisi `true` değerini dönmezse en son else bloğuna girer ve buradaki kodu çalıştırır.

Kullanımı;

``` csharp
if(condition_1)
{
    // condition_1 koşulu true ise çalıştırılacak kod
}
else if(condition_2)
{
    // condition_2 koşulu true ise çalıştırılacak kod
}
else
{
    // hiçbir koşulun sağlanmadığı ve false olduğu durumda çalıştırılacak kod
}
```

Örnek;

``` csharp
if(customerData != null && string.IsNullOrEmpty(customerData.FirstName))
{
    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
}
else if(customerData != null)
{
    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
}
else
{
    Console.WriteLine("Müşteri bilgileri bulunamadı.");
}
```

Yukarıdaki kodu incelediğimizde;

. customerData eğer null değilse ve customerData içerisindeki FirstName verisi yoksa ilk if bloğu içerisindeki kod çalıştırılacak.

. ilk koşul sağlanmazsa sadece customerData bilgisini kontrol edecek ve null değilse bu if bloğu içerisindeki kodu çalıştıracak.

. if-else-if koşullarının hiçbirisi karşılanamzsa else bloğu içerisindeki kod çalıştırılacak.

### <strong>Nested if</strong> Statement

Bir if statement başka bir if statement içerisinde yer aldığı zaman bu Nested if statement olarak adlandırılır. Aslında buradaki koşul kontrollerini parent(ana) ve sub(alt) olarak düşünebiliriz.

Kullanımı;

``` csharp
if(condition_1)
{
    // condition_1 koşulu true ise çalıştırılacak

    if(condition_2)
    {
        // condition_2 koşulu true ise çalıştırılacak kod
    }
}
```

Örnek;

``` csharp
if(customerData != null)
{
    if (string.IsNullOrEmpty(customerData.EmailAddress))
    {
        Console.WriteLine($"{customerData.FullName()} - Müşteri e-posta bilgisi bulunamadı.");
    }
}
```

### <strong>switch</strong> Statement

switch statement çok fazla if-else-if kullanımın yapılacağı yerlerde alternatif olarak kullanıılabiliecek bir mekanizmadır. `default` opsiyoneldir ve en son yazılır. `break` ise altında bulunduğu `case` içerisindeki kod çalıştırıldıktan sonra switch içerisindeki işlemlerin sonlandırılmasını sağlar. Eğer `break` kullanılmazsa mevcut `case` içerisindeki işlemler bittikten sonra diğer `case` leri kontrol eder.

Kullanımı;

``` csharp
switch (expression)
{
    case constant_1:
        // ...
    break;
    case constant_2:
        // ...
    break;
    case constant_N:
        // ...
    break;
    default:
        // default is optional
    break;
}
```

Örnek;

``` csharp
switch (customerData.Id)
{
    case 1:
        Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
    break;
    case 2:
        Console.WriteLine($"{customerData.FullName()} - {customerData.PhoneNumber}");
    break;
    default:
        Console.WriteLine(customerData.FullName());
    break;
}
```

### <strong>Nested switch</strong> Statement

Nested switch'lerin çalışma mantığı da aynı nested if gibidir. İçteki switch statement ile içerisinde bulunduğu `case` birbiri ile ilişkilidir diyebiliriz.

Kullanımı;

``` csharp
switch (expression_1)
{
    case constant_1:
        switch (constant_1_expression_2)
        {
            case expression_2_constant_1:
                // ...
            break;
            case expression_2_constant_2:
                // ...
            break;
            case expression_2_constant_N:
                // ...
            break;
            default:
                // ...
            break;
        }

    break;
    case constant_2:
        // ...
    break;
    case constant_N:
        // ...
    break;
    default:
        // default is optional
    break;
}
```

Örnek;

``` csharp
switch (customerData.LastName)
{
    case "Skywalker":
        Console.WriteLine("Last name : Skywalker");

        switch (customerData.FirstName)
        {
            case "Luke":
                Console.WriteLine("I'm Luke Skywalker. I'm here to rescue you.");
            break;
            case "Leia":
                Console.WriteLine("Help me Obi-Wan Kenobi, you're my only hope.");
            break;
            default:
                Console.WriteLine("I'm your father!");
            break;
        }

    break;
    case "Kenobi":
        Console.WriteLine("That's no moon. It's a space station.");
    break;
    default:
        Console.WriteLine("May the Force be with you.");
    break;
}
```
