namespace ConsoleApp
{
    public class Program
    {

        #region xml serialize and deserialize
            /// <summary>
            /// usage:  
            /// var xml = testObjectToXml();
            /// testXmlToObject(xml);
            ///  </summary>

        #region  case to test convert between object and xml 

        private static string testObjectToXml()
        {
            var men1 = new Montior() { name = "men1", room = "r1" };
            var tec1 = new Teacher()
            {
                name = "tech1",
                men = new List<Montior>() { men1 }
            };

            Student stu1 = new Student() { Name = "okbase", Age = 10, teacher = new List<Teacher>() { tec1 } };
            string xml = XmlUtil.Serializer(typeof(Student), stu1);
            Console.Write(xml);
            return xml;
        }
        private static void testXmlToObject(string xml)
        {
            Student stu2 = XmlUtil.Deserialize(typeof(Student), xml) as Student;
            Console.Write(string.Format("名字:{0},年龄:{1}", stu2.Name, stu2.Age));
        }
        public class Student
        {
            public string Name { set; get; }
            public int Age { set; get; }

            public List<Teacher> teacher { set; get; }
        }
        public class Teacher
        {
            public string name { get; set; }
            public List<Montior> men { get; set; }
        }
        public class Montior
        {
            public string name { get; set; }
            public string room { get; set; }
        }
        #endregion

        /// <summary>
        /// Xml序列化与反序列化
        /// </summary>
        public class XmlUtil
        {
            #region 反序列化
            /// <summary>
            /// 反序列化
            /// </summary>
            /// <param name="type">类型</param>
            /// <param name="xml">XML字符串</param>
            /// <returns></returns>
            public static object Deserialize(Type type, string xml)
            {
                try
                {
                    using (StringReader sr = new StringReader(xml))
                    {
                        XmlSerializer xmldes = new XmlSerializer(type);
                        return xmldes.Deserialize(sr);
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            /// <summary>
            /// 反序列化
            /// </summary>
            /// <param name="type"></param>
            /// <param name="xml"></param>
            /// <returns></returns>
            public static object Deserialize(Type type, Stream stream)
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(stream);
            }
            #endregion

            #region 序列化
            /// <summary>
            /// 序列化
            /// </summary>
            /// <param name="type">类型</param>
            /// <param name="obj">对象</param>
            /// <returns></returns>
            public static string Serializer(Type type, object obj)
            {
                string str = string.Empty;
                using (MemoryStream Stream = new MemoryStream())
                {
                    XmlSerializer xml = new XmlSerializer(type);
                    try
                    {
                        xml.Serialize(Stream, obj);
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }
                    Stream.Position = 0;
                    using (StreamReader sr = new StreamReader(Stream))
                    {
                        str = sr.ReadToEnd();
                    }
                }
                return str;
            }

            #endregion
        }
        #endregion
	}
}