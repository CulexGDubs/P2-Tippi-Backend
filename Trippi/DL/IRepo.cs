using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
    {
    public interface IRepo
    {
        Task<User> CreateUserAsync(User user);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip> GetTripAsync(int id);
        Task DeleteTripAsync(int id);
        Task<List<Trip>> GetAllTripsAsync();
    }
   }
