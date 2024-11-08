using System;
using System.Collections.Generic;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace afe_final_api.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<BudgetTransactionEvent> BudgetTransactionEvents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<TransactionEvent> TransactionEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envVars = DotEnv.Read();
        Console.WriteLine("ENV: " + Environment.GetEnvironmentVariable("db"));
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("db") ?? envVars["db"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("budget_pkey");

            entity.ToTable("budget");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BudgetName).HasColumnName("budget_name");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.SubcategoryOf).HasColumnName("subcategory_of");

            entity.HasOne(d => d.Customer).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("budget_customer_id_fkey");

            entity.HasOne(d => d.SubcategoryOfNavigation).WithMany(p => p.InverseSubcategoryOfNavigation)
                .HasForeignKey(d => d.SubcategoryOf)
                .HasConstraintName("budget_subcategory_of_fkey");
        });

        modelBuilder.Entity<BudgetTransactionEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("budget_transaction_event_pkey");

            entity.ToTable("budget_transaction_event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BudgetId).HasColumnName("budget_id");
            entity.Property(e => e.TransactionEventId).HasColumnName("transaction_event_id");

            entity.HasOne(d => d.Budget).WithMany(p => p.BudgetTransactionEvents)
                .HasForeignKey(d => d.BudgetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("budget_transaction_event_budget_id_fkey");

            entity.HasOne(d => d.TransactionEvent).WithMany(p => p.BudgetTransactionEvents)
                .HasForeignKey(d => d.TransactionEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("budget_transaction_event_transaction_event_id_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Email, "customer_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<TransactionEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_event_pkey");

            entity.ToTable("transaction_event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amt)
                .HasPrecision(10, 2)
                .HasColumnName("amt");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionName).HasColumnName("transaction_name");

            entity.HasOne(d => d.Customer).WithMany(p => p.TransactionEvents)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("transaction_event_customer_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
