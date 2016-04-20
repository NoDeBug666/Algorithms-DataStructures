using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四則運算_後綴表示法
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string MiddleExpression = Console.ReadLine();
                if (MiddleExpression == "") continue;
                // Output Back Exp
                Console.WriteLine("BackExpression is =>");
                string BackExpression = GetBackExpression(MiddleExpression);
                Console.WriteLine(BackExpression);
                // Output Result
                Console.WriteLine("Compute result =>");
                double result = Compute(BackExpression);
                Console.WriteLine(result);

            }
        }
        //如果要新增Express,在下面的字串加字,並在compute方法內新增該Express的運算程式碼.
        const string HighExper = "*/%";
        const string LowExper = "+-";
        
        /*
         * 在這裡運算並取得後綴表示法的字串
         * 處理程序::
         * 
         * 1.if 數字
         * 2.else if 空集合
         * 3.else if 是左括弧
         * 
         * 4.if 輸入是LowExper 而且 Peek是HighExper
         * 5.   while loop pop until Count == 0 or peek is (
         * 6.stack add 
         */
        static string GetBackExpression(string midExp)
        {
            StringBuilder sb = new StringBuilder(midExp.Length);
            string[] exp = midExp.Trim().Split(' ');
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                //數字檢查
                long temp;
                if (long.TryParse(exp[i], out temp)) { sb.Append(temp + " "); continue; }
                //Expty stack
                else if (stack.Count == 0) { stack.Push(exp[i][0]); continue; }
                //Is )
                else if (exp[i][0] == ')') 
                {
                    while (stack.Peek() != '(')
                        sb.Append(stack.Pop() + " ");
                    stack.Pop();
                    continue;
                }
                //High Check
                if(HighExper.IndexOf(stack.Peek()) != -1 && LowExper.IndexOf(exp[i][0]) != -1)
                    while (stack.Count != 0 && stack.Peek() != '(')
                        sb.Append(stack.Pop() + " ");
                
                stack.Push(exp[i][0]);
            }
            while (stack.Count != 0)
                sb.Append(stack.Pop() + " ");
            return sb.ToString();
        }
        /*
         * 在這裡運算後綴表示法的字串的內容
         * 處理程序::
         * 
         * 1.foreach expression
         * 2.  if 是數字
         * 3.  else 所有expression的計算switch
         */
        static double Compute(string backExp)
        {
            string[] exp = backExp.Trim().Split(' ');
            Stack<long> stack = new Stack<long>();
            long l;
            for (int i = 0; i < exp.Length; i++)
                if (long.TryParse(exp[i], out l))
                    stack.Push(l);
                else
                {
                    switch (exp[i][0])
                    {
                        case '+':
                            l = stack.Pop() + stack.Pop(); 
                            break;
                        case '-':
                            l = stack.Pop();
                            l = stack.Pop() - l;
                            break;
                        case '*':
                            l = stack.Pop() * stack.Pop();
                            break;
                        case '/':
                            l = stack.Pop();
                            l = stack.Pop() / l;
                            break;
                        case '%':
                            l = stack.Pop();
                            l = stack.Pop() % l;
                            break;
                        default:
                            throw new Exception("Undeclare expression " + exp[i][0]);
                    }
                    stack.Push(l);
                }
            return stack.Pop();
        }
        
    }
}
