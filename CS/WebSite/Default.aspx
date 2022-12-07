<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <script type="text/javascript">
        function OnCalculateTotal(visibleIndex, keyValue) {
            var controlCollection = ASPxClientControl.GetControlCollection();
            var unitPrice = controlCollection.GetByName("seClientPrice_" + visibleIndex).GetNumber();
            var unitsInStock = controlCollection.GetByName("seClientQuantity_" + visibleIndex).GetNumber();
            var total = unitPrice * unitsInStock;
            controlCollection.GetByName("tbClientTotal_" + visibleIndex).SetText(total.toFixed(2));
            hfChanges.Set("Row_" + visibleIndex.toString(), keyValue + "|" + unitPrice + "|" + unitsInStock);
        }
    </script>

    <form id="form1" runat="server">
    <dx:ASPxGridView ID="grdProducts" runat="server" AutoGenerateColumns="False" KeyFieldName="ProductID"
        OnCustomUnboundColumnData="grdProducts_CustomUnboundColumnData" DataSourceID="ads">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="4">
                <DataItemTemplate>
                    <dx:ASPxSpinEdit ID="seUnitPrice" runat="server" Height="21px" Number="0" Value='<%# Bind("UnitPrice") %>'
                        OnInit="seUnitPrice_Init" />
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="5">
                <DataItemTemplate>
                    <dx:ASPxSpinEdit ID="seUnitInStock" runat="server" Height="21px" Number="0" Value='<%# Bind("UnitsInStock") %>'
                        OnInit="seQuantity_Init">
                    </dx:ASPxSpinEdit>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" VisibleIndex="6" UnboundType="Decimal">
                <DataItemTemplate>
                    <dx:ASPxTextBox ID="tbTotal" runat="server" ClientEnabled="False" OnInit="tbTotal_Init"
                        Width="170px">
                    </dx:ASPxTextBox>
                </DataItemTemplate>
                <PropertiesTextEdit DisplayFormatString="0.00" />
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:AccessDataSource ID="ads" runat="server" DataFile="~/App_Data/Northwind.mdb"
        SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Products]">
    </asp:AccessDataSource>
    <dx:ASPxButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Changes"
        Width="155px">
    </dx:ASPxButton>
    <dx:ASPxHiddenField ID="hf" runat="server" ClientInstanceName="hfChanges">
    </dx:ASPxHiddenField>
    </form>
</body>
</html>