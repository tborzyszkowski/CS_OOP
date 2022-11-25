using System;
using System.Collections.Generic;
using NUnit.Framework;
using WorkersRegistry;
using WorkersRegistry.DTO;
using WorkersRegistry.Enum;
using WorkersRegistry.Exceptions;
using WorkersRegistry.Repository;

namespace WorkersRegistryTest {

	[TestFixture]
	public class Tests {
		private MainEmployeesRegistry _mainEmployeesRegistry;
		private OfficeWorkerDTO _officeWorkerDTO;
		private WorkerDTO _workerDTO;
		private TradesmanDTO _tradesmanDTO;

		[SetUp]
		public void SetUp() {
			_mainEmployeesRegistry = new MainEmployeesRegistry();
			EmployeeRepository.GetInstance().Clear();
			_officeWorkerDTO = new OfficeWorkerDTO(
				"Janusz",
				"Kowalski",
				28,
				7,
				"Mickiewicza",
				"13",
				"2",
				"Gdańsk",
				70,
				1
			);
			_workerDTO = new WorkerDTO(
				"Mariusz",
				"Kaczka",
				45,
				28,
				"Drega",
				"13",
				"2",
				"Sopot",
				70
			);
			_tradesmanDTO = new TradesmanDTO(
				"Mariusz",
				"Dryga",
				55,
				48,
				"Mickiewicza",
				"13",
				"2",
				"Gdańsk",
				3,
				EffectivenessScore.Medium
			);
		}

		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_mainEmployeesRegistry, Is.Not.Null);
		}

		[Test]
		public void AddOfficeWorkerToRegistry() {
			_mainEmployeesRegistry.AddEmployee(_officeWorkerDTO);
			Assert.Pass();
		}

		[Test]
		public void TestDeskUniquenessValidator() {
			_mainEmployeesRegistry.AddEmployee(_officeWorkerDTO);

			Assert.Throws<DeskIdExists>(() => _mainEmployeesRegistry.AddEmployee(_officeWorkerDTO));
		}

		[Test]
		public void TestWrongHighIntellectValue() {
			Assert.Throws<InvalidPropertyValue>(() => _officeWorkerDTO.Intellect = 200);
		}

		[Test]
		public void TestWrongLowIntellectValue() {
			Assert.Throws<InvalidPropertyValue>(() => _officeWorkerDTO.Intellect = 20);
		}

		[Test]
		public void AddTradesmanToRegistry() {
			_mainEmployeesRegistry.AddEmployee(_tradesmanDTO);

			Assert.Pass();
		}

		[Test]
		public void TestWrongLowProvisionValue() {
			Assert.Throws<InvalidPropertyValue>(() => _tradesmanDTO.Provision = 0);
		}

		[Test]
		public void TestWrongHighProvisionValue() {
			Assert.Throws<InvalidPropertyValue>(() => _tradesmanDTO.Provision = 101);
		}

		[Test]
		public void AddWorkerToRegistry() {
			_mainEmployeesRegistry.AddEmployee(_workerDTO);

			Assert.Pass();
		}

		[Test]
		public void TestWrongLowStrengthValue() {
			Assert.Throws<InvalidPropertyValue>(() => _workerDTO.Strength = 0);
		}

		[Test]
		public void TestWrongHighStrengthValue() {
			Assert.Throws<InvalidPropertyValue>(() => _workerDTO.Strength = 101);
		}

		[Test]
		public void AddEmployeesToRegistry() {
			_mainEmployeesRegistry.AddEmployees(
				new List<EmployeeDTOBase>() { _tradesmanDTO, _workerDTO, _officeWorkerDTO }
			);

			Assert.Pass();
		}

		[Test]
		public void DeleteEmployeeFromRegistry() {
			const int id = 2137;
			_officeWorkerDTO.Id = id;
			_mainEmployeesRegistry.AddEmployee(_officeWorkerDTO);
			_mainEmployeesRegistry.DeleteEmployee(id);

			Assert.Pass();
		}

		[Test]
		public void ThrowDeleteEmployeeFromRegistry() {
			_officeWorkerDTO.Id = 2137;
			_mainEmployeesRegistry.AddEmployee(_officeWorkerDTO);

			Assert.Throws<InvalidOperationException>(() => _mainEmployeesRegistry.DeleteEmployee(2324));
		}

		[Test]
		public void TestDisplaySortedByExpAgeSurname() {
			_mainEmployeesRegistry.AddEmployees(
				new List<EmployeeDTOBase>() { _tradesmanDTO, _workerDTO, _officeWorkerDTO }
			);
			_mainEmployeesRegistry.DisplayEmployeesSortedByExpAgeSurname();

			Assert.Pass();
		}

		[Test]
		public void TestDisplayEmployeesInGda() {
			_mainEmployeesRegistry.AddEmployees(
				new List<EmployeeDTOBase>() { _tradesmanDTO, _workerDTO, _officeWorkerDTO }
			);
			_mainEmployeesRegistry.DisplayEmployeesInCity("Gdańsk");

			Assert.Pass();
		}

		[Test]
		public void TestDisplayEmployeesInSopot() {
			_mainEmployeesRegistry.AddEmployees(
				new List<EmployeeDTOBase>() { _tradesmanDTO, _workerDTO, _officeWorkerDTO }
			);
			_mainEmployeesRegistry.DisplayEmployeesInCity("Sopot");

			Assert.Pass();
		}

		[Test]
		public void TestDisplayAllEmployees() {
			_mainEmployeesRegistry.AddEmployees(
				new List<EmployeeDTOBase>() { _tradesmanDTO, _workerDTO, _officeWorkerDTO }
			);
			_mainEmployeesRegistry.DisplayAllEmployees();

			Assert.Pass();
		}
	}
}