using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE_thesis.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    origin = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    qrcode = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    inventory = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    unit_id = table.Column<int>(type: "int", nullable: true),
                    brand_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "Brand",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_Unit_unit_id",
                        column: x => x.unit_id,
                        principalTable: "Unit",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    paid = table.Column<double>(type: "float", nullable: false),
                    refund = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    qr_code = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Invoice_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    note = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    invoice_id = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "Invoice",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "address", "created_at", "is_deleted", "name", "origin", "updated_at" },
                values: new object[,]
                {
                    { 1, "98 Bà Triệu, Phường Hàng Bài, Quận Hoàn Kiếm", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2363), false, "Phúc Long", "Việt Nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2365) },
                    { 2, " Unilever House, 100 Victoria Embankment, London EC4Y 0DY, United Kingdom", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2369), false, "Unilever", "Mỹ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2369) },
                    { 3, "700 Anderson Hill Road, Purchase, NY 10577, Hoa Kỳ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2372), false, "PepsiCo", "Mỹ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2372) },
                    { 4, "One Coca-Cola Plaza, Atlanta, Georgia 30313, Hoa Kỳ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2374), false, "Coca-Cola", "Mỹ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2375) },
                    { 5, " Tầng 8, Tòa nhà Central Plaza, 17 Lê Duẩn, Phường Bến Nghé, Quận 1, TP.", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2377), false, "Masan", "Việt Nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2377) },
                    { 6, " 199-205 Nguyễn Thái Học, Phường Phạm Ngũ Lão, Quận 1, TP.", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2379), false, "Co.op", "Việt Nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2379) },
                    { 7, "1231 QL 1A, KP5, Bình Trị Đông B, Quận Bình Tân, TP. Hồ Chí Minh", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2381), false, "Big C", "Mỹ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2382) },
                    { 8, " 166 Nguyễn Thái Học, Phường Quang Trung, TP. Vinh, Nghệ An", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2384), false, "TH True Milk", "Việt Nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2385) },
                    { 9, "Lô C24 - 24B/II, C25/II - Đường 2F - KCN Vĩnh Lộc - Xã Vĩnh Lộc A - Huyện Bình Chánh - TP. Hồ Chí Minh", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2387), false, "Saigon Food", "Việt nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2387) },
                    { 10, "Tầng 12, Tòa nhà Richy Tower, Số 35 Mạc Thái Tổ, Phường Yên Hòa, Quận Cầu Giấy, Hà Nội", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2389), false, "Sunhouse", "Việt Nam", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2390) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "created_at", "description", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2698), "Trà là một loại thức uống được pha từ lá của cây trà (Camellia sinensis). Cây trà có nguồn gốc từ Đông Á, và được trồng ở nhiều nơi trên thế giới. Trà được biết đến với hương vị thơm ngon, đa dạng và những lợi ích cho sức khỏe.", false, "Trà", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2699) },
                    { 2, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2701), "Thực phẩm là những thứ mà con người và động vật ăn để cung cấp năng lượng và chất dinh dưỡng cho cơ thể. Thực phẩm đóng vai trò quan trọng trong cuộc sống, là nền tảng cho sự phát triển và duy trì sức khỏe của con người.", false, "Thực phẩm", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2702) },
                    { 3, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2704), "Đồ ăn vặt là những món ăn nhẹ được thưởng thức giữa các bữa ăn chính. Đồ ăn vặt có thể là những món ăn đơn giản, dễ làm như trái cây, bánh quy, hoặc là những món ăn cầu kỳ hơn như bánh ngọt, kem,...", false, "Đồ ăn vặt", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2704) },
                    { 4, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2706), "Đồ uống là những chất lỏng được con người và động vật sử dụng để cung cấp nước cho cơ thể. Nước là loại đồ uống quan trọng nhất, là thành phần chính của cơ thể và đóng vai trò quan trọng trong mọi hoạt động sống", false, "Đồ uống", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2707) },
                    { 5, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2708), "Hạt là một phần quan trọng của thực vật, đóng vai trò như một đơn vị sinh sản. Hạt được hình thành từ noãn sau khi được thụ phấn. Hạt có kích thước và hình dạng khác nhau, tùy thuộc vào loại thực vật.", false, "Hạt", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2709) },
                    { 6, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2710), "Trái cây là phần thịt quả của thực vật có vị ngọt và thường được ăn sống. Trái cây là nguồn cung cấp vitamin, khoáng chất và chất xơ thiết yếu cho cơ thể.", false, "Trái cây", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2711) },
                    { 7, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2712), "Đồ hộp là thực phẩm được bảo quản trong hộp kim loại hoặc thủy tinh kín, giúp giữ nguyên hương vị và chất dinh dưỡng trong thời gian dài.", false, "Đồ hộp", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2713) },
                    { 8, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2715), "Nước chấm là một loại hỗn hợp gia vị được sử dụng để chấm các món ăn. Nước chấm có thể được làm từ nhiều nguyên liệu khác nhau như nước mắm, chanh, ớt, tỏi, đường,... Nước chấm đóng vai trò quan trọng trong ẩm thực Việt Nam, giúp tăng hương vị cho món ăn và tạo sự cân bằng trong bữa ăn.", false, "Nước chấm", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2715) },
                    { 9, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2717), "Mì là một món ăn được làm từ bột mì, nước và muối. Mì có thể được chế biến thành nhiều món ăn khác nhau, từ món nước đến món xào, món kho,... Mì là món ăn phổ biến ở nhiều quốc gia trên thế giới, trong đó có Việt Nam.", false, "Mỳ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2717) },
                    { 10, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2719), "Đồ gia dụng là những sản phẩm được sử dụng trong gia đình để phục vụ cho các nhu cầu sinh hoạt hàng ngày như nấu nướng, giặt giũ, dọn dẹp nhà cửa,... Đồ gia dụng giúp cho cuộc sống của con người trở nên tiện nghi và thoải mái hơn.", false, "Đồ gia dụng", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2720) }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "ID", "created_at", "description", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2787), "Kilôgam", false, "kg", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2788) },
                    { 2, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2791), "Gam", false, "g", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2791) },
                    { 3, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2792), "Lon", false, "lon", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2793) },
                    { 4, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2794), "Chai", false, "chai", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2795) },
                    { 5, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2796), "Hộp", false, "hộp", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2797) },
                    { 6, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2798), "Cái", false, "cái", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2799) },
                    { 7, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2800), "Gói", false, "gói", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2801) },
                    { 8, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2802), "Lốc", false, "lốc", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2803) },
                    { 9, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2804), "Bộ", false, "bộ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2804) },
                    { 10, new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2806), "Thùng", false, "thùng ", new DateTime(2024, 5, 10, 11, 28, 4, 61, DateTimeKind.Utc).AddTicks(2806) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customer_id",
                table: "Invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_user_id",
                table: "Invoice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_invoice_id",
                table: "InvoiceDetail",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductID",
                table: "InvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_brand_id",
                table: "Product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_unit_id",
                table: "Product",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
