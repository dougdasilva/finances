using MonthlyFinances.Entities;
using MonthlyFinances.Entities.Enums;
using System;
using System.Globalization;

namespace MonthlyFinances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Competência(MM/AAAA): ");
            string monthAndYear = Console.ReadLine();
            DateTime date = DateTime.ParseExact(monthAndYear, "MM/yyyy", null);
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Área de atuação(Tecnologia/Cultura/Saúde/Administração/Segurança/Contabilidade): ");
            Workspace worker;
            string s = Console.ReadLine();
            Enum.TryParse(s, out worker);
            Console.Write("Cargo: ");
            string prof = Console.ReadLine();

            Performance performance = new Performance(prof);
            PersonalData personalData = new PersonalData(name, date.ToString("MM/yyyy"), baseSalary, worker, performance);

           Console.WriteLine();
            Console.WriteLine("----Extras----");
            Console.WriteLine();
            Console.Write("Quantos extras você fez no mês? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Extra #{i}: ");
                Console.Write("Data(dd/MM/aaaa): ");
                DateTime dateExtra = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double extraIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Horas trabalhadas: ");
                int hours = int.Parse(Console.ReadLine());
                ExtraIncome extra = new ExtraIncome(dateExtra, extraIncome, hours);
                personalData.AddExtra(extra);
            }
            Console.WriteLine();
            Console.WriteLine("----Contas a pagar----");
            Console.WriteLine();

            Console.Write("Digite o número de contas a pagar durante o mês: ");
            int n1 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n1; i++)
            {
                Console.WriteLine($"Conta #{i}: ");
                Console.Write("Tipo de conta: ");
                string ticket = Console.ReadLine();
                Console.Write("Data de pagamento: ");
                DateTime payDay = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor do boleto: ");
                double ticketValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                BillsToPay toPay = new BillsToPay(ticket, payDay, ticketValue);
                personalData.AddBillsToPay(toPay);
            }
            Console.WriteLine();

            
            
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Nome: " + personalData.Name);
            Console.WriteLine("Campo de atuação: " + personalData.Performance.Name);
            Console.WriteLine("Saldo total em " + monthAndYear + ": $" + personalData.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Contas a pagar em " + monthAndYear + ": $" + personalData.ToPay(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
