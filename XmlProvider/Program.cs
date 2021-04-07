using System;
using System.Collections.Generic;
using System.IO;

namespace XmlProvider
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var demo = new DemoDto()
            {
                Code = 1,
                Name = "serhat"
            };

          

            //Xml serialize to string
            string xmlDemo = demo.ToXml();

            Console.WriteLine("Xml serialize to string: ");
            Console.WriteLine(xmlDemo);


            //Deserialize from string
            var deserializedDto = xmlDemo.DeserializeXML<DemoDto>();

            Console.WriteLine("Deserialize from string: ");
            Console.WriteLine(deserializedDto.Name);
            Console.WriteLine(deserializedDto.Code);


           
        }
    }
}
