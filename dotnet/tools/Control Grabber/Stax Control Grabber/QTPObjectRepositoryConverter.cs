using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;


namespace Stax.ControlGrabber
{
    public class QTPObjectRepositoryConverter
    {
        public List<Control> Convert(string fileName)
        {
            List<Control> ConvertedControls = new List<Control>();
            //Holds the contents of the Object Repository file
            string RepositoryFileContents;

            //Read out the contents of the trx file
            using (StreamReader orReader = new StreamReader(fileName))
            {
                RepositoryFileContents = orReader.ReadToEnd();
                orReader.Close();
            }

            //Load the file contents into an XML document object
            XmlDocument orFileXml = new XmlDocument();
            orFileXml.LoadXml(RepositoryFileContents);

            //Configure the namespace manager
            XmlNamespaceManager xmlManager = new XmlNamespaceManager(orFileXml.NameTable);
            xmlManager.AddNamespace("ns", "http://www.mercury.com/qtp/ObjectRepository");

            XmlNodeList resultNodes = orFileXml.GetElementsByTagName("qtpRep:Object");

            ConvertedControls = ProcessResultsNode(resultNodes);
            return ConvertedControls;
        }


        private List<Control> ProcessResultsNode(XmlNodeList resultNodes)
        {
            List<Control> resultCollection = new List<Control>();
            foreach (XmlNode sourceNode in resultNodes)
            {
                //Send each result to the publish method
                Control singleControl = ProcessSingleObjectNode(sourceNode);
                if (singleControl != null)
                {
                    if (singleControl.Type != ControlType.none)
                    {
                        resultCollection.Add(singleControl);
                    }
                }
            }
            return resultCollection;

        }


         internal Control ProcessSingleObjectNode(XmlNode theResultNode)
         {
             Control newControl = new Control();

             newControl.WaitForComplete = true;
             

             XmlDocument xdoc = new XmlDocument();
             xdoc.LoadXml(theResultNode.OuterXml);
             bool weCare = false;



            newControl.Name = theResultNode.Attributes["Name"].Value;

            string QTPClass = theResultNode.Attributes["Class"].Value;

            Console.WriteLine("+++++++++++++++++++++++++");
            Console.WriteLine("Name:" + newControl.Name);
            Console.WriteLine("Class:" + QTPClass);

            switch (QTPClass.ToLower())
            {
                    // WebFile
                    // WebElement

                case "webbutton":

                    newControl.Type = ControlType.button;
                    weCare = true;
                    break;

                case "webtable":
                    newControl.Type = ControlType.none;
                    break;

                case "webcheckbox":
                    newControl.Type = ControlType.checkBox;
                    weCare = true;
                    break;

                case "weblist":
                    newControl.Type = ControlType.select;
                    weCare = true;
                    break;

                case "webedit":
                    newControl.Type = ControlType.text;
                    weCare = true;
                    break;

                case "webradiogroup":
                    newControl.Type = ControlType.radiobutton;
                    weCare = true;
                    break;

                case "link":
                    newControl.Type = ControlType.link;
                    weCare = true;

                    break;


                case "browser":
                case "page":
                case "winbutton":
                default:

                    newControl.Type = ControlType.none;
                    break;
            }


            if (weCare)
            {

                //Configure the namespace manager
                XmlNamespaceManager xmlManager = new XmlNamespaceManager(xdoc.NameTable);
                xmlManager.AddNamespace("ns", "http://www.mercury.com/qtp/ObjectRepository");

                XmlNodeList resultNodes = xdoc.GetElementsByTagName("qtpRep:Property");

                foreach (XmlNode item in resultNodes)
                {
                    Console.WriteLine("     ");
                    Console.WriteLine("     Name:" + item.Attributes["Name"].Value);
                    Console.WriteLine("     Value:" + item.FirstChild.InnerText);


                    if (item.Attributes["Name"].Value == "html id")
                    {
                        if (!string.IsNullOrEmpty(item.FirstChild.InnerText))
                        {
                            newControl.Key = ControlKeyType.id;
                            newControl.Value = item.FirstChild.InnerText;
                            return newControl;
                        }
                    }

                    else if ( item.Attributes["Name"].Value == "value")
                    {
                        if (!string.IsNullOrEmpty(item.FirstChild.InnerText))
                        {
                            newControl.Key = ControlKeyType.value;
                            newControl.Value = item.FirstChild.InnerText;
                            return newControl;
                        }

                    }
                    else if (item.Attributes["Name"].Value == "name")
                    {
                        if (!string.IsNullOrEmpty(item.FirstChild.InnerText))
                        {
                            newControl.Key = ControlKeyType.name;
                            newControl.Value = item.FirstChild.InnerText;
                            return newControl;
                        }

                    }

                    else if (item.Attributes["Name"].Value == "text")
                    {
                        if (!string.IsNullOrEmpty(item.FirstChild.InnerText))
                        {
                            newControl.Key = ControlKeyType.text;
                            newControl.Value = item.FirstChild.InnerText;
                            return newControl;
                        }

                    }

                    else if (item.Attributes["Name"].Value == "href")
                    {
                        if (!string.IsNullOrEmpty(item.FirstChild.InnerText))
                        {
                            newControl.Key = ControlKeyType.href;
                            newControl.Value = "'" + item.FirstChild.InnerText + "'" ;
                            return newControl;
                        }

                    }


                }
            }
     
            return newControl;
        }

        private string GetText(XmlNode context, String xPath)
        {
            String value = String.Empty;

            XmlNode node = context.SelectSingleNode(xPath);
            if (node != null)
            {
                value = node.InnerText;
            }

            return value;
        }
    }
}
