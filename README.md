# 🚗 MyAcademy Car Rental Platform — Onion Architecture

Modern, ölçeklenebilir ve sürdürülebilir bir mimari yaklaşımıyla geliştirilen **MyAcademy Car Rental Platform**, uçtan uca bir araç kiralama çözümüdür.
Proje; **Onion Architecture**, **CQRS**, **JWT Authentication**, **SignalR**, **RabbitMQ** ve **AI entegrasyonları** gibi güncel teknolojileri bir araya getirerek gerçek dünya seviyesinde bir backend & full-stack deneyimi sunar.

---

# ✨ Proje Özeti

Bu çözüm;

* Kurumsal seviyede katmanlı mimari,
* Güçlü authentication & authorization altyapısı,
* Gerçek zamanlı veri akışı,
* Mesaj kuyruğu mimarisi,
* AI destekli servis entegrasyonları,
* Modern ASP.NET Core geliştirme pratikleri

üzerine inşa edilmiştir.

Hem **Admin Paneli** hem de **Vitrin/Kullanıcı Arayüzü** içeren proje, API-first yaklaşımıyla geliştirilmiştir.

---

# 🧩 Kullanılan Teknolojiler

## Backend

* ASP.NET Core Web API
* Entity Framework Core
* ASP.NET Core Identity
* JWT Bearer Authentication
* SignalR
* RabbitMQ
* OpenTelemetry
* CQRS Pattern
* Repository Pattern
* Unit Of Work
* FluentValidation
* AutoMapper

## Frontend

* ASP.NET Core MVC
* Razor View Engine
* Bootstrap
* JavaScript / jQuery
* SignalR Client

## Database

* SQL Server

## AI & Integrations

* ML.NET
* External AI Completion Services
* RabbitMQ Event Publishing

---

# 🏗️ Onion Architecture Yapısı

Proje tamamen bağımlılıkların merkeze aktığı **Onion Architecture** prensibine göre tasarlanmıştır.

```txt
Presentation
 ├── OnionApp.API
 └── OnionApp.WebUI

Infrastructure
 ├── OnionApp.Persistence
 └── OnionApp.Infrastructure

Core
 ├── OnionApp.Domain
 └── OnionApp.Application
```

---

# 📂 Katmanlar

## Core/OnionApp.Domain

Domain katmanı yalnızca iş modellerini içerir.

### İçerikler

* Entity modelleri
* Enum tanımları
* Domain kuralları
* Saf business object’ler

Bu katman hiçbir dış bağımlılık içermez.

---

## Core/OnionApp.Application

Uygulamanın iş kuralları burada yönetilir.

### İçerikler

* CQRS Commands & Queries
* Handlers
* DTO yapıları
* Validators
* Service abstractions
* Repository abstractions
* Behaviors / pipeline işlemleri

---

## Infrastructure/OnionApp.Persistence

Veri erişim katmanıdır.

### İçerikler

* EF Core DbContext
* Repository implementasyonları
* Unit Of Work
* Migrations
* Seed işlemleri
* SQL Server bağlantıları

---

## Infrastructure/OnionApp.Infrastructure

Harici servis entegrasyonları burada bulunur.

### İçerikler

* AI servis adaptörleri
* RabbitMQ publisher
* External provider servisleri
* Infrastructure configuration

---

## Presentation/OnionApp.API

Sistemin merkezi REST API katmanıdır.

### Özellikler

* JWT Authentication
* Role-based Authorization
* SignalR Hubs
* OpenTelemetry tracing
* OpenAPI / Scalar docs
* Global exception handling
* Middleware pipeline

---

## Presentation/OnionApp.WebUI

MVC tabanlı kullanıcı ve admin arayüzüdür.

### Özellikler

* Cookie Authentication
* API tüketimi için HttpClient
* Admin Dashboard
* Reservation işlemleri
* Araç listeleme
* Gerçek zamanlı SignalR güncellemeleri

---

# 🔐 Authentication & Authorization

Platform JWT tabanlı authentication sistemi kullanır.

## Güvenlik Kontrolleri

Uygulama başlangıcında:

* `Jwt:Issuer` zorunludur
* `Jwt:Audience` zorunludur
* `Jwt:Key` zorunludur
* Secret key minimum 32 karakter olmalıdır
* Zayıf/placeholder secret değerleri reddedilir
* Production ortamında `guest/guest` RabbitMQ bilgileri engellenir
* `Cors:AllowedOrigins` boş bırakılamaz
* AI provider tanımlandıysa API key zorunlu hale gelir

---

# ⚡ Gerçek Zamanlı Özellikler

SignalR üzerinden gerçek zamanlı veri akışı sağlanır.

## Hub Endpointleri

```txt
/carhub
/reservationhub
```

### Kullanım Senaryoları

* Canlı araç sayısı
* Anlık rezervasyon güncellemeleri
* Dashboard istatistikleri
* Bildirim altyapısı

SignalR bağlantılarında JWT token query string üzerinden alınır:

```txt
access_token=YOUR_JWT_TOKEN
```

---

# 📨 RabbitMQ Event Sistemi

Sistem event-driven mimariye uygun şekilde RabbitMQ desteği içerir.

### Kullanım Alanları

* Rezervasyon eventleri
* Notification işlemleri
* Async process yönetimi
* Integration event publishing

---

# 🤖 AI Entegrasyonu

Platform AI servisleriyle entegre çalışabilecek şekilde tasarlanmıştır.

### Örnek Senaryolar

* Akıllı araç önerileri
* Kullanıcı davranışı analizi
* Chat/completion işlemleri
* AI destekli rezervasyon akışları

---

# 📊 OpenTelemetry Desteği

Sistem observability odaklı geliştirilmiştir.

### Sağlanan Özellikler

* Distributed tracing
* Request telemetry
* Error monitoring
* Performance metrics
* OTLP exporter desteği

---

# 📌 Öne Çıkan Mimari Yaklaşımlar

* Onion Architecture
* CQRS Pattern
* Repository Pattern
* Unit Of Work
* SOLID Principles
* Dependency Injection
* Clean Code
* Separation of Concerns

---

# 📷 Proje Modülleri

## Kullanıcı Tarafı

* Araç listeleme
* Rezervasyon oluşturma
* Blog & içerik alanları
* AI destekli öneriler

## Admin Paneli

* Dashboard
* Araç yönetimi
* Rezervasyon yönetimi
* İstatistik ekranları
* Gerçek zamanlı veriler

---

# 🎯 Projenin Amacı

Bu proje;

* Modern .NET mimarilerini uygulamak,
* Kurumsal backend yaklaşımını göstermek,
* Gerçek dünya seviyesinde bir örnek oluşturmak,
* Sürdürülebilir yazılım geliştirme prensiplerini uygulamak

amacıyla geliştirilmiştir.

---

# 👨‍💻 Developer

Developed with ASP.NET Core & Onion Architecture.
