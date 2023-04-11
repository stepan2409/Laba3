using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba3
{
    public class Computer
    {
        /// <summary>
        /// Поле экземпляра компьютера
        /// </summary>
        private static Computer computerInstance;
        /// <summary>
        /// Поле названия компьтера
        /// </summary>
        private string computerName;
        /// <summary>
        /// Поле экрана
        /// </summary>
        private Screen computerScreen;

        /// <summary>
        /// Событие изменения параметров компьютера или его экрана
        /// </summary>
        public event EventHandler ComputerParametersChanged;

        /// <summary>
        /// Приватный конструктор для реализации паттерна Singletone
        /// </summary>
        private Computer()
        {
            computerName = "";
            computerScreen = new Screen();
            computerScreen.ScreenParametersChanged += OnScreenParamsChanged;
        }

        /// <summary>
        /// Текущая яроксть экрана
        /// </summary>
        public int ScreenCurrentBrightness
        {
            get
            {
                return GetInstance().computerScreen.CurrentBrightness;
            }
            set
            {
                GetInstance().computerScreen.CurrentBrightness = value;
            }
        }

        /// <summary>
        /// Текущее состояние экрана
        /// </summary>
        public bool ScreenPowerIsOn
        {
            get
            {
                return GetInstance().computerScreen.PowerIsOn;
            }
            set
            {
                GetInstance().computerScreen.PowerIsOn = value;
            }
        }

        /// <summary>
        /// Название компьютера
        /// </summary>
        public string ComputerName
        {
            get
            {
                return GetInstance().computerName;
            }
            set
            {
                GetInstance().computerName = value;
                ThrowParamsChanged();
            }
        }

        /// <summary>
        /// Метод получения экземпляра. Нужен для реализации паттерна Singletone
        /// </summary>
        /// <returns>Экземпляр объекта</returns>
        public static Computer GetInstance()
        {
            if (computerInstance == null)
            {
                computerInstance = new Computer();
            }
            return computerInstance;
        }

        /// <summary>
        /// Включить экран
        /// </summary>
        public void ScreenPowerUp()
        {
            GetInstance().computerScreen.PowerUp();
            ScreenPowerIsOn = GetInstance().computerScreen.PowerIsOn;
        }

        /// <summary>
        /// Выключить экран
        /// </summary>
        public void ScreenPowerDown()
        {
            GetInstance().computerScreen.PowerDown();
            ScreenPowerIsOn = GetInstance().computerScreen.PowerIsOn;
        }

        /// <summary>
        /// Увеличить яркость имеющегося экрана
        /// </summary>
        public void ScreenBrightnessUp(int delta)
        {
            GetInstance().computerScreen.BrightnessUp(delta);
        }

        /// <summary>
        /// Уменьшить яркость имеющегося экрана
        /// </summary>
        public void ScreenBrightnessDown(int delta)
        {
            GetInstance().computerScreen.BrightnessDown(delta);
        }

        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        public override string ToString()
        {
            return "Название компьютера: " + GetInstance().computerName + "\r\nПараметры экрана:\r\n" +
                GetInstance().computerScreen.ToString();
        }

        private static void OnScreenParamsChanged(object sender, EventArgs e)
        {
            GetInstance().ThrowParamsChanged();
        }

        private void ThrowParamsChanged()
        {
            ComputerParametersChanged.Invoke(GetInstance(), EventArgs.Empty);
        }
    }
}