# Kalkulator walut

Prosta aplikacja do przeliczania walut na podstawie aktualnych kursów publikowanych przez Narodowy Bank Polski (NBP).

Projekt został wykonany w technologii **.NET MAUI** i jest aplikacją wieloplatformową.

## Opis projektu

Aplikacja pobiera kursy walut z tabeli A NBP w formacie XML i wykorzystuje je do przeliczania podanej kwoty.

Użytkownik:

1. wpisuje kwotę,
2. wybiera walutę, z której chce przeliczyć wartość,
3. wybiera walutę docelową,
4. otrzymuje przeliczoną kwotę.

Kursy są pobierane z NBP przy uruchomieniu aplikacji, dlatego do działania programu wymagane jest połączenie z internetem.

## Funkcje

### Kalkulator walut

Główna funkcja aplikacji pozwala na przeliczanie wartości pomiędzy walutami dostępnymi w tabeli A NBP.

Przykład:

**100 EUR = 114,58 USD**

Wynik należy traktować jako orientacyjny, ponieważ zależy od kursów opublikowanych przez NBP.

### O programie

Przycisk **„O programie”** otwiera ekran zawierający:

* imię i nazwisko autora,
* datę utworzenia,
* nazwę uniwersytetu,
* nazwę przedmiotu.

### Pomoc

Przycisk **„Pomoc”** otwiera instrukcję obsługi programu przedstawioną w 4 punktach.

## Screenshoty

W folderze `screenshoty` znajdują się 3 zrzuty ekranu przedstawiające działanie aplikacji.

## Technologie

* **Framework:** .NET MAUI
* **Typ projektu:** aplikacja wieloplatformowa
* **Język:** C#
* **Interfejs:** XAML
* **.NET:** 8
* **Źródło danych:** NBP, tabela A
* **Format danych:** XML

### Obsługiwane platformy

Projekt wykorzystuje:

* `net8.0-android`
* `net8.0-ios`
* `net8.0-maccatalyst`
* `net8.0-windows10.0.19041.0` — warunkowo

### Pakiety NuGet

* `Microsoft.Maui.Controls`
* `Microsoft.Maui.Controls.Compatibility`
* `Microsoft.Extensions.Logging.Debug 8.0.1`

## Źródło kursów walut

Kursy pobierane są z oficjalnego pliku XML Narodowego Banku Polskiego:

https://static.nbp.pl/dane/kursy/xml/LastA.xml

Aplikacja korzysta z **tabeli A NBP**.

Nie jest potrzebny żaden klucz API ani rejestracja.

Aplikacja pobiera kursy przy uruchomieniu i wykorzystuje je podczas działania programu.

Adres źródła jest zapisany w pliku `DaneKonfiguracyjne.cs`. Jego zmiana nie jest potrzebna podczas normalnego korzystania z programu. Może być konieczna w przypadku zmiany adresu źródła przez NBP.

## Wymagania

Do uruchomienia projektu potrzebne są:

* Windows 10 lub Windows 11,
* Visual Studio 2022,
* workload **.NET Multi-platform App UI development**,
* .NET 8 SDK,
* dostęp do internetu.

## Instalacja i uruchomienie

### 1. Pobranie projektu

Sklonuj repozytorium albo pobierz projekt jako ZIP i rozpakuj go na komputerze.

### 2. Otwarcie projektu

Otwórz plik:

```text
KalkulatorOld80.sln
```

w programie Visual Studio 2022.

### 3. Przywrócenie pakietów

Po otwarciu rozwiązania Visual Studio powinno automatycznie przywrócić wymagane pakiety NuGet.

### 4. Zbudowanie projektu

Wybierz:

**Build → Rebuild Solution**

### 5. Wybór platformy

Z listy znajdującej się obok przycisku uruchamiania wybierz na przykład:

**Windows Machine**

### 6. Uruchomienie

Uruchom aplikację klawiszem **F5** albo zielonym przyciskiem **Start**.

## Format wpisywania kwoty

Kwotę należy wpisywać z **przecinkiem jako separatorem dziesiętnym**.

Przykład:

```text
100,50
```

Kropka jako separator dziesiętny nie jest obsługiwana.

## Struktura projektu

```text
/Platforms
```

Kod specyficzny dla poszczególnych platform.

```text
/Resources
```

Obrazki, czcionki i style.

```text
MainPage.xaml
```

Główny ekran kalkulatora.

```text
MainPage.xaml.cs
```

Logika głównego ekranu aplikacji.

```text
AppShell.xaml
```

Konfiguracja startowego ekranu i nawigacji.

```text
DaneKonfiguracyjne.cs
```

Adres URL źródła danych NBP.

```text
PomocPage.xaml
```

Ekran pomocy.

```text
OProgramiePage.xaml
```

Ekran „O programie”.

```text
PozycjaTabeliA.cs
```

Model danych dla pozycji w tabeli A NBP.

```text
MauiProgram.cs
```

Punkt startowy konfiguracji aplikacji MAUI.

## Ograniczenia

* Do pobrania kursów wymagane jest połączenie z internetem.
* Przy braku połączenia pojawia się komunikat: **„Nie można pobrać danych z NBP”**.
* Program obsługuje tylko waluty znajdujące się w tabeli A NBP.
* Pozostałe waluty świata nie są dostępne.
* Aplikacja zakłada określony format pliku XML publikowanego przez NBP. Zmiana jego struktury może spowodować problemy z odczytem danych.
* Kursy są pobierane tylko przy starcie aplikacji i nie są automatycznie odświeżane podczas jej działania.
* Kwotę należy wpisywać z przecinkiem jako separatorem dziesiętnym.

## Autor

**Mateusz Boniewicz**

## Licencja

Projekt nie posiada określonej licencji.
