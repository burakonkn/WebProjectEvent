using Microsoft.EntityFrameworkCore;

namespace WebProjectEvent.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<UserEvent> UserEvents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>().HasData(
            new Admin()
            {
                AdminId = 1,
                AdminUsername = "Burka",
                AdminMail = "burka@gmail.com",
                AdminPassword = "1234"
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Teknoloji",
                    CategoryUrl = "teknoloji"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Müzik",
                    CategoryUrl = "müzik"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Sanat",
                    CategoryUrl = "sanat"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "İş & Kariyer",
                    CategoryUrl = "is-kariyer"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Spor",
                    CategoryUrl = "spor"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Eğitim",
                    CategoryUrl = "egitim"
                }
            }
        );

        modelBuilder.Entity<Location>().HasData(
            new List<Location>()
            {
                new Location()
                {
                    LocationId = 1,
                    LocationName = "İstanbul",
                    LocationUrl = "istanbul"
                },
                new Location()
                {
                    LocationId = 2,
                    LocationName = "Ankara",
                    LocationUrl = "ankara"
                },
                new Location()
                {
                    LocationId = 3,
                    LocationName = "İzmir",
                    LocationUrl = "izmir"
                },
                new Location()
                {
                    LocationId = 4,
                    LocationName = "Bursa",
                    LocationUrl = "bursa"
                },
                new Location()
                {
                    LocationId = 5,
                    LocationName = "Antalya",
                    LocationUrl = "antalya"
                }
            }
        );

        modelBuilder.Entity<Event>().HasData(
            new List<Event>()
            {
                new Event()
                {
                    EventId = 1,
                    EventName = "Teknoloji Zirvesi 2024",
                    EventDescription = "Geleceğin teknolojileri ve yenilikçi çözümler üzerine kapsamlı konferans.",
                    EventLocation = "İstanbul Kongre Merkezi",
                    EventImage = "event1.jpg",
                    EventPrice = 250,
                    EventSubscriber =  500,
                    EventDate = new DateOnly(2025, 06, 15),
                    EventTime = "09:00 - 18:00",
                    EventIsActive = true,
                    EventIsHome = true,
                    CategoryId = 1,
                    LocationId = 1
                },
                new Event()
                {
                    EventId = 2,
                    EventName = "Müzik Festivali",
                    EventDescription = "Yaz aylarının en büyük müzik festivali, 3 gün boyunca eğlence.",
                    EventLocation = "İzmir Kültürpark",
                    EventImage = "event2.jpg",
                    EventPrice = 450,
                    EventSubscriber = 2000,
                    EventDate = new DateOnly(2025, 07, 20),
                    EventTime = "18:00 - 23:00",
                    EventIsActive = true,
                    EventIsHome = true,
                    CategoryId = 2,
                    LocationId = 3
                },
                new Event()
                {
                    EventId = 3,
                    EventName = "Sanat Sergisi",
                    EventDescription = "Çağdaş sanat eserlerinin sergileneceği özel etkinlik.",
                    EventLocation = "Ankara Sanat Galerisi",
                    EventImage = "event3.jpg",
                    EventPrice = 0,
                    EventSubscriber = 150,
                    EventDate = new DateOnly(2025, 08, 05),
                    EventTime = "10:00 - 18:00",
                    EventIsActive = true,
                    EventIsHome = true,
                    CategoryId = 3,
                    LocationId = 2
                },
                new Event()
                {
                    EventId = 4,
                    EventName = "Dijital Pazarlama Eğitimi",
                    EventDescription = "Sosyal medya ve dijital pazarlama stratejileri üzerine workshop.",
                    EventLocation = "Bursa Teknopark",
                    EventImage = "event4.jpg",
                    EventPrice = 350,
                    EventSubscriber = 100,
                    EventDate = new DateOnly(2025, 07, 08),
                    EventTime = "13:00 - 17:00",
                    EventIsActive = true,
                    EventIsHome = true,
                    CategoryId = 6,
                    LocationId = 4
                }
            }

        );

    }
}