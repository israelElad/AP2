//Elad Israel 313448888

using System;

namespace AP2_ex1
{
    //interface defining a mission
    public interface IMission
    {
        // An Event of when a mission is activated
        event EventHandler<double> OnCalculate;
        String Name { get; }
        String Type { get; }
        /// <summary>
        /// calculates the mission on the value received and returns the result
        /// </summary>
        /// <param name="value"> value to operate on</param>
        /// <returns> result of the operation </returns>
        double Calculate(double value);
    }
}
