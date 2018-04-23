' Developer Express Code Central Example:
' GridView - How to validate a model field based on another field's value
' 
' This example demonstrates how to implement custom model validation for one field
' based on a another field's value. To accomplish this task, create a
' ValidationAttribute class descendant and override the IsValid method.
' You can
' learn more about this in the How to: Customize Data Field Validation in the Data
' Model Using Custom Attributes
' (http://msdn.microsoft.com/en-us/library/cc668224(v=vs.98).aspx) article.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4824


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace MVCxGridViewDataBinding.Models
	<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple := False)> _
	Public NotInheritable Class CustomAttribute
		Inherits ValidationAttribute
		Protected Overrides Function IsValid(ByVal value As Object, ByVal validationContext As ValidationContext) As ValidationResult
			Dim m As MyModel = TryCast(validationContext.ObjectInstance, MyModel)
			Dim s As String = TryCast(value, String)

			If (Not String.IsNullOrWhiteSpace(s)) AndAlso m.ModelNameValidationState = "Yes" AndAlso s.Contains("Name") Then
				Return New ValidationResult("ModelName contains invalid sequence")
			Else
				Return ValidationResult.Success
			End If

		End Function
	End Class
End Namespace
