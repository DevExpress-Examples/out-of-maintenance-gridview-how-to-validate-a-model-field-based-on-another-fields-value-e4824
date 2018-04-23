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
			If m.ModelNameValidationState = "No" Then
				Return ValidationResult.Success
			End If
			Dim s As String = TryCast(value, String)
			If s.Contains("Name") Then
				Return New ValidationResult("ModelName contains invalid sequence")
			End If
			Return ValidationResult.Success
		End Function
	End Class
End Namespace
