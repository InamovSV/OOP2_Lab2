using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2
{
    public class ControlUnit
    {
        private List<ICommand> commands = new List<ICommand>();
        private int current = 0;
        public void StoreCommand(ICommand command)
        {
            commands = commands.Take(current).ToList();
            commands.Add(command);
        }
        public void ExecuteCommand()
        {
            commands[current].Execute();
            current++;
        }
        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (current > 0)
                    commands[--current].UnExecute();
        }
        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (current < commands.Count)
                    commands[current++].Execute();
        }
    }
}
