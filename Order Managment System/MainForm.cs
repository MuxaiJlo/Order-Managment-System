using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Order_Managment_System
{
    public partial class MainForm : Form
    {
        private OrderDbContext dbContext;
        private DbSet<Customer> customers;
        private DbSet<Product> products;
        private DbSet<Order> orders;
        private DbSet<OrderItem> orderItems;
        private int GlobalInx;
        DataSet dataSet;
        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDbContext();

            // Установка стилей для комбо-боксов
            comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxComand.DropDownStyle = ComboBoxStyle.DropDownList;

            // Регистрация обработчика события FormClosing
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // Регистрация обработчика события KeyDown
            this.KeyDown += new KeyEventHandler(MainForm_KeyDown);

            // Загрузка данных из базы данных
            LoadData();

            // Настройка отображения DataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void InitializeDbContext()
        {
            dbContext = new OrderDbContext();
            customers = dbContext.Customers;
            products = dbContext.Products;
            orders = dbContext.Orders;
            orderItems = dbContext.OrderItems;
        }

        private void LoadData()
        {
            // Загрузка данных из базы данных
            var customersList = customers.ToList();
            var productsList = products.ToList();
            var ordersList = orders.ToList();
            var orderItemsList = orderItems.ToList();

            // Создание DataSet и добавление таблиц в него
            dataSet = new DataSet();
            // Для таблицы Customer
            var includedCustomerProperties = new List<string> { "Customer_ID", "Name", "Surname", "Address", "Email", "Phone" };
            dataSet.Tables.Add(ConvertToDataTable(customersList, "CUSTOMERS", includedCustomerProperties));
            // Для таблицы Products
            var includedProductProperties = new List<string> { "Product_ID", "Name", "Category", "Price", "Description" };
            dataSet.Tables.Add(ConvertToDataTable(productsList, "PRODUCTS", includedProductProperties));

            // Для таблицы Orders
            var includedOrderProperties = new List<string> { "Order_ID", "Customer_ID", "OrderDate", "Status", "DeliveryCost" };
            dataSet.Tables.Add(ConvertToDataTable(ordersList, "ORDERS", includedOrderProperties));

            // Для таблицы OrderItems
            var includedOrderItemProperties = new List<string> { "Order_Item_ID", "Order_ID", "Product_ID", "Quantity", "Description" };
            dataSet.Tables.Add(ConvertToDataTable(orderItemsList, "ORDERITEMS", includedOrderItemProperties));

        }

        private DataTable ConvertToDataTable<T>(List<T> data, string tableName, List<string> includedProperties)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(tableName);

            foreach (PropertyDescriptor prop in properties)
            {
                if (includedProperties.Contains(prop.Name))
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (includedProperties.Contains(prop.Name))
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        private void CheckBoxUtility(int inxTable)
        {
            int step = 0;
            CheckBoxPanel.Controls.Clear();

            Font newFont = new Font("Arial", 12, FontStyle.Bold);
            foreach (DataColumn column in dataSet.Tables[inxTable].Columns)
            {
                CheckBox checkBox = new CheckBox();

                // Установка свойств CheckBox'а
                checkBox.Font = newFont;
                checkBox.AutoSize = false;
                checkBox.Size = new Size(200, 40);
                checkBox.Location = new Point(40, 10 + step);
                checkBox.Text = column.ColumnName;
                checkBox.Checked = true;

                // Обработчик события изменения состояния CheckBox'а
                checkBox.CheckedChanged += checkBox_CheckedChanged;

                // Добавление CheckBox'а на панель
                CheckBoxPanel.Controls.Add(checkBox);

                // Увеличение интервала для следующего CheckBox'а
                step += 60;
            }
        }
        private void SetDataGridViewSourceAndCheckBoxUtility(int tableIndex)
        {
            dataGridView.DataSource = dataSet.Tables[tableIndex];
            CheckBoxUtility(tableIndex);

        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string propertyName = checkBox.Text;

            // Проверяем, что выбранная таблица существует в dataSet
            if (GlobalInx < dbContext.Model.GetEntityTypes().Count())
            {
                var entityType = dbContext.Model.GetEntityTypes().ElementAt(GlobalInx).ClrType;

                var property = entityType.GetProperty(propertyName);

                if (property != null)
                {
                    // Изменяем видимость соответствующего свойства в DataGridView
                    var column = dataGridView.Columns[propertyName];
                    if (column != null)
                    {
                        column.Visible = checkBox.Checked;
                    }
                }
            }
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFilter.SelectedIndex)
            {
                case 0:
                    GlobalInx = 0;
                    SetDataGridViewSourceAndCheckBoxUtility(0);
                    break;
                case 1:
                    GlobalInx = 1;
                    SetDataGridViewSourceAndCheckBoxUtility(1);
                    break;
                case 2:
                    GlobalInx = 2;
                    SetDataGridViewSourceAndCheckBoxUtility(2);
                    break;
                case 3:
                    GlobalInx = 3;
                    SetDataGridViewSourceAndCheckBoxUtility(3);
                    break;
                default:
                    break;
            }
        }

        private void comboBoxComand_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Определение выбранного индекса в ComboBoxCommand
            switch (comboBoxComand.SelectedIndex)
            {
                case 0:
                    // Очистка элементов в FuncPanel и вызов метода для добавления элементов для вставки
                    FuncPanel.Controls.Clear();
                    Func_Insert(GlobalInx);
                    break;
                case 1:
                    // Очистка элементов в FuncPanel и вызов метода для добавления элементов для обновления
                    FuncPanel.Controls.Clear();
                    Func_Update(GlobalInx);
                    break;
                case 2:
                    // Очистка элементов в FuncPanel и вызов метода для добавления элементов для удаления
                    FuncPanel.Controls.Clear();
                    Func_Delete(GlobalInx);
                    break;
                default:
                    break;
            }
        }
        private void Func_Insert(int tableIndex)
        {
            // Логика для вставки данных в выбранную таблицу

            int step = 50;
            int tableIndx = tableIndex;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // Очистка панели от предыдущих элементов
            FuncPanel.Controls.Clear();

            // Установка заголовка формы
            LocationTextBox.Text = dataTable.ToString();

            // Создание шрифта для текста
            Font newFont = new Font("Arial", 12);

            // Создание и настройка заголовка формы
            Label labelTitle = new Label();
            labelTitle.Location = new Point(150, 10);
            labelTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            labelTitle.Text = "Введіть дані для нового рядка";
            labelTitle.AutoSize = true;
            FuncPanel.Controls.Add(labelTitle);

            // Перебор столбцов таблицы
            foreach (DataColumn column in dataTable.Columns)
            {
                // Создание текстового поля для ввода данных
                TextBox textBox = new TextBox();
                Label label = new Label();
                label.AutoSize = true;
                label.Text = column.ColumnName;
                label.Size = new Size(100, 50);
                label.Font = newFont;
                label.Location = new Point(5, step);
                textBox.Size = new Size(200, 50);
                textBox.Location = new Point(120, step);
                textBox.Name = "textBox_" + column.ColumnName;

                // Добавление элементов на панель
                FuncPanel.Controls.Add(label);
                FuncPanel.Controls.Add(textBox);

                // Увеличение шага для следующего элемента
                step += 40;
            }

            // Создание шрифта для кнопок
            Font buttonFont = new Font("Arial", 14, FontStyle.Bold);

            // Создание и настройка кнопки "ОЧИСТИТИ ПОЛЯ"
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "ОЧИСТИТИ ПОЛЯ";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            // Обработчик события Click для кнопки "ОЧИСТИТИ ПОЛЯ"
            buttonClear.Click += (sender, e) =>
            {
                // Очистка текстовых полей
                foreach (DataColumn column in dataTable.Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    if (text != null)
                    {
                        text.Text = "";
                    }
                }
            };

            // Создание и настройка кнопки "ДОДАТИ РЯДОК"
            Button buttonInsert = new Button();
            buttonInsert.FlatStyle = FlatStyle.Flat;
            buttonInsert.FlatAppearance.BorderSize = 0;
            buttonInsert.ForeColor = Color.White;
            buttonInsert.Location = new Point(330, 200);
            buttonInsert.Size = new Size(200, 40);
            buttonInsert.Font = buttonFont;
            buttonInsert.Text = "ДОДАТИ РЯДОК";
            buttonInsert.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonInsert);

            // Обработчик события Click для кнопки "ДОДАТИ РЯДОК"
            buttonInsert.Click += (sender, e) =>
            {
                using (var context = new OrderDbContext())
                {
                    // Проверка заполненности всех полей
                    if (FuncPanel.Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
                    {
                        MessageBox.Show("Заполните все поля перед вставкой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Прерываем выполнение вставки, так как не все поля заполнены
                    }

                    // Формирование SQL-команды для вставки новой записи
                    StringBuilder sqlCommand = new StringBuilder();
                    sqlCommand.Append($"INSERT INTO [{dataTable.TableName.ToString()}] (");

                    // Пропуск первого столбца (ID)
                    bool skipFirstColumn = true;

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sqlCommand.Append($"[{column.ColumnName}], ");
                    }

                    // Удаление лишних символов в строке SQL-команды
                    sqlCommand.Length -= 2;

                    sqlCommand.Append(") VALUES (");

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Получение значения из TextBox для текущего столбца
                        TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                        string textValue = text.Text.Trim();

                        sqlCommand.Append($"'{textValue}', ");
                    }

                    // Удаление лишних символов в строке SQL-команды
                    sqlCommand.Length -= 2;

                    sqlCommand.Append(")");

                    try
                    {
                        // Выполнение SQL-команды для вставки данных
                        context.Database.ExecuteSqlRaw(sqlCommand.ToString());
                        context.SaveChanges();
                        // Вывод сообщения об успешной вставке
                        MessageBox.Show("Ряд успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Вывод сообщения об ошибке при выполнении SQL-команды
                        MessageBox.Show("Ошибка при вставке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                InitializeDbContext();
                LoadData();
                dataGridView.DataSource = dataSet.Tables[tableIndx];
            };
        }


        private void Func_Update(int tableIndex)
        {
            int tableIndx = tableIndex;
            DataTable dataTable = dataSet.Tables[tableIndx];
            LocationTextBox.Text = dataTable.ToString();
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);
            Font newFont = new Font("Arial", 12, FontStyle.Bold);

            // Добавление метки для инструкции
            Label label = new Label();
            label.Location = new Point(50, 10);
            label.Font = newFont;
            label.Text = "Оберіть рядок для редагування за його ID";
            label.AutoSize = true;
            FuncPanel.Controls.Add(label);

            int step = 50;

            foreach (DataColumn column in dataTable.Columns)
            {
                TextBox textBox = new TextBox();
                Label labelText = new Label();
                textBox.Location = new Point(120, step);
                textBox.Size = new Size(200, 50);
                textBox.Name = "textBox_" + column.ColumnName;
                textBox.Font = new Font("Arial", 12);

                // Запрет редактирования первого текстового поля
                if (column.ColumnName == dataTable.Columns[0].ColumnName)
                {
                    textBox.ReadOnly = true;
                }

                labelText.Location = new Point(5, step);
                labelText.Font = new Font("Arial", 12);
                labelText.Text = column.ColumnName;
                labelText.AutoSize = true;
                step += 40;

                FuncPanel.Controls.Add(labelText);
                FuncPanel.Controls.Add(textBox);
            }

            // Добавление метки и текстового поля для выбора ID ряда
            Label chooseLabel = new Label();
            chooseLabel.Location = new Point(320, 40);
            chooseLabel.AutoSize = true;
            chooseLabel.Font = new Font("Arial", 14);
            chooseLabel.Text = "Оберіть рядок за його ID";
            FuncPanel.Controls.Add(chooseLabel);

            TextBox chooseText = new TextBox();
            chooseText.Location = new Point(400, 70);
            chooseText.Size = new Size(50, 20);
            FuncPanel.Controls.Add(chooseText);

            // Добавление кнопки для выбора ряда
            Button buttonChoose = new Button();
            buttonChoose.FlatStyle = FlatStyle.Flat;
            buttonChoose.FlatAppearance.BorderSize = 0;
            buttonChoose.ForeColor = Color.White;
            buttonChoose.Location = new Point(330, 100);
            buttonChoose.Size = new Size(200, 40);
            buttonChoose.Font = buttonFont;
            buttonChoose.Text = "ОБРАТИ РЯДОК";
            buttonChoose.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonChoose);

            buttonChoose.Click += (sender, e) =>
            {
                int selectedID;
                if (int.TryParse(chooseText.Text, out selectedID))
                {
                    DataRow selectedRow = null;

                    // Поиск выбранного ряда по ID
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[0] is int && (int)row[0] == selectedID)
                        {
                            selectedRow = row;
                            break;
                        }
                    }

                    // Заполнение текстовых полей данными выбранного ряда
                    if (selectedRow != null)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            if (text != null)
                            {
                                text.Text = selectedRow[column.ColumnName].ToString();
                            }
                        }
                    }
                    else
                    {
                        // Вывод сообщения об ошибке, если ряд не найден
                        MessageBox.Show("Ряд с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Очистка текстовых полей
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            text.Text = "";
                            chooseText.Text = "";
                        }
                    }
                }
                else
                {
                    // Вывод сообщения об ошибке, если введен некорректный ID
                    MessageBox.Show("Введите корректное значение ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Добавление кнопки для очистки полей
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "ОЧИСТИТИ ПОЛЯ";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            buttonClear.Click += (sender, e) =>
            {
                // Очистка всех текстовых полей
                foreach (DataColumn column in dataTable.Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    text.Text = "";
                }
            };

            // Добавление кнопки для обновления ряда
            Button buttonUpdate = new Button();
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(330, 200);
            buttonUpdate.Size = new Size(200, 40);
            buttonUpdate.Font = buttonFont;
            buttonUpdate.Text = "ЗМІНИТИ РЯДОК";
            buttonUpdate.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonUpdate);

            buttonUpdate.Click += (sender, e) =>
            {
                using (var context = new OrderDbContext())
                {
                    // Получение ID выбранного ряда для обновления
                    int selectedID;
                    if (int.TryParse(chooseText.Text, out selectedID))
                    {
                        // Проверка заполненности всех полей
                        if (FuncPanel.Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
                        {
                            MessageBox.Show("Заполните все поля перед обновлением.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Прерываем выполнение обновления, так как не все поля заполнены
                        }

                        // Формирование SQL-команды для обновления записи
                        StringBuilder sqlCommand = new StringBuilder();
                        sqlCommand.Append($"UPDATE [{dataTable.TableName.ToString()}] SET ");

                        foreach (DataColumn column in dataTable.Columns)
                        {
                            // Получение значения из TextBox для текущего столбца
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            string textValue = text.Text.Trim();

                            sqlCommand.Append($"[{column.ColumnName}] = '{textValue}', ");
                        }

                        // Удаление лишних символов в строке SQL-команды
                        sqlCommand.Length -= 2;

                        // Добавление условия для определения ряда по ID
                        sqlCommand.Append($" WHERE [{dataTable.Columns[0].ColumnName}] = {selectedID}");

                        try
                        {
                            // Выполнение SQL-команды для обновления данных
                            context.Database.ExecuteSqlRaw(sqlCommand.ToString());
                            context.SaveChanges();
                            // Вывод сообщения об успешном обновлении ряда
                            MessageBox.Show("Ряд успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Вывод сообщения об ошибке при выполнении SQL-команды
                            MessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Вывод сообщения об ошибке, если введен некорректный ID
                        MessageBox.Show("Введите корректное значение ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                InitializeDbContext();
                LoadData();
                dataGridView.DataSource = dataSet.Tables[tableIndx];
            };
        }

        private void Func_Delete(int tableIndex)
        {
            // Инициализация переменных
            int tableIndx = tableIndex;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // Очистка панели от предыдущих элементов
            FuncPanel.Controls.Clear();

            // Установка заголовка формы
            LocationTextBox.Text = dataTable.ToString();

            // Получение имени таблицы
            string nameTable = dataTable.TableName.ToString();

            // Создание шрифтов для текста и кнопок
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);
            Font newFont = new Font("Arial", 12, FontStyle.Bold);

            // Создание и настройка метки для инструкций
            Label label = new Label();
            label.Location = new Point(50, 10);
            label.Font = newFont;
            label.Text = "Оберіть наступний запис, який буде видалено за його ID";
            label.AutoSize = true;
            FuncPanel.Controls.Add(label);

            // Инициализация переменной для позиции элементов на панели
            int step = 50;

            // Перебор столбцов таблицы
            foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
            {
                // Создание текстового поля для отображения данных
                TextBox textBox = new TextBox();
                Label labelText = new Label();
                textBox.Location = new Point(120, step);
                textBox.Size = new Size(200, 50);
                textBox.Name = "textBox_" + column.ColumnName;
                textBox.Font = new Font("Arial", 12);
                labelText.Location = new Point(5, step);

                // Запрет редактирования текстовых полей
                textBox.ReadOnly = true;

                labelText.Font = new Font("Arial", 12);
                labelText.Text = column.ColumnName;
                labelText.AutoSize = true;
                step += 40;

                // Добавление текстового поля и метки на панель
                FuncPanel.Controls.Add(textBox);
                FuncPanel.Controls.Add(labelText);
            }

            // Создание и настройка метки для выбора ряда по ID
            Label chooseLabel = new Label();
            chooseLabel.Location = new Point(320, 40);
            chooseLabel.AutoSize = true;
            chooseLabel.Font = new Font("Arial", 14);
            chooseLabel.Text = "Оберіть рядок за його ID";
            FuncPanel.Controls.Add(chooseLabel);

            // Создание текстового поля для ввода ID ряда
            TextBox chooseText = new TextBox();
            chooseText.Location = new Point(400, 70);
            chooseText.Size = new Size(50, 20);
            FuncPanel.Controls.Add(chooseText);

            // Создание и настройка кнопки "ОБРАТИ РЯДОК"
            Button buttonChoose = new Button();
            buttonChoose.FlatStyle = FlatStyle.Flat;
            buttonChoose.FlatAppearance.BorderSize = 0;
            buttonChoose.ForeColor = Color.White;
            buttonChoose.Location = new Point(330, 100);
            buttonChoose.Size = new Size(200, 40);
            buttonChoose.Font = buttonFont;
            buttonChoose.Text = "ОБРАТИ РЯДОК";
            buttonChoose.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonChoose);

            // Обработчик события Click для кнопки "ОБРАТИ РЯДОК"
            buttonChoose.Click += (sender, e) =>
            {
                // Попытка преобразования введенного ID в число
                int selectedID;
                if (int.TryParse(chooseText.Text, out selectedID))
                {
                    // Поиск выбранного ряда по ID
                    DataRow selectedRow = null;
                    foreach (DataRow row in dataSet.Tables[tableIndx].Rows)
                    {
                        if (row[0] is int && (int)row[0] == selectedID)
                        {
                            selectedRow = row;
                            break;
                        }
                    }

                    // Отображение данных выбранного ряда в текстовых полях
                    if (selectedRow != null)
                    {
                        foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
                        {
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            if (text != null)
                            {
                                text.Text = selectedRow[column.ColumnName].ToString();
                            }
                        }
                    }
                    else
                    {
                        // Вывод сообщения об ошибке, если ряд не найден
                        MessageBox.Show("Ряд с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
                        {
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            text.Text = "";
                            chooseText.Text = "";
                        }
                    }
                }
                else
                {
                    // Вывод сообщения об ошибке при некорректном вводе ID
                    MessageBox.Show("Введите корректное значение ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Создание и настройка кнопки "ОЧИСТИТИ ПОЛЯ"
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "ОЧИСТИТИ ПОЛЯ";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            // Обработчик события Click для кнопки "ОЧИСТИТИ ПОЛЯ"
            buttonClear.Click += (sender, e) =>
            {
                foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    text.Text = "";
                }
            };

            // Создание и настройка кнопки "ВИДАЛИТИ РЯДОК"
            Button buttonDelete = new Button();
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(330, 200);
            buttonDelete.Size = new Size(200, 40);
            buttonDelete.Font = buttonFont;
            buttonDelete.Text = "ВИДАЛИТИ РЯДОК";
            buttonDelete.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonDelete);

            buttonDelete.Click += (sender, e) =>
            {
                int selectedID;
                if (int.TryParse(chooseText.Text, out selectedID))
                {
                    using (var context = new OrderDbContext())
                    {
                        var dataTable = dataSet.Tables[tableIndx];
                        var tableName = dataTable.TableName;
                        var primaryKeyColumnName = dataTable.Columns[0].ColumnName;

                        // Формируем SQL-запрос на удаление ряда
                        var sqlQuery = $"DELETE FROM {tableName} WHERE {primaryKeyColumnName} = {selectedID}";

                        try
                        {
                            // Выполняем SQL-запрос
                            context.Database.ExecuteSqlRaw(sqlQuery);

                            MessageBox.Show("Ряд успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновление данных в таблице после успешного удаления
                            LoadData();
                            dataGridView.DataSource = dataSet.Tables[tableIndx];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении ряда: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректное значение ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InitializeDbContext();
                LoadData();
                dataGridView.DataSource = dataSet.Tables[tableIndx];
            };
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы "О программе"
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void AdviceButtonFunc_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы функций
            AdviceFuncForm adviceFuncForm = new AdviceFuncForm();
            adviceFuncForm.Show();
        }

        private void AdviceButtonSearch_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы поиска советов
            AdviceSearchForm adviceSearchForm = new AdviceSearchForm();
            adviceSearchForm.Show();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            // Получение индекса текущей таблицы
            int tableIndx = GlobalInx;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // Создание строки для фильтрации
            StringBuilder filterExpression = new StringBuilder();

            // Перебор столбцов таблицы
            foreach (DataColumn column in dataTable.Columns)
            {
                // Добавление условия для строковых столбцов
                if (column.DataType == typeof(string))
                {
                    filterExpression.Append($" OR {column.ColumnName} LIKE '%{SearchBox.Text}%'");
                }
            }

            // Удаление первых 4 символов, если строка фильтрации не пуста
            if (filterExpression.Length > 0)
            {
                filterExpression.Remove(0, 4);
            }

            // Применение фильтра к данным таблицы
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();
        }

        private void SearchIDtextBox_TextChanged(object sender, EventArgs e)
        {
            // Получение индекса текущей таблицы
            int tableIndx = GlobalInx;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // Установка фильтра по ID или очистка фильтра, если поле пустое
            if (string.IsNullOrWhiteSpace(SearchIDtextBox.Text))
            {
                (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView.DataSource as DataTable).DefaultView.RowFilter = $"{dataTable.Columns[0].ColumnName} = {SearchIDtextBox.Text}";
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Вызываем нужную функцию в зависимости от нажатой клавиши
            if (Control.ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.I: // Для вставки
                        comboBoxComand.SelectedIndex = 0;
                        break;
                    case Keys.U: // Для обновления
                        comboBoxComand.SelectedIndex = 1;
                        break;
                    case Keys.D: // Для удаления
                        comboBoxComand.SelectedIndex = 2;
                        break;
                    case Keys.Escape:
                        Application.Exit();
                        break;
                    // Выбор таблицы
                    case Keys.D1:
                        comboBoxFilter.SelectedIndex = 0;
                        break;
                    case Keys.D2:
                        comboBoxFilter.SelectedIndex = 1;
                        break;
                    case Keys.D3:
                        comboBoxFilter.SelectedIndex = 2;
                        break;
                    case Keys.D4:
                        comboBoxFilter.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Освобождение ресурсов и закрытие соединения с базой данных
            dbContext.Dispose();
        }
    }
}