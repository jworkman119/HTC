using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmPinnacle
{
    

    public partial class ctlTabs : UserControl
    {
        private string _User;
        private string _Position;
        public event Enable EnableButtons;
        public event PassConsumer PassConsumerID_Frame;
        
       
        public ctlTabs(string User, string Position)
        {
            InitializeComponent();
            _User = User;
            _Position = Position;
            loadControls(_Position);
        }

        private void loadControls(string Status)
        {
            if (_Position == "Stf")
            {
              TabControl.TabPageCollection objTabs  =  this.tabMain.TabPages;
              setupTabs_Staff(objTabs);
            }
        }

        private void setupTabs_Staff(TabControl.TabPageCollection objTabs)
        {
            staffActivityLog objStaff = new staffActivityLog(_User);
            

            TabPage objTab = addControl2Tab("Consumer",objStaff);

            this.tabMain.Width = objTab.Width + 10;
            this.tabMain.Height = objTab.Height + 20;
            this.tabMain.TabPages.Add(objTab);
            this.Height = tabMain.Height + 30;
            this.Width = tabMain.Width + 5;
        }



        private TabPage addControl2Tab(string Name, UserControl objControl)
        {
            TabPage objTab = new TabPage(Name);
            
            objTab.Width = objControl.Width + 10;
            objTab.Height = objControl.Height + 10;
            objTab.Controls.Add(objControl);
            return objTab;
        }
    }
}
