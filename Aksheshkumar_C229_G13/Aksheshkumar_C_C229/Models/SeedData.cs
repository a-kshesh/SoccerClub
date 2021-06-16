using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                    new Club()
                    {
                        Name = "FC Barcelona",
                        About = "Fútbol Club Barcelona, often known simply as Barcelona and informally as Barça, is a Spanish professional football club based in Barcelona, Spain. FC Barcelona is the world's second richest football club in terms of revenue, with an annual turn-over of €366 million.",
                        Country = "Barcelona, Spain",
                        CreatedOn = new DateTime(1995, 10, 24),
                        NumOfFans = 14000000,
                        NumOfTrofies = 6,
                        Revenue = 2300000
                    },
                    new Club()
                    {
                        Name = "Internazionale Milano",
                        About = "Fútbol Club Milano, often known simply as Barcelona and informally as Barça, is a Spanish professional football club based in Barcelona, Spain. FC Barcelona is the world's second richest football club in terms of revenue, with an annual turn-over of €366 million.",
                        Country = "Milano, Italy",
                        CreatedOn = new DateTime(1995, 10, 24),
                        NumOfFans = 9000000,
                        NumOfTrofies = 5,
                        Revenue = 2100000
                    },
                    new Club()
                    {
                        Name = "Estudiantes De La Plata",
                        About = "Fútbol Club Milano, often known simply as Barcelona and informally as Barça, is a Spanish professional football club based in Barcelona, Spain. FC Barcelona is the world's second richest football club in terms of revenue, with an annual turn-over of €366 million.",
                        Country = "La Plata, Argentine",
                        CreatedOn = new DateTime(1996, 4, 10),
                        NumOfFans = 11000000,
                        NumOfTrofies = 5,
                        Revenue = 3200000
                    },
                    new Club()
                    {
                        Name = "Bayern Munich",
                        About = "Fútbol club milano, often known simply as barcelona and informally as barça, is a spanish professional football club based in barcelona, spain. fc barcelona is the world's second richest football club in terms of revenue, with an annual turn-over of €366 million.",
                        Country = "Munich, Germany",
                        CreatedOn = new DateTime(2000, 9, 12),
                        NumOfFans = 17000000,
                        NumOfTrofies = 7,
                        Revenue = 3300000
                    }
                );
                
            }
            if (!context.Players.Any()) {
                context.Players.AddRange(
                    new Player
                    {
                        Name = "Lionel Messi",
                        Country = "Spain",
                        Dob = new DateTime(1989, 11, 12),
                        Goals = 43,
                        Salary = 2345232,
                        ClubId = null
                    },
                    new Player
                    {
                        Name = "Cristiano Ronaldo",
                        Country = "Portugal",
                        Dob = new DateTime(1987, 2, 9),
                        Goals = 31,
                        Salary = 4500000,
                        ClubId = null
                    },
                    new Player
                    {
                        Name = "Pele",
                        Country = "Brazil",
                        Dob = new DateTime(1940, 10, 23),
                        Goals = 23,
                        Salary = 5500000,
                        ClubId = null
                    },
                    new Player
                    {
                        Name = "David Beckham",
                        Country = "United Kingdom",
                        Dob = new DateTime(1975, 2, 5),
                        Goals = 73,
                        Salary = 5600000,
                        ClubId = null
                    }
                );
            }
            context.SaveChanges();
        }
    }
}

