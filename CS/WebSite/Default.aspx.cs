using System;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void grdProducts_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e) {
        if(e.Column.FieldName == "Total") {
            decimal price = (decimal)e.GetListSourceFieldValue("UnitPrice");
            int quantity = Convert.ToInt32(e.GetListSourceFieldValue("UnitsInStock"));
            e.Value = price * quantity;
        }
    }

    protected void tbTotal_Init(object sender, EventArgs e) {
        ASPxTextBox textBox = sender as ASPxTextBox;
        GridViewDataItemTemplateContainer container = textBox.NamingContainer as GridViewDataItemTemplateContainer;
        textBox.Text = container.Text;
        textBox.ClientInstanceName = String.Format("tbClientTotal_{0}", container.VisibleIndex);
    }

    protected void seQuantity_Init(object sender, EventArgs e) {
        ASPxSpinEdit spinEdit = (ASPxSpinEdit)sender;
        GridViewDataItemTemplateContainer container = spinEdit.NamingContainer as GridViewDataItemTemplateContainer;
        spinEdit.ClientInstanceName = String.Format("seClientQuantity_{0}", container.VisibleIndex);
        spinEdit.ClientSideEvents.NumberChanged = String.Format("function(s, e) {{ OnCalculateTotal({0},{1}); }}", container.VisibleIndex, container.KeyValue);

    }
    protected void seUnitPrice_Init(object sender, EventArgs e) {
        ASPxSpinEdit spinEdit = (ASPxSpinEdit)sender;
        GridViewDataItemTemplateContainer container = spinEdit.NamingContainer as GridViewDataItemTemplateContainer;
        spinEdit.ClientInstanceName = String.Format("seClientPrice_{0}", container.VisibleIndex);
        spinEdit.ClientSideEvents.NumberChanged = String.Format("function(s, e) {{ OnCalculateTotal({0},{1}); }}", container.VisibleIndex, container.KeyValue);
    }

    protected void btnSubmit_Click(object sender, EventArgs e) {
        ads.UpdateCommand = "UPDATE  [Products] SET [UnitPrice] = @price, [UnitsInStock] = @quantity WHERE [ProductID] = @keyValue;";
        foreach(var dict in hf) {
            string[] newValues = dict.Value.ToString().Split('|');
            ads.UpdateParameters.Add("price", newValues[1]);
            ads.UpdateParameters.Add("quantity", newValues[2]);
            ads.UpdateParameters.Add("keyValue", newValues[0]);

            //Database update is not allowed in Online examples
            //ads.Update();
            ads.UpdateParameters.Clear();
        }
        hf.Clear();
    }
}