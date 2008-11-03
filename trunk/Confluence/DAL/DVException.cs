using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public class DVException : Exception
    {
        private String table_name;
        public String TableName
        {
            set {table_name = value; }
            get { return table_name; }
        }
        private int row;
        public int Row
        {
            set { row = value; }
            get { return row; }
        }
        private bool vertical;
        public bool Vertical
        {
            set { vertical = value; }
            get { return vertical; }
        }
        public DVException(String table_name, int row)
        {
            TableName = table_name;
            Row = row;
            Vertical = (row.Equals(0));
        }
    }
}
