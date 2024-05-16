using Microsoft.EntityFrameworkCore;

namespace Assignment01.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Subject configuration
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectCode)
                    .HasName("PK_Subject");

                entity.ToTable("Subject");

                entity.Property(e => e.SubjectCode)
                    .HasColumnName("SubjectCode")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.SubjectName)
                    .HasColumnName("SubjectName")
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // Instructor configuration
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.TeacherCode)
                    .HasName("PK_Instructor");

                entity.ToTable("Instructor");

                entity.Property(e => e.TeacherCode)
                    .HasColumnName("TeacherCode")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.FullName)
                    .HasColumnName("FullName")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(15);
            });

            // InstructorSubject configuration
            modelBuilder.Entity<InstructorSubject>(entity =>
            {
                entity.HasKey(e => new { e.TeacherCode, e.SubjectCode })
                    .HasName("PK_InstructorSubject");

                entity.ToTable("InstructorSubject");

                entity.Property(e => e.TeacherCode).HasColumnName("TeacherCode");
                entity.Property(e => e.SubjectCode).HasColumnName("SubjectCode");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.InstructorSubjects)
                    .HasForeignKey(d => d.TeacherCode)
                    .HasConstraintName("FK_InstructorSubject_Instructor");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.InstructorSubjects)
                    .HasForeignKey(d => d.SubjectCode)
                    .HasConstraintName("FK_InstructorSubject_Subject");
            });

            // Student configuration
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentCode)
                    .HasName("PK_Student");

                entity.ToTable("Student");

                entity.Property(e => e.StudentCode)
                    .HasColumnName("StudentCode")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.FullName)
                    .HasColumnName("FullName")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DateOfBirth")
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .HasColumnName("Gender")
                    .IsRequired();

                entity.Property(e => e.Course)
                    .HasColumnName("Course")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.StillStudying)
                    .HasColumnName("StillStudying")
                    .IsRequired();
            });

            // Transcript configuration
            modelBuilder.Entity<Transcript>(entity =>
            {
                entity.HasKey(e => new { e.StudentCode, e.SubjectCode })
                    .HasName("PK_Transcript");

                entity.ToTable("Transcript");

                entity.Property(e => e.StudentCode).HasColumnName("StudentCode");
                entity.Property(e => e.SubjectCode).HasColumnName("SubjectCode");

                entity.Property(e => e.HighestScore)
                    .HasColumnName("HighestScore")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValue(0);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Transcripts)
                    .HasForeignKey(d => d.StudentCode)
                    .HasConstraintName("FK_Transcript_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Transcripts)
                    .HasForeignKey(d => d.SubjectCode)
                    .HasConstraintName("FK_Transcript_Subject");
            });
        }
    }
}
