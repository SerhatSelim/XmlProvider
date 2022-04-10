using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using XpathProvider;

namespace XmlXsdProvider
{
    partial class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XmlXsdProvider\RTGS_1218_enriched.xml");
            //xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XmlXsdProvider\RTGS_1540.xml");
            //xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XmlXsdProvider\EnrichedNew.xml");
            //xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XmlXsdProvider\EnrichedOld.xml");
            xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XsdValidator\message.xml");
            string xmlcontents = xmlDoc.InnerXml;
            TextReader tr = new StringReader(xmlcontents);
            XDocument doc = XDocument.Load(tr);

            foreach (XObject obj in doc.Descendants())
            {

                if (!((XElement)obj).HasElements)
                {
                    Console.WriteLine(obj.GetXPath2());
                    if (obj.GetType() == typeof(XElement))
                        Console.WriteLine(((XElement)obj).Name.LocalName);
                        Console.WriteLine(((XElement)obj).Value);
                    //else if (obj.GetType() == typeof(XAttribute))
                    //    Console.WriteLine(((XAttribute)obj).Value);
                }

            }




            //foreach (XObject obj in doc.DescendantNodes())
            //{
            //    if (obj.GetXPath() != null)
            //    {
            //        Console.WriteLine(obj.GetXPath());
            //        XElement el = obj as XElement;
            //        if (el != null)
            //        {

            //            foreach (XObject at in el.Attributes())
            //            {
            //                if (at.GetXPath() != null)
            //                {
            //                    Console.WriteLine(at.GetXPath());
            //                    if (at.GetType() == typeof(XElement))
            //                        Console.WriteLine(((XElement)at).Value);
            //                    else if (at.GetType() == typeof(XAttribute))
            //                        Console.WriteLine(((XAttribute)at).Value);


            //                }

            //            }
            //        }
            //    }

            //}
        }
    }
}
