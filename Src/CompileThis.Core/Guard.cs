namespace CompileThis
{
    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;

    public static class Guard
    {
        [DebuggerHidden]
        public static void NullParameter<TParameter>(TParameter parameter, string parameterName = null, string message = null)
            where TParameter : class 
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, message);
            }
        }

        [DebuggerHidden]
        public static void NullParameter<TParameter>(TParameter parameter, Expression<Func<TParameter>> parameterExpression, string message = null)
            where TParameter : class 
        {
            if (parameter == null)
            {
                var parameterName = GetParameterName(parameterExpression);

                throw new ArgumentNullException(parameterName, message);
            }
        }

        [DebuggerHidden]
        private static string GetParameterName<TParameter>(Expression<Func<TParameter>> parameterExpression)
        {
            var memberExpression = parameterExpression.Body as MemberExpression;
            return memberExpression == null ? null : memberExpression.Member.Name;
        }
    }
}
