//Elad Israel 313448888

using System.Collections.Generic;

namespace AP2_ex1
{
    public delegate double actionDelegate(double val);
    /**
    * indexer- receives a function name and returns the appropriate function.
    */
    public class FunctionsContainer
    {
        Dictionary<string, actionDelegate> strToAction = new Dictionary<string, actionDelegate>();
        public actionDelegate this [string functionName]
        {
            get
            {
                //if key doesn't exist(no matching action- Stam) - create function that return the same value received
                if (!strToAction.ContainsKey(functionName))
                {
                    strToAction.Add(functionName, x => x);
                }
                return strToAction[functionName];
            }
            set
            {
                //if key exists- update the delegate to be the new function received.
                if (strToAction.ContainsKey(functionName))
                {
                    strToAction[functionName] = value;
                }
                else
                {
                    addStrAndAction(functionName, value);
                }
            }
        }

        /// <summary>
        /// return all missions(keys of the dictionaries)
        /// </summary>
        /// <returns>missions list</returns>
        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach (KeyValuePair<string, actionDelegate> entry in strToAction)
            {
                missions.Add(entry.Key);
            }
            return missions;
        }


        /// <summary>
        /// add action name and action to the container
        /// </summary>
        /// <param name="str">action name</param>
        /// <param name="action">action</param>
        void addStrAndAction(string str, actionDelegate action)
        {
            strToAction.Add(str, action);
        }

        /// <summary>
        /// remove action name and the appropriate action from the container
        /// </summary>
        /// <param name="str">action name</param>
        void removeStrAndAction(string str)
        {
            strToAction.Remove(str);
        }
    }
}
