using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using WinSolution.Module;

namespace WinWebSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Department dept = new Department(Session);
            dept.Title = "Demo Department";
            LocalEmployee le = new LocalEmployee(Session);
            le.Name = "LocalEmployee 1";
            ForeignEmployee fe = new ForeignEmployee(Session);
            fe.Name = "ForeignEmployee 1";
            dept.Employees.AddRange(new EmployeeBase[] { le, fe });
            dept.Save();
        }
    }
}
