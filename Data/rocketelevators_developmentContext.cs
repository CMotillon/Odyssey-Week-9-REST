using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Data
{
    public partial class rocketelevators_developmentContext : DbContext
    {
        public rocketelevators_developmentContext()
        {
        }

        public rocketelevators_developmentContext(DbContextOptions<rocketelevators_developmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BlazerAudits> BlazerAudits { get; set; }
        public virtual DbSet<BlazerChecks> BlazerChecks { get; set; }
        public virtual DbSet<BlazerDashboardQueries> BlazerDashboardQueries { get; set; }
        public virtual DbSet<BlazerDashboards> BlazerDashboards { get; set; }
        public virtual DbSet<BlazerQueries> BlazerQueries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Interventions> Interventions { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Entity)
                    .HasColumnName("entity")
                    .HasMaxLength(255);

                entity.Property(e => e.GoogleMap).HasColumnName("google_map");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .HasColumnName("number_and_street")
                    .HasMaxLength(255);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.SuiteOrApartment)
                    .HasColumnName("suite_or_apartment")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeOfAddress)
                    .HasColumnName("type_of_address")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryType)
                    .HasColumnName("battery_type")
                    .HasMaxLength(255);

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CertificateOfOperations)
                    .HasColumnName("certificate_of_operations")
                    .HasMaxLength(255);

                entity.Property(e => e.DateCommissioning)
                    .HasColumnName("date_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnName("date_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");
            });

            modelBuilder.Entity<BlazerAudits>(entity =>
            {
                entity.ToTable("blazer_audits");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_audits_on_query_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_blazer_audits_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasMaxLength(255);

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BlazerChecks>(entity =>
            {
                entity.ToTable("blazer_checks");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_checks_on_creator_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_checks_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckType)
                    .HasColumnName("check_type")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Emails).HasColumnName("emails");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .HasMaxLength(255);

                entity.Property(e => e.SlackChannels).HasColumnName("slack_channels");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BlazerDashboardQueries>(entity =>
            {
                entity.ToTable("blazer_dashboard_queries");

                entity.HasIndex(e => e.DashboardId)
                    .HasName("index_blazer_dashboard_queries_on_dashboard_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_dashboard_queries_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DashboardId).HasColumnName("dashboard_id");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.QueryId).HasColumnName("query_id");
            });

            modelBuilder.Entity<BlazerDashboards>(entity =>
            {
                entity.ToTable("blazer_dashboards");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_dashboards_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BlazerQueries>(entity =>
            {
                entity.ToTable("blazer_queries");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_queries_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.InformationKey).HasColumnName("information_key");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressBuilding)
                    .HasColumnName("address_building")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmailAdministrator)
                    .HasColumnName("email_administrator")
                    .HasMaxLength(255);

                entity.Property(e => e.FullNameAdministrator)
                    .HasColumnName("full_name_administrator")
                    .HasMaxLength(255);

                entity.Property(e => e.FullNameTechnicalContactBuilding)
                    .HasColumnName("full_name_technical_contact_building")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneAdministrator)
                    .HasColumnName("phone_administrator")
                    .HasMaxLength(255);

                entity.Property(e => e.TechnicalContactBuildingEmail)
                    .HasColumnName("technical_contact_building_email")
                    .HasMaxLength(255);

                entity.Property(e => e.TechnicalContactBuildingPhone)
                    .HasColumnName("technical_contact_building_phone")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.ColumnType)
                    .HasColumnName("column_type")
                    .HasMaxLength(255);

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.NumberOfFloorsServed).HasColumnName("number_of_floors_served");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Batteries).HasColumnName("batteries");
                entity.Property(e => e.Columns).HasColumnName("columns");
                entity.Property(e => e.Elevators).HasColumnName("elevators");
                entity.Property(e => e.Doors).HasColumnName("doors");
                entity.Property(e => e.Displays).HasColumnName("displays");
                entity.Property(e => e.Buttons).HasColumnName("buttons");
                

            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("company_address")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyContactEmail)
                    .HasColumnName("company_contact_email")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyContactPhone)
                    .HasColumnName("company_contact_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyDescription).HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("date");

                entity.Property(e => e.FullNameCompanyContact)
                    .HasColumnName("full_name_company_contact")
                    .HasMaxLength(255);

                entity.Property(e => e.FullNameServiceTechnicalAuthority)
                    .HasColumnName("full_name_service_technical_authority")
                    .HasMaxLength(255);

                entity.Property(e => e.TechnicalAuthorityEmail)
                    .HasColumnName("technical_authority_email")
                    .HasMaxLength(255);

                entity.Property(e => e.TechnicalAuthorityPhone)
                    .HasColumnName("technical_authority_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CertificateOfInspection)
                    .IsRequired()
                    .HasColumnName("certificate_of_inspection")
                    .HasMaxLength(255);

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.DateOfCommissioning)
                    .HasColumnName("date_of_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfLastInspection)
                    .HasColumnName("date_of_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.ElevatorType)
                    .HasColumnName("elevator_type")
                    .HasMaxLength(255);

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasColumnName("serial_number")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_employees_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Interventions>(entity =>
            {
                entity.ToTable("interventions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ElevatorId).HasColumnName("elevator_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasMaxLength(255);

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.InterventionStart).HasColumnName("intervention_start");

                entity.Property(e => e.InterventionEnd).HasColumnName("intervention_end");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("blob");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectDescription).HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("project_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ElevatorAmount).HasColumnName("elevator_amount");

                entity.Property(e => e.ElevatorInstallationFees)
                    .HasColumnName("elevator_installation_fees")
                    .HasMaxLength(255);

                entity.Property(e => e.ElevatorTotalPrice)
                    .HasColumnName("elevator_total_price")
                    .HasMaxLength(255);

                entity.Property(e => e.ElevatorUnitPrice)
                    .HasColumnName("elevator_unit_price")
                    .HasMaxLength(255);

                entity.Property(e => e.ElevatorsRequired).HasColumnName("elevators_required");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FinalPrice)
                    .HasColumnName("final_price")
                    .HasMaxLength(255);

                entity.Property(e => e.MaximumOccupancy).HasColumnName("maximum_occupancy");

                entity.Property(e => e.NumberOfApartments).HasColumnName("number_of_apartments");

                entity.Property(e => e.NumberOfBasements).HasColumnName("number_of_basements");

                entity.Property(e => e.NumberOfElevators).HasColumnName("number_of_elevators");

                entity.Property(e => e.NumberOfFloors).HasColumnName("number_of_floors");

                entity.Property(e => e.ProductLine)
                    .HasColumnName("product_line")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.ToTable("tracks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Artist)
                    .HasColumnName("artist")
                    .HasMaxLength(255);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Preview)
                    .HasColumnName("preview")
                    .HasMaxLength(255);

                entity.Property(e => e.SpotifyId)
                    .HasColumnName("spotify_id")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasMaxLength(255);

                entity.Property(e => e.SupervisorRole)
                    .HasColumnName("supervisor_role")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserRole)
                    .HasColumnName("user_role")
                    .HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
