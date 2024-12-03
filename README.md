Dưới đây là phiên bản README.md được chỉnh sửa lại với tone gần gũi, dễ tiếp cận hơn:

---

# Hệ Thống Gợi Ý Sản Phẩm Mua Kèm Cho Cửa Hàng Trực Tuyến

## 1. Nhóm Thực Hiện

| **STT** | **Họ và Tên**    | **Vai trò**             | **Email**               | **Ghi chú**                              |
|---------|------------------|-------------------------|-------------------------|------------------------------------------|
| 1       | [Lê Hữu Đán] | Lập trình WebForms       | [Email thành viên 1]     | Phụ trách giao diện và chức năng trên web |
| 2       | [Bùi Quốc Công] | Lập trình WinForms       | [Email thành viên 2]     | Phát triển ứng dụng trên desktop         |
| 3       | [Hà Phú Quý] | AI và phân tích dữ liệu  | [Email thành viên 3]     | Xây dựng mô hình AI và xử lý dữ liệu     |

## 2. Giới Thiệu Dự Án
Dự án này phát triển một hệ thống gợi ý sản phẩm mua kèm cho cửa hàng trực tuyến. Mục tiêu chính là khi khách hàng thêm một sản phẩm vào giỏ hàng, hệ thống sẽ tự động gợi ý những sản phẩm liên quan hoặc thường được mua kèm. Điều này giúp khách hàng dễ dàng lựa chọn, đồng thời giúp cửa hàng tăng doanh thu.

## 3. Chức Năng Chính

### 3.1 Quản Lý Dữ Liệu Sản Phẩm
- Bạn có thể quản lý thông tin sản phẩm như tên, giá, mô tả, hình ảnh, danh mục, thương hiệu, kích thước, màu sắc, v.v.
- Tất cả thông tin này được lưu trong cơ sở dữ liệu, giúp dễ dàng tra cứu và quản lý.

### 3.2 Thu Thập Và Phân Tích Dữ Liệu Mua Sắm
- Hệ thống sẽ theo dõi lịch sử mua hàng của khách hàng, phân tích xem những sản phẩm nào thường được mua kèm với nhau.
- Dựa vào những phân tích này, hệ thống sẽ đưa ra các gợi ý phù hợp cho khách hàng.

### 3.3 Gợi Ý Sản Phẩm
- Khi khách hàng thêm sản phẩm vào giỏ, hệ thống sẽ gợi ý những sản phẩm có liên quan để khách hàng cân nhắc mua thêm.
- Gợi ý cũng sẽ xuất hiện trên trang chi tiết sản phẩm và trong quá trình thanh toán.

### 3.4 Quản Lý Thông Tin Khách Hàng
- Hệ thống lưu trữ thông tin cá nhân của khách hàng như tên, email, lịch sử mua sắm, sở thích.
- Những gợi ý sẽ được cá nhân hóa dựa trên hành vi mua sắm của từng khách hàng.

### 3.5 Báo Cáo Và Phân Tích
- Cung cấp báo cáo về các sản phẩm đã được mua thông qua gợi ý để theo dõi hiệu quả của hệ thống.
- Hệ thống còn phân tích xu hướng mua sắm để liên tục cải tiến thuật toán và tăng hiệu quả gợi ý.

## 4. Chia Chức Năng Giữa WebForms và WinForms

### WebForms:
- **Hiển thị sản phẩm và gợi ý mua kèm**: Đây là nơi khách hàng sẽ thấy các gợi ý sản phẩm khi duyệt web và thực hiện mua sắm.
- **Quản lý giỏ hàng**: Khách hàng có thể thêm sản phẩm vào giỏ và hệ thống sẽ ngay lập tức gợi ý những sản phẩm liên quan.
- **Quản lý thông tin khách hàng và lịch sử giao dịch**: Bảo mật thông tin khách hàng và lưu trữ lịch sử giao dịch thông qua trình duyệt.
- **Báo cáo và phân tích trực tuyến**: Hệ thống quản trị có thể theo dõi hiệu quả của gợi ý và xu hướng mua hàng từ xa.

### WinForms:
- **Quản lý và phân tích dữ liệu nội bộ**: Nhân viên quản lý có thể xử lý dữ liệu sản phẩm, khách hàng và lịch sử mua hàng một cách dễ dàng trên máy tính.
- **Phát triển và thử nghiệm AI**: Sử dụng WinForms để thử nghiệm các thuật toán AI trước khi triển khai chính thức.
- **Báo cáo chi tiết nội bộ**: Cung cấp các báo cáo phân tích hiệu quả hệ thống, phục vụ công tác quản lý.

## 5. Chức Năng AI
- **Collaborative Filtering**: Sử dụng dữ liệu từ những khách hàng khác để đưa ra gợi ý về những sản phẩm thường được mua cùng nhau.
- **Association Rules (Apriori, FP-Growth)**: Phân tích các giao dịch mua hàng để tìm ra các mẫu liên kết giữa các sản phẩm.
- **Deep Learning**: Áp dụng học sâu để xử lý các trường hợp phức tạp hơn, giúp đưa ra gợi ý chính xác hơn dựa trên nhiều yếu tố.

## 6. Công Nghệ Sử Dụng
- **Ngôn ngữ lập trình**: C# (cho WinForms) và ASP.NET (cho WebForms).
- **Cơ sở dữ liệu**: SQL Server hoặc MySQL để lưu trữ thông tin sản phẩm và khách hàng.
- **Thư viện AI**: ML.NET hoặc TensorFlow.NET để xây dựng các mô hình AI.
- **API tích hợp**: Có thể tích hợp với các sàn thương mại điện tử lớn như Tiki, Shopee, Lazada để lấy dữ liệu sản phẩm.

## 7. Hướng Dẫn Cài Đặt

### Yêu Cầu Hệ Thống:
- .NET Framework 4.7 trở lên
- SQL Server hoặc MySQL
- ML.NET hoặc TensorFlow.NET

### Các Bước Cài Đặt:
1. **Clone dự án về máy:**
   ```bash
   git clone https://github.com/yourusername/recommendation-system.git
   ```
2. **Cấu hình cơ sở dữ liệu:**
   - Mở file `appsettings.json` và điền thông tin kết nối với cơ sở dữ liệu của bạn.
3. **Chạy dự án:**
   - Mở dự án trong Visual Studio, nhấn `Run` và hệ thống sẽ hoạt động.

## 8. Link Tham Khảo
- [Tiki.vn](https://tiki.vn)
- [Shopee.vn](https://shopee.vn)
- [Lazada.vn](https://lazada.vn)

---


