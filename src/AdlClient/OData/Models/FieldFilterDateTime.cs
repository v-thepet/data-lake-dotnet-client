using AdlClient.OData.Models;

namespace AdlClient.OData.Models
{

    public class FieldFilterDateTime : FieldFilter
    {
        private AdlClient.Models.RangeDateTime range;
        public bool Inclusive;
        private DateTimeFilterCategory Category;

        public FieldFilterDateTime(ExprField field) :
            base(field)
        {
            this.Inclusive = true;
            this.Category = DateTimeFilterCategory.NoFilter;
        }

        public void IsInRange(AdlClient.Models.RangeDateTime range)
        {
            this.Category = DateTimeFilterCategory.IsInRange;
            this.range = range;
        }

        public void IsNull()
        {
            this.Category = DateTimeFilterCategory.IsNull;
        }

        public void IsNotNull()
        {
            this.Category = DateTimeFilterCategory.IsNotNull;
        }

        public override Expr ToExpression()
        {
            if (this.Category == DateTimeFilterCategory.NoFilter)
            {
                return null;
            }
            else if (this.Category == DateTimeFilterCategory.IsInRange)
            {
                // The range must have at least one bound
                if (!this.range.IsBounded)
                {
                    return null;
                }

                var expr_and = new ExprLogicalAnd();

                if (this.range.UpperBound.HasValue)
                {
                    var op = this.Inclusive ? ComparisonOperation.GreaterThanOrEquals : ComparisonOperation.LesserThan;

                    var expr_date = new ExprLiteralDateTime(this.range.UpperBound.Value);
                    var expr_compare = Expr.GetExprComparison(this.expr_field, expr_date, op);
                    expr_and.Add(expr_compare);
                }

                if (this.range.LowerBound.HasValue)
                {
                    var op = this.Inclusive ? ComparisonOperation.GreaterThanOrEquals : ComparisonOperation.GreaterThan;
                    var expr_date = new ExprLiteralDateTime(this.range.LowerBound.Value);
                    var expr_compare = Expr.GetExprComparison(this.expr_field, expr_date, op);
                    expr_and.Add(expr_compare);
                }

                return expr_and;
            }
            else if (this.Category ==  DateTimeFilterCategory.IsNull)
            {
                return CreateIsNullExpr();
            }
            else if (this.Category == DateTimeFilterCategory.IsNotNull)
            {
                return CreateIsNotNullExpr();
            }
            else
            {
                string msg = string.Format("Unhandled datetime filter category: \"{0}\"", this.Category);
                throw new System.ArgumentException(msg);
            }
        }
    }
}