using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QandA_App.DataLayer
{
    public class QandABagContext : DbContext
    {
        public QandABagContext(): base("name=QandAConnectionString")
        {
        }

        public DbSet<User> Users { get; set; } // Represent user Table in DB
        public DbSet<Question> Questions { get; set; } // Represent question Table in DB
        public DbSet<Answer> Answres { get; set; } // Represent Answer Table in DB
    

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //setting UserId as primarykey
        modelBuilder.Entity<User>().HasKey(c => c.UserId);

        // FLUENT API Validations for Users Table
        modelBuilder.Entity<User>()
            .Property(c => c.UserName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnAnnotation(
            "Index",
             new IndexAnnotation(new IndexAttribute("IX_UserName") { IsUnique = true}));

            modelBuilder.Entity<User>()
            .Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(25);

            modelBuilder.Entity<User>()
            .Property(s => s.LastName)
            .HasMaxLength(25);

            modelBuilder.Entity<User>()
            .Property(s => s.Email)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(s => s.DOB)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(s => s.Password)
            .IsRequired()
            .HasMaxLength(16);
            


            //setting QuestionId as primarykey
            modelBuilder.Entity<Question>().HasKey(q => q.QuestionId);

            // FLUENT API Validations for Question Table
            modelBuilder.Entity<Question>()
           .Property(q => q.Title)
           .IsRequired()
           .HasMaxLength(5000);

            modelBuilder.Entity<Question>()
            .Property(q => q.Description)
            .IsRequired()
            .HasMaxLength(10000);

            modelBuilder.Entity<Question>()
            .Property(q => q.Status)
            .IsRequired();


            modelBuilder.Entity<Question>()
            .Property(q => q.DateTimeAsked)
            .IsRequired();


            modelBuilder.Entity<Question>()
            .Property(q => q.AnswerCount)
            .IsRequired();


            //setting UserId as primarykey
            modelBuilder.Entity<Answer>().HasKey(c => c.AnswerId);

            // FLUENT API Validations for Answers table
            modelBuilder.Entity<Answer>()
            .Property(a => a.AnswerDetails)
            .IsRequired();
            

            modelBuilder.Entity<Answer>()
            .Property(a => a.DateTimeAnswered)
            .IsRequired();

            modelBuilder.Entity<Answer>()
            .Property(a => a.QuestionId)
            .IsRequired();

            // Relationships in Fluent setting QuestionId as foreignkey
            modelBuilder.Entity<Answer>()
            .HasRequired(q => q.Question)
            .WithMany(a => a.Answers)
            .HasForeignKey(a => a.QuestionId);

        }
} 

}