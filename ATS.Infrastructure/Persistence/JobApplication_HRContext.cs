using ATS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS.Infrastructure.Persistence
{
    public partial class JobApplication_HRContext : DbContext
    {
        public JobApplication_HRContext()
        {

        }

        public JobApplication_HRContext(DbContextOptions<JobApplication_HRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AplicantQuestion> AplicantQuestions { get; set; } = null!;
        public virtual DbSet<ApplicantCertificate> ApplicantCertificates { get; set; } = null!;
        public virtual DbSet<ApplicantEducation> ApplicantEducations { get; set; } = null!;
        public virtual DbSet<ApplicantLanguage> ApplicantLanguages { get; set; } = null!;
        public virtual DbSet<ApplicantProfile> ApplicantProfiles { get; set; } = null!;
        public virtual DbSet<ApplicantSkill> ApplicantSkills { get; set; } = null!;
        public virtual DbSet<ApplicantWorkExperience> ApplicantWorkExperiences { get; set; } = null!;
        public virtual DbSet<ATS.Domain.Models.Application> Applications { get; set; } = null!;
        public virtual DbSet<ApplicationStatusLog> ApplicationStatusLogs { get; set; } = null!;
        public virtual DbSet<ApplicationType> ApplicationTypes { get; set; } = null!;
        public virtual DbSet<ApplyProccess> ApplyProccesses { get; set; } = null!;
        public virtual DbSet<InputControl> InputControls { get; set; } = null!;
        public virtual DbSet<Interview> Interviews { get; set; } = null!;
        public virtual DbSet<InterviewDate> InterviewDates { get; set; } = null!;
        public virtual DbSet<JobCategory> JobCategories { get; set; } = null!;
        public virtual DbSet<JobLooksLog> JobLooksLogs { get; set; } = null!;
        public virtual DbSet<LoginLog> LoginLogs { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<MultiLanguage> MultiLanguages { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<OpenJob> OpenJobs { get; set; } = null!;
        public virtual DbSet<OpenJobsRequirement> OpenJobsRequirements { get; set; } = null!;
        public virtual DbSet<OpenJobsResponsibility> OpenJobsResponsibilities { get; set; } = null!;
        public virtual DbSet<Process> Processes { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleModule> RoleModules { get; set; } = null!;
        public virtual DbSet<UrlRoute> UrlRoutes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<VwGetActiveJob> VwGetActiveJobs { get; set; } = null!;
        public virtual DbSet<VwGetAllNote> VwGetAllNotes { get; set; } = null!;
        public virtual DbSet<VwGetAllUser> VwGetAllUsers { get; set; } = null!;
        public virtual DbSet<VwGetCategory> VwGetCategories { get; set; } = null!;
        public virtual DbSet<VwGetInterview> VwGetInterviews { get; set; } = null!;
        public virtual DbSet<VwGetNote> VwGetNotes { get; set; } = null!;
        public virtual DbSet<VwGetOffer> VwGetOffers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicantQuestion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AplicantProfileId).HasColumnName("AplicantProfileID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AplicantProfile)
                    .WithMany(p => p.AplicantQuestions)
                    .HasForeignKey(d => d.AplicantProfileId)
                    .HasConstraintName("FK__AplicantQ__Aplic__693CA210");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AplicantQuestions)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__AplicantQ__Appli__6754599E");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AplicantQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__AplicantQ__Quest__6A30C649");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AplicantQuestions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AplicantQ__UserI__68487DD7");
            });

            modelBuilder.Entity<ApplicantCertificate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantEducationId).HasColumnName("ApplicantEducationID");

                entity.Property(e => e.CertificateName).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ApplicantEducation)
                    .WithMany(p => p.ApplicantCertificates)
                    .HasForeignKey(d => d.ApplicantEducationId)
                    .HasConstraintName("FK__Applicant__Appli__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantCertificates)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Applicant__UserI__0C1BC9F9");
            });

            modelBuilder.Entity<ApplicantEducation>(entity =>
            {
                entity.ToTable("ApplicantEducation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AplicantProfileId).HasColumnName("AplicantProfileID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Direction).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Institution).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AplicantProfile)
                    .WithMany(p => p.ApplicantEducations)
                    .HasForeignKey(d => d.AplicantProfileId)
                    .HasConstraintName("FK__Applicant__Aplic__4D94879B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantEducations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Applicant__UserI__4CA06362");
            });

            modelBuilder.Entity<ApplicantLanguage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AplicantProfileId).HasColumnName("AplicantProfileID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.KnowledgeLevel).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AplicantProfile)
                    .WithMany(p => p.ApplicantLanguages)
                    .HasForeignKey(d => d.AplicantProfileId)
                    .HasConstraintName("FK__UserLangu__Aplic__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantLanguages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLangu__UserI__5535A963");
            });

            modelBuilder.Entity<ApplicantProfile>(entity =>
            {
                entity.ToTable("ApplicantProfile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthCountry).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthPlace).HasMaxLength(50);

                entity.Property(e => e.CurrentCountry).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PersonalNumber).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantProfiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Applicant__UserI__49C3F6B7");
            });

            modelBuilder.Entity<ApplicantSkill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AplicantProfileId).HasColumnName("AplicantProfileID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.KnowledgeLevel).HasMaxLength(50);

                entity.Property(e => e.Skill).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AplicantProfile)
                    .WithMany(p => p.ApplicantSkills)
                    .HasForeignKey(d => d.AplicantProfileId)
                    .HasConstraintName("FK__UserSkill__Aplic__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserSkill__UserI__59063A47");
            });

            modelBuilder.Entity<ApplicantWorkExperience>(entity =>
            {
                entity.ToTable("ApplicantWorkExperience");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Institution).HasMaxLength(100);

                entity.Property(e => e.Position).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.ApplicantWorkExperiences)
                    .HasForeignKey(d => d.ApplicantProfileId)
                    .HasConstraintName("FK__Applicant__Appli__6AEFE058");

                entity.HasOne(d => d.InsertByNavigation)
                    .WithMany(p => p.ApplicantWorkExperienceInsertByNavigations)
                    .HasForeignKey(d => d.InsertBy)
                    .HasConstraintName("FK__Applicant__Inser__6BE40491");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.ApplicantWorkExperienceUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK__Applicant__Updat__6CD828CA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicantWorkExperienceUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Applicant__UserI__69FBBC1F");
            });

            modelBuilder.Entity<ATS.Domain.Models.Application>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AplicantProfileId).HasColumnName("AplicantProfileID");

                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.OpenJobId).HasColumnName("OpenJobID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AplicantProfile)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.AplicantProfileId)
                    .HasConstraintName("FK__Applicati__Aplic__5FB337D6");

                entity.HasOne(d => d.ApplicationType)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ApplicationTypeId)
                    .HasConstraintName("FK__Applicati__Appli__619B8048");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Applicati__Categ__41B8C09B");

                entity.HasOne(d => d.OpenJob)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.OpenJobId)
                    .HasConstraintName("FK__Applicati__OpenJ__60A75C0F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Applicati__UserI__5EBF139D");
            });

            modelBuilder.Entity<ApplicationStatusLog>(entity =>
            {
                entity.ToTable("ApplicationStatusLOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationStatusLogs)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Applicati__Appli__54CB950F");
            });

            modelBuilder.Entity<ApplicationType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplyProccess>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.ApplyProccesses)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__ApplyProc__JobId__11D4A34F");
            });

            modelBuilder.Entity<InputControl>(entity =>
            {
                entity.ToTable("InputControl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");

                entity.Property(e => e.InputName).HasMaxLength(100);

                entity.HasOne(d => d.ApplicationType)
                    .WithMany(p => p.InputControls)
                    .HasForeignKey(d => d.ApplicationTypeId)
                    .HasConstraintName("FK__InputCont__Appli__787EE5A0");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InterviewDate).HasColumnType("datetime");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Interview__Appli__5D60DB10");
            });

            modelBuilder.Entity<InterviewDate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.InterviewId).HasColumnName("InterviewID");

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.InterviewDates)
                    .HasForeignKey(d => d.InterviewId)
                    .HasConstraintName("FK__Interview__Inter__6E8B6712");
            });

            modelBuilder.Entity<JobCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Departament).HasMaxLength(100);

                entity.Property(e => e.Division).HasMaxLength(100);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");
            });

            modelBuilder.Entity<JobLooksLog>(entity =>
            {
                entity.ToTable("JobLooksLOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobLooksLogs)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__JobLooksL__JobID__7C4F7684");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.ToTable("LoginLOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LoginLOG__UserID__7F2BE32F");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComponentName).HasMaxLength(50);

                entity.Property(e => e.Icon).HasMaxLength(100);

                entity.Property(e => e.Layout).HasMaxLength(50);

                entity.Property(e => e.MenuName).HasMaxLength(50);

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__Menus__ModuleID__12FDD1B2");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Menus__ParentID__13F1F5EB");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModuleName).HasMaxLength(50);
            });

            modelBuilder.Entity<MultiLanguage>(entity =>
            {
                entity.ToTable("MultiLanguage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.TableProcessId).HasColumnName("TableProcessID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.MultiLanguages)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK__MultiLang__Proce__09746778");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicantProfileId).HasColumnName("ApplicantProfileID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.ApplicantProfile)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ApplicantProfileId)
                    .HasConstraintName("FK__Notes__Applicant__51EF2864");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Notes__Applicati__50FB042B");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ConfrimDate).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Offer1).HasColumnName("Offer");

                entity.Property(e => e.OfferExpire).HasColumnType("datetime");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Offers__Applicat__5A846E65");
            });

            modelBuilder.Entity<OpenJob>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Departament).HasMaxLength(50);

                entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");

                entity.Property(e => e.DescriptionSr).HasColumnName("DescriptionSR");

                entity.Property(e => e.Division).HasMaxLength(50);

                entity.Property(e => e.ExperienceLevel).HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("date");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.JobLocation).HasMaxLength(100);

                entity.Property(e => e.JobName).HasMaxLength(100);

                entity.Property(e => e.JobNameEn).HasColumnName("JobNameEN");

                entity.Property(e => e.JobNameSr).HasColumnName("JobNameSR");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.RemainingDays).HasComputedColumnSql("(datediff(day,getdate(),[ExpireDate]))", false);

                entity.Property(e => e.Status)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [ExpireDate]>getdate() then 'Open' else 'Expired' end)", false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.OpenJobs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__OpenJobs__Catego__42ACE4D4");
            });

            modelBuilder.Entity<OpenJobsRequirement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.RequirementEn).HasColumnName("RequirementEN");

                entity.Property(e => e.RequirementSr).HasColumnName("RequirementSR");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.OpenJobsRequirements)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__OpenJobsR__JobID__440B1D61");
            });

            modelBuilder.Entity<OpenJobsResponsibility>(entity =>
            {
                entity.ToTable("OpenJobsResponsibility");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.ResponsibilityEn).HasColumnName("ResponsibilityEN");

                entity.Property(e => e.ResponsibilitySr).HasColumnName("ResponsibilitySR");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.OpenJobsResponsibilities)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__OpenJobsR__JobID__46E78A0C");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Question1).HasColumnName("Question");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ApplicationTypeId)
                    .HasConstraintName("FK__Questions__Appli__6477ECF3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleModule>(entity =>
            {
                entity.ToTable("RoleModule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.RoleModules)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__RoleModul__Modul__58D1301D");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleModules)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RoleModul__RoleI__57DD0BE4");
            });

            modelBuilder.Entity<UrlRoute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Url).HasMaxLength(100);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.UrlRoutes)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__UrlRoutes__MenuI__15DA3E5D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4AD4F6BFE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__3B75D760");
            });

            modelBuilder.Entity<VwGetActiveJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getActiveJobs");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Departament).HasMaxLength(50);

                entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");

                entity.Property(e => e.DescriptionSr).HasColumnName("DescriptionSR");

                entity.Property(e => e.Division).HasMaxLength(50);

                entity.Property(e => e.ExperienceLevel).HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.JobLocation).HasMaxLength(100);

                entity.Property(e => e.JobName).HasMaxLength(100);

                entity.Property(e => e.JobNameEn).HasColumnName("JobNameEN");

                entity.Property(e => e.JobNameSr).HasColumnName("JobNameSR");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.OpenJobName).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwGetAllNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getAllNotes");

                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.ApplicationType)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(101);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NoteDate).HasColumnType("date");
            });

            modelBuilder.Entity<VwGetAllUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getAllUsers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(101);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VwGetCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GetCategories");

                entity.Property(e => e.Departament).HasMaxLength(100);

                entity.Property(e => e.Division).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<VwGetInterview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getInterviews");

                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.ApplicationType)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ConfrimType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InterviewDate).HasColumnType("datetime");

                entity.Property(e => e.JobTitle).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<VwGetNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GetNotes");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<VwGetOffer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getOffers");

                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.ApplicationType)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ConfrimDate).HasColumnType("datetime");

                entity.Property(e => e.ConfrimType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobTitle).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OfferExpire).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
