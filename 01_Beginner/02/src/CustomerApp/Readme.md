# C# ile Programlamaya Giriş

İlk olarak Program.cs içerisindeki kod satırlarının ne olduğunu inceleyelim :)

## Namespace (İsimuzayı, Ad Alanı yada Kütüphaneler)

Namespace'ler hem .NET Framework sınıflarını hem de kendi tanımladığınız sınıfları ve methodların isimlerini daha büyük ve kapsamlı projelerde kontrol edebilmemizi sağlar.

`using` anahtar sözcüğü (keyword) ile `System` kütüphanesini uygulamaya dahil etmiş ve kod içerisinde defalarca tekrar eden kod kullanımında kurtulmuş oluruz.

Mevcut kodumuzun başına `System` kütüphanesini eklediğimiz zaman;

``` csharp
   using System;
```

yazacağımız kod şu şekilde olacaktır;

``` csharp
   Console.WriteLine("Hello Developer!");
```

> `Console` ise `System` kütüphanesi içerisinde bulunan bir methoddur.

Ancak kullanmazsak şu şekilde yazmamız gerekecektir;

``` csharp
   System.Console.WriteLine("Hello Developer!");
```

Oluşturduğumuz kodu incelediğimiz zaman `CustomerApp` adında bir kütüphane oluşturmuş oluyoruz;

``` csharp
   namespace CustomerApp
   {
      //...
   }
```

## Main() Metodu Nedir?

Main() metodu C# ile uygulama geliştirmek için başlangıç noktasıdır diyebilriz. Uygulama ilk çalıştırıldığı zaman bu method çağırılır.

``` csharp
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello Developer!");
      }
   }
```

Main() metodumuzu istersek herhangi bir parametre belirtmeden de yazabiliriz;

``` csharp
   class Program
   {
      static void Main()
      {
         Console.WriteLine("Hello Developer!");
      }
   }
```

Main() methodumuzu tanımladıktan sonra parantez içerisine herhangi bir parametre eklemeyeceğimiz gibi bir yada birden fazla parametre ekleyebiliriz.

Her parametre bir tür (type) ve bir isimden (name) oluşmalıdır. Bizim methodumuzda `string[]` parametremizin `String Array` olarak türünü, `args` ise ismini belirtmektedir.

> Dizilerin kullanımına daha sonra değineceğiz ;)

## Parametre Kullanımı

Main() metodu üzerinden parametre kullanımını kodumuzda yapacağımız ufak değişiklikler ile inceleyelim.

Önce kodumuzu aşağıdaki şekilde değiştirelim;

``` csharp
   static void Main(string[] args)
   {
      Console.WriteLine("Hello " + args[0] + "!");
   }
```

Yazdığımız kodu eğer `dotnet run` komutu ile direkt olarak çalıştırırsak aşağıdaki hatayı alırsınız;

``` command
   Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at CustomerApp.Program.Main(String[] args) in
   C:\Data\GitHub\DotNetCore-Learning\01_Beginner\02\src\CustomerApp\Program.cs:line 9
```

Komutun doğru yazımı ise `dotnet run Hakan` şeklinde olmalıdır. Komutumuzu çalıştırdığımız zaman konsol uygulamamızın geri dönüş değeri aşağıdaki gibi olacaktır;

``` console
   Hello Hakan!
```

Burada `dotnet run` komutundan sonra Main() metodumuza `Hakan` parametresini gönderiyoruz.

Yazdığımız kodda biraz daha değişiklik yapabilmek için `String Interpolation` kavramına da giriş yapmış olalım :)

## String Interpolation (Metin Formatlama)

Bu kavram C# 6.0 ile gelmiş olup `string.Format` yerine kullanabileceğimiz ve okunablirliği daha fazla olan metin biçimlendirme yöntemidir.

`string.Format` kullanımında formatlamak istedğimiz metinler aşağıdaki örnekte olduğu gibi daha karmaşık ve hataya yol açabilecekken;

``` csharp
   var customerName = "Hakan";
   var editorName = "VS Code";

   Console.WriteLine(string.Format("Hello {0}! This is {1}.", customerName, editorName));
```

string interpolation bizi bu karmaşadan kurtarmaktadır.

``` csharp
   var customerName = "Hakan";
   var editorName = "VS Code";

   Console.WriteLine($"Hello {customerName}! This is {editorName}.");
```

Gördüğünüz üzere metin içerisine yazılacak her parametrenin yeri belli ve okunabilirliği diğer yönteme göre daha kolay ;)

Şimdi gelelim yazdığımız kod üzerinde string interpolation kullanarak ve parametrik olarak verileri değiştirerek çıktı almaya.

Son yazmış olduğumuz kod üzerinde sadece `customerName` değişkenimize `args` parametresini atıyoruz;

``` csharp
   var customerName = args[0];
```

ve tekrar kodumuzu command prompt'ta çalıştırıyoruz;

``` command
   dotnet run -- Hasan
```

> `dotnet run` komutundan sonra  `--` koyarak bu komuttan sonra bir parametre gödereceğimizi belirtmiş oluyoruz.

``` command
   dotnet run [[--] [application arguments]]
```

Komutu çalıştırdığmız zaman çıktısı;

``` command
   Hello Hasan! This is VS Code.
```

## Debugging (Hata Ayıklama)

Yukarında <strong>Parametre Kullanımı</strong> başlığı altında `args` parametresine herhangi bir veri göndermediğimiz zaman kodumuzu çalıştırdığımızda hata vereceğinden bahsetmiştik. Şimdi bu hatanın nasıl debug edilerek düzeltileceğine bakalım.

Aldığımız hata şöyleydi;

``` command
   Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at CustomerApp.Program.Main(String[] args) in
   C:\Data\GitHub\DotNetCore-Learning\01_Beginner\02\src\CustomerApp\Program.cs:line 9
```

Hatayı incelediğimiz zaman aslında çok bariz bir şekilde hangi satırda olduğunu bize gösteriyor. Hata aldığımız 9. satıra giderek breakpoint atalım (Kısayolu F9 :) ) ve isterseniz <strong>F5</strong> ile isterseniz <strong>Debug</strong> menüsü altında yer alan <strong>Start Debugging</strong> ile kodumuzu debug etmeye başlayalım.

![vscode-debug](https://user-images.githubusercontent.com/19264860/63210340-c8ce6200-c0f5-11e9-9072-c56dca16033c.png)

F10 ile debug etmek için devam ettiğimiz zaman şöyle bir hata ile karşılaşırınız;

![vscode-debug-error](https://user-images.githubusercontent.com/19264860/63210460-2dd68780-c0f7-11e9-9772-834e722a5934.png)

Bu hatayı engellemek için `args` dizisine herhangi bir parametre gönderilip gönderilmediğini kontrol etmek gerekiyor. `args.Length` ile bu kontrol işlemini gerçekleştirmiş oluruz.

Mevcut kodumuzu <strong>if-else</strong> bloğuna alarak tekrardan debug etmeye başlayalım. <strong>if</strong> kontrolünde parantez içerisinde `args.Length > 0` yazdığımız zaman build yada debug esnasında array'in içerisindeki eleman sayısının 0'dan büyük olup olmadığını kontrol ediyor olacak.

![vscode-debug-update](https://user-images.githubusercontent.com/19264860/63211033-9a9f5100-c0fa-11e9-9c36-efd0a9383b81.png)

<strong>if-else</strong> bloğumuzun başına yeni bir breakpoint attıktan sonra kodumuzu tekrar debug etmeye başlayalım. Array'imizin `Length` property'si üzerinde cursor ile beklediğimiz zaman hemen üzerinde <strong>0</strong> yazdığını göreceksiniz. Burada IDE'miz bize array'in eleman sayısının <strong>0</strong> olduğunu ve if koşuluna girmeyeceğini söylüyor :) Bunun yerine genel bir mesaj vermesi için eklemiş olduğumuz <strong>else</strong> koşuluna girecek. Bu noktada isterseniz F10 ile satır satır debug ederek devam edebilir ya da F5 ile devam ederek debug işlemini bitirebilirsiniz. Debug işlemi bittiği zaman <strong>Debug Console</strong> içerisinde else koşulunda yazmış olduğumuz mesajı göreceksiniz.

![vscode-debug-console-result](https://user-images.githubusercontent.com/19264860/63424084-5374d100-c416-11e9-84dd-ea7b1ac125f9.png)
