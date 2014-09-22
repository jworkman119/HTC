using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Drawing.Printing;
using System.Diagnostics;




namespace HiTechnic
{


    public delegate void SystemStatus(string message);
    


    class clsUploadData
    {
        public event SystemStatus RelayStatus;
        string strDB = HiTecResources.DB;
        string xmlPackingList = Path.GetTempPath() + "\\PackingList.xml";
        string csvPackingList = Path.GetTempPath() + "\\DailyFinal.csv";


        /* Creating struct for readability */
        public struct Data
        {
            public string OrderNumber;
            public string BillToContact;
            public string BillToLine1;
            public string BillToLine2;
            public string BillToLine3;
            public string BillToLine4;
            public string BillToCity;
            public string BillToState;
            public string BillToPostalCode;
            public string BillToCountry;
            public string BillToCountryCode;
            public string ShipToContact;
            public string ShipToLine1;
            public string ShipToLine2;
            public string ShipToLine3;
            public string ShipToLine4;
            public string ShipToCity;
            public string ShipToState;
            public string ShipToPostalCode;
            public string ShipToCountry;
            public string ShipToCountryCode;
            public string ShipMethod;
            public string CustEmailAddr;
            public string TelephoneNbr;
            public string ItemNumber;
            public string ItemDescription;
            public int    Qty;
            public float  Price;
            public float SubtotalPerLine;
            public int TotalQtyPerOrder;
            public float Subtotal;  
            public float  Weight;
            public string aesNumber;
            public string ShippingAccountNo;
            public long    SectionBCode; //will probably phase out Section B Codes and just public integrate it within FedEx application
            public string SectionBDescription;
        }
        
        public void uploadData(string strFile, string strDatabase, int Rows)
        {
            
            RelayStatus("Adding Data to Database");
            streamData(strFile, Rows);

            RelayStatus("Creating Packing List");
            // TEST
            createPackingList();
            
        }

        private void streamData(string strFile, int Rows)
        {
            FileStream objStream = new FileStream(strFile, FileMode.Open);
            StreamReader objReader = new StreamReader(objStream);

            System.Collections.ArrayList objErrors =  new System.Collections.ArrayList();
            
            
            int CurrentRow = 1;            
            string strOrder = "";
            bool blStart=true;
            
            clsDatabase objDB = new clsDatabase(strDB);

            XmlWriter xmlWrite = XmlWriter.Create(xmlPackingList);
            xmlWrite.WriteStartDocument();
            xmlWrite.WriteStartElement("Orders");
            xmlWrite.WriteStartElement("Header");
                xmlWrite.WriteElementString("Date",DateTime.Today.ToString("M/dd/yyyy"));
            xmlWrite.WriteEndElement();
            
            while(objReader.EndOfStream != true)
            {
                string strLine = objReader.ReadLine();
                strLine = strLine.Replace("'", "''");
                string[] arLine = strLine.Split('|');


                    Data objData = addToStruct(arLine);

                    // Creating Packing List, condition placed so I can tell xml we have last order in list.
                    if (CurrentRow < Rows)
                        {
                            strOrder = createXML(objData, ref xmlWrite, strOrder, ref blStart, false);
                         }
                    else
                    {
                        strOrder = createXML(objData, ref xmlWrite, strOrder, ref blStart, true);
                    }
                
                    // TEST
                    addToDB(objData, strDB, objDB);
                    CurrentRow++;

            }
            
            xmlWrite.WriteEndElement();
            xmlWrite.Close();
            objReader.Close();
            objReader.Dispose();
            objStream.Dispose();
            // send Nancy a list of orders that didn't process.
            processErrors(objErrors);
        }

        private void addToDB(Data objData, string strDB, clsDatabase objDB)
        {

            
            objDB.addToDB(objData);
            if (objDB.Error != null)
            {
                // Add to array, that will be used to create an email that will be sent to Nancy.
            }
        }

        private Data addToStruct(string[] arLine)
        {
            Data objData = new Data();
            clsDatabase objDB = new clsDatabase(strDB);

            objData.OrderNumber = arLine[4];
            objData.BillToContact = arLine[8];
            objData.BillToLine1 = arLine[9];
            objData.BillToLine2 = arLine[10];
            objData.BillToLine3 = arLine[11];
            objData.BillToLine4 = arLine[12];
            objData.BillToCity = arLine[13];
            objData.BillToState = arLine[14];
            objData.BillToPostalCode = arLine[15];
            objData.BillToCountryCode = arLine[16];
            objData.BillToCountry = objDB.returnCountry(arLine[16]);
            objData.ShipToContact = arLine[17];
            objData.ShipToLine1 = arLine[18];
            objData.ShipToLine2 = arLine[19];
            objData.ShipToLine3 = arLine[20];
            objData.ShipToLine4 = arLine[21];
            objData.ShipToCity = arLine[22];
            objData.ShipToState = arLine[23];
            objData.ShipToPostalCode = arLine[24];
            objData.ShipToCountryCode = arLine[25];
            // Todo - change the way I'm entering country code, will enter country code into Database
            objData.ShipToCountry = objDB.returnCountry(arLine[25]);
            objData.ShipMethod = arLine[31];
            objData.CustEmailAddr = arLine[54].Trim();
            objData.ShippingAccountNo = arLine[55];
            objData.TelephoneNbr = arLine[57].Trim();
            objData.ItemNumber = arLine[42].Trim();
            objData.ItemDescription = arLine[43].Replace("'", "''");
            objData.Qty = Convert.ToInt16(arLine[41]);
            objData.Price = Convert.ToSingle(arLine[46]);
            objData.SubtotalPerLine = Convert.ToInt16(arLine[41]) * Convert.ToSingle(arLine[46]);
            objData.TotalQtyPerOrder = Convert.ToInt16(arLine[52]);
            if (arLine[53].Length > 0)
            {
                objData.Subtotal = Convert.ToSingle(arLine[53]);
            }
            objData.aesNumber = arLine[62];

            
            return objData;
        }

        private Data addToStruct_Legacy(string[] arLine)
        {
            Data objData = new Data();

            objData.OrderNumber = arLine[5];
            objData.BillToLine1 = arLine[9];
            objData.BillToLine2 = arLine[10];
            objData.BillToLine3 = arLine[11];
            objData.BillToLine4 = arLine[12];
            objData.BillToCity = arLine[13];
            objData.BillToState = arLine[14];
            objData.BillToPostalCode = arLine[15];
            objData.BillToCountry = arLine[16];
            objData.ShipToLine1 = arLine[17];
            objData.ShipToLine2 = arLine[18];
            objData.ShipToLine3 = arLine[19];
            objData.ShipToLine4 = arLine[20];
            objData.ShipToCity = arLine[21];
            objData.ShipToState = arLine[22];
            objData.ShipToPostalCode = arLine[23];
            objData.ShipToCountry = arLine[24];
            //objData.FirstOfCountryCode = arLine[];
            objData.ShipMethod = arLine[30];
            objData.CustEmailAddr = arLine[51].Trim();
            objData.ShippingAccountNo = arLine[52];
            objData.TelephoneNbr = arLine[54].Trim();
            objData.ItemNumber = arLine[40].Trim();
            objData.ItemDescription = arLine[41].Replace("'","''");
            objData.Qty = Convert.ToInt16(arLine[39]);
            objData.Price = Convert.ToSingle(arLine[44]);
            objData.SubtotalPerLine = Convert.ToInt16(arLine[39]) * Convert.ToSingle(arLine[44]);
// Legacy Format - will delete when get word from Mark 
            if (arLine[50].Length > 0)
            {
                objData.Subtotal = Convert.ToSingle(arLine[50]);
            }
           objData.aesNumber = arLine[59];

/* New Format - waiting on Mark to implement this
            objData.TotalQtyPerOrder = Convert.ToInt16(arLine[50]);
            objData.Subtotal = Convert.ToSingle(arLine[51]);
            objData.aesNumber = arLine[61];
            objData.SectionBCode = Convert.ToInt64(arLine[63]);
            objData.SectionBDescription = arLine[64];
*/            
            return objData;
        }

        //Needed for Packing List - todo move to own class
        private string createXML(Data objData,ref XmlWriter xmlWrite,string strOrder,ref bool blStart,bool blLastRow)
        {
            if (objData.OrderNumber != strOrder)
            {
                if (blStart == true)
                {
                    blStart = false;
                }
                else // Need to end the previous element
                {
                    xmlWrite.WriteEndElement();
                    
                    xmlWrite.WriteEndElement();
                }

                writeOrder(objData, ref xmlWrite,blLastRow);

            }
            else
            {
                writeOrderDetails(objData, ref xmlWrite);
            }
            
            return objData.OrderNumber;
        }

        private void writeOrder(Data objData, ref XmlWriter xmlWrite,bool blLast)
        {
            xmlWrite.WriteStartElement("Order");
            xmlWrite.WriteElementString("LastOrder", blLast.ToString());
            xmlWrite.WriteElementString("OrderNumber", objData.OrderNumber);
            xmlWrite.WriteStartElement("ShippingInfo");
            xmlWrite.WriteElementString("Number", objData.OrderNumber);
            xmlWrite.WriteStartElement("BillTo");
                xmlWrite.WriteElementString("Contact", objData.BillToContact);
                xmlWrite.WriteElementString("Address1", objData.BillToLine1);
                xmlWrite.WriteElementString("Address2", objData.BillToLine2);
                xmlWrite.WriteElementString("Address3", objData.BillToLine3);
                xmlWrite.WriteElementString("CityStateZip", objData.BillToCity + ", " + objData.BillToState + " " + objData.BillToPostalCode);
                xmlWrite.WriteElementString("Country", objData.BillToCountry);
            xmlWrite.WriteEndElement();

            xmlWrite.WriteStartElement("ShipTo");
                xmlWrite.WriteElementString("Contact", objData.ShipToContact);
                xmlWrite.WriteElementString("Address1", objData.ShipToLine1);
                xmlWrite.WriteElementString("Address2", objData.ShipToLine2);
                xmlWrite.WriteElementString("Address3", objData.ShipToLine3);
                xmlWrite.WriteElementString("CityStateZip", objData.ShipToCity + ", " + objData.ShipToState + " " + objData.ShipToPostalCode);
                xmlWrite.WriteElementString("Country", objData.ShipToCountry);
            xmlWrite.WriteEndElement();

            xmlWrite.WriteElementString("Carrier", objData.ShipMethod); // todo change shipmethod to Carrier
            xmlWrite.WriteElementString("Email", objData.CustEmailAddr); //todo change to email
            xmlWrite.WriteElementString("Phone", objData.TelephoneNbr); //todo change to Phone
            xmlWrite.WriteElementString("ShippingAccount", objData.ShippingAccountNo);
            xmlWrite.WriteElementString("AES", objData.aesNumber); // todo change to aes
            
            xmlWrite.WriteEndElement();

            //Start Order Details
            xmlWrite.WriteStartElement("OrderDetails");
                xmlWrite.WriteAttributeString("TotalQty", objData.TotalQtyPerOrder.ToString());
                xmlWrite.WriteAttributeString("SubTotal", String.Format("{0:c}",objData.Subtotal));
            writeOrderDetails(objData, ref xmlWrite);
            
        }

        private void writeOrderDetails(Data objData, ref XmlWriter xmlWrite)
        {
            xmlWrite.WriteStartElement("Item");
                xmlWrite.WriteElementString("Number", objData.ItemNumber);
                xmlWrite.WriteElementString("Description", objData.ItemDescription);
                xmlWrite.WriteElementString("Qty", Convert.ToString(objData.Qty));
            xmlWrite.WriteEndElement();
            
        }

        private void createPackingList()
        {
            clsPackingList objPackingList = new clsPackingList();
            objPackingList.RelayStatus += new SystemStatus(NewStatus);

            //Using Apache FOP, to create pdf
            RelayStatus("Creating Packing List");
            objPackingList.CreateFO("Incomplete Orders");
            
            // Printing pdf w/ FoxItReader
            RelayStatus("Sending Packing List to Printer");
            objPackingList.PrintPDF();
            objPackingList.PrintPDF();

        }

        private void NewStatus(string strStatus)
        {
            RelayStatus(strStatus);
        }

        private void verifyAddress(ref clsVerifyAddress objVerify, string[] arLine)
        {
            objVerify.OrderNumber = arLine[5];
            if (arLine[23] != "")
            {
                objVerify.verifyAddress(arLine[23], arLine[24]);
            }
            else
            {
                objVerify.verifyAddress(arLine[18], arLine[21], arLine[22], arLine[24]);
            }
        }

        private void processErrors(System.Collections.ArrayList objErrors)
        {
            if (objErrors.Count > 0)
            {
    //            clsEmail objMail = new clsEmail();
    //            objMail.sendErrors(objErrors);
            }
        }
  }
}

