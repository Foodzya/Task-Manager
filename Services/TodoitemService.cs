using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodoitemService : ITodoitemService
    {
        private readonly ITodoitemRepository _todoitemRepo;

        public TodoitemService(ITodoitemRepository todoitemRepo)
        {
            _todoitemRepo = todoitemRepo;
        }

        public async Task AddAsync(Todoitem todoitem)
        {
            await _todoitemRepo.AddAsync(todoitem);
        }

        public async Task ChangeDeadlineDate(Todoitem todoitem, DateTime newDeadlineDate)
        {
            int idOfItem = (int)todoitem.Id;

            Todoitem updatableTodoitem = await _todoitemRepo.GetOneByIdAsync(idOfItem);

            updatableTodoitem.Deadlinedate = ToDateSqlite(newDeadlineDate);

            await _todoitemRepo.UpdateAsync(updatableTodoitem);
        }

        public async Task ChangePriority(Todoitem todoitem, Priority newPriority)
        {
            Todoitem updatableTodoitem = await _todoitemRepo.GetOneByIdAsync((int)todoitem.Id);

            updatableTodoitem.Priority = newPriority;
            updatableTodoitem.Priorityid = newPriority.Id;

            await _todoitemRepo.UpdateAsync(updatableTodoitem);
        }

        public async Task DeleteAsync(Todoitem todoitem)
        {
            await _todoitemRepo.DeleteAsync(todoitem);
        }

        public async Task<List<Todoitem>> GetAllAsync()
        {
           return await  _todoitemRepo.GetAllAsync();
        }

        public async Task<Todoitem> GetOneByIdAsync(int id)
        {
            return await _todoitemRepo.GetOneByIdAsync(id); 
        }

        public async Task ChangeExecutionStatus(Todoitem todoitem, bool isFinished)
        {
            Todoitem updatableTodoitem = await _todoitemRepo.GetOneByIdAsync((int)todoitem.Id);

            updatableTodoitem.Isfinished = isFinished ? 1 : 0;

            await _todoitemRepo.UpdateAsync(updatableTodoitem);
        }

        private string ToDateSqlite(DateTime dateTime)
        {
            string dateFormat = "yyyy-MM-dd HH:mm:ss.fff";

            return dateTime.ToString(dateFormat);
        }
    }
}