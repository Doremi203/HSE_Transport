using System.Text;
using System.Text.RegularExpressions;

namespace EKRLib;
/// <summary>
/// Абстрактный базовый класс транспорта
/// </summary>
public abstract class Transport 
{
    private readonly string? _model;
    private readonly uint _power;

    /// <summary>
    /// Строковое св-во для модели транспорта
    /// </summary>
    /// <exception cref="TransportException">Исключение возникает при попытке присвоения некорректной модели</exception>
    public string? Model
    {
        get => _model;
        init
        {
            if (!Regex.IsMatch(value!, "^[A-Z0-9]{5}$"))
                throw new TransportException($"Недопустимая модель {value}");
            _model = value;
        }
    }

    /// <summary>
    /// Uint св-во для мощности транспорта
    /// </summary>
    /// <exception cref="TransportException">Исключение возникает при попытке присвоения некорректной мощности</exception>
    public uint Power
    {
        get => _power;
        init
        {
            if (value < 20)
                throw new TransportException("мощность не может быть меньше 20 л.с.");
            _power = value;
        }
    }

    /// <summary>
    /// Конструктор инициализирующий модель и мощность
    /// </summary>
    /// <param name="model">Модель транспорта</param>
    /// <param name="power">Мощность транспорта</param>
    protected Transport(string? model, uint power) 
    {
        Model = model;
        Power = power;
    }

    /// <summary>
    /// Переопределенный метод ToString()
    /// </summary>
    /// <returns>Строковое представление транспорта</returns>
    public override string ToString() => $"Model: {Model}, Power: {Power}";

    /// <summary>
    /// Абстрактный метод запуска двигателя
    /// </summary>
    /// <returns>Строку со звуком запуска двигателя</returns>
    public abstract string StartEngine();

    /// <summary>
    /// Метод для получения рандомной модели
    /// </summary>
    /// <returns>Рандомную строку модели</returns>
    public static string GetRandomModel()
    {
        var rand = new Random();
        var modelStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var sb = new StringBuilder();
        for (int j = 0; j < 5; j++)
        {
            sb.Append(modelStr[rand.Next(modelStr.Length)]);
        }

        return sb.ToString();
    }
}