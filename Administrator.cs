using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Administrator
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
            set { _name = value; Update(Programming_Café_DB.adminTable.Name, value); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; Update(Programming_Café_DB.adminTable.Address, value); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; Update(Programming_Café_DB.adminTable.Phone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; Update(Programming_Café_DB.adminTable.Email, value); }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; Update(Programming_Café_DB.adminTable.UserId, value); }
        }

        public Administrator(string UserId) 
        {
            Administrator_Table adminTable = Programming_Café_DB.adminTable;
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

        public void Update(Collumn collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.adminTable.Rows.Find(row => row.values[Programming_Café_DB.adminTable.Id] == _id);
            for(int i = 0; i < Programming_Café_DB.adminTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.adminTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Collumn, string> updatedValues = Programming_Café_DB.adminTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.adminTable.Rows[i].values = updatedValues;
                }
            }
        }


    }
}
