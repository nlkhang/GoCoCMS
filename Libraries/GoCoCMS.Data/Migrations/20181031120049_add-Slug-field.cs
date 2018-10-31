using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoCoCMS.Data.Migrations
{
    public partial class addSlugfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContentOverview",
                table: "BlogPosts",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomePage",
                table: "BlogPosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOnHomePage",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "BlogPosts",
                newName: "ContentOverview");
        }
    }
}
