using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class add9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    cid = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "企业唯一标识（用于与外部关联）", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    company_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValueSql: "''", comment: "企业名称", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    company_type = table.Column<byte>(type: "tinyint(4) unsigned", nullable: false, comment: "企业类型：1：建设集团，2：施工单位，3：劳务企业，4：设计单位 99,其他"),
                    organization_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "统一社会信用代码（原组织机构代码）", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    businesslicense_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "营业执照编号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    businesslicense = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, comment: "营业执照附件", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    owner = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "法人", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    owner_certificate_type = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'", comment: "法人证件类型(1,身份证2,军官证；3,护照；4,台湾居民身份证；5,港澳永久性居民身份证；6,警官证；99,其他)"),
                    owner_cardid = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, defaultValueSql: "''", comment: "法人身份证号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    owner_phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", comment: "法人联系电话", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    province_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", comment: "省份编号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    city_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", comment: "市编号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    county_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "''", comment: "县或区编号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    address = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, defaultValueSql: "''", comment: "街道地址", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    checked_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "审批时间"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    create_user = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "创建人", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    last_modify_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "修改时间"),
                    last_modify_user = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "修改人", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    is_deleted = table.Column<byte>(type: "tinyint(4) unsigned", nullable: false, defaultValueSql: "'1'", comment: "是否删除 - 1:未删除 2:删除"),
                    register_time = table.Column<DateOnly>(type: "date", nullable: true, comment: "注册时间:成立日期"),
                    safety_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValueSql: "''", comment: "安全许可证号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    register_currency_type = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'", comment: "注册资本币种"),
                    register_capital = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "注册资金(万元)"),
                    quality_time = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "资质有效时间", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    company_email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "企业邮箱", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    company_url = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "企业网址", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fax = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "''", comment: "传真", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    sync_flag = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "用作同步数据字段", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    manage_province_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "管理所在省(自治", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    manage_city_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "管理所在市", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    manage_county_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "注册所在区、县", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    manage_street_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "管理街道编号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    manage_address = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "管理地详细地址", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    contact = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "企业联系人", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    contact_phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "企业联系人手机号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    contact_card = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "企业联系人身份证号", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    organization_url = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, comment: "统一社会信用代码附件", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    source_type = table.Column<int>(type: "int(11)", nullable: false, comment: "来源（1，注册  2，openapi导入   3，excel导入  4，天正数据 5 银行导入 6,工商局 7,政府 8,企薪）"),
                    street_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "街道名称", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    industry_type = table.Column<int>(type: "int(11)", nullable: true, comment: "行业类型（1，住建行业；2，交通行业；3，水利行业；4，制造行业 5，服务行业  ）"),
                    nature_firms = table.Column<int>(type: "int(11)", nullable: true, comment: "企业性质"),
                    is_compliance = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'", comment: "是否是规上企业，1：是，2否"),
                    subcontract_type = table.Column<int>(type: "int(11)", nullable: true, comment: "分包类型"),
                    certification_status = table.Column<int>(type: "int(11)", nullable: true, comment: "企业认证状态（1，未认证 2，认证中 3，认证成功 4，认证失败）"),
                    certification_date = table.Column<DateTime>(type: "datetime", nullable: true, comment: "企业认证时间"),
                    certification_reason = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "企业认证失败理由", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    zj_status = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'0'", comment: "安监备案状态（0：无  1：温州工薪企业，安监已备案 2：温州工薪企业，安监未备案）"),
                    businesslicense_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "上传营业执照修改时间"),
                    businesslicense_user = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "上传营业执照修改人", collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    business_status = table.Column<int>(type: "int(11)", nullable: true, comment: "[山西综改区]经营状态(1存续2注销3吊销)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                },
                comment: "企业表")
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "idx_cid",
                table: "company",
                column: "cid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
