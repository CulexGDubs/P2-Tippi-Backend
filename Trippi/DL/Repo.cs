using System;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DL
    {
    public class Repo : IRepo
    {
        private DBContext _context;
        public Repo(DBContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return user;
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            await _context.AddAsync(trip);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return trip;
        }

        public async Task<Trip> GetTripAsync(int Id)
        {
            return await _context.Trips.FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task DeleteTripAsync(int id)
        {
            _context.Trips.Remove(await GetTripAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Rating> GetRatingAsync(int Id)
        {
            return await _context.Ratings.FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<Rating> CreateRatingAsync(Rating rating)
        {
            await _context.AddAsync(rating);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return rating;
        }

        public async Task DeleteRatingAsync(int id)
        {
            _context.Ratings.Remove(await GetRatingAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<List<Rating>> GetAllRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }
    }
}
