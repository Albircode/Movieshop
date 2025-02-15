﻿using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
   public class MovieRepository : EtRepository<Movie>,IMovieRepository
    {
        public MovieRepository(MovieDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _DBContext.Movie.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();
            return movies;
        }
        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _DBContext.Movie
                                        .Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres)
                                        .ThenInclude(m => m.Name)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = await _DBContext.Review.Where(r => r.MovieId == id).DefaultIfEmpty()
                                              .AverageAsync(r => r == null ? 0 : r.Rating);
            //if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        }
    }
}
