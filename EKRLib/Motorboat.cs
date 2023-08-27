namespace EKRLib;

/// <summary>
/// Класс моторной лодки наследованный от базового класса транспорта
/// </summary>
public class MotorBoat : Transport 
{
    public MotorBoat(string model, uint power) : base(model, power) { }

    /// <summary>
    /// Переопределенный метод ToString()
    /// </summary>
    /// <returns>Строковое представление транспорта</returns>
    public override string ToString() => $"MotorBoat. {base.ToString()}";

    public override string StartEngine() => $"{Model}: Brrrbrr";
}