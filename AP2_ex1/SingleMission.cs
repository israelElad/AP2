//Elad Israel 313448888

using System;

namespace AP2_ex1
{
    /// <summary>
    /// a mission composed of a single action
    /// </summary>
    public class SingleMission : IMission
    {
        
        public String Name { get; }
        public String Type { get; }
        actionDelegate SingleAction { get; set; }
        
        public SingleMission(actionDelegate action, string name)
        {
            SingleAction = action;
            Name = name;
            Type = "Single";
        }

        // An Event of when a mission is activated
        public event EventHandler<double> OnCalculate;

        /// <summary>
        /// calculates the mission on the value received and returns the result
        /// </summary>
        /// <param name="value"> value to operate on</param>
        /// <returns> result of the operation </returns>
        public double Calculate(double value)
        {
            double result = SingleAction(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
       
    }
}
