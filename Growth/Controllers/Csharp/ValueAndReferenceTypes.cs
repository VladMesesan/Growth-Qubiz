using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace Growth.Controllers.Csharp
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValueAndReferenceTypes : ControllerBase
    {
        [HttpGet]
        public ValueAndReferenceType GetReferenceType()
        {
            ValueAndReferenceType originalObject = new ValueAndReferenceType { RefName = "Value" }; //this is stored on the HEAP, and a reference is stored on the STACK
            //so, we have the RefName: Value on the HEAP, and a memory address(reference) on the STACK

            Point structPoint = new Point { X = 0, Y = 0 }; //this is a STRUCT; it's a value type - best used for small data structures that have value semantics.

            static void SendVal(ValueAndReferenceType x)
            {
                x.RefName = "AAAAA";
            }

            static void SendRef(ref ValueAndReferenceType x)
            {
                x = new ValueAndReferenceType { RefName = "BBBBB" };
            }

            static void SendVal2(ValueAndReferenceType x)
            {
                x = new ValueAndReferenceType { RefName = "CCCCC" };
            }

            Trace.WriteLine("Before: " + originalObject.RefName); // Value
            SendVal(originalObject);
            Trace.WriteLine("In between: " + originalObject.RefName); // AAAAA
            SendRef(ref originalObject);
            Trace.WriteLine("After: " + originalObject.RefName); // BBBBB - because we send a 'ref Object', so 'new Object' works.
            SendVal2(originalObject);
            Trace.WriteLine("After sendVal2: " + originalObject.RefName);

            ValueAndReferenceType newObj = originalObject;
            newObj.RefName = "BothChanged?";
            Trace.WriteLine("After ALL new: " + newObj.RefName);
            Trace.WriteLine("After ALL original: " + originalObject.RefName); //Both will be 'BothChanged?', since we are changing the value using the same reference address.

            //--------------------------------------------------------------------------------------------------------------------//

            // [String, Array, Class, Delegate] are reference type data types.
            // When you pass a reference type variable from one method to another, it doesn't create a new copy;
            // instead, it passes the variable's address. So, if we change the value of a variable in a method, it will also be reflected in the calling method.
            ValueAndReferenceType RT0 = new ValueAndReferenceType()
            {
                RefName = "First Name I've ever had"
            };
            Trace.WriteLine(RT0.RefName); //This returns "First Name I've ever had" (obviously)


            //This here actually passes the memory address of RT0;
            //The method ChangeReferenceType() changes the value of RT0, because both RT0 and RT1 are both pointing to the same address in memory.
            ChangeReferenceType(RT0);


            //String is immutable. It means once we assigned a value, it cannot be changed.
            //If we change a string value, then the compiler creates a new string object in the memory and point a variable to the new memory location.
            string name = "Never Changed";
            ChangeReferenceTypeString(name);
            Trace.WriteLine(name); //This will, as such, be "Never Changed", despite our changing it in "ReferenceTypeString was changed".

            return RT0;
        }

        public int[] GetReferenceArray()
        {
            ValueAndReferenceType RTarray = new ValueAndReferenceType()
            {
                RefArray = new int[] { 1, 2, 6, 7 }
            };

            IncrementRefArray(RTarray);

            return RTarray.RefArray;
        }

        [HttpGet]
        public int GetValueType()
        {
            //BOOL, byte, CHAR, decimal, double, ENUM, float, INT, long, sbyte, short, struct, uint, ulong, ushort
            //When we pass value types, we actually create a copy and any changes made on the copy have no impact on the original
            int numberValue = 100;

            Trace.WriteLine(numberValue); //100

            ChangeValue(numberValue); //200
            //Since we create a seperate copy of the variable in this method, the numberValue variable does not actually change.

            Trace.WriteLine(numberValue); //100
            //If we change the value in one method, it does not affect the variable from another method.
            //Basically, changing the value in the called method, does not change the value in the calling method.

            return numberValue;
        }

        static void ChangeReferenceType(ValueAndReferenceType RT1)
        {
            RT1.RefName = "ReferenceType was changed";
        }

        static void IncrementRefArray(ValueAndReferenceType passedRef)
        {
            for (int i = 0; i < passedRef.RefArray.Length; i++)
            {
                passedRef.RefArray[i]++;
            }
        }

        static void ChangeReferenceTypeString(string RTS1)
        {
            RTS1 = "ReferenceTypeString was changed";
            //even the IDE is telling me this variable/parameter is useless because its initial value is never used
        }

        static void ChangeValue(int x)
        { //even the IDE is telling me this variable/parameter is useless because its initial value is never used
            x = 200;

            Trace.WriteLine(x);
        }
    }

    public class ValueAndReferenceType
    {
        public string? RefName { get; set; }
        public string? ValName { get; set; }
        public int[]? RefArray { get; set; }
    }
}