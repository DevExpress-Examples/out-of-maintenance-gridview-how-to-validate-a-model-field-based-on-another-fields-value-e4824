Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports MVCxGridViewDataBinding.Models
Imports System.Web.UI
Imports DevExpress.Web.ASPxGridView
Imports System.Web.UI.HtmlControls

Namespace Q512251.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function

		Private list_Renamed As List(Of MyModel)
		Private ReadOnly Property List() As List(Of MyModel)
			Get
				If list_Renamed Is Nothing Then
					If Session("list") Is Nothing Then
						list_Renamed = MyModel.GetModelList()
						Session("list") = list_Renamed
					Else
						list_Renamed = TryCast(Session("list"), List(Of MyModel))
					End If
				End If
				Return list_Renamed
			End Get
		End Property
		Public Function EditingUpdate(ByVal model As MyModel) As ActionResult

			If ModelState.IsValid Then
				MyModel.UpdateModel(List, model)
			End If
			Return PartialView("_GridViewPartial", List)
		End Function
		Public Function EditingAddNew(ByVal model As MyModel) As ActionResult
			If ModelState.IsValid Then
				MyModel.InsertModel(List, model)
			End If
			Return PartialView("_GridViewPartial", List)
		End Function

		Public Function EditingDelete(ByVal modelID As Integer) As ActionResult

			If ModelState.IsValid Then
				MyModel.DeleteModel(List, modelID)
			End If
			Return PartialView("_GridViewPartial", List)
		End Function

		<ValidateInput(False)> _
		Public Function GridViewPartial() As ActionResult

			Return PartialView("_GridViewPartial", List)
		End Function
	End Class

End Namespace
