﻿using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MovieShop.Core.models.Request
{
    public class MovieCreateRequest
    {
        public string Title { get; set; }

        public string Overview { get; set; }

        public string Tagline { get; set; }

        public decimal? Budget { get; set; }

        public decimal? Revenue { get; set; }

        public string ImdbUrl { get; set; }

        public string TmdbUrl { get; set; }

        public string PosterUrl { get; set; }

        public string BackdropUrl { get; set; }

        public string OriginalLanguage { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? RunTime { get; set; }

        public decimal? Price { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatedBy { get; set; }



        //one movie can have multiple trailers

        public ICollection<Trailer> Trailers { get; set; }



        //the navigation property of movie+genre will automatically create a junction table for genre and movie

        public ICollection<Genre> Genres { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }

        public ICollection<MovieCrew> MovieCrews { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}