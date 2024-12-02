﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20241130120614_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Models.TodoList", b =>
                {
                    b.Property<int>("TodoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TodoListId");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("Models.TodoTask", b =>
                {
                    b.Property<int>("TodoTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TodoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoTaskId");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoTasks");
                });

            modelBuilder.Entity("Models.TodoTask", b =>
                {
                    b.HasOne("Models.TodoList", "TodoList")
                        .WithMany("TodoTasks")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("Models.TodoList", b =>
                {
                    b.Navigation("TodoTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
