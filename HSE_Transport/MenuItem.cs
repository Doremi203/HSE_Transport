namespace HSE_Transport;

/// <summary>
/// Пункт меню
/// </summary>
/// <param name="Input">Ввод по которому вызывается данный пункт меню</param>
/// <param name="Description">Описание пункта меню</param>
/// <param name="Action">Действия выполняемые при вызове пункта меню</param>
internal record MenuItem(string Input, string Description, Action Action);