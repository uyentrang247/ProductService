# ProductService – BTH3 SOA

# 1. Giới thiệu
ProductService là REST API quản lý sản phẩm được xây dựng bằng ASP.NET Core Web API trong bài thực hành Service-Oriented Architecture (SOA).

# 2. Công nghệ sử dụng
- C# và ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite
- JWT Bearer Authentication
- Swagger / OpenAPI

# 3. Chức năng
- Lấy danh sách sản phẩm.
- Lấy thông tin sản phẩm theo ID.
- Thêm sản phẩm mới.
- Cập nhật thông tin sản phẩm.
- Xóa sản phẩm.
- Xác thực JWT khi truy cập các API sản phẩm.

# 4. Các API

| Method | Endpoint | Chức năng |
|---|---|---|
| GET | '/products' | Lấy danh sách sản phẩm |
| GET | '/products/{id}' | Lấy sản phẩm theo ID |
| POST | '/products' | Thêm sản phẩm |
| PUT | '/products/{id}' | Cập nhật sản phẩm |
| DELETE | '/products/{id}' | Xóa sản phẩm |

# 5. Cách chạy
1. Mở project 'ProductService.csproj' bằng Visual Studio.
2. Khôi phục các NuGet packages.
3. Chạy project bằng profile HTTP đã cấu hình.
4. Truy cập 'http://localhost:5145/swagger' để thử nghiệm API.

# 6. Database
Ứng dụng sử dụng SQLite. Database được tạo tự động khi khởi chạy ứng dụng nếu chưa tồn tại.
