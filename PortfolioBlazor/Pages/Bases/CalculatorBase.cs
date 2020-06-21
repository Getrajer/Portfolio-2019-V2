using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlazor.Pages.Bases
{
    public class CalculatorBase : ComponentBase
    {

        public class StringToFormula
        {
            private string[] _operators = { "-", "+", "/", "*","^"};
            private  Func<double, double, double>[] _operations = {
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => a1 * a2,
            (a1, a2) => Math.Pow(a1, a2)
        };

    public double Eval(string expression)
    {
        List<string> tokens = getTokens(expression);
        Stack<double> operandStack = new Stack<double>();
        Stack<string> operatorStack = new Stack<string>();
        int tokenIndex = 0;

        while (tokenIndex < tokens.Count) {
            string token = tokens[tokenIndex];
            if (token == "(") {
                string subExpr = getSubExpression(tokens, ref tokenIndex);
                operandStack.Push(Eval(subExpr));
                continue;
            }
            if (token == ")") {
                throw new ArgumentException("Mis-matched parentheses in expression");
            }
            //If this is an operator  
            if (Array.IndexOf(_operators, token) >= 0) {
                while (operatorStack.Count > 0 && Array.IndexOf(_operators, token) < Array.IndexOf(_operators, operatorStack.Peek())) {
                    string op = operatorStack.Pop();
                    double arg2 = operandStack.Pop();
                    double arg1 = operandStack.Pop();
                    operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
                }
                operatorStack.Push(token);
            } else {
                operandStack.Push(double.Parse(token));
            }
            tokenIndex += 1;
        }

        while (operatorStack.Count > 0) {
            string op = operatorStack.Pop();
            double arg2 = operandStack.Pop();
            double arg1 = operandStack.Pop();
            operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
        }
        return operandStack.Pop();
    }

    private string getSubExpression(List<string> tokens, ref int index)
    {
        StringBuilder subExpr = new StringBuilder();
        int parenlevels = 1;
        index += 1;
        while (index < tokens.Count && parenlevels > 0) {
            string token = tokens[index];
            if (tokens[index] == "(") {
                parenlevels += 1;
            }

            if (tokens[index] == ")") {
                parenlevels -= 1;
            }

            if (parenlevels > 0) {
                subExpr.Append(token);
            }

            index += 1;
        }

        if ((parenlevels > 0)) {
            throw new ArgumentException("Mis-matched parentheses in expression");
        }
        return subExpr.ToString();
    }

    private List<string> getTokens(string expression)
    {
        string operators = "()^*/+-";
        List<string> tokens = new List<string>();
        StringBuilder sb = new StringBuilder();

        foreach (char c in expression.Replace(" ", string.Empty)) {
            if (operators.IndexOf(c) >= 0) {
                if ((sb.Length > 0)) {
                    tokens.Add(sb.ToString());
                    sb.Length = 0;
                }
                tokens.Add(c.ToString());
            } else {
                sb.Append(c);
            }
        }

        if ((sb.Length > 0)) {
            tokens.Add(sb.ToString());
        }
            return tokens;
        }
}




        protected string error;
        protected string success;
        protected string result;

        public async void add1() { result += "1"; success = ""; error = ""; StateHasChanged(); }
        public async void add2() { result += "2"; success = ""; error = ""; StateHasChanged(); }
        public async void add3() { result += "3"; success = ""; error = ""; StateHasChanged(); }
        public async void add4() { result += "4"; success = ""; error = ""; StateHasChanged(); }
        public async void add5() { result += "5"; success = ""; error = ""; StateHasChanged(); }
        public async void add6() { result += "6"; success = ""; error = ""; StateHasChanged(); }
        public async void add7() { result += "7"; success = ""; error = ""; StateHasChanged(); }
        public async void add8() { result += "8"; success = ""; error = ""; StateHasChanged(); }
        public async void add9() { result += "9"; success = ""; error = ""; StateHasChanged(); }
        public async void add0() { result += "0"; success = ""; error = ""; StateHasChanged(); }
        

        public async void clean()
        {
            result = "";
            StateHasChanged();
        }

        public async void addc()
        {

            success = "";
            error = "";

            string r = result;
            if (result != null)
                if (result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if (r != "*")
                    if (r != "/")
                        if (r != "+")
                            if (r != "-")
                                if (r != " ")
                                    if (r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += ",";
                                                StateHasChanged();
                                            }
        }


        public async void addpow()
        {
            success = "";
            error = "";

            string r = result;
            if (result != null)
                if (result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if (r != "*")
                    if (r != "/")
                        if (r != "+")
                            if (r != "-")
                                if (r != " ")
                                    if (r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += "^";
                                                StateHasChanged();
                                            }
        }

        public async void addX() {

            success = "";
            error = "";

            string r = result;
            if (result != null)
                if(result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if ( r !=  "*")
                    if(r != "/")
                        if( r != "+")
                            if(r != "-")
                                if(r != " ")
                                    if(r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += "*";
                                                StateHasChanged();
                                            }
        }

        public async void addP() {

            success = "";
            error = "";

            string r = result;
            if (result != null)
                if (result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if (r != "*")
                    if (r != "/")
                        if (r != "+")
                            if (r != "-")
                                if (r != " ")
                                    if (r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += "+";
                                                StateHasChanged();
                                            }
        }

        public async void addM() {

            success = "";
            error = "";

            string r = result;
            if (result != null)
                if (result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if (r != "*")
                    if (r != "/")
                        if (r != "+")
                            if (r != "-")
                                if (r != " ")
                                    if (r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += "-"; 
                                                StateHasChanged();
                                            }
        }

        public async void addD() {

            success = "";
            error = "";

            string r = result;
            if (result != null)
                if (result.Length > 1)
                {
                    r = result[result.Length - 1].ToString();
                }

            if (result != null)
                if (r != "*")
                    if (r != "/")
                        if (r != "+")
                            if (r != "-")
                                if (r != " ")
                                    if (r != "")
                                        if (r != ",")
                                            if (r != "^")
                                            {
                                                result += "/";
                                                StateHasChanged();
                                            }
        }

        public async void del()
        {
            if(result.Length > 0)
            {
               result = result.Remove(result.Length - 1);
            }
            StateHasChanged();
        }

        public async void Sum()
        {
            success = "";
            error = "";
            char last = result[result.Length - 1];

            if(result == null)
            {
                error = "Input needed for calculation";
            }
            else if(result.Length < 1)
            {
                error = "Input needed for calculation";
            }
            else if(last != '-' && last != '+' && last != '*' && last != '/' && last != '^')
            {
                StringToFormula stf = new StringToFormula();
                double r = stf.Eval(result);

                success = "Success!";
                result = r.ToString();
                StateHasChanged();
            }
        }
    }
}
