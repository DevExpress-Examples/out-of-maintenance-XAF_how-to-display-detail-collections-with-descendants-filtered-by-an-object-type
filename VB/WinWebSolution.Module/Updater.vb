Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports WinSolution.Module

Namespace WinWebSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim dept As Department = ObjectSpace.CreateObject(Of Department)()
			dept.Title = "Demo Department"
			Dim le As LocalEmployee = ObjectSpace.CreateObject(Of LocalEmployee)()
			le.Name = "LocalEmployee 1"
			Dim fe As ForeignEmployee = ObjectSpace.CreateObject(Of ForeignEmployee)()
			fe.Name = "ForeignEmployee 1"
			dept.Employees.AddRange(New EmployeeBase() { le, fe })
			dept.Save()
		End Sub
	End Class
End Namespace
