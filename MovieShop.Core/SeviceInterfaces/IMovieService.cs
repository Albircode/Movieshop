﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.models;
using MovieShop.Core.models.Request;
using MovieShop.Core.models.Response;


namespace MovieShop.Core.SeviceInterfaces
{
   public interface IMovieService
    {
        Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "");
        Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0);
        Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId);

        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id);

        Task<int> GetMoviesCount(string title = "");
        Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies();
        Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId);

        Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest);
        Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest);
    }
}
