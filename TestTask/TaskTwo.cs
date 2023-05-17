using System;
using System.Collections.Generic;

namespace TestTask
{
    public class TaskTwo
    {
        public static string GetInfixForm(string postfix)
        {
            var postfixTokens = postfix.Split(' ');

            var infixStack = new Stack<Middleware>();

            foreach (string token in postfixTokens)
            {
                if (token == "+" || token == "-")
                {
                    var rightIntermediate = infixStack.Pop();
                    var leftIntermediate = infixStack.Pop();

                    var newExpr = leftIntermediate.Expression + token + rightIntermediate.Expression;
                    infixStack.Push(new Middleware(newExpr, token));
                }
                else if (token == "*" || token == "/")
                {
                    string leftExpr, rightExpr;

                    var rightIntermediate = infixStack.Pop();
                    if (rightIntermediate.Operator == "+" || rightIntermediate.Operator == "-")
                    {
                        rightExpr = "(" + rightIntermediate.Expression + ")";
                    }
                    else
                    {
                        rightExpr = rightIntermediate.Expression;
                    }

                    var leftIntermediate = infixStack.Pop();
                    if (leftIntermediate.Operator == "+" || leftIntermediate.Operator == "-")
                    {
                        leftExpr = "(" + leftIntermediate.Expression + ")";
                    }
                    else
                    {
                        leftExpr = leftIntermediate.Expression;
                    }

                    var newExpr = leftExpr + token + rightExpr;

                    infixStack.Push(new Middleware(newExpr, token));
                }
                else
                {
                    infixStack.Push(new Middleware(token, ""));
                }
            }

            return infixStack.Peek().Expression;
        }

        public static double Calculate(string input)
        {
            double result = Counting(input);
            return result; 
        }


        private static double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i])) 
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) 
                    {
                        case '+': 
                            result = b + a;
                            break;
                        case '-': 
                            result = b - a;
                            break;
                        case '*': 
                            result = b * a;
                            break;
                        case '/': 
                            result = b / a;
                            break;
                        case '^':
                            result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString());
                            break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }

        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
            {
                return true;
            }
            return false;
        }
        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
            {
                return true;
            }
            return false;
        }
    }
}
