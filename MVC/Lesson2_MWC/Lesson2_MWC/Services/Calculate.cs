using System.Data;

namespace Lesson2_MWC.Services
{
    public class Calculate : ICalculate
    {
        public decimal Data { get; set; }
        decimal ICalculate.Calculate(decimal value) => Data += 100;

    }
}
