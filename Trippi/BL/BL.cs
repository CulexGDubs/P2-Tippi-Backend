using System;
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
    }
}
