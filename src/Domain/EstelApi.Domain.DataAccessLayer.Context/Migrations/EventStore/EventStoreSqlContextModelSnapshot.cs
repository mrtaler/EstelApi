﻿// <auto-generated />
using System;
using EstelApi.Domain.DataAccessLayer.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstelApi.Domain.DataAccessLayer.Context.Migrations.EventStore
{
    [DbContext(typeof(EventStoreSqlContext))]
    partial class EventStoreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstelApi.Core.Cqrs.Events.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("Data");

                    b.Property<string>("MessageType")
                        .HasColumnName("Action")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("CreationDate");

                    b.Property<string>("User");

                    b.Property<long>("Version");

                    b.HasKey("Id");

                    b.ToTable("StoredEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
