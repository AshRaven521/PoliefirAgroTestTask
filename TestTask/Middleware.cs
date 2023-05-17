namespace TestTask
{
    public class Middleware
    {
        public string Expression { get; set; }
        public string Operator { get; set; }

        public Middleware(string expr, string oper)
        {
            Expression = expr;
            Operator = oper;
        }
    }
}
