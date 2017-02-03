            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // A label expression of the void type that is the target for the GotoExpression.
            LabelTarget returnTarget = Expression.Label();

            // This block contains a GotoExpression.
            // It transfers execution to a label expression that is initialized with the same LabelTarget as the GotoExpression.
            // The types of the GotoExpression, label expression, and LabelTarget must match.
            BlockExpression blockExpr =
                Expression.Block(
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("GoTo")),
                    Expression.Goto(returnTarget),
                    Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("Other Work")),
                    Expression.Label(returnTarget)
                );

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action>(blockExpr).Compile()();

            // This code example produces the following output:
            //
            // GoTo

            // "Other Work" is not printed because 
            // the GoTo expression transfers execution from Expression.GoTo(returnTarget)
            // to Expression.Label(returnTarget).