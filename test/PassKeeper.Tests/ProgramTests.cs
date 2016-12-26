using System;
using Xunit;
using PassKeeper;

namespace PassKeeper.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void should_resolve_list_command() 
        {
            var cmd = Program.GetCommandType("list");            
            Assert.Equal(CommandType.List, cmd);
        }

        [Fact]
        public void should_resolve_add_command() 
        {
            var cmd = Program.GetCommandType("add");            
            Assert.Equal(CommandType.Add, cmd);
        }

        [Fact]
        public void should_resolve_get_command() 
        {
            var cmd = Program.GetCommandType("get");            
            Assert.Equal(CommandType.Get, cmd);
        }

        [Fact]
        public void should_resolve_update_command() 
        {
            var cmd = Program.GetCommandType("update");            
            Assert.Equal(CommandType.Update, cmd);
        }

        [Fact]
        public void should_resolve_delete_command() 
        {
            var cmd = Program.GetCommandType("delete");            
            Assert.Equal(CommandType.Delete, cmd);
        }
    }
}
