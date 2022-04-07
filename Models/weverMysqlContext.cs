using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestAPI.Models
{
    public partial class weverMysqlContext : DbContext
    {
        public weverMysqlContext()
        {
        }

        public weverMysqlContext(DbContextOptions<weverMysqlContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Battery> Batteries { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<BuildingDetail> BuildingDetails { get; set; } = null!;
        public virtual DbSet<Column> Columns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Elevator> Elevators { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Intervention> Interventions { get; set; } = null!;
        public virtual DbSet<Lead> Leads { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=weverMysql;user=wevertr;password=3090", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Entity)
                    .HasMaxLength(255)
                    .HasColumnName("entity");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .HasColumnName("lat");

                entity.Property(e => e.Lng)
                    .HasMaxLength(255)
                    .HasColumnName("lng");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.NumberStreet)
                    .HasMaxLength(255)
                    .HasColumnName("number_street");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.SuiteApartment)
                    .HasMaxLength(255)
                    .HasColumnName("suite_apartment");

                entity.Property(e => e.TypeOfAddress)
                    .HasMaxLength(255)
                    .HasColumnName("type_of_address");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId, "index_batteries_on_employee_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CertificateOfOperations)
                    .HasMaxLength(255)
                    .HasColumnName("certificate_of_operations");

                entity.Property(e => e.CommissionDate)
                    .HasMaxLength(255)
                    .HasColumnName("commission_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Information)
                    .HasColumnType("text")
                    .HasColumnName("information");

                entity.Property(e => e.LastInspectionDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_inspection_date");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId, "index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BuildingAdministratorEmail)
                    .HasMaxLength(255)
                    .HasColumnName("building_administrator_email");

                entity.Property(e => e.BuildingAdministratorName)
                    .HasMaxLength(255)
                    .HasColumnName("building_administrator_name");

                entity.Property(e => e.BuildingAdministratorPhone)
                    .HasMaxLength(255)
                    .HasColumnName("building_administrator_phone");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.TechContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("tech_contact_email");

                entity.Property(e => e.TechContactName)
                    .HasMaxLength(255)
                    .HasColumnName("tech_contact_name");

                entity.Property(e => e.TechContactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("tech_contact_phone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<BuildingDetail>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId, "index_building_details_on_building_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.InfoKey)
                    .HasMaxLength(255)
                    .HasColumnName("info_key");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information)
                    .HasColumnType("text")
                    .HasColumnName("information");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.NumberOfFloorsServed)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_floors_served");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId, "index_customers_on_address_id");

                entity.HasIndex(e => e.UserId, "index_customers_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CompanyContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("company_contact_email");

                entity.Property(e => e.CompanyContactName)
                    .HasMaxLength(255)
                    .HasColumnName("company_contact_name");

                entity.Property(e => e.CompanyContactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("company_contact_phone");

                entity.Property(e => e.CompanyDescription)
                    .HasColumnType("text")
                    .HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.creation_date)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.TeachnicalAuthorityEmail)
                    .HasMaxLength(255)
                    .HasColumnName("teachnical_authority_email");

                entity.Property(e => e.TechnicalAuthorityName)
                    .HasMaxLength(255)
                    .HasColumnName("technical_authority_name");

                entity.Property(e => e.TechnicalAuthorityPhone)
                    .HasMaxLength(255)
                    .HasColumnName("technical_authority_phone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CertificateOfInspection)
                    .HasMaxLength(255)
                    .HasColumnName("certificate_of_inspection");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CommissionDate)
                    .HasMaxLength(255)
                    .HasColumnName("commission_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information)
                    .HasColumnType("text")
                    .HasColumnName("information");

                entity.Property(e => e.LastInspectionDate)
                    .HasMaxLength(255)
                    .HasColumnName("last_inspection_date");

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("model");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("serial_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "index_employees_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.ToTable("interventions");

                entity.HasIndex(e => e.AuthorId, "index_interventions_on_author_id");

                entity.HasIndex(e => e.BatteryId, "index_interventions_on_battery_id");

                entity.HasIndex(e => e.BuildingId, "index_interventions_on_building_id");

                entity.HasIndex(e => e.ColumnId, "index_interventions_on_column_id");

                entity.HasIndex(e => e.CustomerId, "index_interventions_on_customer_id");

                entity.HasIndex(e => e.ElevatorId, "index_interventions_on_elevator_id");

                entity.HasIndex(e => e.EmployeeId, "index_interventions_on_employee_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ElevatorId).HasColumnName("elevator_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.Report)
                    .HasMaxLength(255)
                    .HasColumnName("report");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .HasColumnName("result");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.InterventionAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("fk_rails_6766059600");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_268aede6d6");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_911b4ef939");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_d05fb241b3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_4242c0f569");

                entity.HasOne(d => d.Elevator)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ElevatorId)
                    .HasConstraintName("fk_rails_11b5a4bd36");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.InterventionEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_2e0d31b7ad");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttachedFile)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attached_file");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .HasColumnName("contact_name");

                entity.Property(e => e.contact_request_date)
                    .HasColumnType("datetime")
                    .HasColumnName("contact_request_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .HasColumnName("filename");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnType("text")
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("project_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessHours)
                    .HasMaxLength(255)
                    .HasColumnName("business_hours");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("contact_email");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .HasColumnName("contact_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateCreated)
                    .HasMaxLength(255)
                    .HasColumnName("date_created");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.ElevatorAmount)
                    .HasMaxLength(255)
                    .HasColumnName("elevator_amount");

                entity.Property(e => e.ElevatorTotalPrice)
                    .HasMaxLength(255)
                    .HasColumnName("elevator_total_price");

                entity.Property(e => e.ElevatorUnitPrice)
                    .HasMaxLength(255)
                    .HasColumnName("elevator_unit_price");

                entity.Property(e => e.FinalPrice)
                    .HasMaxLength(255)
                    .HasColumnName("final_price");

                entity.Property(e => e.InstallationFees)
                    .HasMaxLength(255)
                    .HasColumnName("installation_fees");

                entity.Property(e => e.MaximumOccupancy)
                    .HasMaxLength(255)
                    .HasColumnName("maximum_occupancy");

                entity.Property(e => e.NumberOfApartments)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_apartments");

                entity.Property(e => e.NumberOfBasements)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_basements");

                entity.Property(e => e.NumberOfCompanies)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_companies");

                entity.Property(e => e.NumberOfCorporations)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_corporations");

                entity.Property(e => e.NumberOfElevators)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_elevators");

                entity.Property(e => e.NumberOfFloors)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_floors");

                entity.Property(e => e.NumberOfParkingSpots)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_parking_spots");

                entity.Property(e => e.ServiceGrade)
                    .HasMaxLength(255)
                    .HasColumnName("service_grade");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken).HasColumnName("reset_password_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
