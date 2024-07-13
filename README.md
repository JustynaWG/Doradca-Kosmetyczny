# Doradca-Kosmetyczny
Doradca-Kosmetyczny to aplikacja do analizy i rekomendacji kosmetyków spełnia aktualne potrzeby rynku kosmetycznego, gdzie personalizacja jest kluczowym trendem. Aplikacja zapewnia spersonalizowane rekomendacje kosmetyków poprzez analizę danych o typie skóry, problemach i preferencjach klientów.

Must Have – plan 
Przygotowanie projektu i baz danych  - S
    • Zadania:
        ◦ Stworzenie projektu .NET Core z architekturą N-warstwową.
        ◦ Przygotowanie bazy danych MS SQL.
        ◦ Stworzenie schematu bazy danych z tabelami dla Klienta, Kosmetyku i Rekomendacji.
        ◦ Implementacja początkowego skryptu SQL do stworzenia bazy danych.

Implementacja warstwy dostępu do danych i logiki biznesowej - M
    • Zadania:
        ◦ Implementacja repozytoriów dla Klienta, Kosmetyku i Rekomendacji przy użyciu Dapper .NET.
        ◦ Stworzenie serwisów biznesowych, które będą zarządzać operacjami na encjach.
        ◦ Dodanie metod CRUD w serwisach biznesowych.

Implementacja warstwy aplikacji/integracji - L
    • Zadania:
        ◦ Stworzenie serwisów aplikacji, które będą wykorzystywać serwisy biznesowe i repozytoria.
        ◦ Implementacja metod w serwisach aplikacji do obsługi operacji CRUD.

Implementacja API i warstwy prezentacji - L
    • Zadania:
        ◦ Implementacja kontrolerów WebAPI dla Klienta, Kosmetyku i Rekomendacji.
        ◦ Dodanie endpointów CRUD dla każdej encji.
        ◦ Stworzenie podstawowego frontendu w React, który będzie komunikował się z API.

Testowanie, poprawki i prezentacja - M
    • Zadania:
        ◦ Testowanie endpointów API przy użyciu Swaggera.
        ◦ Testowanie podstawowych funkcjonalności w frontendzie.
        ◦ Poprawa błędów i optymalizacja kodu.
        ◦ Przygotowanie do prezentacji i demonstracja funkcjonalności aplikacji.


Should Have:
    • Mechanizm autoryzacji i autentykacji użytkowników przy użyciu JWT.
    • Stworzenie podstawowego wyświetlania graficznego aplikacji na stronie przy użyciu React i CSS+HTML


