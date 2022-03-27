using System;
using CalcLib;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InputIsNotNumeric_1()
        {
            int expected_result = ErrorCodes.INPUT_SHOULD_BE_NUMERIC;
            TestInputRetriever input = new TestInputRetriever(new string[] {"12,3", "fdsd"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void InputIsNotNumeric_2()
        {
            int expected_result = ErrorCodes.INPUT_SHOULD_BE_NUMERIC;
            TestInputRetriever input = new TestInputRetriever(new string[] {"12..,4DFtrqwe3", "..sa=-0dfhu"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void DesiredSumIsUnreachable_1()
        {
            int expected_result = ErrorCodes.DESIRED_SUM_IS_UNREACHABLE;
            TestInputRetriever input = new TestInputRetriever(new string[] {"12.0", "1000000"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test:]
        public void DesiredSumIsUnreachable_2()
        {
            int expected_result = ErrorCodes.DESIRED_SUM_IS_UNREACHABLE;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1", "1000000"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void NoInputWasReceived()
        {
            int expected_result = ErrorCodes.NO_INPUT_WAS_RECEIVED;
            TestInputRetriever input = new TestInputRetriever(new string[] {null,null});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void CalculationsReachesInfinity()
        {
            int expected_result = ErrorCodes.CALCULATIONS_REACHES_INFINITY;
            TestInputRetriever input = new TestInputRetriever(new string[] {Double.MaxValue.ToString(),Double.MaxValue.ToString()+"00"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void DesiredSumIsLessThanDeposit()
        {
            int expected_result = ErrorCodes.DESIRED_SUM_IS_LESS_THEN_DEPOSIT;
            TestInputRetriever input = new TestInputRetriever(new string[] {"400","100"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void ValidInputCalculationResultIsFine_1()
        {
            int expected_result = 5;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1000000","1500000"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void ValidInputCalculationResultIsFine_2()
        {
            int expected_result = 11;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1000000","2600000"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void ValidInputCalculationResultIsFine_3()
        {
            int expected_result = 6;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1000,50","1700.20"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void DotDecimalSeparatorUsed()
        {
            int expected_result = 6;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1000.47","1700.10"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void CommaDecimalSeparatorUsed()
        {
            int expected_result = 6;
            TestInputRetriever input = new TestInputRetriever(new string[] {"1000,94","1700,10"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void CalculatingLittleNumbers()
        {
            int expected_result = ErrorCodes.CALCULATED_NUMBERS_ARE_TOO_LITTLE;
            TestInputRetriever input = new TestInputRetriever(new string[] {"0.000000000064","0.00000000064"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void NegativeValue()
        {
            int expected_result = ErrorCodes.NEGATIVE_VALUE_WAS_ENTERED;
            TestInputRetriever input = new TestInputRetriever(new string[] {"543","-200"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
        
        [Test]
        public void ZeroValue()
        {
            int expected_result = ErrorCodes.ZERO_WAS_ENTERED;
            TestInputRetriever input = new TestInputRetriever(new string[] {"0","1"});
            Assert.AreEqual(expected_result, BankCalculations.CalculateCompoundInterest(input));
            Assert.Pass();
        }
    }
}