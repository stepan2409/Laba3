using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba3
{
    public class Screen
    {
        /// <summary>
        /// Поле текущего состояния
        /// </summary>
        private bool powerIsOn;
        /// <summary>
        /// Поле текущей яркости
        /// </summary>
        private int currentBrightness;

        private int previousBrightness;

        /// <summary>
        /// Событие изменения параметров экрана
        /// </summary>
        public event EventHandler ScreenParametersChanged;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Screen()
        {
            this.powerIsOn = false;
            this.currentBrightness = 0;
            this.previousBrightness = 0;
        }

        /// <summary>
        /// Конструктор с параметрами состояния и яркости
        /// </summary>
        public Screen(bool isOn, int brightness)
        {
            this.powerIsOn = isOn;
            this.currentBrightness = brightness;
        }

        /// <summary>
        /// Конструктор с параметром яркости
        /// </summary>
        public Screen(int brightness)
        {
            this.currentBrightness = brightness;
            this.powerIsOn = false;
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public bool PowerIsOn
        {
            get
            {
                return powerIsOn;
            }
            set
            {
                powerIsOn = value;
                ThrowParamsChangedEvent();
            }
        }

        /// <summary>
        /// Текущая яркость
        /// </summary>
        /// <exception cref="ArgumentException">Произошла попытка задать яркость больше 100 или меньше 0</exception>
        public int CurrentBrightness
        {
            get { return currentBrightness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new System.ArgumentException();
                }
                currentBrightness = value;
                ThrowParamsChangedEvent();
            }
        }

        /// <summary>
        /// Уменьшить яркость
        /// </summary>
        /// <remarks>В случае, если currentBrightness - delta окажется меньше 0, currentBrightness будет присвоено значение 0</remarks>
        /// <param name="delta">Изменение яркости экрана, целое НЕОТРИЦАТЕЛЬНОЕ число</param>
        /// <exception cref="ArgumentException">delta задано отрицательное значение</exception>
        public void BrightnessDown(int delta)
        {
            if (delta < 0)
            {
                throw new System.ArgumentException();
            }
            if (powerIsOn)
            {
                currentBrightness = Math.Max(currentBrightness - delta, 0);
                ThrowParamsChangedEvent();
            }
        }

        /// <summary>
        /// Увеличить яркость.
        /// </summary>
        /// <remarks>В случае, если currentBrightness + delta окажется больше 100, currentBrightness будет присвоено значение 100</remarks>
        /// <param name="delta">Изменение яркости экрана, целое НЕОТРИЦАТЕЛЬНОЕ число</param>
        /// <exception cref="ArgumentException">delta задано отрицательное значение</exception>
        public void BrightnessUp(int delta)
        {
            if (delta < 0)
            {
                throw new System.ArgumentException();
            }
            if (powerIsOn)
            {
                currentBrightness = Math.Min(currentBrightness + delta, 100);
                ThrowParamsChangedEvent();
            }
        }

        /// <summary>
        /// Включить экран
        /// </summary>
        public void PowerUp()
        {
            powerIsOn = true;
            currentBrightness = previousBrightness;
            ThrowParamsChangedEvent();
        }

        /// <summary>
        /// Выключить экран
        /// </summary>
        public void PowerDown()
        {
            powerIsOn = false;
            previousBrightness = currentBrightness;
            currentBrightness = 0;
            ThrowParamsChangedEvent();
        }

        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        /// <returns>Строка вида "Текущая яркость экрана: <see cref="CurrentBrightness"/>/100; Экран включён: ДА/НЕТ"</returns>
        public override string ToString()
        {
            return "Текущая яркость экрана: " + currentBrightness + "/100; Экран включён: " + (powerIsOn ? "ДА" : "НЕТ");
        }

        private void ThrowParamsChangedEvent()
        {
            ScreenParametersChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}