using System;
using ToDoList.Library;
using Xunit;

namespace ToDoList.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test2()
        {
            Assert.True(new ToDoSomething().DoSomething(true));
        }

        [Fact]
        public void Test1()
        {
            Assert.True(new ToDoSomething().DoSomething(false));
        }
        
    }
}
