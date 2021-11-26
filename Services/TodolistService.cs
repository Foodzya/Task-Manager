using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodolistService : ITodolistService
    {
        public Task AddAsync(Todolist list)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletAsync(Todolist list)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateTitleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}