using System;
using System.Collections.Generic;
using WorkersRegistry.Model;

namespace WorkersRegistry.Repository {

	public class EmployeeRepository {
		// ----------- Helpers
		private readonly List<EmployeeRecordBase> _database = new();

		private static EmployeeRepository _instance;

		private EmployeeRepository() { }

		public static EmployeeRepository GetInstance() {
			return _instance ??= new EmployeeRepository();
		}

		// ----------- Repository
		public void Clear() {
			_database.Clear();
		}

		public void Add(EmployeeRecordBase employeeRecord) {
			if (employeeRecord.Id == 0)
			{
				employeeRecord.Id = GetUniqueId();
			}

			_database.Add(employeeRecord);
		}

		public void DeleteById(int id) {
			var removedEntries = _database.RemoveAll(element => element.Id == id);

			if (removedEntries == 0)
			{
				throw new InvalidOperationException();
			}
		}

		public List<EmployeeRecordBase> GetAllEmployees() {
			return new List<EmployeeRecordBase>(_database);
		}

		public List<EmployeeRecordBase> GetByCityName(string cityName) {
			return _database.FindAll(element => element.Facility.CityName == cityName);
		}

		public bool DeskIdExist(int id) {
			return _database.Exists(employee =>
			{
				if (employee is OfficeWorker officeWorker)
				{
					return officeWorker.DeskId == id;
				}

				return false;
			});
		}

		private int GetUniqueId() {
			var id = 1;

			while (_database.Exists(employee => employee.Id == id))
			{
				id++;
			}

			return id;
		}
	}
}