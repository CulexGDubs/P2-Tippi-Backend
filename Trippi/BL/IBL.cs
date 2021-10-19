using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace TrippiBL
    {
    public interface IBL
    {
        Task<User> CreateUserAsync(User user);
        Task<Trip> CreateTripAsync(Trip trip);
    }
}
