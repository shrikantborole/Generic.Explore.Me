using Generic.Common.Entity.Explore.Me;
using Generic.Common.Implementation.Explore.Me;
using Generic.Common.Implementation.Explore.Me.Data;
using Generic.Common.Interface.Explore.Me.Model;
using Generic.Common.Interface.Explore.Me.Repo;

namespace Generic.Explore.Me
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SqlRepository - Employee");
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

            AddEmployee(employeeRepository);

            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName} {employee.LastName}");

            Console.WriteLine("ListRepository - Organization");
            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
        }
       
        public static void AddOrganization(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();
        }
        public static void WriteAllToConsole(IRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia", LastName = "Zayac" });
            employeeRepository.Add(new Employee { FirstName = "Anna", LastName = "Cook" });
            employeeRepository.Add(new Employee { FirstName = "Thomas", LastName = "Edison" });
            employeeRepository.Save();
        }
    }
}
