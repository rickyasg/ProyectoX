using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HamSecurityModel
{
    public class SecTOC
    {
        public List<SecMenuItem> MenuItems { get; set; }
        public string TOCJson { get; set; }

        public SecTOC(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                MenuItems = jss.Deserialize<List<SecMenuItem>>(json);
                TOCJson = json;
            }
        }
    }



    //public class NullPropertiesConverter : JavaScriptConverter
    //{
    //    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    //    {
    //        var jsonExample = new Dictionary<string, object>();
    //        foreach (var prop in obj.GetType().GetProperties())
    //        {
    //            //check if decorated with ScriptIgnore attribute
    //            bool ignoreProp = prop.IsDefined(typeof(ScriptIgnoreAttribute), true);

    //            var value = prop.GetValue(obj, BindingFlags.Public, null, null, null);
    //            if (value != null && !ignoreProp)
    //                jsonExample.Add(prop.Name, value);
    //        }

    //        return jsonExample;
    //    }

    //    public override IEnumerable<Type> SupportedTypes
    //    {
    //        get { return GetType().Assembly.GetTypes(); }
    //    }
    //}
    //[DataContract]
    public class SecMenuItem
    {
        //[JsonProperty("results")]
        //[DataMember(Name = "Label", IsRequired = true)]
        public string label { get; set; }

        //[JsonProperty("results")]
        //[DataMember(Name = "Label", IsRequired = false)]
        public string icon { get; set; }

        //[JsonProperty("results")]
        //[DataMember(Name = "RouterLink", IsRequired = false)]
        public List<string> routerLink { get; set; }

        //[JsonProperty("results")]
        //[DataMember(Name = "Command", IsRequired = false)]
        public string command { get; set; }
        
        //[JsonProperty("results")]
        //[DataMember(Name = "Url", IsRequired = false)]
        public string url { get; set; }

        //[JsonProperty("results")]
        //[DataMember(Name = "Target", IsRequired = false)]
        public string target { get; set; }

        public List<SecMenuItem> items { get; set; }


    }
    
}
