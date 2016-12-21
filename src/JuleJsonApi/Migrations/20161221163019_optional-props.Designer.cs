using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JuleJsonApi.Model;

namespace JuleJsonApi.Migrations
{
    [DbContext(typeof(JuleContext))]
    [Migration("20161221163019_optional-props")]
    partial class optionalprops
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuleJsonApi.Model.Bruker", b =>
                {
                    b.Property<int>("BrukerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Kode")
                        .IsRequired();

                    b.Property<string>("Navn")
                        .IsRequired();

                    b.HasKey("BrukerId");

                    b.ToTable("Brukere");
                });

            modelBuilder.Entity("JuleJsonApi.Model.Drikke", b =>
                {
                    b.Property<int>("DrikkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("Abv");

                    b.Property<string>("Beskrivelse");

                    b.Property<string>("Bilde");

                    b.Property<string>("Bryggeri");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Land");

                    b.Property<string>("Navn")
                        .IsRequired();

                    b.Property<float?>("Pris");

                    b.Property<string>("Stil");

                    b.HasKey("DrikkeId");

                    b.ToTable("Drikker");
                });

            modelBuilder.Entity("JuleJsonApi.Model.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bilde");

                    b.Property<int>("BrukerID");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("DrikkeID");

                    b.Property<int>("Karakter");

                    b.Property<string>("Nokkelord")
                        .IsRequired();

                    b.Property<bool>("SmakerJul");

                    b.HasKey("RatingId");

                    b.HasIndex("BrukerID");

                    b.HasIndex("DrikkeID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("JuleJsonApi.Model.Rating", b =>
                {
                    b.HasOne("JuleJsonApi.Model.Bruker", "Bruker")
                        .WithMany("Rating")
                        .HasForeignKey("BrukerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuleJsonApi.Model.Drikke", "Drikke")
                        .WithMany("Rating")
                        .HasForeignKey("DrikkeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
