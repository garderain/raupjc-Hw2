using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2.zadatak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _GenericList;

namespace _2.zadatak.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod()]
        public void MarkAsCompletedTodoItem()
        {
            TodoItem item = new TodoItem("First");
            item.MarkAsCompleted();
            Assert.AreEqual<bool>(false, item.MarkAsCompleted());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<TodoItem> list = new List<TodoItem>();
            list.Add(new TodoItem("First"));
            list.Add(new TodoItem("Second"));
            list.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository();
            foreach (TodoItem item in list)
            {
                database.Add(item);
            }
            List<TodoItem> returned = database.GetAll();
            bool value = list[0].Equals(returned[0]) && list[1].Equals(returned[1]) && list[2].Equals(returned[2]) && returned.Count()==3;
            Assert.AreEqual<bool>(true, value);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            List<TodoItem> list = new List<TodoItem>();
            list.Add(new TodoItem("First"));
            list.Add(new TodoItem("Second"));
            list.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository();
            foreach (TodoItem item in list)
            {
                database.Add(item);
            }
            List<TodoItem> returned = database.GetActive();
            bool value = list[0].Equals(returned[0]) && list[1].Equals(returned[1]) && list[2].Equals(returned[2]) && returned.Count()==3;
            Assert.AreEqual<bool>(true, value);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            List<TodoItem> list = new List<TodoItem>();
            list.Add(new TodoItem("First"));
            list.Add(new TodoItem("Second"));
            list.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository();
            foreach (TodoItem item in list)
            {
                database.Add(item);
            }
            TodoItem todoItem = new TodoItem("Fourth");
            todoItem.MarkAsCompleted();
            database.Add(todoItem);
            List<TodoItem> returned = database.GetCompleted();
            bool value = todoItem.Equals(returned[0]) && returned.Count()==1;
            Assert.AreEqual<bool>(true, value);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            List<TodoItem> list = new List<TodoItem>();
            list.Add(new TodoItem("First"));
            list.Add(new TodoItem("Second"));
            list.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository();
            foreach (TodoItem item in list)
            {
                database.Add(item);
            }
            TodoItem todoItem = new TodoItem("Fourth");
            todoItem.MarkAsCompleted();
            database.Add(todoItem);
            List<TodoItem> returned = database.GetFiltered(item=>item==todoItem);
            bool value = todoItem.Equals(returned[0]) && returned.Count() == 1;
            Assert.AreEqual<bool>(true, value);
        }

        [TestMethod()]
        public void GetTest()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            database.Add(todoItem);
            TodoItem returned = database.Get(todoItem.Id);
            Assert.AreEqual<TodoItem>(todoItem, returned);
        }

        [TestMethod()]
        public void GetTestFail()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            TodoItem returned = database.Get(todoItem.Id);
            Assert.AreEqual<TodoItem>(null, returned);
        }

        [TestMethod()]
        public void AddTest()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            TodoItem returned = database.Add(todoItem);

            Assert.AreEqual<TodoItem>(todoItem, returned);
        }

        [TestMethod()]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddTestFail()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            database.Add(todoItem);
            TodoItem returned = database.Add(todoItem);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            database.Add(todoItem);
            bool returned = database.Remove(todoItem.Id);
            Assert.AreEqual<bool>(true,returned);
        }

        [TestMethod()]
        public void RemoveTestFail()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            bool returned = database.Remove(todoItem.Id);
            Assert.AreEqual<bool>(false, returned);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            database.Add(todoItem);
            todoItem.MarkAsCompleted();
            TodoItem returned = database.Update(todoItem);
            Assert.AreEqual<TodoItem>(todoItem, returned);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            database.Add(todoItem);
            bool returned = database.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual<bool>(true,returned);
        }

        [TestMethod()]
        public void MarkAsCompletedTestFail()
        {
            GenericList<TodoItem> initial = new GenericList<TodoItem>();
            initial.Add(new TodoItem("First"));
            initial.Add(new TodoItem("Second"));
            initial.Add(new TodoItem("Third"));
            TodoRepository database = new TodoRepository(initial);
            TodoItem todoItem = new TodoItem("Fourth");
            bool returned = database.MarkAsCompleted(todoItem.Id);
            Assert.AreEqual<bool>(false, returned);
        }
    }
}