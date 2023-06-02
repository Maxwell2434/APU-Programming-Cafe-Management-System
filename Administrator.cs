using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    internal class Administrator
    {
        private string _id;
        private string _name;
        private string _address;
        private string _phone;
        private string _email;
        private string _userId;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public Administrator(Administrator_Table adminTable, string UserId) 
        {
            List<Row> rows = adminTable.Search_Row_For_Value(adminTable.UserId, UserId);
            if (rows.Count == 1)
            {
                _id = rows[0].values[adminTable.Id];
                _name = rows[0].values[adminTable.Name];
                _address = rows[0].values[adminTable.Address];
                _phone = rows[0].values[adminTable.Phone];
                _email = rows[0].values[adminTable.Email];
                _userId = rows[0].values[adminTable.UserId];
            }

        }


    }
}
