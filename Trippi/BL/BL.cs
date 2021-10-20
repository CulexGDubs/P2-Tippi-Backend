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

        public async Task<User> AddUserAsync(User user)
        {
            return await _repo.AddUserAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _repo.GetAllUsersAsync();
        }

        public async Task<User> GetOneUserByIdAsync(int id)
        {
            return await _repo.GetOneUserByIdAsync(id);
        }

        public async Task<Friends> AddFriendAsync(Friends friend)
        {
            return await _repo.AddFriendAsync(friend);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteUserAsync(id);
        }

    }
}
