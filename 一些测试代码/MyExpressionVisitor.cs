using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 一些测试代码
{
    public class MyExpressionVisitor : ExpressionVisitor
    {
        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
    }
}
