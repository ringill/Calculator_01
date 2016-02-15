using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    /// <summary>
    /// Класс, отвечающий за изменение интерфейса формы
    /// </summary>
    public class CalculView
    {
        public ComboBox ComboBoxOperators { get; set; }
        public TextBox TextBoxArg1 { get; set; }
        public TextBox TextBoxArg2 { get; set; }
        public TextBox TextBoxResult { get; set; }
        public ListBox ListBox { get; set; }

        /// <summary>
        /// Подготавливает внешний вид формы
        /// </summary>
        public void Init()
        {
            //fill combobox
            this.ComboBoxOperators.BeginUpdate();
            for (int i = 0; i < OperList.Opers.Length - 1; i++)
            {
                this.ComboBoxOperators.Items.Add(OperList.Opers[i].Name);
            }
            this.ComboBoxOperators.EndUpdate();

            this.ComboBoxOperators.SelectedIndex = 0;
            this.ComboBoxOperators.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Заполняет поле результатом вычисления
        /// </summary>
        /// <param name="text"></param>
        public void ShowResult(string text)
        {
            TextBoxResult.Text = text;
        }

        /// <summary>
        /// Возвращает имя операции
        /// </summary>
        public string GetOperationName()
        {
            return ComboBoxOperators.SelectedItem.ToString();
        }

        /// <summary>
        /// Очищает поля формы
        /// </summary>
        public void ClearForm()
        {
            //TextBoxArg1.Clear();
            //TextBoxArg2.Clear();
            TextBoxResult.Clear();
        }

        /// <summary>
        /// Проверяет форму на корректность данных
        /// </summary>
        /// <returns>если форма корректа, то возвращает данные для расчета</returns>
        public CalculModel ValidateInput()
        {
            CalculModel calculModel = new CalculModel();
            bool result = true;
            string message = string.Empty;

            //not empty
            if (TextBoxArg1.Text == String.Empty & TextBoxArg2.Text == String.Empty)
            {
                message = message + "Все поля должны быть заполнены\n";
                result = false;
            }

            //incorrect number
            try
            {
                calculModel.Arg1 = int.Parse(TextBoxArg1.Text);
            }
            catch (Exception)
            {
                message = message + "Недопустимое значение первого аргумента\n";
                result = false;
            }

            try
            {
                calculModel.Arg2 = int.Parse(TextBoxArg2.Text);
            }
            catch (Exception)
            {
                message = message + "Недопустимое значение второго аргумента\n";
                result = false;
            }

            //message
            if (result == false)
            {
                MessageBox.Show(message);
                return null;
            }

            return calculModel;
        }

        /// <summary>
        /// Обновляет исторические данные в окне
        /// </summary>
        /// <param name="records"></param>
        public void ShowListboxData(string[] records)
        {
            this.ListBox.Items.Clear();

            this.ListBox.BeginUpdate();
            foreach (var record in records)
            {
                this.ListBox.Items.Add(record);
            }
            this.ListBox.EndUpdate();
        }
    }
}
