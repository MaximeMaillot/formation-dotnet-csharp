using Helper.Classes;
using System.Reflection;

namespace DemoAdo.Classes.Filter
{
    internal class ContactFilter : AdoDBClass
    {
        public int? contact_id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }

        /// <summary>
        /// get the value of a props via Array notation
        /// contact[propsName] is equivalent to contact.propsName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object this[string name]
        {
            get
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(name);
                return myPropInfo.GetValue(this, null);

            }
            set
            {
                Type myType = GetType();
                PropertyInfo myPropInfo = myType.GetProperty(name);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}
