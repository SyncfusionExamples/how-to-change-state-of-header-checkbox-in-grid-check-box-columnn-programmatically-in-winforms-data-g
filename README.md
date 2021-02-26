# How to change state of header checkbox in GridCheckBoxColumnn Programmatically in WinForms DataGrid?

## About the sample

This sample illustrates how to change state of header checkbox in GridCheckBoxColumnn Programmatically in WinForms DataGrid.

In [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid), checkbox in the header cell of the [GridCheckBoxColumn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.GridCheckBoxColumn.html#%22%22) can be checked/unchecked by manually clicking on the checkbox in the header or by checking/unchecking the checkboxes in all the record cells. You can also change the checkbox state of the header cell of the GridCheckBoxColumn programmatically.

``` c#

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


```
