@Code
    Dim grid As GridViewExtension = Html.DevExpress().GridView(Sub(settings)
    
                                                                       settings.Name = "GridView"
                                                                       settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

                                                                       settings.SettingsEditing.Mode = GridViewEditingMode.EditForm
                                                                       settings.SettingsBehavior.ConfirmDelete = True

                                                                       settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "EditingAddNew"}
                                                                       settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "EditingUpdate"}
                                                                       settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "EditingDelete"}

                                                                       settings.CommandColumn.Visible = True
                                                                       settings.CommandColumn.ShowNewButtonInHeader = True
                                                                       settings.CommandColumn.ShowDeleteButton = True
                                                                       settings.CommandColumn.ShowEditButton = True

                                                                       settings.KeyFieldName = "ModelID"

                                                                       settings.SettingsPager.Visible = True
                                                                       settings.Settings.ShowGroupPanel = True
        
                                                                       settings.SettingsBehavior.AllowSelectByRowClick = True
                                                                       settings.Columns.Add("ModelID").EditFormSettings.Visible = DefaultBoolean.False
                                                                       settings.Columns.Add(Sub(c)
        
                                                                                                    c.FieldName = "ModelName"
                                                                                                    c.ColumnType = MVCxGridViewColumnType.ComboBox
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).ValidationSettings.Display = Display.Dynamic
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).ValueType = GetType(String)
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).Items.Add("Model1", "Model1")
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).Items.Add("ModelName2", "ModelName2")
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).Items.Add("Model3", "Model3")
                                                                                            End Sub)
                                                                       settings.Columns.Add(Sub(c)
        
                                                                                                    c.Caption = "ModelState"
                                                                                                    c.FieldName = "ModelNameValidationState"
                                                                                                    c.ColumnType = MVCxGridViewColumnType.ComboBox
                                                                                                    c.EditFormSettings.Caption = "ValidateName"
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).ValueType = GetType(String)
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).Items.Add("No", "No")
                                                                                                    CType(c.PropertiesEdit, ComboBoxProperties).Items.Add("Yes", "Yes")

                                                                                            End Sub)
                                                                       settings.Columns.Add(Sub(col)
                                                                                                    col.FieldName = "ModelDate"
                                                                                                    col.ColumnType = MVCxGridViewColumnType.DateEdit
                                                                                                    CType(col.PropertiesEdit, DateEditProperties).ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText
                                                                                                    CType(col.PropertiesEdit, DateEditProperties).ValidationSettings.Display = Display.Dynamic
                                                                                            End Sub)
                                                               End Sub)
    If ViewData("EditError") IsNot Nothing Then
        grid.SetEditErrorText(CStr(ViewData("EditError")))
    End If
End Code
@grid.Bind(Model).GetHtml()