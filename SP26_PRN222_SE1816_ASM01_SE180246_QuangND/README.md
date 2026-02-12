# ?? Franchise Management System

## ??? Ki?n trúc d? án

D? án s? d?ng ki?n trúc **N-Tier/Layered Architecture** v?i 4 project:

| Layer | Project | Mô t? |
|-------|---------|-------|
| **Presentation** | `FManagement.MVCWebApp.QuangND` | ASP.NET Core MVC Web App (.NET 8) |
| **Business Logic** | `FManagement.Services.QuangND` | Service layer ch?a business logic |
| **Data Access** | `FManagement.Repositories.QuangND` | Repository pattern v?i Generic Repository |
| **Domain/Entities** | `FManagement.Entities.QuangND` | Entity models + DbContext (EF Core 9) |

---

## ??? Database - Các Entity chính

H? th?ng qu?n lý **Franchise (Nh??ng quy?n)** bao g?m:

### Qu?n lý c?a hàng & b?p trung tâm
- **`FranchiseStore`** - C?a hàng nh??ng quy?n
- **`CentralKitchen`** - B?p trung tâm

### Qu?n lý s?n ph?m
- **`Product`** - S?n ph?m
- **`ProductType`** - Lo?i s?n ph?m
- **`ProductBatch`** - Lô s?n ph?m

### Qu?n lý ??n hàng
- **`StoreOrder`** - ??n hàng c?a c?a hàng
- **`StoreOrderItemQuangNd`** - Chi ti?t ??n hàng

### Qu?n lý s?n xu?t
- **`ProductionPlanQuangNd`** - K? ho?ch s?n xu?t

### Qu?n lý kho
- **`Inventory`** - Kho hàng
- **`InventoryTransaction`** - Giao d?ch kho
- **`InventoryType`** - Lo?i kho

### Qu?n lý nguyên li?u & công th?c
- **`Ingredient`** - Nguyên li?u
- **`Recipe`** - Công th?c
- **`RecipeItem`** - Chi ti?t công th?c
- **`Supplier`** - Nhà cung c?p

### Qu?n lý giao hàng
- **`DeliverySchedule`** - L?ch giao hàng
- **`DeliveryIssue`** - S? c? giao hàng

### Khác
- **`Feedback`** - Ph?n h?i
- **`SystemUserAccount`** - Tài kho?n ng??i dùng

---

## ?? Authentication

- S? d?ng **Cookie Authentication**
- Các trang: Login, Forbidden
- Session timeout: **5 phút**

---

## ?? Services ?ã tri?n khai

| Service | Interface | Mô t? |
|---------|-----------|-------|
| `ProductPlanQuangNDService` | `IProductPlanQuangNDService` | Qu?n lý k? ho?ch s?n xu?t |
| `SystemAccountService` | - | Qu?n lý tài kho?n |
| `StoreOrderItemQuangNDService` | - | Qu?n lý item ??n hàng |

---

## ?? Controllers & Ch?c n?ng

| Controller | Ch?c n?ng |
|------------|-----------|
| `HomeController` | Trang ch?, Privacy |
| `AccountController` | ??ng nh?p, ??ng xu?t, Forbidden |
| `ProductionPlanQuangNdsController` | CRUD k? ho?ch s?n xu?t (Index, Create, Edit, Details, Delete) |

---

## ??? Công ngh? s? d?ng

| Công ngh? | Version |
|-----------|---------|
| .NET | 8.0 |
| Entity Framework Core | 9.0.6 |
| SQL Server | - |
| ASP.NET Core MVC | - |
| Bootstrap | - |

---

## ?? C?u trúc th? m?c

```
SP26_PRN222_SE1816_ASM01_SE180246_QuangND/
??? FManagement.MVCWebApp.QuangND/          # Web Application
?   ??? Controllers/
?   ??? Models/
?   ??? Views/
?   ??? wwwroot/
??? FManagement.Services.QuangND/           # Business Logic Layer
??? FManagement.Repositories.QuangND/       # Data Access Layer
?   ??? Base/
?   ??? DBContext/
??? FManagement.Entities.QuangND/           # Domain Layer
    ??? Entities/
```

---

## ?? H??ng d?n ch?y d? án

1. **C?u hình Connection String** trong `appsettings.json`
2. **Restore packages**: `dotnet restore`
3. **Ch?y ?ng d?ng**: `dotnet run --project FManagement.MVCWebApp.QuangND`

---

## ?? Thông tin

- **Tác gi?**: QuangND (SE180246)
- **Branch**: `AuthenticateFunciton`
- **Repository**: [FranchiseManagement](https://github.com/DangQuangSE/FranchiseManagement)
