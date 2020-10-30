using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }


        //public void AddRange(IEnumerable<string> collection)
        //{

        //    foreach (var element in collection)
        //    {
        //        stack.Push(element);
        //    } 
        //}


        public void AddRange(Stack<string> stackString)
        {
            while (stackString.Count > 0)
            {
                stack.Push(stackString.Pop());
            }
        }
    }
}
