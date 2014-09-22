using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;


namespace consoleUpdateRemoteDB
{
    class clsPingTest
    {
        public bool PingTest(string strURL)
        {
            System.Net.NetworkInformation.Ping objPing = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions objOptions = new System.Net.NetworkInformation.PingOptions();
            objOptions.DontFragment = true;

            try{
                System.Net.NetworkInformation.PingReply objReply = objPing.Send(strURL, 4);
                return true;
            }
            catch(SystemException e)
            {
                return false;
            }
            
        }
    }
}
