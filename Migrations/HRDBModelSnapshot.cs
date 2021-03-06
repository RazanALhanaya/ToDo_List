// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todoList.Models;

#nullable disable

namespace todoList.Migrations
{
    [DbContext(typeof(HRDB))]
    partial class HRDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("todoList.Models.List", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"), 1L, 1);

                    b.Property<string>("DateOfTask")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TimeOfTask")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("ListId");

                    b.ToTable("list");
                });
#pragma warning restore 612, 618
        }
    }
}
