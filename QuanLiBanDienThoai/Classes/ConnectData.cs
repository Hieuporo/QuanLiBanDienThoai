using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuanLiBanDienThoai.Classes
{
	internal class ConnectData
	{
		string strConnect = "Data Source=.;Initial Catalog=QLDienThoai;Integrated Security=True";
		SqlConnection sqlConn = null;

		void OpenConnect()
		{
			sqlConn = new SqlConnection(strConnect);
			if (sqlConn.State != ConnectionState.Open)
				sqlConn.Open();
		}

		public string GetFieldValues(string sql)
		{
			OpenConnect();
			string ma = "";
			SqlCommand cmd = new SqlCommand(sql, sqlConn);
			SqlDataReader reader;
			reader = cmd.ExecuteReader();
			while (reader.Read())
				ma = reader.GetValue(0).ToString();
			reader.Close();

			CloseConnect();


			return ma;
		}

		public DataTable ReadData(string sqlSelect)
		{
			DataTable dt = new DataTable();
			OpenConnect();
			SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConn);
			sqlData.Fill(dt);
			CloseConnect();
			sqlData.Dispose();
			return dt;
		}

		public void ChangeData(string sql)
		{
			OpenConnect();
			SqlCommand sqlCom = new SqlCommand();
			sqlCom.Connection = sqlConn;
			sqlCom.CommandText = sql;
			sqlCom.ExecuteNonQuery();
			CloseConnect();
			sqlCom.Dispose();
		}

		void CloseConnect()
		{
			if (sqlConn.State != ConnectionState.Closed)
			{
				sqlConn.Close();
				sqlConn.Dispose();
			}

		}
	}
}
