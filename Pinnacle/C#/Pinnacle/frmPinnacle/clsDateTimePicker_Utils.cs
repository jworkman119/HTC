using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmPinnacle
{
    class clsDateTimePicker_Utils
    {
        public void Setup_BlankDate(ref DateTimePicker dtPicker)
        {
            dtPicker.CustomFormat = " ";
            dtPicker.Format = DateTimePickerFormat.Custom;
        }

        public void Setup_ShortDate(ref DateTimePicker dtPicker)
        {
            dtPicker.Format = DateTimePickerFormat.Short;
        }
    }
}
