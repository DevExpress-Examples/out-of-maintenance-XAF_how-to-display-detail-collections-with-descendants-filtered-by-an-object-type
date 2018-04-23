Imports DevExpress.ExpressApp.Model
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Data.Filtering
Imports System.ComponentModel
Imports System.Collections

Namespace WinSolution.Module
    <DefaultClassOptions, System.ComponentModel.DefaultProperty("Title")> _
    Public Class Department
        Inherits BaseObject


        Private title_Renamed As String

        Private office_Renamed As String
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Title() As String
            Get
                Return title_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Title", title_Renamed, value)
            End Set
        End Property
        Public Property Office() As String
            Get
                Return office_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Office", office_Renamed, value)
            End Set
        End Property
        <Association("Department-Employees"), Aggregated> _
        Public ReadOnly Property Employees() As XPCollection(Of EmployeeBase)
            Get
                Return GetCollection(Of EmployeeBase)("Employees")
            End Get
        End Property
        Private _LocalEmployees As XPCollection(Of LocalEmployee)
        <ModelDefault("AllowEdit", "False")> _
        Public ReadOnly Property LocalEmployees() As XPCollection(Of LocalEmployee)
            Get
                If _LocalEmployees Is Nothing Then
                    _LocalEmployees = New XPCollection(Of LocalEmployee)(Session, New GroupOperator(New BinaryOperator(BaseObject.Fields.ObjectType.TypeName, New OperandValue(GetType(LocalEmployee).FullName), BinaryOperatorType.Equal), New BinaryOperator("Department", Me)))
                End If
                Return _LocalEmployees
            End Get
        End Property
        Private _ForeignEmployees As XPCollection(Of ForeignEmployee)
        <ModelDefault("AllowEdit", "False")> _
        Public ReadOnly Property ForeignEmployees() As XPCollection(Of ForeignEmployee)
            Get
                If _ForeignEmployees Is Nothing Then
                    _ForeignEmployees = New XPCollection(Of ForeignEmployee)(Session, New GroupOperator(New BinaryOperator(BaseObject.Fields.ObjectType.TypeName, New OperandValue(GetType(ForeignEmployee).FullName), BinaryOperatorType.Equal), New BinaryOperator("Department", Me)))
                End If
                Return _ForeignEmployees
            End Get
        End Property
        Protected Overrides Sub OnLoaded()
            MyBase.OnLoaded()
            UpdateCollections()
        End Sub
        Public Sub UpdateCollections()
            LocalEmployees.Reload()
            ForeignEmployees.Reload()
        End Sub
    End Class
    Public MustInherit Class EmployeeBase
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private name_Renamed As String

        Private email_Renamed As String
        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", name_Renamed, value)
            End Set
        End Property
        Public Property Email() As String
            Get
                Return email_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Email", email_Renamed, value)
            End Set
        End Property

        Private department_Renamed As Department
        <Association("Department-Employees")> _
        Public Property Department() As Department
            Get
                Return department_Renamed
            End Get
            Set(ByVal value As Department)
                Dim oldDepartment As Department = department_Renamed
                SetPropertyValue("Department", department_Renamed, value)
                If (Not IsLoading) AndAlso (Not IsSaving) AndAlso oldDepartment IsNot department_Renamed Then
                    If oldDepartment IsNot Nothing Then
                        oldDepartment.UpdateCollections()
                    End If
                    If department_Renamed IsNot Nothing Then
                        department_Renamed.UpdateCollections()
                    End If
                End If
            End Set
        End Property
        Protected Overrides Sub OnSaved()
            MyBase.OnSaved()
            If Department IsNot Nothing Then
                Me.Department.UpdateCollections()
            End If
        End Sub
    End Class
    Public Class LocalEmployee
        Inherits EmployeeBase

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private insurancePolicyNumber_Renamed As String
        Public Property InsurancePolicyNumber() As String
            Get
                Return insurancePolicyNumber_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("InsurancePolicyNumber", insurancePolicyNumber_Renamed, value)
            End Set
        End Property
    End Class
    Public Class ForeignEmployee
        Inherits EmployeeBase

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private visaExpirationDate_Renamed As Date
        Public Property VisaExpirationDate() As Date
            Get
                Return visaExpirationDate_Renamed
            End Get
            Set(ByVal value As Date)
                SetPropertyValue("VisaExpirationDate", visaExpirationDate_Renamed, value)
            End Set
        End Property
    End Class

End Namespace