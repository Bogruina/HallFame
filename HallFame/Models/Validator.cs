using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HallOfFame.Models
{
    /// <summary>
    /// Статический класс проверяет валидность различных данных и логирует
    /// исключения в физический файл
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Поле инициализации объекта класса Logger
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Метод проверяет валидность данных типа string и логирует исключения в файл
        /// </summary>
        /// <param name="length">Максимальная длина строки</param>
        /// <param name="value">Строка, которую требуется проверить</param>
        /// <param name="currentProperty">Текущее свойство</param>
        public static void AssertString(int length, string value, string currentProperty)
        {
            try
            {
                if (value.Length > length)
                {
                    throw new ArgumentException();
                }       
            }
            catch (ArgumentException ex)
            {
                Logger.Error(ex, $"{currentProperty} max length {length} letters");
            };
        }

        /// <summary>
        /// Метод проверяет валидность данных типа byte и логирует исключения в файл
        /// </summary>
        /// <param name="value">Переменная, которую требуется проверить</param>
        /// <param name="maxSize">Максимальное значение</param>
        /// <param name="minSize">Минимальное значение</param>
        /// <param name="currentProperty">Текущее свойство</param>
        public static void AssertByte(byte value, byte maxSize, byte minSize, string currentProperty)
        {
            try
            {
                if (value < minSize || value > maxSize)
                {
                    throw new ArgumentException();
                }

            }
            catch (ArgumentException ex)
            {
                Logger.Error(ex, $"{currentProperty} must be between {minSize} and {maxSize}");
            }
        }
    }
}
