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

## Loops (Döngüler)

Döngüler, bir kod parçasının birden fazla defa çalıştırılması için kullanılırlar ve genellikle de sıralı olarak çalıştırılırlar.

1. for loop
2. foreach loop
3. while loop
4. do...while loop

### for Loop

for döngüsü, içerisinde yazılan kod parçasının birden fazla kez çalıştırılması gerektiği durumlarda ve özellikle kaç kez çalıştırılacakları biliniyorsa kullanılır.

Kullanımı;

``` csharp
for (init; condition; increment/decrement)
{
    // ...
}
```

init : döngü başlangıç değeri
condition : test edilecek koşul
increment/decrement : değişim miktarı (+/-)

Örnek;

``` csharp
for (var i = 1; i <= 3; i++)
{
    Console.WriteLine($"for : {i}. {customerData.FullName()}");
}
```

Sonuç;

``` console
for : 1. Anakin Skywalker
for : 2. Anakin Skywalker
for : 3. Anakin Skywalker
```

for döngüsü için yazdığımız kodu özetleyecek olursak; `i` değişkenine 1 değerini atayarak başlangıç değerini belirledik ve bu değişken 3'ten küçük ve eşit olduğu sürece (i <= 3) arttırmaya devam et dedik. Böylece bize 3 adet sonuç listeleyen bir for döngüsü yazmış olduk. Peki `i` değişkenine 1 değerini değil de 0 değerini verseydik ne olurdu?

Sonuç;

``` console
for : 0. Anakin Skywalker
for : 1. Anakin Skywalker
for : 2. Anakin Skywalker
```

Daha önce <strong>[array](https://github.com/hgunay/DotNetCore-Learning/tree/master/01_Beginner/03/src/CustomerApp#arrays-diziler)</strong> başlığı altında index'ler 0'dan başlar ve tanımlı olduğu boyut kadar arttırılabilir demiştik. İşte burada da aynı durum geçerli.

### while Loop

while döngüsü ile for döngüsü fonksiyonel olarak birbirine benzer. for döngüsü ile arasındaki fark; for döngüsünde döngünün ne zaman biteceği bilinir ancak while döngüsünde döngünün ne zaman biteceği bilinmez.
Kullanım olarak ise <strong>if statement</strong>'a çok benzer ve ikisi de belirtilen koşul `true` olduğu sürece içerisinde yazılan kod bloğunu çalıştırır ancak while döngüsünde bu kod bloğu koşul `false` oluncaya kadar sürekli döngüde kalarak çalıştırılmaya devam eder.

Kullanımı;

``` csharp
while (condition)
{
    // ...
}
```

Örnek;

``` csharp
var j = 1;
while (j <= 3)
{
    Console.WriteLine($"while : {j}. {customerData.FullName()}");
    j++;
}
```

Sonuç;

``` console
while : 1. Anakin Skywalker
while : 2. Anakin Skywalker
while : 3. Anakin Skywalker
```

### do-while Loop

do-while döngüsü, while döngüsü ile aynı mantıktadır ancak aradaki fark do-while döngüsü önce içerisinde yazılan kodu çalıştırır daha sonra yazılan koşulun uygun olup olmadığına bakar.

Kullanımı;

``` csharp
do
{
    // ...
} while (condition);
```

Örnek;

``` csharp
var x = 1;
do
{
    Console.WriteLine($"do-while : {x}. {customerData.FullName()}");
    x++;
} while (x <= 3);
```

Sonuç;

``` console
do-while : 1. Anakin Skywalker
do-while : 2. Anakin Skywalker
do-while : 3. Anakin Skywalker
```

### foreach Loop

foreach döngüsü, bir array ya da list üzerinde işlem yapmak için kullanılır. Bu array ya da list içerisindeki tüm elemanlar döngü içerisinde çalıştırılır.

Kullanımı;

``` csharp
foreach (var variable_name in collection)
{
    // ...
}
```

Örnek;

``` csharp
foreach (var item in list)
{
    Console.WriteLine($"foreach : {item}. {customerData.FullName()}");
}
```

Sonuç;

``` console
foreach : 1. Anakin Skywalker
foreach : 2. Anakin Skywalker
foreach : 3. Anakin Skywalker
```

for ve forach arasında performans açısından az elemanlı kolleksiyonlarda bir fark yoktur. Ancak kolleksiyon içerisindeki eleman sayısı arttıkça for döngüsünün performansı forache'e göre daha fazla olacaktır. Benim size tavsiyem eğer eleman sayısı çok olan ve içerisinde bolca işlem yapacağınız durumlar ile kaşılaşırsanız for döngüsü kullanmaya özen gösterin.

## Jumping Statements (break, continue, goto)

Jumping statements kod içerisinde belirli durumlarda kodun sonlandırılması (break), devam ettirilmesi (continue) ve kodun başka bir yerine atlamaya (goto) yarar. Bunları gerçek hayattan basit bir örnekle inceleyelim :)

Evde akşam izleyeceğiniz 5-6 tane filminiz olduğunu düşünün ve hangisini izleyeceğiniz konusunda kararsızsınız. İçlerinde dram, bilim-kurgu ve aksiyon olmak üzere çeşitleri olsun. Ancak içinizden bilim-kurgu izlemek geçiyor ve filmlerinizi incelemeye başlıyorsunuz. Bulduğunuz ilk bilim-kurgu filmini hemen içlerinden alıyor ve izlemeye geçiyorsunuz. İşte bu noktada kafanızda kod yazmış gibi `break` komutunu çalıştırıp hem film listesi döngüsünü kesmiş hem de filminizi izlemeye başlamış oldunuz.

`break` için akış diagramı alttaki gibi olacak;

<p align="center">
<img src="https://user-images.githubusercontent.com/19264860/69483104-419b3380-0e34-11ea-85de-d9c6c3205282.png" data-canonical-src="https://user-images.githubusercontent.com/19264860/69483104-419b3380-0e34-11ea-85de-d9c6c3205282.png" width="40%" />
</p>

Örnek;

``` csharp
var movieTypeList = new string[]{ "dram", "action", "sci-fi", "romance" };
foreach (var item in movieTypeList)
{
    if(item == "sci-fi")
    {
        Console.WriteLine($"Movie Type : {item}");
        break;
    }

    Console.WriteLine($"Movie Type : {item}");
}
```

Sonuç;

``` console
Movie Type : dram
Movie Type : action
Movie Type : sci-fi
```

> `break` komutunu özellikle <strong>[switch](https://github.com/hgunay/DotNetCore-Learning/tree/master/01_Beginner/05/src/CustomerApp#switch-statement)</strong> yazarken bolca kullanıyor olacaksınız.  

Şimdi biraz hikayemizi değiştirelim :)

İzlemek istediğimiz film türünü gene bilim-kurgu olarak seçelim ancak elimizde okadar çok film var ki bu liste içerisinde film türü romantik olanları gördüğümüz gibi geçelim :) bu noktada işte `continue` komutunu kullanmamız gerekiyor. `continue` komutunda film türümüz romantik olduğu zaman hemen sonraki film türüne geçmiş olacaktır.

`continue` için akış diagramı alttaki gibi olacak;

<p align="center">
<img src="https://user-images.githubusercontent.com/19264860/69496122-c0997600-0edf-11ea-865f-9e3371115b3e.png" data-canonical-src="https://user-images.githubusercontent.com/19264860/69496122-c0997600-0edf-11ea-865f-9e3371115b3e.png" width="40%" />
</p>

Örnek;

``` csharp
var movieTypeList = new string[]{ "dram", "action", "romance", "sci-fi" };
foreach (var item in movieTypeList)
{
    if(item == "romance")
    {
        continue;
    }

    Console.WriteLine($"Movie Type : {item}");
}
```

Sonuç;

``` console
Movie Type : dram
Movie Type : action
Movie Type : sci-fi
```

Diğer bir atlama komutu ise `goto` 'dur. Kod içerisinde bu satıra gelindiği zaman etiketlenmiş olan satıra atlamaya yarar.
Bu komutu da şöyle düşünebiliriz; elimizdeki film listesinden gene bilim-kurgu türünde olanların isimlerini görmek isteyelim. `goto` komutu ile film türü bilim-kurgu olan bir film geldiği zaman ilgili label'a atlasın ve burada ismini ekrana yazdırsın. Bunu şimdilik class vs. başka işlere girmeden en basit haliyle yazalım :)

`goto` için akış diagramı alttaki gibi olacak;

<p align="center">
<img src="https://user-images.githubusercontent.com/19264860/69719538-c1b9e580-1121-11ea-813f-4f9b0d73a2a3.png" data-canonical-src="https://user-images.githubusercontent.com/19264860/69719538-c1b9e580-1121-11ea-813f-4f9b0d73a2a3.png" width="40%" />
</p>

Aşağıdaki yöntemde foreach içerisinden dışarıda tanımlamış olduğumuz bir label'a atlıyoruz.

Örnek;

``` csharp
var movieTypeList = new string[]{ "dram", "action", "romance", "sci-fi" };
foreach (var item in movieTypeList)
{
    if(item == "sci-fi")
    {
        goto SciFi;
    }
}

SciFi:
    Console.WriteLine($"Movie type is Sci-Fi");
```

Sonuç;

``` console
Movie type is Sci-Fi
```

`goto` komutunun `switch` deyimi içerisinde kullanımına da örnek kod yazalım.

Örnek;

``` csharp
var movieTypeList = new string[]{ "dram", "action", "romance", "sci-fi" };
foreach (var item in movieTypeList)
{
    switch (item)
    {
        case "dram":
            goto default;
        case "action":
            goto default;
        case "romance":
            goto default;
        case "sci-fi":
            Console.WriteLine($"Movie type is Sci-Fi");
            break;
        default:
            Console.WriteLine($"Movie type is...");
            break;
    }
}
```

Sonuç;

``` console
Movie type is...
Movie type is...
Movie type is...
Movie type is Sci-Fi
```

