using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMovie.Models;
using WebApiMovie.Models.DTO;

namespace WebApiMovie.Controllers
{
    [RoutePrefix("api/Movies")]
    public class MoviesController : ApiController
    {
        ImdbDataEntities db = new ImdbDataEntities();

        //filmleri listeleme
        [Route("GetMovies")]
        public IHttpActionResult GetMovies()
        {
            var movies = db.Movies.Select(x => new MovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Year = x.Year,
                Rating = x.Rating
            }).ToList();

            return Json(movies);
        }
        //rastgele film getirme

        [Route("GetRandomMovie")]
        public IHttpActionResult GetRandomMovie()
        {
            try
            {
                Random rnd = new Random();
                int rastgelefilm = rnd.Next(1, db.Movies.Count() + 1);

                MovieDTO movieDTO = db.Movies.Select(x => new MovieDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Year = x.Year,
                    Rating = x.Rating
                }).FirstOrDefault(x => x.Id == rastgelefilm);
                return Json(movieDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        //puanı x den büyük olan rastgele film getirme
        [Route("GetRandomHighRatingMovie")]
        public IHttpActionResult GetRandomHighRatingMovie()
        {
            try
            {
                List<Movy> highRatingMovie = db.Movies.Where(x => x.Rating > 70).ToList();

                Random rnd = new Random();

                int rastgele = rnd.Next(1, highRatingMovie.Count());

                List<MovieDTO> movies = highRatingMovie.Select(x => new MovieDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Year = x.Year,
                    Rating = x.Rating
                }).ToList();

                return Json(movies[rastgele]);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //filmler için istenileni arama-getirme

        public IHttpActionResult GetSearchMovie(string param)
        {
            var result = db.Movies.Where(x => x.Description.Contains(param)).Select(x => new MovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Year = x.Year,
                Rating = x.Rating
            }).ToList();

            return Json(result);
        }

        //film ekleme
        [Route("PostMovie")]
        public IHttpActionResult PostMovie(MovieDTO movieDTo)
        {
            if (movieDTo != null)
            {
                Movy movy = new Movy
                {
                    Id = movieDTo.Id,
                    Title = movieDTo.Title,
                    Year = movieDTo.Year,
                    Rating = movieDTo.Rating,
                    Description = movieDTo.Description,

                };
                db.Movies.Add(movy);
                db.SaveChanges();

                return Json(movy);

            }

            else
            {
                return BadRequest();
            }
        }

    }
}

