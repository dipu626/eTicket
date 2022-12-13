﻿using eticket.Models;
using Microsoft.EntityFrameworkCore;

namespace eticket.Data
{
    public class AppDbInitializer
    {
        public static void Delete(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureDeleted();
            }
        }

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>
                    {
                        new Cinema
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first Cinema."
                        },
                        new Cinema
                        {
                            Name = "Cinema 2",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second Cinema."
                        },
                        new Cinema
                        {
                            Name = "Cinema 3",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third Cinema."
                        },
                        new Cinema
                        {
                            Name = "Cinema 4",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the fourth Cinema."
                        },
                        new Cinema
                        {
                            Name = "Cinema 5",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the fifth Cinema."
                        },
                        new Cinema
                        {
                            Name = "Cinema 6",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-6.jpeg",
                            Description = "This is the description of the sixth Cinema."
                        },
                    });
                    context.SaveChanges();
                }
                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>
                    {
                        new Actor
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of first actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of second actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of third actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of fourth actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of fifth actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                // Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>
                    {
                        new Producer
                        {
                            FullName = "Producer 1",
                            Bio = "This is the bio of producer 1",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-1.jpeg",
                        },
                        new Producer
                        {
                            FullName = "Producer 2",
                            Bio = "This is the bio of producer 2",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-2.jpeg",
                        },
                        new Producer
                        {
                            FullName = "Producer 3",
                            Bio = "This is the bio of producer 3",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-3.jpeg",
                        },
                        new Producer
                        {
                            FullName = "Producer 4",
                            Bio = "This is the bio of producer 4",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-4.jpeg",
                        },
                        new Producer
                        {
                            FullName = "Producer 5",
                            Bio = "This is the bio of producer 5",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-5.jpeg",
                        },
                    });
                    context.SaveChanges();
                }
                // Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>
                    {
                        new Movie
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Documentary
                        },
                        new Movie
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Action
                        },
                        new Movie
                        {
                            Name = "Ghost",
                            Description = "This is the description of Ghost movie description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-4",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = Enums.MovieCategory.Horror
                        },
                        new Movie
                        {
                            Name = "Scoob",
                            Description = "This is the description of Scoob movie description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-77.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Cartoon
                        },
                        new Movie
                        {
                            Name = "Cold Soles",
                            Description = "This is the description of Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = Enums.MovieCategory.Drama
                        }
                    });

                    context.SaveChanges();
                }
                // Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>
                    {
                        new Actor_Movie
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie
                        {
                            ActorId = 2,
                            MovieId = 1
                        },
                        new Actor_Movie
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new Actor_Movie
                        {
                            ActorId = 3,
                            MovieId = 2
                        },
                        new Actor_Movie
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie
                        {
                            ActorId = 4,
                            MovieId = 2
                        },
                        new Actor_Movie
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                        new Actor_Movie
                        {
                            ActorId = 4,
                            MovieId = 4
                        },
                        new Actor_Movie
                        {
                            ActorId = 5,
                            MovieId = 2
                        },
                        new Actor_Movie
                        {
                            ActorId = 5,
                            MovieId = 3
                        },
                        new Actor_Movie
                        {
                            ActorId = 5,
                            MovieId = 4
                        },
                        new Actor_Movie
                        {
                            ActorId = 5,
                            MovieId = 5
                        },
                        //new Actor_Movie
                        //{
                        //    ActorId = 6,
                        //    MovieId = 3
                        //},
                        //new Actor_Movie
                        //{
                        //    ActorId = 6,
                        //    MovieId = 4
                        //},
                        //new Actor_Movie
                        //{
                        //    ActorId = 6,
                        //    MovieId = 5
                        //},
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}