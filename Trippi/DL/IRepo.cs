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
        Task<User> AddUserAsync(User user);
        Task<User> GetOneUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<Friends> AddFriendAsync(Friends friend);
        Task DeleteUserAsync(int id); 
    }
    }
