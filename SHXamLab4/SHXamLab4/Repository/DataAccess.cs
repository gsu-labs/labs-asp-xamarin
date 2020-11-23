using System;
using System.Collections.Generic;
using System.Text;

namespace SHXamLab4.Repository
{
    public class DataAccess
    {
        private MovieRepository movieRepository;
        public MovieRepository Movie { get => movieRepository; private set => movieRepository = value; }
        private SellRepository sellRepository;
        public SellRepository Sell { get => sellRepository; private set => sellRepository = value; }
        private CinemaRepository cinemaRepository;
        public CinemaRepository Cinema { get => cinemaRepository; private set => cinemaRepository = value; }

        public DataAccess(string datePath)
        {
            MovieRepository movieRepository = new MovieRepository(datePath);
            this.movieRepository = movieRepository;
            SellRepository sellRepository = new SellRepository(datePath);
            this.sellRepository = sellRepository;
            CinemaRepository cinemaRepository = new CinemaRepository(datePath);
            this.cinemaRepository = cinemaRepository;
        }
    }
}
