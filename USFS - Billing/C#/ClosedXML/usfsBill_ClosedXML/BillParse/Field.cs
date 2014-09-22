﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillParse
{
    class Field
    {
        private string _name;
        private int _start;
        private int _length;
        private string _type;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
