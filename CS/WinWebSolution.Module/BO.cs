using DevExpress.ExpressApp.Model;
using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;
using System.ComponentModel;
using System.Collections;

namespace WinSolution.Module {
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Title")]
    public class Department : BaseObject {
        private string title;
        private string office;
        public Department(Session session) : base(session) { }
        public string Title {
            get { return title; }
            set {
                SetPropertyValue("Title", ref title, value);
            }
        }
        public string Office {
            get { return office; }
            set {
                SetPropertyValue("Office", ref office, value);
            }
        }
        [Association("Department-Employees"), Aggregated]
        public XPCollection<EmployeeBase> Employees {
            get { return GetCollection<EmployeeBase>("Employees"); }
        }
        private XPCollection<LocalEmployee> _LocalEmployees;
        [ModelDefault("AllowEdit", "False")]
        public XPCollection<LocalEmployee> LocalEmployees {
            get {
                if (_LocalEmployees == null)
                    _LocalEmployees = new XPCollection<LocalEmployee>(Session,
                        new GroupOperator(
                        new BinaryOperator(BaseObject.Fields.ObjectType.TypeName, new OperandValue(typeof(LocalEmployee).FullName), BinaryOperatorType.Equal),
                        new BinaryOperator("Department", this)));
                return _LocalEmployees;
            }
        }
        private XPCollection<ForeignEmployee> _ForeignEmployees;
        [ModelDefault("AllowEdit", "False")]
        public XPCollection<ForeignEmployee> ForeignEmployees {
            get {
                if (_ForeignEmployees == null)
                    _ForeignEmployees = new XPCollection<ForeignEmployee>(Session,
                        new GroupOperator(
                        new BinaryOperator(BaseObject.Fields.ObjectType.TypeName, new OperandValue(typeof(ForeignEmployee).FullName), BinaryOperatorType.Equal),
                        new BinaryOperator("Department", this)));
                return _ForeignEmployees;
            }
        }
        protected override void OnLoaded() {
            base.OnLoaded();
            UpdateCollections();
        }
        public void UpdateCollections() {
            LocalEmployees.Reload();
            ForeignEmployees.Reload();
        }
    }
    public abstract class EmployeeBase : BaseObject {
        public EmployeeBase(Session session) : base(session) { }
        private string name;
        private string email;
        public string Name {
            get { return name; }
            set {
                SetPropertyValue("Name", ref name, value);
            }
        }
        public string Email {
            get { return email; }
            set {
                SetPropertyValue("Email", ref email, value);
            }
        }
        private Department department;
        [Association("Department-Employees")]
        public Department Department {
            get { return department; }
            set {
                Department oldDepartment = department;
                SetPropertyValue("Department", ref department, value);
                if (!IsLoading && !IsSaving && oldDepartment != department) {
                    if (oldDepartment != null) oldDepartment.UpdateCollections();
                    if (department != null) department.UpdateCollections();
                }
            }
        }
        protected override void OnSaved() {
            base.OnSaved();
            if (Department != null) this.Department.UpdateCollections();
        }
    }
    public class LocalEmployee : EmployeeBase {
        public LocalEmployee(Session session) : base(session) { }
        private string insurancePolicyNumber;
        public string InsurancePolicyNumber {
            get { return insurancePolicyNumber; }
            set {
                SetPropertyValue("InsurancePolicyNumber", ref insurancePolicyNumber, value);
            }
        }
    }
    public class ForeignEmployee : EmployeeBase {
        public ForeignEmployee(Session session) : base(session) { }
        private DateTime visaExpirationDate;
        public DateTime VisaExpirationDate {
            get { return visaExpirationDate; }
            set {
                SetPropertyValue("VisaExpirationDate", ref visaExpirationDate, value);
            }
        }
    }

}