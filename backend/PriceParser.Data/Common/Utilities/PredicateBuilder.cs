using System.Linq.Expressions;
using PriceParser.Data.Common.Utilities.Contracts;

namespace PriceParser.Data.Common.Utilities
{
	public class PredicateBuilder : IPredicateBuilder
	{
		public Expression<Func<T, bool>> True<T>() => f => true;
		public Expression<Func<T, bool>> False<T>() => f => false;

		public Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			if (expr1 == null)
			{
				throw new ArgumentNullException(nameof(expr1));
			}

			if (expr2 == null)
			{
				throw new ArgumentNullException(nameof(expr2));
			}

			var secondBody = new ReplaceVisitor(expr2.Parameters[0], expr1.Parameters[0]).Visit(expr2.Body);
			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, secondBody), expr1.Parameters);
		}

		public Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			if (expr1 == null)
			{
				throw new ArgumentNullException(nameof(expr1));
			}

			if (expr2 == null)
			{
				throw new ArgumentNullException(nameof(expr2));
			}

			var secondBody = new ReplaceVisitor(expr2.Parameters[0], expr1.Parameters[0]).Visit(expr2.Body);
			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, secondBody), expr1.Parameters);
		}

		private class ReplaceVisitor : ExpressionVisitor
		{
			private readonly Expression _from;
			private readonly Expression _to;

			public ReplaceVisitor(Expression from, Expression to)
			{
				_from = from;
				_to = to;
			}

			public override Expression Visit(Expression node)
				=> node == _from ? _to : base.Visit(node);
		}
	}
}
