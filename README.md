# ExpressionSolver
## Description to the exercise.

In order to completing the exercise I decided to implement stack-based algorithms with the use of Reverse Polish Notation [Source: https://en.wikipedia.org/wiki/Reverse_Polish_notation]. 
Application calculates the expression given as an input through the following steps:
1.	Initial processing of the expression by removing whitespaces,
2.	Converting infix form of expression to postfix notation,
3.	Calculating the result from expression in the postfix notation and send as an output.

In the 2nd step, the essential part was to prioritize operators, which allowed to keep mathematical rules of operator precedence.

The main part of the program is located in the `ExpressionSolver.Engine` assembly. I extracted the algorithm engine into separate dll, to enable reusability for other applications i.e. Web application. 
The code is easily extendable to support brackets. This requires creating new BracketOperator class, assign correct priority and add key value pair to the operators dictionary (`ExpressionCalculator.cs`).

The solution has production quality and is easily maintainable, because it contains extensive unit tests coverage and exception handling, which gives information to the end user if he try to use unsupported expression element or divide by zero. For simplicity, classes: `InfixToPostfixNotationConverter.cs` and `RPNCalculator.cs` have been changed to internal classes, in real scenario they can be public and also covered by unit tests.

