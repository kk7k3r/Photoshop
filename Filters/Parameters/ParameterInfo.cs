using System;

namespace MyPhotoshop.Filters.Parameters
{
    /// <summary>
    /// Этот класс содержит описание одного параметра фильтра: как он называется, в каких пределах изменяется, и т.д.
    /// Эта информация необходима для настройки графического интерфейса.
    /// </summary>
    public class ParameterInfo: Attribute
    {
        public readonly string Name;
        public readonly double DefaultValue;
        public readonly double MinValue;
        public readonly double MaxValue;
        public readonly double Increment;

        public ParameterInfo(string name, double defaultValue, 
            double increment, double minValue = 0, double maxValue = 1)
        {
            Name = name;
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
            Increment = increment;
        }
    }
}
