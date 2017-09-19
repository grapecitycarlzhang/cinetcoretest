using System;

namespace ToDoList.Library
{
    public class ToDoSomething
    {
        public bool DoSomething(bool success)
        {
            if (!success)
            {
                return DoSomething();
            }
            return success;
        }
        bool DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
