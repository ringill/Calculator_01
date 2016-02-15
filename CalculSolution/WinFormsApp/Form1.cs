using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Logger;
using Logger.Abstract;
using Logger.Entities;
using Logic;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Repository for logger
        /// </summary>
        private IRepository _repository;

        private CalculView _calculView;
        private CalculService _calculService;
        private LoggerService _loggerService;

        public Form1(IRepository repository)
        {
            //Привязываемся к хранилищу
            _repository = repository;

            //Инициализация компонентов формы
            InitializeComponent();

            //класс отвечающий за представление
            _calculView = new CalculView
            {
                ComboBoxOperators = this.comboBox1,
                TextBoxArg1 = this.textBox1,
                TextBoxArg2 = this.textBox2,
                TextBoxResult = this.textBox3,
                ListBox = this.listBox1
            };

            //Заполняем форму данными
            _calculView.Init();

            //Класс, отвечающий за вычисления
            _calculService = new CalculService();
            
            //класс отвечающий за запись лога в хранилище
            _loggerService = new LoggerService(_repository);
        }

        /// <summary>
        /// "Show history" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            //лочим кнопку
            var button = (Button)sender;
            button.Enabled = false;

            //Получаем записи
            //ЭТО ДОЛГИЙ ПРОЦЕСС, поэтому выполняем его асинхронно
            var strings = await _loggerService.GetString5();
            //Обновляем listbox
            _calculView.ShowListboxData(strings);

            //разлочиваем кнопку
            button.Enabled = true;
        }

        /// <summary>
        /// Calculation & logging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Проверяем введенные значения на корректность и получаем аргументы
            var arguments = _calculView.ValidateInput();
            //если аргументы корректны, то проводим вычисления
            if (arguments!=null)
            {
                //Добавляем наименование операции в аргументы
                arguments.OperationName = _calculView.GetOperationName();
                //Проводим вычисления и запоминаем результат
                arguments = _calculService.Calculate(arguments);
                //Если результат вычисления удачен
                if (arguments!=null)
                {
                    //Показываем результат на форме
                    _calculView.ShowResult(arguments.Result.ToString());
                    
                    //Записываем результат в лог
                    //ЭТО ДОЛГИЙ ПРОЦЕСС, поэтому запускаем его в отдельном потоке
                    _loggerService.SaveToLog(arguments);
                }
                else
                {
                    MessageBox.Show("Не удалось произвести рассчет!\nВозможно, деление на ноль.");
                    //Стираем результат предыдущего вычисления
                    _calculView.ClearForm();
                }
            }

        }
    }
}
