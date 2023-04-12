using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Classes
{
    public class AdoHelper
    {
        /// <summary>
        /// Return the list of the props name of a ContactFilter minus the Item one
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static List<string> GetFilterPropertiesName(AdoDBClass filters)
        {
            List<string> propertyFilterNames = new List<string>();
            filters.GetType().GetProperties().ToList().ForEach(item => {
                if (item.Name != "Item" && filters[item.Name] != null)
                {
                    propertyFilterNames.Add(item.Name);
                }
            });
            return propertyFilterNames;
        }

        /// <summary>
        /// Update the string given by reference with the where clause given with the propsName
        /// </summary>
        /// <param name="request"></param>
        /// <param name="propsNames"></param>
        /// <param name="suffix"></param>
        public static void UpdateRequestWithWhere(ref string request, List<string> propsNames, string suffix = "_f")
        {
            if (propsNames.Count > 0)
            {
                request += " WHERE";
                for (int i = 0; i < propsNames.Count; i++)
                {
                    if (i < propsNames.Count - 1)
                    {
                        request += $" {propsNames[i]} = @{propsNames[i]}{suffix} AND";
                    }
                    else
                    {
                        request += $" {propsNames[i]} =  @{propsNames[i]}{suffix}";
                    }
                }
            }
        }

        /// <summary>
        /// Update the string given by reference with the set clause given with the propsName
        /// </summary>
        /// <param name="request"></param>
        /// <param name="propsNames"></param>
        /// <param name="suffix"></param>
        public static void UpdateRequestWithSet(ref string request, List<string> propsNames, string suffix = "_u")
        {
            if (propsNames.Count > 0)
            {
                request += " SET";
                for (int i = 0; i < propsNames.Count; i++)
                {
                    if (i < propsNames.Count - 1)
                    {
                        request += $" {propsNames[i]} = @{propsNames[i]}{suffix},";
                    }
                    else
                    {
                        request += $" {propsNames[i]} =  @{propsNames[i]}{suffix}";
                    }
                }
            }
        }
    }
}
