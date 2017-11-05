using _GenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zadatak
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            //if (initialDbState != null)
            //{
            //    _inMemoryTodoDatabase = initialDbState;
            //}
            //else
            //{
            //    _inMemoryTodoDatabase = new GenericList<TodoItem>();
            //}
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will
            //return y.
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.Select(i => i).OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func <TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction (i) == true).ToList();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(i => i.Id == todoId).FirstOrDefault(); 
        }
        
        public TodoItem Add(TodoItem todoItem)
        {
            TodoItem item =this.Get(todoItem.Id);

            if (item == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                throw new DuplicateTodoItemException("Duplicate Id: {todoItem.Id}");
            }
        }

        public bool Remove (Guid guid)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(i => i.Id == guid).FirstOrDefault();

            if (item == null)
            {
                return false;
            }
            else
            {
                _inMemoryTodoDatabase.Remove(item);
                return true;
            }
        }

        public TodoItem Update(TodoItem todoItem)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(i => i.Id == todoItem.Id).FirstOrDefault();

            if (item != null)
            {
                this.Remove(item.Id);
            }

            return this.Add(todoItem);
        }

        public bool MarkAsCompleted(Guid guid)
        {
            TodoItem item = _inMemoryTodoDatabase.Where(i => i.Id == guid).FirstOrDefault();

            if (item == null)
            {
                return false;
            }
            else
            {
                this.Update(item);
                return true;
            }
        }

    }
}
