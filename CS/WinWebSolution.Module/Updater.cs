using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using WinSolution.Module;

namespace WinWebSolution.Module {
    public class Updater : ModuleUpdater {
        public Updater(DevExpress.ExpressApp.IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Department dept = ObjectSpace.CreateObject<Department>();
            dept.Title = "Demo Department";
            LocalEmployee le = ObjectSpace.CreateObject<LocalEmployee>();
            le.Name = "LocalEmployee 1";
            ForeignEmployee fe = ObjectSpace.CreateObject<ForeignEmployee>();
            fe.Name = "ForeignEmployee 1";
            dept.Employees.AddRange(new EmployeeBase[] { le, fe });
            dept.Save();
        }
    }
}
