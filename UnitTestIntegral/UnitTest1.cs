using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using integral;
namespace UnitTestIntegral
{
    [TestClass]
    public class UnitTest1
    {
        // Trap method
        //проверка на точность метода траеций
        [TestMethod]
        public void TrapMethod_XmultiplyX_2666Returned()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 2666.66;

            //act
            IMath math = new IntegralMath();
            double res = math.Trap(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.01);
        }

        //проверка на точность метода трапеций
        [TestMethod]
        public void TrapMethod_2X_400Returned()
        {
            //assert 
            Func<double, double> func = x => x * 2;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 400.0;

            //act
            IMath math = new IntegralMath();
            double res = math.Trap(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.00001);

        }

        //проверка на точность метода симпсона
        [TestMethod]
        public void SimsMethod_XmultiplyX_2666Returned()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 2666.66;

            //act
            IMath math = new IntegralMath();
            double res = math.Sims(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.01);
      
        }

        //проверка на точность метода симпсона
        [TestMethod]
        public void SimsMethod_2X_400Returned()
        {
            //assert 
            Func<double, double> func = x => 2 * x;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 400;

            //act
            IMath math = new IntegralMath();
            double res = math.Sims(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.0001);
        }

        //ввод отрицательного шага для метода Симпсона
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void SimpsonMethod_InvalidIterationCount_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 0;
            double b = 20;
            double h = -0.01;

            //act
            IMath math = new IntegralMath();
            double res = math.Sims(a, b, h, func);
        }

        //ввод отрицательного шага для метода Трапеций
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void TrapMethod_InvalidStride_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 0;
            double b = 20;
            double h = -0.01;
            
            //act
            IMath math = new IntegralMath();
            double res = math.Trap(a, b, h, func);
        }

        // правильность введенных пределов интегрирования для метода Симсона
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void MixedUpLimits_Sims_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 20;
            double b = -20;
            double h = 0.001;

            //act
            IMath math = new IntegralMath();
            double res = math.Sims(a, b, h, func);
        }

        // правильность введенных пределов интегрирования для метода трапеций
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void MixedUpLimits_Trap_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 20;
            double b = -20;
            double h = 0.001;

            //act
            IMath math = new IntegralMath();
            double res = math.Trap(a, b, h, func);
        }

        // очень маленький шаг для метода трапеций
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void TooShortStep_Trap_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 1;
            double b = 10000;
            double h = 0.0000001;

            //act
            IMath math = new IntegralMath();
            double res = math.Trap(a, b, h, func);
        }

        // очень маленький шаг для параллельного метода трапеций
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void ParallelTooShortStep_Trap_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 1;
            double b = 10000;
            double h = 0.0000001;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pTrap(a, b, h, func);
        }

        //проверка на результат параллельного метода трапеций
        [TestMethod]
        public void ParallelTrapMethod_2X_400Returned()
        {
            //assert 
            Func<double, double> func = x => x * 2;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 400.0;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pTrap(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.001);
        }

        // правильность введенных пределов интегрирования
        // для параллельного метода Трапеций
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void ParallelMixedUpLimits_Trap_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 20;
            double b = -20;
            double h = 0.001;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pTrap(a, b, h, func);
        }


        /*тесты для парралельного варианта метода Симпсона*/

        // очень маленький шаг для метода Симпсона

        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void TooShortStep_Sims_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 1;
            double b = 10000;
            double h = 0.0000001;

            //act
            IMath math = new IntegralMath();
            double res = math.Sims(a, b, h, func);
        }

        // очень маленький шаг для параллельного метода Симпсона

        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void ParallelTooShortStep_Sims_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 1;
            double b = 10000;
            double h = 0.0000001;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pSims(a, b, h, func);
        }

        //проверка на результат параллельного метода Симпсона

        [TestMethod]
        public void ParallelSimsMethod_2X_400Returned()
        {
            //assert 
            Func<double, double> func = x => 2 * x;
            double a = 0;
            double b = 20;
            double h = 0.001;
            double correct_res = 400;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pSims(a, b, h, func);

            //arrange
            Assert.AreEqual(correct_res, res, 0.001);
        }

        // правильность введенных пределов интегрирования
        // для параллельного метода Симсона
        [TestMethod]

        [ExpectedException(typeof(ArgumentException))]
        public void ParallelMixedUpLimits_Sims_Exception()
        {
            //assert 
            Func<double, double> func = x => x * x;
            double a = 20;
            double b = -20;
            double h = 0.001;

            //act
            IntegralMath math = new IntegralMath();
            double res = math.pSims(a, b, h, func);
        }
    }
}
