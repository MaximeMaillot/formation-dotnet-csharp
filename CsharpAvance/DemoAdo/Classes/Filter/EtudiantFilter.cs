using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.Classes.Filter
{
    internal class EtudiantFilter
    {
        public int? etudiant_id { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public int? num_classe { get; set; }
        public DateTime? date_diplome { get; set; }

        public object this[string name]
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
