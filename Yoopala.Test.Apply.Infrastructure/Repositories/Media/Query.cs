using System;
using System.Linq.Expressions;

namespace Yoopala.Test.Apply.Infrastructure.Repositories.Medias
{
    public class Query<T>
    {
        private Expression<Func<T, bool>> Criteria;

        public void Add(Expression<Func<T, bool>> criteria)
        {
            Criteria = GetExpressionInfo(Criteria, criteria, Expression.AndAlso);
        }

        public Expression<Func<T, bool>> GetCriteria()
        {
            return Criteria;
        }

        #region private
        private static Expression<Func<T, bool>> GetExpressionInfo(
                        Expression<Func<T, bool>> funcToAdd,
                        Expression<Func<T, bool>> criteria,
                        Func<Expression, Expression, BinaryExpression> functionToApply
                        )
        {
            if(funcToAdd == null)
            {
                return criteria;
            }
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            var leftVisitor = new ReplaceExpressionVisitor(criteria.Parameters[0], parameter);
            Expression left = leftVisitor.Visit(criteria.Body);
            var rightVisitor = new ReplaceExpressionVisitor(funcToAdd.Parameters[0], parameter);
            Expression right = rightVisitor.Visit(funcToAdd.Body);
            return Expression.Lambda<Func<T, bool>>(functionToApply(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;
            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }
                return base.Visit(node);
            }
        }
        #endregion
    }
}
