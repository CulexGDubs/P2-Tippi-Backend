using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace TrippiBL
    {
    public class BL : IBL


    {
        private readonly IRepo _repo;
        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _repo.CreateUserAsync(user);
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            return await _repo.CreateTripAsync(trip);
        }

        public async Task<Trip> GetTripAsync(int id)
        {
            return await _repo.GetTripAsync(id);
        }

        public async Task DeleteTripAsync(int id)
        {
            await _repo.DeleteTripAsync(id);
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _repo.GetAllTripsAsync();
        }
    }
}
