using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Balance
{
    public static void Main()
    {
        string s = Console.ReadLine();
        List<char> checkedCharacters = new List<char>();

        Stack<char> stack = new Stack<char>();

       
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            //Takes a character from the string.
        
            if (c == '(' || c == '[')
            {
                stack.Push(c);
                //If character is an open bracket, it gets pushed into the stack.
                Console.WriteLine("Pushed, current count is " + stack.Count + "The current value is " + stack.Peek());
            }
            else if (c == ')' || c == ']' && stack.Count != 0)
            {
                //If a character is a closed bracket and a value exists in the stack, we check the stack for a matching open bracket.
                for (int j = 0; j < stack.Count; j++)
                {
                    char d = stack.Pop();
                    //Pop the items in the stack and reference them against the closed bracket.
                    if ((c == ')' && d == '(') || c == ']' && d == '[')
                    {
                        Console.WriteLine("Popped, current count is " + stack.Count + checkedCharacters.Count);
                        //If the brackets match, the loop continues on to the next character in the string. C is then cleared.
                        c = ' ';
                        continue;
                    }
                    else
                    {
                        //If the brackets don't match, the bracket is added onto a list and later pushed again into the stack.
                        checkedCharacters.Add(d);
                    }
                }
                foreach (char d in checkedCharacters)
                {
                    stack.Push(d);
                }
                checkedCharacters.Clear();
                //List of checked brackets resets once the matching bracket is found or all items in the list are returned into the stack.
            }
            else if (c == ']' || c == ')' && stack.Count == 0)
            {
                //If the stack count is equal to 0 and we recieve a closed bracket, the brackets are not balanced.
                Console.WriteLine("0");
                return;
            }
        }
        
        if (stack.Count == 0)
        {
            //If the stack is empty (I.e. we have balanced all the brackets into pairs) we return 1.
            Console.WriteLine("1");
        }
        else
        {
            //Otherwise, we return 0, along with the number of items in the stack.
            Console.WriteLine("0");
            Console.WriteLine("Current stack count is " + stack.Count);
        }
    }
}



