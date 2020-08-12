﻿// <auto-generated />
using Books.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Books.API.Migrations
{
    [DbContext(typeof(BookInfoContext))]
    [Migration("20200306134955_SampleData")]
    partial class SampleData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.API.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Charles Dickens",
                            Description = "",
                            Title = "Great Expectations"
                        },
                        new
                        {
                            Id = 2,
                            Author = "George Orwell",
                            Description = "",
                            Title = "Animal Farm"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Dashiell Hammett",
                            Description = "",
                            Title = "The Maltese Falcon"
                        },
                        new
                        {
                            Id = 4,
                            Author = "E M Forster",
                            Description = "",
                            Title = "A Room with a View"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Harper Lee",
                            Description = "",
                            Title = "To Kill a Mockingbird"
                        });
                });

            modelBuilder.Entity("Books.API.Entities.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Quote")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Quotations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Notes = "",
                            Quote = "You are in every line I have ever read."
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Notes = "",
                            Quote = "Spring is the time of year when it is summer in the sun and winter in the shade."
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Notes = "",
                            Quote = "All animals are equal, but some animals are more equal than others."
                        },
                        new
                        {
                            Id = 4,
                            BookId = 2,
                            Notes = "",
                            Quote = "Four legs good, two legs bad."
                        },
                        new
                        {
                            Id = 5,
                            BookId = 2,
                            Notes = "",
                            Quote = "This work was strictly voluntary, but any animal who absented himself from it would have his rations reduced by half."
                        },
                        new
                        {
                            Id = 6,
                            BookId = 3,
                            Notes = "",
                            Quote = " I wanted it, and I'm not a man that's easily discouraged when he wants something."
                        },
                        new
                        {
                            Id = 7,
                            BookId = 3,
                            Notes = "",
                            Quote = "You know how to do things ... you'll land on your feet in the end."
                        },
                        new
                        {
                            Id = 8,
                            BookId = 3,
                            Notes = "",
                            Quote = "The cheaper the crook, the gaudier the patter."
                        },
                        new
                        {
                            Id = 9,
                            BookId = 4,
                            Notes = "",
                            Quote = "Life is easy to chronicle, but bewildering to practice."
                        },
                        new
                        {
                            Id = 10,
                            BookId = 4,
                            Notes = "",
                            Quote = "Of course he despised the world as a whole; every thoughtful man should; it is almost a test of refinement."
                        },
                        new
                        {
                            Id = 11,
                            BookId = 4,
                            Notes = "",
                            Quote = "The world is certainly full of beautiful things, if only I could come across them."
                        },
                        new
                        {
                            Id = 12,
                            BookId = 5,
                            Notes = "",
                            Quote = "You never really understand a person until you consider things from his point of view... Until you climb inside of his skin and walk around in it."
                        },
                        new
                        {
                            Id = 13,
                            BookId = 5,
                            Notes = "",
                            Quote = "People generally see what they look for, and hear what they listen for."
                        },
                        new
                        {
                            Id = 14,
                            BookId = 5,
                            Notes = "",
                            Quote = "Lawyers, I suppose were once children, too."
                        });
                });

            modelBuilder.Entity("Books.API.Entities.Quotation", b =>
                {
                    b.HasOne("Books.API.Entities.Book", "Book")
                        .WithMany("Quotes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
