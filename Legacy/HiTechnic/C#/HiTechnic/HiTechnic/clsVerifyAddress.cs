using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Globalization;
using System.Web;



namespace HiTechnic
{
    class clsVerifyAddress
    {
        /*********** - Properties - *********************/
        private string strCity;
        private string strState;
        private string strZip;
        private string strCountry;
        private string strCountryCode;
        private bool blError;
        private string strErrorString;
        private string strOrderNumber;

        public string City
        {
            get
            {
                return strCity;
            }
        }

        public string State
        {
            get
            {
                return strState;
            }
        }

        public string Zip
        {
            get
            {
                return strZip;
            }
        }

        public string Country
        {
            get
            {
                return strCountry;
            }
        }

        public string CountryCode
        {
            get
            {
                return strCountryCode;
            }
        }

        public string OrderNumber
        {
            get
            {
                return strOrderNumber;
            }
            set
            {
                strOrderNumber = value;
            }
        }

        public bool Error
        {
            get
            {
                return blError;
            }
        }

        public string ErrorString
        {
            get
            {
                return strErrorString;
            }

        }

        /***********    - Methods - ***************/
        public void verifyAddress(string Zip, string Country)
        {
            if (strCountry == "")
                Country="United States";

            string strUrl = tryYahoo(Country, Zip);
            XmlDocument doc = returnXML(strUrl);
            
            string sZip = returnYahooData(doc, Country, Zip);
            if (sZip == null)
            {
                strUrl = tryGeoName(strCountryCode, Zip);
                doc = returnXML(strUrl);
                strZip = returnGeoNameData(doc, Zip);
            }

            if(blError==true)
                strErrorString = "Order #" + strOrderNumber + " - does not have a valid zip code for the given country (" + strCountry + ")";
        }

        public void verifyAddress(string strLine1, string strCity, string strState, string strCountry)
        {
/*            string strUrl;
            if (strCountry == "")
                strCountry = "United States";
            
            if (strState != "")
            {
                strUrl = "http://where.yahooapis.com/geocode?line1=" + strLine1 + "&city=" + strCity + "&state=" + strState + "&country=" + strCountry;
            }
            else
            {
                strUrl = "http://where.yahooapis.com/geocode?line1=" + strLine1 + "&city=" + strCity + "&country=" + strCountry;
            }
            returnXML(strUrl);

            if (blError == true)
                strErrorString = "Order #" + strOrderNumber + " - does not have a zip code and the address could not be verified with provided information";
       
 */          
        }

        private XmlDocument returnXML(string strUrl)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(strUrl);
            return doc;
        }

        private string tryYahoo(string Country, string Zip = "", string City = "", string State = "", string Line1 = "")
        {
            string strUrl = "";

            if (Zip != "")
            {
                strUrl = "http://where.yahooapis.com/geocode?postal=" + Zip + "&country=" + Country;
            }
            else if (State != "")
            {
                strUrl = "http://where.yahooapis.com/geocode?line1=" + Line1 + "&city=" + City + "&state=" + State + "&country=" + Country;
            }
            else if (State == "")
            {
                strUrl = "http://where.yahooapis.com/geocode?line1=" + Line1 + "&city=" + strCity + "&country=" + strCountry;
            }
            return strUrl;
        }

        private string returnYahooData(XmlDocument doc, string Country,string Zip="",string City="")
        {
            XPathNavigator xmlNavigator = doc.CreateNavigator();
            XmlNode xmlNode = doc.SelectSingleNode("/ResultSet/Found");
            int intFound = int.Parse(xmlNode.FirstChild.Value);

            xmlNode = doc.SelectSingleNode("/ResultSet/Result");
            if (intFound > 0 && Country == xmlNode.ChildNodes[21].InnerText)
            {
                strCountry = xmlNode.ChildNodes[21].InnerText;
                strCountryCode = xmlNode.ChildNodes[22].InnerText;
                
                if (City != "" && City == xmlNode.ChildNodes[18].InnerText)
                {
                    strCity = xmlNode.ChildNodes[18].InnerText;
                    strState = xmlNode.ChildNodes[23].InnerText;
                    strZip = xmlNode.ChildNodes[16].InnerText;
                }
                else if (Zip != "" && Zip == xmlNode.ChildNodes[16].InnerText)
                {
                    strCity = xmlNode.ChildNodes[18].InnerText;
                    strState = xmlNode.ChildNodes[23].InnerText;
                    strZip = xmlNode.ChildNodes[16].InnerText;
                }
            }
            else      
            {
                blError = true;
            }

            return strZip;
        }

        private string tryGeoName(string CountryCode, string Zip)
        {
            return "http://api.geonames.org/postalCodeSearch?postalcode=" + Zip + "&country=" + CountryCode + "&username=HumanTechnologies";
        }

        private string returnGeoNameData(XmlDocument doc, string Zip)
        {
            XPathNavigator xmlNavigator = doc.CreateNavigator();
            XmlNode xmlNode = doc.SelectSingleNode("/geonames/totalResultsCount");
            int intFound = int.Parse(xmlNode.FirstChild.Value);

            xmlNode = doc.SelectSingleNode("/geonames/code");
            Test(xmlNode.ChildNodes[1].InnerText.ToString());
            if (Zip != "" && Zip == xmlNode.ChildNodes[0].InnerText)
            {
                strCity = xmlNode.ChildNodes[1].InnerText;
                strState = xmlNode.ChildNodes[6].InnerText;
                strZip = xmlNode.ChildNodes[0].InnerText;
            }
            else
            {
                blError = true;
            }

            return strZip;
        }


        private void Test(string TestString)
        {
            Encoding Russian = Encoding.GetEncoding(1251);
            Encoding English = Encoding.GetEncoding(1252);
            byte[] unicodeBytes = Russian.GetBytes(TestString);
            byte[] EnglishBytes = Encoding.Convert(Russian, English, unicodeBytes);
            char[] EnglishChars = new char[English.GetCharCount(EnglishBytes, 0, EnglishBytes.Length)];
            English.GetChars(EnglishBytes, 0, EnglishBytes.Length, EnglishChars, 0);
            string EnglishString = new string(EnglishChars);

            string test = System.Text.Encoding.GetEncoding(1252).GetString(EnglishBytes); 

             
        }

    }
}
