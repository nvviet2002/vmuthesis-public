using System.Collections.Generic;
using System.Reflection.Emit;
using BE_thesis.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BE_thesis.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Brand>().HasData(
                new Brand() { ID = 1, Name = "Phúc Long", Origin = "Việt Nam", Address = "98 Bà Triệu, Phường Hàng Bài, Quận Hoàn Kiếm" },
                new Brand() { ID = 2, Name = "Unilever", Origin = "Mỹ", Address = " Unilever House, 100 Victoria Embankment, London EC4Y 0DY, United Kingdom" },
                new Brand() { ID = 3, Name = "PepsiCo", Origin = "Mỹ", Address = "700 Anderson Hill Road, Purchase, NY 10577, Hoa Kỳ" },
                new Brand() { ID = 4, Name = "Coca-Cola", Origin = "Mỹ", Address = "One Coca-Cola Plaza, Atlanta, Georgia 30313, Hoa Kỳ" },
                new Brand() { ID = 5, Name = "Masan", Origin = "Việt Nam", Address = " Tầng 8, Tòa nhà Central Plaza, 17 Lê Duẩn, Phường Bến Nghé, Quận 1, TP." },
                new Brand() { ID = 6, Name = "Co.op", Origin = "Việt Nam", Address = " 199-205 Nguyễn Thái Học, Phường Phạm Ngũ Lão, Quận 1, TP." },
                new Brand() { ID = 7, Name = "Big C", Origin = "Mỹ", Address = "1231 QL 1A, KP5, Bình Trị Đông B, Quận Bình Tân, TP. Hồ Chí Minh" },
                new Brand() { ID = 8, Name = "TH True Milk", Origin = "Việt Nam", Address = " 166 Nguyễn Thái Học, Phường Quang Trung, TP. Vinh, Nghệ An" },
                new Brand() { ID = 9, Name = "Saigon Food", Origin = "Việt nam", Address = "Lô C24 - 24B/II, C25/II - Đường 2F - KCN Vĩnh Lộc - Xã Vĩnh Lộc A - Huyện Bình Chánh - TP. Hồ Chí Minh" },
                new Brand() { ID = 10, Name = "Sunhouse", Origin = "Việt Nam", Address = "Tầng 12, Tòa nhà Richy Tower, Số 35 Mạc Thái Tổ, Phường Yên Hòa, Quận Cầu Giấy, Hà Nội" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { ID = 1, Name = "Trà", Description = "Trà là một loại thức uống được pha từ lá của cây trà (Camellia sinensis). Cây trà có nguồn gốc từ Đông Á, và được trồng ở nhiều nơi trên thế giới. Trà được biết đến với hương vị thơm ngon, đa dạng và những lợi ích cho sức khỏe." },
                new Category() { ID = 2, Name = "Thực phẩm", Description = "Thực phẩm là những thứ mà con người và động vật ăn để cung cấp năng lượng và chất dinh dưỡng cho cơ thể. Thực phẩm đóng vai trò quan trọng trong cuộc sống, là nền tảng cho sự phát triển và duy trì sức khỏe của con người." },
                new Category() { ID = 3, Name = "Đồ ăn vặt", Description = "Đồ ăn vặt là những món ăn nhẹ được thưởng thức giữa các bữa ăn chính. Đồ ăn vặt có thể là những món ăn đơn giản, dễ làm như trái cây, bánh quy, hoặc là những món ăn cầu kỳ hơn như bánh ngọt, kem,..." },
                new Category() { ID = 4, Name = "Đồ uống", Description = "Đồ uống là những chất lỏng được con người và động vật sử dụng để cung cấp nước cho cơ thể. Nước là loại đồ uống quan trọng nhất, là thành phần chính của cơ thể và đóng vai trò quan trọng trong mọi hoạt động sống" },
                new Category() { ID = 5, Name = "Hạt", Description = "Hạt là một phần quan trọng của thực vật, đóng vai trò như một đơn vị sinh sản. Hạt được hình thành từ noãn sau khi được thụ phấn. Hạt có kích thước và hình dạng khác nhau, tùy thuộc vào loại thực vật." },
                new Category() { ID = 6, Name = "Trái cây", Description = "Trái cây là phần thịt quả của thực vật có vị ngọt và thường được ăn sống. Trái cây là nguồn cung cấp vitamin, khoáng chất và chất xơ thiết yếu cho cơ thể." },
                new Category() { ID = 7, Name = "Đồ hộp", Description = "Đồ hộp là thực phẩm được bảo quản trong hộp kim loại hoặc thủy tinh kín, giúp giữ nguyên hương vị và chất dinh dưỡng trong thời gian dài." },
                new Category() { ID = 8, Name = "Nước chấm", Description = "Nước chấm là một loại hỗn hợp gia vị được sử dụng để chấm các món ăn. Nước chấm có thể được làm từ nhiều nguyên liệu khác nhau như nước mắm, chanh, ớt, tỏi, đường,... Nước chấm đóng vai trò quan trọng trong ẩm thực Việt Nam, giúp tăng hương vị cho món ăn và tạo sự cân bằng trong bữa ăn." },
                new Category() { ID = 9, Name = "Mỳ", Description = "Mì là một món ăn được làm từ bột mì, nước và muối. Mì có thể được chế biến thành nhiều món ăn khác nhau, từ món nước đến món xào, món kho,... Mì là món ăn phổ biến ở nhiều quốc gia trên thế giới, trong đó có Việt Nam." },
                new Category() { ID = 10, Name = "Đồ gia dụng", Description = "Đồ gia dụng là những sản phẩm được sử dụng trong gia đình để phục vụ cho các nhu cầu sinh hoạt hàng ngày như nấu nướng, giặt giũ, dọn dẹp nhà cửa,... Đồ gia dụng giúp cho cuộc sống của con người trở nên tiện nghi và thoải mái hơn." }
            );
            modelBuilder.Entity<Unit>().HasData(
                new Unit() { ID = 1, Name = "kg", Description = "Kilôgam" },
                new Unit() { ID = 2, Name = "g", Description = "Gam" },
                new Unit() { ID = 3, Name = "lon", Description = "Lon" },
                new Unit() { ID = 4, Name = "chai", Description = "Chai" },
                new Unit() { ID = 5, Name = "hộp", Description = "Hộp" },
                new Unit() { ID = 6, Name = "cái", Description = "Cái" },
                new Unit() { ID = 7, Name = "gói", Description = "Gói" },
                new Unit() { ID = 8, Name = "lốc", Description = "Lốc" },
                new Unit() { ID = 9, Name = "bộ", Description = "Bộ" },
                new Unit() { ID = 10, Name = "thùng ", Description = "Thùng" }
            );
            modelBuilder.Entity<Product>()
                .Property(q=>q.Type)
                .HasConversion<string>()
                .HasMaxLength(50);
            modelBuilder.Entity<Invoice>()
                .Property(q => q.Status)
                .HasConversion<string>()
                .HasMaxLength(50);
            modelBuilder.Entity<Invoice>()
                .Property(q => q.Method)
                .HasConversion<string>()
                .HasMaxLength(50);


            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
