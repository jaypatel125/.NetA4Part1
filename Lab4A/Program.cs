/*
Author: Jay Patel, 000881881
Date: 11/11/2023
Purpose: Lab 4 Part A
I, Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

namespace Lab4A
{
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            List<Employee> employees = ReadEmployeesFromFile("employees.txt");

            // Display a menu and handle user input
            bool toggle = true;
            while (toggle)
            {
                string menu = @"
Menu
1. Sort by Employee Name (ascending)
2. Sort by Employee Number (ascending)
3. Sort by Employee Pay Rate (descending)
4. Sort by Employee Hours (descending)
5. Sort by Employee Gross Pay (descending)
6. Exit

Enter Option:".Trim();
                Console.WriteLine(menu);
                string input = Console.ReadLine();

                // Switch case for each option
                switch (input)
                {
                    case "1":
                        SortEmployeesByName(employees);
                        break;

                    case "2":
                        SortEmployeesByNumber(employees);
                        break;

                    case "3":
                        SortEmployeesByPayRate(employees);
                        break;

                    case "4":
                        SortEmployeesByHours(employees);
                        break;

                    case "5":
                        SortEmployeesByGrossPay(employees);
                        break;

                    case "6":
                        Console.WriteLine("Goodbye!");
                        toggle = false;
                        break;

                    default:
                        Console.WriteLine("Try Again. Enter from the above options.\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads employees from a file into a List<Employee>.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>A List of Employee objects.</returns>
        public static List<Employee> ReadEmployeesFromFile(string fileName)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 4)
                    {
                        string name = parts[0].Trim();
                        int number = int.Parse(parts[1].Trim());
                        decimal rate = decimal.Parse(parts[2].Trim());
                        double hours = double.Parse(parts[3].Trim());

                        employees.Add(new Employee(name, number, rate, hours));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Please try again." + ex.Message);
            }

            return employees;
        }

        /// <summary>
        /// Sorts employees by name and prints the results.
        /// </summary>
        /// <param name="employees">The List of Employee objects.</param>
        public static void SortEmployeesByName(List<Employee> employees)
        {
            employees.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
            PrintEmployees(employees);
        }

        /// <summary>
        /// Sorts employees by Employee Number and prints the results.
        /// </summary>
        /// <param name="employees">The List of Employee objects.</param>
        public static void SortEmployeesByNumber(List<Employee> employees)
        {
            employees.Sort((emp1, emp2) => emp1.Number.CompareTo(emp2.Number));
            PrintEmployees(employees);
        }

        /// <summary>
        /// Sorts employees by Pay Rate and prints the results.
        /// </summary>
        /// <param name="employees">The List of Employee objects.</param>
        public static void SortEmployeesByPayRate(List<Employee> employees)
        {
            employees.Sort((emp1, emp2) => emp2.Rate.CompareTo(emp1.Rate));
            PrintEmployees(employees);
        }

        /// <summary>
        /// Sorts employees by hours worked and prints the results.
        /// </summary>
        /// <param name="employees">The List of Employee objects.</param>
        public static void SortEmployeesByHours(List<Employee> employees)
        {
            employees.Sort((emp1, emp2) => emp2.Hours.CompareTo(emp1.Hours));
            PrintEmployees(employees);
        }

        /// <summary>
        /// Sorts employees by Gross Pay and prints the results.
        /// </summary>
        /// <param name="employees">The List of Employee objects.</param>
        public static void SortEmployeesByGrossPay(List<Employee> employees)
        {
            employees.Sort((emp1, emp2) => emp2.GetGross().CompareTo(emp1.GetGross()));
            PrintEmployees(employees);
        }

        /// <summary>
        /// Prints employee information in a formatted table.
        /// </summary>
        /// <param name="employees">The List of Employee objects to print.</param>
        public static void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("\n=================================================================");
            Console.WriteLine("| Name               | Number  | Rate     | Hours  | Gross Pay  |");
            Console.WriteLine("=================================================================");

            foreach (var employee in employees)
            {
                if (employee != null)
                {
                    string name = employee.Name.PadRight(18);
                    string number = employee.Number.ToString().PadLeft(7);
                    string rate = employee.Rate.ToString("F2").PadLeft(8);
                    string hours = employee.Hours.ToString("F2").PadLeft(6);
                    string grosspay = employee.GetGross().ToString("F2").PadLeft(10);

                    Console.WriteLine($"| {name} | {number} | {rate} | {hours} | {grosspay} |");
                }
            }

            Console.WriteLine("=================================================================");
        }
    }
}