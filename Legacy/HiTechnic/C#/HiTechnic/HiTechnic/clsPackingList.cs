using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;


namespace HiTechnic
{
   

    class clsPackingList
    {
        public event SystemStatus RelayStatus;
        private string strPackingXML = Path.GetTempPath() + "PackingList.xml";
        private string strPackingPDF = Path.GetTempPath() + "PackingList.pdf";

        public void returnPackingList(string strOrder, string strType)
        {
            writeXML(strOrder,strType);
            createPackingList(strType);
        }

     

        private void writeXML(string strOrder,string strType)
        {
            
            XmlWriter xmlWrite = XmlWriter.Create(strPackingXML);
            xmlWrite.WriteStartDocument();
                xmlWrite.WriteStartElement("Orders");
                xmlWrite.WriteStartElement("Header");
                xmlWrite.WriteElementString("Date", DateTime.Today.ToString("M/dd/yyyy"));
                xmlWrite.WriteEndElement();
            
                    writeOrders(ref xmlWrite, strOrder);
                    writeShipTo(ref xmlWrite, strOrder);
                    writeBillTo(ref xmlWrite, strOrder);
                    xmlWrite.WriteEndElement(); //End of ShippingInfo
                    writeOrderDetails(ref xmlWrite, strOrder);
                    if (strType == "Completed Orders")
                    {
                        writeShippedInfo(ref xmlWrite, strOrder);
                    }                
            xmlWrite.WriteEndElement();
            xmlWrite.Close();
        }

        private void writeOrders(ref XmlWriter xmlWrite,string strOrder)
        {
            clsDatabase objDB = new clsDatabase(HiTecResources.DB);
            SQLiteDataReader objData = objDB.returnData("Select * From Orders where Number ='" + strOrder + "'");
            
                xmlWrite.WriteStartElement("Order");
                xmlWrite.WriteElementString("LastOrder", "True");
                
                xmlWrite.WriteStartElement("ShippingInfo");
                    xmlWrite.WriteElementString("Number", objData["Number"].ToString());
                    xmlWrite.WriteElementString("Carrier",objData["ShipMethod"].ToString());
                    xmlWrite.WriteElementString("Email",objData["Email"].ToString());
                    xmlWrite.WriteElementString("Phone",objData["Telephone"].ToString());
                    xmlWrite.WriteElementString("ShippingAccount", objData["ShippingAccount"].ToString());
                    xmlWrite.WriteElementString("AES",objData["AES"].ToString());

        }

        private void writeShipTo(ref XmlWriter xmlWrite, string strOrder)
        {
            clsDatabase objDB = new clsDatabase(HiTecResources.DB);
            SQLiteDataReader objData = objDB.returnData("Select * From ShipTo where Orders_Number ='" + strOrder + "'");

            xmlWrite.WriteStartElement("ShipTo");
                xmlWrite.WriteElementString("Contact", objData["Contact"].ToString());
                xmlWrite.WriteElementString("Address1", objData["Address1"].ToString());
                xmlWrite.WriteElementString("Address2", objData["Address2"].ToString());
                xmlWrite.WriteElementString("Address3", objData["Address3"].ToString());
                string strCityStateZip = objData["City"].ToString() + ", " + objData["State"].ToString() + " " + objData["Zip"].ToString();
                xmlWrite.WriteElementString("CityStateZip", strCityStateZip);
                xmlWrite.WriteElementString("Country", objData["Country"].ToString());
            xmlWrite.WriteEndElement();
        }

        private void writeBillTo(ref XmlWriter xmlWrite, string strOrder)
        {
            clsDatabase objDB = new clsDatabase(HiTecResources.DB);
            SQLiteDataReader objData = objDB.returnData("Select * From BillTo where Orders_Number ='" + strOrder + "'");

            xmlWrite.WriteStartElement("BillTo");
            xmlWrite.WriteElementString("Contact", objData["Contact"].ToString());
            xmlWrite.WriteElementString("Address1", objData["Address1"].ToString());
            xmlWrite.WriteElementString("Address2", objData["Address2"].ToString());
            xmlWrite.WriteElementString("Address3", objData["Address3"].ToString());
            string strCityStateZip = objData["City"].ToString() + ", " + objData["State"].ToString() + " " + objData["Zip"].ToString();
            xmlWrite.WriteElementString("CityStateZip", strCityStateZip);
            xmlWrite.WriteElementString("Country", objData["Country"].ToString());
            xmlWrite.WriteEndElement();

        }

        private void writeOrderDetails(ref XmlWriter xmlWrite, string strOrder)
        {
            clsDatabase objDB = new clsDatabase(HiTecResources.DB);
            string strSQL = "Select sum(Qty)as Qty From OrderDetails Where OrderDetails.Orders_Number ='" + strOrder + "'";
            SQLiteDataReader objData = objDB.returnData(strSQL);
            string strQty = objData["Qty"].ToString();

            strSQL = "SELECT PartID, Description, Qty";
            strSQL = strSQL + " FROM OrderDetails";
            strSQL = strSQL + " WHERE Orders_Number ='" + strOrder + "'";

            objData = objDB.returnData(strSQL);
            xmlWrite.WriteStartElement("OrderDetails");
            xmlWrite.WriteAttributeString("TotalQty", strQty);

            while (objData.Read())
            {
                xmlWrite.WriteStartElement("Item");
                    xmlWrite.WriteElementString("Number", objData["PartID"].ToString());
                    xmlWrite.WriteElementString("Description", objData["Description"].ToString());
                    xmlWrite.WriteElementString("Qty", objData["Qty"].ToString());
                xmlWrite.WriteEndElement();
            }

            xmlWrite.WriteEndElement();
        }

        private void writeShippedInfo(ref XmlWriter xmlWrite, string strOrder)
        {
            clsDatabase objDB = new clsDatabase(HiTecResources.DB);
            SQLiteDataReader objData = objDB.returnData("Select * From Tracking where Orders_Number ='" + strOrder + "'");

            xmlWrite.WriteStartElement("SentInfo");
                xmlWrite.WriteElementString("Tracking",objData["Tracking"].ToString());
                xmlWrite.WriteElementString("Carrier", objData["ShipMethod"].ToString());
                DateTime TS = Convert.ToDateTime(objData["TS"]);
                xmlWrite.WriteElementString("ShippedDate", TS.ToString("MM/dd/yyyy hh:mm")); //DateTime.Today.ToString("M/dd/yyyy")
                xmlWrite.WriteElementString("Weight", objData["Weight"].ToString());
                xmlWrite.WriteElementString("ShipCost", objData["Cost"].ToString());
            xmlWrite.WriteEndElement();
        }

        private void createPackingList(string strType)
        {
            //Deleting packing list that's already in the system
            File.Delete(strPackingPDF);

            bool Error = CreateFO(strType);
            if (Error == false)
            {
                //PrintWFoxIT(true);
                PrintPDF();
            }
        }

        public bool CreateFO(string strType)
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();
            
            objProcess.StartInfo.WorkingDirectory = HiTecResources.FOP_Directory; 

            objProcess.StartInfo.FileName = "fop.bat";
            if (strType == "Completed Orders")
            {
                objProcess.StartInfo.Arguments = "-xml %Temp%\\PackingList.xml -xsl ..\\PackingListShipped.xsl  -pdf %Temp%\\PackingList.pdf";
            }
            else
            {
                objProcess.StartInfo.Arguments = "-xml %Temp%\\PackingList.xml -xsl ..\\PackingList.xsl  -pdf %Temp%\\PackingList.pdf";
            }
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            objProcess.Start();

            //sleeping the code, until the process completes. If it takes more than 7 seconds I will produce an error.
            int intSleep = 0;
            bool blProcess = false;
            while (objProcess.HasExited == false)
            {
                System.Threading.Thread.Sleep(500);
                if (intSleep == 14)
                {
                    // raise an error, and place in messagebox
                    RelayStatus("Error - the pdf could not be created. Please contact tech support");
                    blProcess = true;
                    break;
                }
                intSleep++;
            }
            objProcess.Close();
            return blProcess;
        }

        public void PrintPDF()
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();

            objProcess.StartInfo.CreateNoWindow = true;

            objProcess.StartInfo.WorkingDirectory = HiTecResources.FoxIt_Directory;
            objProcess.StartInfo.FileName = "Foxit Reader.exe";

            
            string strArguments = "/p \"" + @strPackingPDF + "\"";
            objProcess.StartInfo.Arguments = strArguments;

            objProcess.Start();
            
        }
    }
}
