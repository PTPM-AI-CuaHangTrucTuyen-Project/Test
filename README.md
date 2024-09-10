# Hệ Thống Gợi Ý Sản Phẩm Mua Kèm Cho Cửa Hàng Trực Tuyến

## 1. Giới Thiệu
Dự án này nhằm phát triển một hệ thống giúp cửa hàng trực tuyến tự động gợi ý các sản phẩm có liên quan hoặc thường được mua kèm với sản phẩm mà khách hàng chọn. Điều này không chỉ giúp tăng giá trị đơn hàng mà còn nâng cao trải nghiệm mua sắm của khách hàng, giúp họ dễ dàng tìm thấy những gì họ có thể cần thêm.

## 2. Chức Năng Chính
### 2.1 Quản Lý Dữ Liệu Sản Phẩm
- Hệ thống sẽ cho phép bạn quản lý toàn bộ dữ liệu sản phẩm như tên, giá, mô tả, hình ảnh, và các thông tin như thương hiệu, kích thước, màu sắc, v.v.
- Tất cả các thông tin này sẽ được lưu trữ trong cơ sở dữ liệu để dễ dàng truy xuất và quản lý.

### 2.2 Thu Thập Và Phân Tích Dữ Liệu Mua Sắm
- Hệ thống sẽ tự động thu thập lịch sử mua sắm của khách hàng và phân tích dữ liệu để tìm ra các sản phẩm thường được mua kèm.
- Qua đó, nó sẽ hiểu được mối liên hệ giữa các sản phẩm và đưa ra gợi ý thông minh.

### 2.3 Gợi Ý Sản Phẩm
- Khi khách hàng thêm sản phẩm vào giỏ, hệ thống sẽ đưa ra các sản phẩm có thể mua kèm, giúp khách hàng dễ dàng lựa chọn hơn.
- Ngoài ra, trên trang chi tiết sản phẩm và trong quá trình thanh toán, các gợi ý này cũng sẽ xuất hiện để tăng khả năng khách hàng mua thêm.

### 2.4 Quản Lý Thông Tin Khách Hàng
- Lưu trữ và quản lý thông tin cá nhân của khách hàng như tên, email, lịch sử mua sắm.
- Dựa trên hành vi mua sắm trước đây của khách hàng, hệ thống sẽ cá nhân hóa gợi ý, làm cho chúng chính xác và hữu ích hơn.

### 2.5 Báo Cáo Và Phân Tích
- Hệ thống sẽ cung cấp báo cáo về số lượng sản phẩm được bán qua các gợi ý, giúp bạn theo dõi hiệu quả của chức năng này.
- Phân tích xu hướng mua sắm để tối ưu hóa thuật toán và cải thiện hệ thống gợi ý.

## 3. Phân Chia Chức Năng Giữa WebForms và WinForms
### WebForms:
- **Hiển thị sản phẩm và gợi ý mua kèm** trên trang web cửa hàng, cho phép khách hàng xem và chọn các sản phẩm liên quan ngay khi duyệt trang.
- **Quản lý giỏ hàng**: Cho phép khách hàng thêm sản phẩm vào giỏ và nhận gợi ý mua kèm ngay khi họ tiếp tục quá trình thanh toán.
- **Quản lý thông tin khách hàng và giao dịch**: Tạo môi trường an toàn cho việc lưu trữ và truy cập thông tin khách hàng thông qua trình duyệt.
- **Báo cáo và phân tích trực tuyến**: Giúp quản trị viên dễ dàng theo dõi hiệu suất hệ thống thông qua giao diện web, từ bất kỳ đâu.

### WinForms:
- **Quản lý dữ liệu nội bộ**: Cho phép quản lý dữ liệu sản phẩm, khách hàng và đơn hàng một cách nhanh chóng, không cần kết nối mạng.
- **Phân tích và cải thiện thuật toán AI**: WinForms là nơi thử nghiệm các mô hình AI trước khi triển khai trên hệ thống web, giúp tối ưu các gợi ý sản phẩm.
- **Báo cáo nội bộ**: Cung cấp báo cáo chi tiết về doanh số và xu hướng mua sắm, hỗ trợ nhân viên quản lý dữ liệu cục bộ hiệu quả.

## 4. Chức Năng AI
- **Collaborative Filtering**: Sử dụng hành vi của khách hàng để gợi ý sản phẩm tương tự mà các khách hàng khác đã mua.
- **Association Rules (Apriori, FP-Growth)**: Phân tích các mẫu giao dịch để tìm ra mối liên kết giữa các sản phẩm, từ đó đưa ra gợi ý mua kèm hợp lý.
- **Deep Learning**: Áp dụng mô hình học sâu để phân tích hành vi phức tạp và dự đoán chính xác hơn những gì khách hàng có thể quan tâm.

## 5. Công Nghệ Sử Dụng
- **Ngôn ngữ lập trình**: C# (WinForms), ASP.NET (WebForms).
- **Cơ sở dữ liệu**: SQL Server hoặc MySQL để lưu trữ thông tin sản phẩm và khách hàng.
- **Thư viện AI**: Sử dụng ML.NET hoặc TensorFlow.NET để tích hợp các mô hình AI vào hệ thống.
- **API tích hợp**: Lấy dữ liệu sản phẩm từ các sàn thương mại điện tử lớn như Tiki, Shopee, Lazada.

## 6. Hướng Dẫn Cài Đặt
### Yêu Cầu Hệ Thống:
- .NET Framework 4.7 hoặc mới hơn
- SQL Server/MySQL
- ML.NET hoặc TensorFlow.NET

### Các Bước Cài Đặt:
1. **Clone dự án về máy:**
   ```bash
   git clone https://github.com/yourusername/recommendation-system.git
   ```
2. **Cấu hình cơ sở dữ liệu:**
   - Mở file `appsettings.json` và cập nhật thông tin kết nối cơ sở dữ liệu.
3. **Chạy dự án:**
   - Sử dụng Visual Studio, mở giải pháp và nhấn `Run` để khởi động ứng dụng.

## 7. Link Tham Khảo
- [Tiki.vn](https://tiki.vn)
- [Shopee.vn](https://shopee.vn)
- [Lazada.vn](https://lazada.vn)

## 8. Tác Giả
- **Tên**: [Tên của bạn]
- **Email**: [Email của bạn]
- **Ngày tạo**: [Ngày bắt đầu dự án] 

File README.md này sẽ cung cấp cho bạn cái nhìn tổng quan về hệ thống gợi ý sản phẩm mua kèm, từ cách cài đặt cho đến các chức năng chính và công nghệ được sử dụng trong dự án.
