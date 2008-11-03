using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using System.Data.Common;

namespace Confluence.DAL
{
    public class HashService : IHashService
    {
        private ConnectionFactory factory = new SQLServerConnectionFactory();

        private static IDictionary<Type, String> Tables;

        static HashService()
        {
            Tables = new Dictionary<Type, String>();
            Tables.Add(typeof(Service), "services");
            Tables.Add(typeof(Message), "contact");
            Tables.Add(typeof(Family), "families");
            Tables.Add(typeof(Project), "projects");
            Tables.Add(typeof(User), "users");
            Tables.Add(typeof(Client), "clients");
        }

        #region UPDATE DV
        public void ComputeTotalHash(DomainObject obj)
        {
            String table_name = Tables[obj.GetType()];
            long hash = ComputeHashForTable(table_name);
            DbCommand cmd = factory.GetCommand("UPDATE DV SET DV = " + hash + " WHERE table_name = '" + table_name + "'");
            cmd.ExecuteNonQuery();
        }
        private long ComputeHashForTable(String table_name)
        {
            DbCommand cmd = factory.GetCommand("SELECT SUM(DVH) FROM " + table_name);
            try
            {
                return (long)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region VALIDATE DV
        public void ValidateDV()
        {
            foreach (KeyValuePair<Type, String> entry in Tables)
                ValidateTableHash(entry.Value);
        }
        private void ValidateTableHash(String table_name)
        {
            long computed = RecalculateHashForTable(table_name);
            DbCommand cmd = factory.GetCommand("SELECT DV FROM DV WHERE table_name = '" + table_name + "'");
            long stored = (long)cmd.ExecuteScalar();

            if (!stored.Equals(computed)) throw new DVException(table_name, 0); //DV Vertical

        }
        private long RecalculateHashForTable(String table_name)
        {
            DbCommand cmd = factory.GetCommand("SELECT * FROM " + table_name);
            DbDataReader reader = cmd.ExecuteReader();
            long total = 0;
            long row_total = 0;
            int index = 1;
            int row = 1;
            while (reader.Read())
            {
                int x;
                for (x = 1; x < reader.FieldCount - 1; x++)
                {
                    row_total += index * Hash(reader[x]);
                    index++;
                }
                if (!row_total.Equals(reader[x])) throw new DVException(table_name, row); //DV Horizontal

                total += row_total;
                row_total = 0;
                index = 1;
                row++;
            }
            reader.Close();
            return total;
        }
        #endregion


        public void RepairDV()
        {
            foreach (KeyValuePair<Type, String> entry in Tables)
            {
                RepairHashForTable(entry.Value);
                RepairVerticalHashForTable(entry.Value);
            }
        }
        private void RepairHashForTable(String table_name)
        {
            DbCommand cmd = factory.GetCommand("SELECT * FROM " + table_name);
            DbDataReader reader = cmd.ExecuteReader();
            long row_total = 0;
            int index = 1;
            while (reader.Read())
            {
                int x;
                for (x = 1; x < reader.FieldCount - 1; x++)
                {
                    row_total += index * Hash(reader[x]);
                    index++;
                }

                factory.GetCommand("UPDATE " + table_name + " SET DVH = " + row_total + " WHERE id = " + reader[0].ToString()).ExecuteNonQuery();

                row_total = 0;
                index = 1;
            }
            reader.Close();
        }
        private void RepairVerticalHashForTable(String table_name)
        {
            long DVV = ComputeHashForTable(table_name);
            factory.GetCommand("UPDATE DV SET DV = " + DVV + " WHERE table_name = '" + table_name + "'").ExecuteNonQuery();
        }

        private long Hash(object o)
        {
            if (o == null) return 0;

            if (o is long) return (long)o;
            if (o is int) return long.Parse(o.ToString());

            if (o is string) return ((string)o).GetHashCode();
            if (o is double) return ((double)o).GetHashCode();
            if (o is DateTime) return ((DateTime)o).GetHashCode();
            else
                return 0;
        }
    }
    
}
