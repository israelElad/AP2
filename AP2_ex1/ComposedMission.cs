//Elad Israel 313448888

using System;
using System.Collections.Generic;




namespace AP2_ex1
{
    /// <summary>
    /// a mission composed of multiple actions
    /// </summary>
    public class ComposedMission : IMission
    {
        public String Name { get; }
        public String Type { get; }
        List<actionDelegate> MultipleActions { get; }

        public ComposedMission(string name)
        {
            Name = name;
            Type = "Composed";
            MultipleActions = new List<actionDelegate>();
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
            double result=value;
            // activate the action on the value and use the result as the value for the next operation.
            foreach (actionDelegate action in MultipleActions)
            {
                result=action(result);
            }
            //if OnCalculate has an event(not null) invoke it - run the events on another thread
            OnCalculate?.Invoke(this, result);
            return result;
        }

        /// <summary>
        /// add action to the list
        /// </summary>
        /// <param name="action"> action to add to the mission </param>
        /// <returns> this- the composed mission with the added action for fluent programming </returns>
        public ComposedMission Add(actionDelegate action)
        {
            MultipleActions.Add(action);
            return this;
        }
    }
}
