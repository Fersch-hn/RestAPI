using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Repository
{
    public interface ICRMRepository
    {
        Task<List<ClientCategory>> GetClientCategories();

        Task<ClientCategory> GetClientCategory(int id);

        Task<ClientCategory> PostClientCategory(ClientCategory category);

        Task<ClientCategory> UpdateClientCategory(ClientCategory category);

        Task<bool> DeleteClientCategory(ClientCategory category);
    }
}
