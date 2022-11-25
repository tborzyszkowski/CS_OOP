using WorkersRegistry.Interface;

namespace WorkersRegistry.Model {

    public abstract class EmployeeRecordBase : Employee, IEmployeeRecord {
        public Facility Facility { get; set; }

        protected EmployeeRecordBase(
            int id,
            string name,
            string surname,
            int age,
            int experience,
            Facility facility
        ) : base(name, surname, age, experience) {
            Id = id;
            Facility = facility;
        }
    }
}