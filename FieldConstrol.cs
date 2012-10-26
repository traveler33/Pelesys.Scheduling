using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pelesys.Scheduling
{
    public  class FieldConstrol
    {
        private string _ControlName = string.Empty;
        private string _LableName = string.Empty;

        private bool _IsValidFieldName = false;
        public bool IsValidFieldName
        {
            get
            {
                return _IsValidFieldName;
            }

            set
            {

                _IsValidFieldName = value;
            }


        }

        public string LableName
        {
            get
            {
                return _LableName;
            }

            set
            {

                _LableName = value;
            }


        }

        public string ControlName
        {
            get
            {
                return _ControlName;
            }

            set
            {

                _ControlName = value;
            }


        }
    }
}
