# C# Syntax (Sözdizimi)

## Comments (Yorumlar)

Yorumlar kodu açıklamak için kullanılırlar ve derleyiciler tarafından derleme esnasında yoksayılırlar. İki tip yorum çeşidi vardır;

- Single-line Comments (Tek satırlı yorumlar)
- Multi-line Comments (Çok satırlı yorumlar)

### Single-line Comments

Tek satırlı yorumlar // ile başlar ve tüm yorum tek satırda olur. Ancak altına // ile başlayan yeni bir satır daha eklenirse ilk yazılan yorum ile birleştirilebilir.

``` csharp
// bu tek satırlı bir yorumdur.
```

ya da

``` csharp
// bu tek satılır bir yorumdur.
// başka bir tek satırlı yorum ile devam edilebilir.
```

### Multi-line Comments

Çok satırlı yorumlar ise /* ile başlayıp */ ile biter, herhangi bir satır sayısı sınırlaması yoktur.

``` csharp
/*
    bu çok
    satırlı bir
    yorumdur.
*/
```

## Value Types (Değer Türleri)

Value Type'lar en basit tanımıyla yazdığımız kod içerisinde kullandığımız değişkenlerdir.

Bu listeyi Microsoft'un dokumanlarından inceleyebilirsiniz. [MS Docs Value Types](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/value-types-table)

Örnek;

``` csharp
int x = 1;
bool isActive = false;
double y = 3.14;
```

Ancak C# 3.0 ile gelen yeniliklerden birisi ise `var` anonim türüdür. Yukarıdaki örnekte vermiş olduğumuz değerleri `var` olarak tanımlarsak;

``` csharp
var x = 1;
var isActive = false;
var y = 3.14;
```

şeklinde olacaktır.

<strong>Peki Neden Var Bu `var`? :)</strong>

Aslında bir çok yazılımcı ( ben de dahil :) ) yazılan kodu kısaltmak, kodu daha temiz ve düzenli tutmak için kullanıyor diyebiliriz. Ancak asıl sebebi herhangi bir tür belirtmeden anonim türdeki verilerin bir değişkende tutulması içindir.

Performans açısından `var` yazmak ile `int` ya da başka bir tür tanımlamak arasında runtime esnasında bir farkı yoktur. Tek fark build anında `var` ile tanımlanmış bir değişkeni atanan değere baktıktan sonra hangi türe çevireceğine karar vermek olacaktır. Eğer değişken tanımlaması direkt olarak yapılmış olursa herhangi bir kontrol yapmadan build etmeye devam edecektir.

Yukarıda kısaca değindiğimiz türler için örnek kodlarımızı yazalım şimdi :)
Elimizde `int` ve `double` değişkenlerimiz olsun, bunların toplamlarını `var` türünden bir değişkenlere ayrı ayrı atalım ve bu toplamları `String Interpolation`'ı da kullanarak console'da yazdıralım.

``` csharp
int x = 1;
int y = 3;
var intTotal = x + y;

Console.WriteLine($"Integer Değerlerin Toplamı : {intTotal}");
```

``` csharp
double a = 15.3;
double b = 23.8;
var doubleTotal = a + b;

Console.WriteLine($"Double Değerlerin Toplamı : {doubleTotal}");
```

Bir de `bool` türünden değişkenimizi `var` olarak tanımlayalım ve aynı şekilde console'a yazdıralım.

``` csharp
var isActive = false;

Console.WriteLine($"Bool Değeri : {isActive}");
```

Command prompt üzerinden yazdığımız kodu her seferinde çalıştırmadan [Debugging](https://github.com/hgunay/DotNetCore-Learning/tree/master/01_Beginner/02/src/CustomerApp#debugging-hata-ay%C4%B1klama) kısmında anlatmış olduğum şekilde <strong>F5</strong> yada <strong>Ctrl+F5</strong> ile yazdığımız kodu derleyerek <strong>Debug Console</strong> altında da sonuçları görebiliriz.

Sonuç;

``` console
Integer Değerlerin Toplamı : 4
Double Değerlerin Toplamı : 39,1
Bool Değeri : False
```

## Arrays (Diziler)

Diziler, aynı veri türündeki öğelerin sabit boyutlu bir kolleksiyonunu saklamak için kullanılırlar. Yazdığımız kod içerisinde aynı türde birden fazla değişken tanımlamak yerine (number1, number2, number3 ...) bunları bir dizi içerisinde tanımlayabiliriz (<strong>NumberList[]</strong>).

<p align="center">
<img src="https://user-images.githubusercontent.com/19264860/69482746-5a094f00-0e30-11ea-8df8-f85769fc2459.png" data-canonical-src="https://user-images.githubusercontent.com/19264860/69482746-5a094f00-0e30-11ea-8df8-f85769fc2459.png" width="60%" />
</p>

Array'lerin index'leri 0'dan başlar ve 1'er tanımlı olan boyutu kadar artarak devam eder.

### Array Tanımlama

C#'ta bir array tanımlanırken şu formatta yazılmalıdır;

``` csharp
dataType[] arrayName;
```

- datatype[] > Array'in data türü
- arrayName > Array'in adı

Örnek;

``` csharp
int[] i;
double[] d;
string[] s;
```

### Array Başlatma

Array'i tanımladıktan sonra `new` anahtar kelimesi ile array'i başlatmış ve istersek boyutunu da belirtmiş oluruz.

``` csharp
int[] intList = new int[5]; // Tek boyutlu ve 5 elemanlı integer türünden dizi
```

### Array'e Değer Atama

Başlatmış olduğumuz array'e istersek başlattığımız zaman istersek sonradan elemanlarını atayabiliriz.

``` csharp
int[] intList = new int[5]{ 1, 2, 3, 4, 5 };
```

yada

``` csharp
int[] intList;
intList =  new int[5]{ 1, 2, 3, 4, 5 };
```

Eğer oluşturduğumuz array'e herhangi bir boyut girmezsek bunun <strong>Tek Boyutlu(Single Dimensional)</strong> array olduğunu belirtmiş oluruz.

``` csharp
int[] intList = new int[]{ 1, 2, 3, 4, 5 }; // Boyut belirtilmemiş
```

<strong>Çok Boyutlu(Multi Dimensional)</strong> array'lerde boyut tanımlama biraz daha farklıdır. Tek boyutlu dizileri tanımlerken belirttiğimiz boyutun yanına bir boyut daha belirtiriz.

Örnek;

``` csharp
// İki Boyutlu (Multi Dimensional)
int[,] multiList1 = new int[3, 2]{
    { 1, 2 },
    { 3, 4 },
    { 5, 6 }
};

// Üç Boyutlu (Multi Dimensional)
 int[, ,] multiList2 = new int[2, 3, 3] {
    { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
    { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } }
};
```

### Array'e Eleman Ekleme

Herhangi bir elemanı olmayan yeni tanımlanmış bir array'e ise alttaki örnekte yer aldığı şekilde index'lerini belirterek elemanlarını atayabilirsiniz.

``` csharp
var newIntList = new int[3];
newIntList[0] = 11;
newIntList[1] = 22;
newIntList[2] = 33;
```

Basit bir örnek ile bu array'deki elemanların toplamlarını alalım;

``` csharp
var newIntListTotal = newIntList[0];
newIntListTotal += newIntList[1];
newIntListTotal += newIntList[2];

Console.WriteLine($"Integer Array Listesi Toplamı : {newIntListTotal}");
```

Sonuç;

``` console
Integer Array Listesi Toplamı : 66
```

Şimdi bu örneğimizi biraz daha düzgün hale getirip `foreach` içerisinde çağırıp toplamlarını alalım :)

``` csharp
var newIntTotal = 0;
foreach(var item in newIntList){
    newIntTotal += item;
}

Console.WriteLine($"Integer Array Listesi Toplamı (foreach) : {newIntTotal}");
```

Sonuç;

``` console
Integer Array Listesi Toplamı : 66
```

## Generic List

Generic List sınıfı, mantık olarak dizilere benzerlik gösteriyor olsa bile dizilerden çok daha farklı özellikleri bulunan bir sınıftır. <strong>System.Collection.Generic</strong> namespace'i altında yer almaktadır. Bir dizi tanımlarken o diziye ait boyutu girmek zorundayız ancak bir List tanımlarken herhangi bir boyut değeri girmeye gerek yoktur. Generic List'lerin boyutları dinamik olarak girilen eleman sayısı kadar artmakta ya da azalmaktadır.

### List Tanımlama

Generic List tanımlanırken formatı şu şekilde olmalıdır;

``` csharp
List<T> listItems;
```

- T > List içerisinde yer alacak elemanların türünü belirler. (int, double, string vs.)

### List'e Eleman Ekleme

Tanımladığımız list'e `Add` yöntemi ile eleman ekleyebiliriz.

``` csharp
List<string> nameList = new List<string>();
nameList.Add("Anakin");
nameList.Add("Luke");
nameList.Add("Leia");
```

Array örneğinde olduğu gibi list'imizin elemanlarını da foreach döngüsü içerisinde birleştirip konsola yazdıralım.

``` csharp
var nameResult = string.Empty;
foreach (var item in nameList)
{
    nameResult += $"{item} ";
}

Console.WriteLine($"Generic List Kullanımı : {nameResult}");
```

Sonuç;

``` console
Generic List Kullanımı : Anakin Luke Leia
```
