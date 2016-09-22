using System;
using DevExpress.Data.Filtering;
using DevExpress.Xpf.Grid;

namespace DXSample8
{
    public class CustomTableView : TableView
    {
        protected override CriteriaOperator CreateAutoFilterCriteria(String fieldName, AutoFilterCondition condition, Object value)
        {
            if (fieldName == "State")
            {
                var statusWrapper = (AddressStateWrapper)value;
                if (statusWrapper?.State == null)
                {
                    return null;
                }

                return new BinaryOperator(new OperandProperty(fieldName), new OperandValue((Int16)statusWrapper.State.Value), BinaryOperatorType.Equal);
            }
            return base.CreateAutoFilterCriteria(fieldName, condition, value);
        }

        protected override Object GetAutoFilterValue(ColumnBase column, CriteriaOperator op)
        {
            if (column.FieldName == "State")
            {
                BinaryOperator binaryOp = op as BinaryOperator;
                if (ReferenceEquals(binaryOp, null))
                {
                    return null;
                }
                var criteriaOperator = binaryOp.RightOperand as OperandValue;
                if (ReferenceEquals(criteriaOperator, null))
                {
                    return null;
                }
                return new AddressStateWrapper() { State = (AddressState)((Int16)criteriaOperator.Value) };
            }
            return base.GetAutoFilterValue(column, op);
        }
    }
}