using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace UnitTest.Classes
{
    public class MathOp
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double Div(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

    }





    public class MathOpTest
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(3, 15, 18)]
        [InlineData(1000000, 35, 1000035)]
        public void Add_Ok(int a,int b,int sum)
        {
            MathOp math = new MathOp();
            var ret = math.Add(a, b);
            Assert.True(sum == ret);
        }
        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(2, 1, 2)]
        public void Div_Ok(double a, double b, double result)
        {
            MathOp math = new MathOp();
            var ret = math.Div(a, b);
            Assert.True(ret == result);
            Assert.Throws<DivideByZeroException>(()=>math.Div(3,0));
        }



    }
}
