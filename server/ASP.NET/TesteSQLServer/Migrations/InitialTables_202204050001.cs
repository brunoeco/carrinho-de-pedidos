using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace TesteSQLServer.Migrations
{
    [Migration(202204050001)]
    public class InitialTables_202204050001 : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-users")
                .WithColumn("name").AsString(50).NotNullable()
                .WithColumn("email").AsString(60).NotNullable()
                .WithColumn("username").AsString(20).NotNullable()
                .WithColumn("password-hash").AsString(255).NotNullable();

            Create.Table("payments")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-payments")
                .WithColumn("name").AsString(50).NotNullable();

            Create.Table("products")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-products")
                .WithColumn("name").AsString(50).NotNullable()
                .WithColumn("description").AsString(255).NotNullable()
                .WithColumn("category").AsString(20).NotNullable()
                .WithColumn("price").AsDecimal(18, 3).NotNullable()
                .WithColumn("image-url").AsString(255).NotNullable();

            Create.Table("favorites")
               .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-favorites")
               .WithColumn("created-at").AsDate().NotNullable()
               .WithColumn("product-id").AsGuid().NotNullable().ForeignKey("fk-favorites-products", "products", "id")
               .WithColumn("user-id").AsGuid().NotNullable().ForeignKey("fk-favorites-users", "users", "id");

            Create.Table("orders") 
               .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-orders")
               .WithColumn("created-at").AsDate().NotNullable()
               .WithColumn("payment-id").AsGuid().NotNullable().ForeignKey("fk-orders-payments", "payments", "id")
               .WithColumn("user-id").AsGuid().NotNullable().ForeignKey("fk-orders-users", "users", "id");

            Create.Table("order-items")
               .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-order-items")
               .WithColumn("price").AsDecimal(18,3).NotNullable()
               .WithColumn("quantity").AsInt32().NotNullable()
               .WithColumn("product-id").AsGuid().NotNullable().ForeignKey("fk-order-items-products", "products", "id")
               .WithColumn("order-id").AsGuid().NotNullable().ForeignKey("fk-order-items-users", "orders", "id");

            Create.Table("addresses")
               .WithColumn("id").AsGuid().NotNullable().PrimaryKey("pk-addresses")
               .WithColumn("street").AsString(150).NotNullable()
               .WithColumn("district").AsString(150).NotNullable()
               .WithColumn("city").AsString(100).NotNullable()
               .WithColumn("state").AsString(2).NotNullable()
               .WithColumn("zipcode").AsString(8).NotNullable()
               .WithColumn("order-id").AsGuid().NotNullable().ForeignKey("fk-addresses-orders", "orders", "id");
        }

        public override void Down()
        {
            Delete.Table("addresses");
            Delete.Table("order-items");
            Delete.Table("orders");
            Delete.Table("favorites");
            Delete.Table("products");
            Delete.Table("payments");
            Delete.Table("users");
        }
    }
}
