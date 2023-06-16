using Microsoft.AspNetCore.Mvc;

namespace Growth.Controllers.Csharp
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PassingParametersController : ControllerBase
    { //There are four different ways of passing parameters to a method in C# which are as: value, reference, out(reference) and params(param arrays)
        [HttpGet]
        public PassingParams GetPassingParametersTest()
        {
            ValuesSentAsReference refValues = new ValuesSentAsReference { A = 5, B = 15 };

            int a = 12;
            int b = 13;
            ValuesSentAsReference? outValues;

            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            var PassingParamsResult = new PassingParams
            {
                Value = SumValues(10, 20),
                Reference = SumReferences(ref refValues),
                OutValue = SumOut(a, b, out outValues),
                Parameters = IncrementParamsArray(1, 2, 3, 4)
            };

            return PassingParamsResult;
        }

        //By default, parameters are passed by value. A duplicate copy is made and sent to the called function. There are two copies of the variables.
        //If you change the value in the called method it won't be changed in the calling method.
        public int SumValues(int a, int b)
        {
            a += 5;
            b += 15;
            return a + b;
        }

        //Passing parameters by 'ref' uses the address of the actual parameters to the formal parameters.
        //It requires 'ref' keyword in front of variables to identify in both actual and formal parameters.
        //The process of 'ref' is bidirectional i.e. we have to supply value to the formal parameters and we get back processed value.
        //We use this process when we want to use or change the values of the parameters passed.
        public int SumReferences(ref ValuesSentAsReference values)
        {
            values.A += 10;
            values.B += 20;
            return values.A + values.B;
        }

        //Like 'ref', 'out' parameters don't create a new storage location and are passed by reference.
        //difference between 'ref' and 'out' keyword is that 'ref' needs the variable to be initialized before it's passed to the method, 'out' doesn't
        //It requires 'out' keyword in front of variables to identify in both actual and formal parameters.
        //The process of 'out' is unidirectional i.e. we don't have to supply value to the formal parameters but we get back processed value.
        //We use this process when we want some parameters to bring back some processed values from the called method
        //used to pass arguments to methods by reference, without having to initialize them
        public int SumOut(int a, int b, out ValuesSentAsReference values)
        {
            values = new ValuesSentAsReference { A = 5, B = 15 };
            values.A = a + b;
            values.B = values.A + 100;
            a = values.A;
            b = values.B;
            return a + b;
        }

        //"params" is used when we don't know the number of parameters that will be passed to the called method.
        //It can accept multiple values; or it can be dimensional or a jagged array.
        //The params keyword lets you specify a method parameter that takes an argument where the number of arguments is variable.
        //No additional parameters are permitted after the params keyword in a method declaration, and only one params keyword is permitted in a method declaration.
        public int[] IncrementParamsArray(params int[] numbers) //method can be called with an array ([1, 2, 3]) or just with more parameters ...(1, 2, 3 etc)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]++;
            }
            return numbers;
        }
    }

    public class PassingParams
    {
        public int Value { get; set; }
        public int? Reference { get; set; }
        public int OutValue { get; set; }
        public int[]? Parameters { get; set; }
    }

    public class ValuesSentAsReference
    {
        public int A { get; set; }
        public int B { get; set; }
    }
}
