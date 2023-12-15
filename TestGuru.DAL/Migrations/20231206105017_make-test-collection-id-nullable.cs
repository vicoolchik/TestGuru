using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestGuru.DAL.Migrations
{
    /// <inheritdoc />
    public partial class maketestcollectionidnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TestCollections_TestCollectionId",
                table: "Tests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestCollectionId",
                table: "Tests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TestCollections_TestCollectionId",
                table: "Tests",
                column: "TestCollectionId",
                principalTable: "TestCollections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TestCollections_TestCollectionId",
                table: "Tests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TestCollectionId",
                table: "Tests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TestCollections_TestCollectionId",
                table: "Tests",
                column: "TestCollectionId",
                principalTable: "TestCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
