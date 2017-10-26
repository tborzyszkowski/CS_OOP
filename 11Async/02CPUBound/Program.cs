using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02CPUBound {
    class AsyncCPUDemo {
        public double resultAsc = 100;
        private double DoExpensiveCalculation(double data) {
            double result = data;
            while (result > 0.0001) {
                result = result / 2;
                //Thread.Sleep(1);
            }
            return result;
        }
        public async Task<double> CalculateResult(double data) {
            // This queues up the work on the threadpool.
            var expensiveResultTask = Task.Run(() => DoExpensiveCalculation(data));

            // Note that at this point, you can do some other work concurrently,
            // as CalculateResult() is still executing!

            // Execution of CalculateResult is yielded here!
            var result = await expensiveResultTask;

            return result;
        }
        public async Task getResult() {
            await Task.Run(() => resultAsc = CalculateResult(10).Result);
        }

    }
    class Program {
        static void Main(string[] args) {
            AsyncCPUDemo acpu = new AsyncCPUDemo();

            acpu.getResult();
            int count = 0;
            while (acpu.resultAsc > 0.0001) {
                //Console.Write(".");
                //Thread.Sleep(1);
                count++;
            }
            Console.WriteLine(count);
            Console.WriteLine(acpu.resultAsc);

        }
    }
}
