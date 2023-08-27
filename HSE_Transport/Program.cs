using System.Text;
namespace HSE_Transport;
using EKRLib;

internal static class Program
{
    private static readonly List<Transport> Transports = new();
    private static readonly MenuItem[] Menu = {
        new ("0", "выйти из программы", () => _isCanceled = true),
        new ("1", "выполнить программу", () =>
        {
            CreateRandomTransportList();
            CreateCarsAndMotorBoatFiles();
        }),
    };
    private static bool _isCanceled;
    
    private static void Main()
    {
        while (!_isCanceled)
        {
            ShowMenu();
            ProcessMenu();
        }
    }

    /// <summary>
    /// Обработка выбранного пользователем элемента меню приложения
    /// </summary>
    /// <exception cref="ArgumentException">Исключение выбрасывается при попытке неверного ввода пункта меню</exception>
    private static void ProcessMenu()
    {
        try
        {
            var input = Console.ReadLine();
            var menuItem = Menu.FirstOrDefault(i => i.Input == input);
            if (menuItem is null)
                throw new ArgumentException("Несуществующая команда, повторите ввод");
            menuItem.Action();
        }
        catch (IOException)
        {
            Console.WriteLine("Закройте файл, над которым проводится операция");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Вывод меню приложения
    /// </summary>
    private static void ShowMenu()
    {
        foreach (var item in Menu)
        {
            Console.WriteLine($"Введите \"{item.Input}\", чтобы {item.Description}");
        }
    }

    /// <summary>
    /// Метод для создания двух файлов с информацией о машинах и моторных лодках
    /// </summary>
    private static void CreateCarsAndMotorBoatFiles()
    {
        using var carsWriter = new StreamWriter(@"../../../../Cars.txt", false, Encoding.Unicode);
        using var motorBoatsWriter = new StreamWriter(@"../../../../MotorBoats.txt", false, Encoding.Unicode);
        foreach (var transport in Transports)
        {
            switch (transport)
            {
                case Car:
                    carsWriter.WriteLine(transport);
                    break;
                case MotorBoat:
                    motorBoatsWriter.WriteLine(transport);
                    break;
            }
        }
        Console.WriteLine("Файлы Cars.txt и MotorBoats.txt успешно созданы");
    }
    
    /// <summary>
    /// Метод для создания списка транспорта
    /// </summary>
    private static void CreateRandomTransportList()
    {
        var rand = new Random();
        var transportCount = rand.Next(6, 11);
        for (int i = 0; i < transportCount; i++)
        {
            try
            {
                var model = Transport.GetRandomModel();
                var power = (uint)rand.Next(10, 100);
                
                Transport transport = rand.Next(2) == 0
                    ? new Car(model, power)
                    : new MotorBoat(model, power);

                Transports.Add(transport);
                Console.WriteLine(transport.StartEngine());
            }
            catch (TransportException e)
            {
                Console.WriteLine(e.Message);
                //Запуск повторной попытки создания транспорта
                i--;
            }
        }
    }
}