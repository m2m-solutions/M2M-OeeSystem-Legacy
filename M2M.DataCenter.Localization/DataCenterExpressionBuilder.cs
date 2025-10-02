using System;
using System.Web.Compilation;

namespace M2M.DataCenter.Localization
{
    [ExpressionPrefix("DataCenter"), ExpressionEditor("M2M.DataCenter.Localization.DataCenterExpressionEditor, M2M.DataCenter.Localization")]
    public class DataCenterExpressionBuilder : BaseDataCenterExpressionBuilder
    {
        public static DataCenterExpressionBuilder Instance()
        {
            return new DataCenterExpressionBuilder();
        }

        protected override string GetValue(string key)
        {
            return ResourceStrings.GetString(key);
        }

        public override string SourceObjectName
        {
            get { return "DataCenter"; }
        }   
    }

    public class DataCenterExpressionEditor : System.Web.UI.Design.ExpressionEditor
    {
        public override object EvaluateExpression(string expression, object parsedData, Type propertyType, IServiceProvider serviceProvider)
        {
            return ResourceStrings.GetString(expression);
        }
    }
}
