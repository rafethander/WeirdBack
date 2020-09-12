using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeirdBack.Models
{
    public class WeirdBackDbContext:DbContext
    {
        public WeirdBackDbContext(DbContextOptions<WeirdBackDbContext> options):base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Exam> Exam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = Guid.NewGuid(), Header = "Peloton Is Betting You’ll Never Go Back to the Gym", Content = System.IO.File.ReadAllText(@".\Contents\PelotonIsBettingYou’llNeverGoBacktotheGym.txt") },
                new Topic { TopicId=Guid.NewGuid(),Header= "Peter Strzok Has a Warning About Russia—and Trump",Content=System.IO.File.ReadAllText(@".\Contents\PeterStrzokHasaWarningAboutRussia—andTrump.txt") },
                new Topic { TopicId=Guid.NewGuid(),Header= "Join Us for This Year's Virtual WIRED25 Celebration",Content=System.IO.File.ReadAllText(@".\Contents\JoinUsforThisYear'sVirtualWIRED25Celebration.txt") },
                new Topic { TopicId=Guid.NewGuid(),Header= "All Your Questions on Apple’s Move Away from Intel,Answered",Content=System.IO.File.ReadAllText(@".\Contents\AllYourQuestionsonApple’sMoveAwayfromIntel,Answered.txt") },
                new Topic { TopicId=Guid.NewGuid(),Header= "The 11 Best New Features in Android 11" ,Content=System.IO.File.ReadAllText(@".\Contents\The11BestNewFeaturesinAndroid11.txt") }
                );

            modelBuilder.Entity<Login>().HasData(
                new Login { LoginId=Guid.NewGuid(),Username="deneme",Password="deneme"}
                );
        }


    }
    
    
}
