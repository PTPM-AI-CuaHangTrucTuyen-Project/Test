# Hệ Thống Gợi Ý Sản Phẩm Mua Kèm Cho Cửa Hàng Trực Tuyến

# 1. Giới Thiệu
Dự án này phát triển một hệ thống gợi ý sản phẩm mua kèm dành cho cửa hàng trực tuyến. Mục tiêu chính là cung cấp gợi ý sản phẩm liên quan hoặc thường được mua kèm khi khách hàng thêm một sản phẩm vào giỏ hàng, giúp tăng giá trị đơn hàng và nâng cao trải nghiệm mua sắm của khách hàng.

# 2. Chức Năng Chính
## 2.1 Quản Lý Dữ Liệu Sản Phẩm
- Cho phép quản lý thông tin sản phẩm bao gồm: tên, giá, mô tả, hình ảnh, danh mục sản phẩm, thương hiệu, kích thước, màu sắc, v.v.
- Dữ liệu sản phẩm được lưu trữ và quản lý trong cơ sở dữ liệu.

## 2.2 Thu Thập Và Phân Tích Dữ Liệu Mua Sắm
- Thu thập lịch sử mua hàng của khách hàng và phân tích các sản phẩm thường được mua cùng nhau.
- Xác định mối quan hệ giữa các sản phẩm để tạo ra các gợi ý phù hợp.

## 2.3 Chức Năng Gợi Ý Sản Phẩm
- Gợi ý sản phẩm mua kèm khi khách hàng thêm sản phẩm vào giỏ hàng.
- Hiển thị gợi ý sản phẩm liên quan trên trang chi tiết sản phẩm và trong quá trình thanh toán.

## 2.4 Quản Lý Thông Tin Khách Hàng
- Lưu trữ thông tin khách hàng bao gồm: tên, email, lịch sử mua sắm, và các sản phẩm ưa thích.
- Phân loại khách hàng dựa trên hành vi mua sắm để cá nhân hóa gợi ý sản phẩm.

## 2.5 Báo Cáo Và Phân Tích
- Báo cáo số lượng sản phẩm được mua thông qua gợi ý.
- Phân tích xu hướng mua sắm để cải thiện thuật toán gợi ý và tối ưu hóa doanh thu.

Trong hệ thống gợi ý sản phẩm mua kèm, việc sử dụng **WebForms** và **WinForms** sẽ có những chức năng khác nhau dựa trên môi trường triển khai và trải nghiệm người dùng mà bạn muốn cung cấp. Dưới đây là phân chia chức năng giữa WebForms và WinForms:

### **1. Chức năng của WebForms:**
WebForms được sử dụng cho các ứng dụng web, có thể truy cập từ bất kỳ thiết bị nào có trình duyệt. Do đó, WebForms sẽ chịu trách nhiệm xử lý các chức năng liên quan đến giao diện web và tương tác trực tuyến.

#### **Chức năng cụ thể:**
- **Hiển thị sản phẩm và gợi ý mua kèm:**
  - WebForms sẽ chịu trách nhiệm hiển thị danh sách sản phẩm và các gợi ý sản phẩm mua kèm cho người dùng khi họ truy cập trang web.
- **Quản lý giỏ hàng:**
  - Người dùng có thể thêm sản phẩm vào giỏ hàng, xem gợi ý mua kèm, và chọn các sản phẩm được đề xuất trong quá trình thanh toán.
- **Quản lý thông tin khách hàng và lịch sử giao dịch:**
  - Lưu trữ và quản lý thông tin của khách hàng, bao gồm lịch sử mua hàng để cá nhân hóa gợi ý sản phẩm.
- **Phân tích và báo cáo trên giao diện web:**
  - Quản trị viên có thể xem các báo cáo liên quan đến hiệu suất gợi ý sản phẩm, doanh thu, và các xu hướng mua sắm qua một dashboard trực tuyến.
- **Giao diện quản lý sản phẩm và khách hàng:**
  - WebForms cũng có thể được dùng cho trang quản trị, cho phép quản lý sản phẩm, danh mục sản phẩm, và khách hàng từ bất kỳ trình duyệt nào.

#### **Ưu điểm của WebForms:**
- Khả năng truy cập từ nhiều thiết bị.
- Không yêu cầu cài đặt trên máy người dùng, chỉ cần trình duyệt.
- Thích hợp cho các hệ thống thương mại điện tử trực tuyến.

---

### **2. Chức năng của WinForms:**
WinForms thường được sử dụng cho các ứng dụng desktop, chạy trực tiếp trên hệ điều hành Windows. WinForms sẽ phù hợp hơn cho các tác vụ nội bộ hoặc quản lý hệ thống tại chỗ, nơi hiệu suất và tính tương tác của ứng dụng là rất quan trọng.

#### **Chức năng cụ thể:**
- **Quản lý và phân tích dữ liệu nội bộ:**
  - WinForms có thể được sử dụng cho các tác vụ quản lý dữ liệu nội bộ, ví dụ như xử lý và phân tích dữ liệu mua sắm và sản phẩm để hỗ trợ gợi ý sản phẩm mua kèm.
- **Quản lý sản phẩm và khách hàng nội bộ:**
  - WinForms cho phép nhân viên hoặc quản trị viên quản lý sản phẩm và thông tin khách hàng tại chỗ mà không cần phải truy cập qua web.
- **Phân tích và cải thiện thuật toán AI:**
  - WinForms có thể được sử dụng để phát triển và thử nghiệm các mô hình AI như collaborative filtering, apriori trực tiếp trên máy tính cá nhân trước khi triển khai lên hệ thống web.
- **Ứng dụng cục bộ cho quản lý kho hàng:**
  - Nếu có nhu cầu quản lý kho hàng, WinForms có thể được sử dụng cho ứng dụng cục bộ để theo dõi tồn kho và đề xuất gợi ý mua hàng cho cửa hàng trực tiếp.
- **Báo cáo và phân tích nội bộ:**
  - Các báo cáo chi tiết về hiệu suất gợi ý sản phẩm, phân tích xu hướng mua sắm có thể được cung cấp dưới dạng các báo cáo nội bộ trên ứng dụng WinForms.

#### **Ưu điểm của WinForms:**
- Hiệu suất cao, phản hồi nhanh do không cần kết nối mạng.
- Dễ dàng phát triển các ứng dụng nội bộ hoặc quản lý dữ liệu cục bộ.
- Tính tương tác và độ tùy biến cao.

### **Tóm tắt:**
- **WebForms:** Phù hợp với các chức năng liên quan đến giao diện người dùng trên web, bao gồm việc hiển thị sản phẩm, gợi ý mua kèm, quản lý giỏ hàng và phân tích trực tuyến.
- **WinForms:** Thích hợp cho các ứng dụng nội bộ trên máy tính, nơi yêu cầu quản lý dữ liệu cục bộ, phân tích thuật toán AI, và các tác vụ quản trị offline.

Việc phân chia chức năng giữa WebForms và WinForms sẽ giúp tận dụng tốt nhất đặc thù của từng nền tảng để phát triển hệ thống gợi ý sản phẩm hiệu quả.

# 3. Chức Năng AI
- **Collaborative Filtering:** Dùng để gợi ý sản phẩm dựa trên hành vi mua sắm của những người dùng khác.
- **Association Rules (Apriori, FP-Growth):** Phân tích các quy tắc liên kết giữa các sản phẩm dựa trên lịch sử giao dịch để tìm sản phẩm thường được mua cùng nhau.
- **Deep Learning:** Sử dụng mô hình học sâu để cải thiện khả năng dự đoán và gợi ý các sản phẩm phù hợp hơn.

# 4. Công Nghệ Sử Dụng
- **Ngôn ngữ lập trình:** C# (cho WinForms) hoặc ASP.NET (cho WebForms).
- **Cơ sở dữ liệu:** SQL Server hoặc MySQL.
- **Thư viện AI:** ML.NET hoặc TensorFlow.NET.
- **API:** Tích hợp API từ các trang thương mại điện tử như Tiki, Shopee, Lazada để lấy dữ liệu sản phẩm và giao dịch.

# 5. Hướng Dẫn Cài Đặt
# Yêu Cầu Hệ Thống:
- .NET Framework 4.7 trở lên
- SQL Server/MySQL
- ML.NET hoặc TensorFlow.NET

# Bước Cài Đặt:
1. **Clone dự án về máy:**
   ```bash
   git clone https://github.com/yourusername/recommendation-system.git
   ```
2. **Cấu hình cơ sở dữ liệu:**
   - Mở file `appsettings.json` và cập nhật thông tin kết nối cơ sở dữ liệu.
3. **Chạy dự án:**
   - Sử dụng Visual Studio, mở giải pháp và nhấn `Run` để khởi động ứng dụng.

# 6. Link Tham Khảo
- [Tiki.vn](https://tiki.vn)
- [Shopee.vn](https://shopee.vn)
- [Lazada.vn](https://lazada.vn)

# 7. Tác Giả
- Tên: [Tên của bạn]
- Email: [Email của bạn]
- Ngày tạo: [Ngày bắt đầu dự án]

# Mô tả file README.md:
- **Mục tiêu dự án**: Giới thiệu về mục đích và chức năng chính của hệ thống.
- **Chức năng hệ thống**: Liệt kê các tính năng mà hệ thống gợi ý sản phẩm cung cấp.
- **Chức năng AI**: Giới thiệu các mô hình AI được sử dụng để gợi ý sản phẩm.
- **Công nghệ sử dụng**: Thông tin về các công nghệ, framework và thư viện AI cần thiết.
- **Hướng dẫn cài đặt**: Bước chi tiết để cài đặt và chạy dự án.
- **Link tham khảo**: Các trang web tại Việt Nam có hệ thống gợi ý sản phẩm tương tự.
- **Thông tin tác giả**: Cung cấp thông tin cá nhân và ngày tạo dự án.

File README.md này giúp người đọc hiểu rõ hơn về dự án, cách cài đặt, và sử dụng hệ thống gợi ý sản phẩm mua kèm.
