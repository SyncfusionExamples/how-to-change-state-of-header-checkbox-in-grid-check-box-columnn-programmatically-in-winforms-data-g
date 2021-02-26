using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCommon.Grid;
using System.Windows.Forms.VisualStyles;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Globalization;
using Syncfusion.WinForms.ListView;
using Syncfusion.WinForms.ListView.Enums;

namespace ColumnTypes
{
    public partial class Form1 : Form
    {
        #region Fields
        OrderInfoCollection orderInfo;
        #endregion

        #region Constuctor
        public Form1()
        {
            InitializeComponent();
            orderInfo = new OrderInfoCollection();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.DataSource = orderInfo.OrdersListDetails;
            this.sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsClosed", HeaderText = "Closed", AllowCheckBoxOnHeader = true, CheckBoxSize = new Size(14, 14), Width = 100 });

            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ContactNumber", HeaderText = "Contact Number" });
            this.sfDataGrid1.Columns["ContactNumber"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = "UnitPrice",
                HeaderText = "Unit Price",
                FormatMode = FormatMode.Currency,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                HeaderText = "Quantity",
                MappingName = "Quantity",
                FormatMode = FormatMode.Numeric,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.PercentDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var headerState = (CheckState)(this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn).GetType().GetProperty("HeaderState", System.Reflection.BindingFlags.Instance 
                | System.Reflection.BindingFlags.NonPublic).GetValue(this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn);

            if (headerState == CheckState.Checked)
            {
                (this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn).GetType().GetProperty("HeaderState", System.Reflection.BindingFlags.Instance 
                    | System.Reflection.BindingFlags.NonPublic).SetValue(this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn, CheckState.Unchecked);

                foreach(var item in orderInfo.OrdersListDetails)
                {
                    item.IsClosed = false;
                }
            }
            else if (headerState == CheckState.Unchecked)
            {
                (this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn).GetType().GetProperty("HeaderState", System.Reflection.BindingFlags.Instance 
                    | System.Reflection.BindingFlags.NonPublic).SetValue(this.sfDataGrid1.Columns["IsClosed"] as GridCheckBoxColumn, CheckState.Checked);

                foreach (var item in orderInfo.OrdersListDetails)
                {
                    item.IsClosed = true;
                }
            }
        }
    }
}
