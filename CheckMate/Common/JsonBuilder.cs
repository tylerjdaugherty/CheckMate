using System;
using System.Runtime.Serialization.Json;
 
using System.Text.Json;
using System.Reflection;
using System.Collections.Generic;

namespace CheckMate.Common
{
    public static class JsonBuilder
    {
        
        public static string toJson(Object obj)
        {
            bool first = true; 
            string json = "{";

            foreach(PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (!first)
                    json += ", \n";
                var type = propertyInfo.PropertyType;
                var value = propertyInfo.GetValue(obj, null);
                var name = propertyInfo.Name;
                //ex: "id" : 
                json += "\"" + name + "\" : ";

                if(type.ToString() == "System.Int32")
                {
                    json += value.ToString();
                }
                else
                {
                    json += "\"" + value + "\"";
                }
                first = false;
            }
            json += " }";
            return json;
        }
        

    }

    /*
    public static List<Object> jsonToObject(string str)
    {
        //get first object from string
        //check which type of model obj it is?
        //pass to appropriate method

        //int indexof = 0;
    }
    */
}
