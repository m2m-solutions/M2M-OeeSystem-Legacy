using System;
using System.Web.UI;
using System.Web.Compilation;
using System.CodeDom;

namespace M2M.DataCenter.Localization
{
    public abstract class BaseDataCenterExpressionBuilder : ExpressionBuilder
    {
        protected abstract string GetValue(string key);
        public abstract string SourceObjectName { get; }
        
        public override System.CodeDom.CodeExpression GetCodeExpression(BoundPropertyEntry
                entry, object parsedData, ExpressionBuilderContext context)
        {
           CodeMethodInvokeExpression ex = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(this.GetType()),
            "Instance().GetRequestedValue", new CodePrimitiveExpression(entry.Expression.ToString().Trim()));
            return ex;
        }

        public override object EvaluateExpression(object target, BoundPropertyEntry
                        entry, object parsedData, ExpressionBuilderContext context)
        {
            return GetValue(entry.Expression);
        }

        public string GetRequestedValue(string key)
        {
            return this.GetValue(key);
        }

        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
    }
}
