using System;

namespace Examples.TodoList.Scripts
{
    public class Todo
    {
        public string guid { get; }
        public string message { get; set; }
        public bool isDone { get; set; }

        public Todo(string message)
        {
            this.guid = Guid.NewGuid().ToString();
            this.message = message;
            this.isDone = false;
        }

        public Todo(string message, bool isDone)
        {
            this.guid = Guid.NewGuid().ToString();
            this.message = message;
            this.isDone = isDone;
        }
    }
}