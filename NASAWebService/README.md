# NASA WebAPI Service

## Opis projektu

Projekt **NASA WebAPI Service** to aplikacja, która udostępnia dane z różnych zasobów NASA, takich jak satelity (TLE), zdjęcie dnia (APOD) oraz dane z **Open Science Data Repository** (OSDR). Serwis WebAPI składa się z kilku kontrolerów, które odpowiadają za pobieranie i udostępnianie danych z NASA APIs. Komunikacja z serwisem NASA odbywa się poprzez odpowiednie API, a dostęp do serwisu jest chroniony za pomocą tokenów.

## Struktura projektu

### 1. Kontroler /api/satellite

Kontroler ten jest odpowiedzialny za interakcję z zasobami związanymi z satelitami:
- **GET /api/satellite** - zwraca listę dostępnych satelit.
- **GET /api/satellite/{name}** - zwraca dane dla wybranego satelity (na podstawie nazwy).
- **Private Method** - sprawdza, czy w nagłówku żądania znajduje się odpowiedni Client-Token.

### 2. Kontroler /api/apod

Kontroler ten udostępnia dane dotyczące zdjęcia dnia:
- **GET /api/apod** - zwraca dane zdjęcia dnia, w tym URL do zdjęcia.

### 3. Kontroler /api/osdr

Kontroler ten pozwala na dostęp do danych związanych z pojazdami i misjami:
- **GET /api/osdr/vehicles** - pobiera listę dostępnych pojazdów.
- **GET /api/osdr/vehicle/{url}** - pobiera szczegóły dla wybranego pojazdu, wskazując jego URL.
- **GET /api/osdr/mission/{url}** - pobiera szczegóły misji na podstawie URL.

### 4. Kontroler /api/system

Kontroler ten dostarcza informacje o stanie systemu WebAPI:
- **GET /api/system/status** - sprawdza, czy serwis WebAPI działa oraz czy serwis NASA APIs jest dostępny.
- **GET /api/system/version** - zwraca wersję systemu WebAPI, dane o autorach projektu oraz datę ostatnich modyfikacji.

## Wymagania

- .NET Core 3.1 / .NET 5+
- Dostęp do internetu w celu komunikacji z API NASA
- Klucz API NASA (token autoryzacyjny) należy ustawić w pliku `appsettings.json`. Domyślnie ustawiony jest na wartość 'token'
