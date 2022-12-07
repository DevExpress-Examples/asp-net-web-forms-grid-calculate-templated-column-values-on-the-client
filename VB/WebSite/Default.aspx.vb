Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub grdProducts_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDataEventArgs)
		If e.Column.FieldName = "Total" Then
			Dim price As Decimal = CDec(e.GetListSourceFieldValue("UnitPrice"))
			Dim quantity As Integer = Convert.ToInt32(e.GetListSourceFieldValue("UnitsInStock"))
			e.Value = price * quantity
		End If
	End Sub

	Protected Sub tbTotal_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim textBox As ASPxTextBox = TryCast(sender, ASPxTextBox)
		Dim container As GridViewDataItemTemplateContainer = TryCast(textBox.NamingContainer, GridViewDataItemTemplateContainer)
		textBox.Text = container.Text
		textBox.ClientInstanceName = String.Format("tbClientTotal_{0}", container.VisibleIndex)
	End Sub

	Protected Sub seQuantity_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim spinEdit As ASPxSpinEdit = CType(sender, ASPxSpinEdit)
		Dim container As GridViewDataItemTemplateContainer = TryCast(spinEdit.NamingContainer, GridViewDataItemTemplateContainer)
		spinEdit.ClientInstanceName = String.Format("seClientQuantity_{0}", container.VisibleIndex)
		spinEdit.ClientSideEvents.NumberChanged = String.Format("function(s, e) {{ OnCalculateTotal({0},{1}); }}", container.VisibleIndex, container.KeyValue)

	End Sub
	Protected Sub seUnitPrice_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim spinEdit As ASPxSpinEdit = CType(sender, ASPxSpinEdit)
		Dim container As GridViewDataItemTemplateContainer = TryCast(spinEdit.NamingContainer, GridViewDataItemTemplateContainer)
		spinEdit.ClientInstanceName = String.Format("seClientPrice_{0}", container.VisibleIndex)
		spinEdit.ClientSideEvents.NumberChanged = String.Format("function(s, e) {{ OnCalculateTotal({0},{1}); }}", container.VisibleIndex, container.KeyValue)
	End Sub

	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
		ads.UpdateCommand = "UPDATE  [Products] SET [UnitPrice] = @price, [UnitsInStock] = @quantity WHERE [ProductID] = @keyValue;"
		For Each dict In hf
			Dim newValues() As String = dict.Value.ToString().Split("|"c)
			ads.UpdateParameters.Add("price", newValues(1))
			ads.UpdateParameters.Add("quantity", newValues(2))
			ads.UpdateParameters.Add("keyValue", newValues(0))

			'Database update is not allowed in Online examples
			'ads.Update();
			ads.UpdateParameters.Clear()
		Next dict
		hf.Clear()
	End Sub
End Class