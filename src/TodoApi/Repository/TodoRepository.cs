using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> todos = new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            todos[item.Key] = item;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            todos[item.Key] = item;
        }
    }
}
