using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFirstVersion
{
    internal class CommandBlock
    {
        public enum CommandBlockType
        {
            Command,
            If,
            Else,
            While
        }

        public CommandBlockType Type { get; }
        public string Value { get; }
        public List<CommandBlock> NestedBlocks { get; }

        public CommandBlock(CommandBlockType type, string value)
        {
            Type = type;
            Value = value;
            NestedBlocks = new List<CommandBlock>();
        }
        

        //public override string ToString()
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"if({Condition}) {{");
        //    foreach (var command in Commands)
        //    {
        //        sb.AppendLine($"    {command}");
        //    }
        //    sb.AppendLine("}");
        //    return sb.ToString();
        //}

    }
}
