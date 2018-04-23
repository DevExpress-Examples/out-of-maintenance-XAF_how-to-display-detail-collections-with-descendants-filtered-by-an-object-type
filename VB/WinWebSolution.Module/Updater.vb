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
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim dept As New Department(Session)
			dept.Title = "Demo Department"
			Dim le As New LocalEmployee(Session)
			le.Name = "LocalEmployee 1"
			Dim fe As New ForeignEmployee(Session)
			fe.Name = "ForeignEmployee 1"
			dept.Employees.AddRange(New EmployeeBase() { le, fe })
			dept.Save()
		End Sub
	End Class
End Namespace
