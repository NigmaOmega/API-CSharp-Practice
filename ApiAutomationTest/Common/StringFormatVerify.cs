using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public static class StringFormatVerify
{
    public static bool IsHtmlFormat(this string input)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(input);

        if (doc.ParseErrors.Any())
        {
            foreach (var item in doc.ParseErrors)
            {
                Console.WriteLine(item);
            }
            return false;
        }

        return true;
    }

    public static bool IsXmlFormat(this string input)
    {
        try
        {
            new XmlDocument().LoadXml(input);
            return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

}

