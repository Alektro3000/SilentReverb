public enum ResonanceEffect
{
    None = 0,
    /// <summary>
    /// Эффект Модерато
    /// </summary>
    AddResonance = 1,
    /// <summary>
    /// Эффект Либера
    /// </summary>
    DistantResonance = 2,
    /// <summary>
    /// Эффект Вивас
    /// </summary>
    CloseResonance = 4,
    /// <summary>
    /// Все предыдущие эффекты
    /// </summary>
    AllBase = 7,
    /// <summary>
    /// Активация Резонанса при любых условиях
    /// </summary>
    ActivateAll = 8
}
