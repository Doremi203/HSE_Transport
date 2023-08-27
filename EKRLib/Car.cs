namespace EKRLib;

/// <summary>
/// Класс машины наследованный от базового класса транспорта
/// </summary>
public class Car : Transport 
{
    public Car(string model, uint power) : base(model, power) { }

    /// <summary>
    /// Переопределенный метод ToString()
    /// </summary>
    /// <returns>Строковое представление машины</returns>
    public override string ToString() => $"Car. {base.ToString()}";
    
    public override string StartEngine() => $"{Model}: Vroom";
}