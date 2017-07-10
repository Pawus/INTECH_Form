using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_Form.Models
{
    public class Form
    {
        private String _title;

        public Form()
        {
            _title = null;
        }

        public String Title {
            get {
                return _title;
            }
            set {
                _title = value;
            }
        }
    }
}
