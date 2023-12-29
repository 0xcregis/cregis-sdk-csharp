using javax.xml.crypto;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CregisSdk.Core.Util
{
    public class ModelUtil
    {
        public static Dictionary<string, object> ModelToDict<T>(T model)
        {
            var d = model.GetType().GetProperties()//这一步获取匿名类的公共属性，返回一个数组
                .OrderBy(q => q.Name)//这一步排序，需要引入System.Linq，当然可以省略
                .ToDictionary(q => q.Name, q => q.GetValue(model));//这一步将数组转换为字典
            return d;
        }
       /* public static Dictionary<string, object> ModelToDict<T>(T model)
        {
            if (model == null)
                return new Dictionary<string, object>();
            //将model实体转为Dictionary<string, object>
            Dictionary<string, object> dicts = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(model));
            return dicts;
        }*/

        public static T DictToModel<T>(Dictionary<string, object> dicts)
        {
            if (dicts == null)
                return default(T);
            //将Dictionarymodel转化为model实体
            T model = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dicts));
            return model;
        }

        public static T StrToModel<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static string DictToStr(Dictionary<string, object> dicts)
        {
            return JsonConvert.SerializeObject(dicts);
        }
    }
}
