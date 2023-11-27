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

            // ��������� ������ ��� �����-������
            comboBoxFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxComand.DropDownStyle = ComboBoxStyle.DropDownList;

            // ����������� ����������� ������� FormClosing
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // ����������� ����������� ������� KeyDown
            this.KeyDown += new KeyEventHandler(MainForm_KeyDown);

            // �������� ������ �� ���� ������
            LoadData();

            // ��������� ����������� DataGridView
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
            // �������� ������ �� ���� ������
            var customersList = customers.ToList();
            var productsList = products.ToList();
            var ordersList = orders.ToList();
            var orderItemsList = orderItems.ToList();

            // �������� DataSet � ���������� ������ � ����
            dataSet = new DataSet();
            // ��� ������� Customer
            var includedCustomerProperties = new List<string> { "Customer_ID", "Name", "Surname", "Address", "Email", "Phone" };
            dataSet.Tables.Add(ConvertToDataTable(customersList, "CUSTOMERS", includedCustomerProperties));
            // ��� ������� Products
            var includedProductProperties = new List<string> { "Product_ID", "Name", "Category", "Price", "Description" };
            dataSet.Tables.Add(ConvertToDataTable(productsList, "PRODUCTS", includedProductProperties));

            // ��� ������� Orders
            var includedOrderProperties = new List<string> { "Order_ID", "Customer_ID", "OrderDate", "Status", "DeliveryCost" };
            dataSet.Tables.Add(ConvertToDataTable(ordersList, "ORDERS", includedOrderProperties));

            // ��� ������� OrderItems
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

                // ��������� ������� CheckBox'�
                checkBox.Font = newFont;
                checkBox.AutoSize = false;
                checkBox.Size = new Size(200, 40);
                checkBox.Location = new Point(40, 10 + step);
                checkBox.Text = column.ColumnName;
                checkBox.Checked = true;

                // ���������� ������� ��������� ��������� CheckBox'�
                checkBox.CheckedChanged += checkBox_CheckedChanged;

                // ���������� CheckBox'� �� ������
                CheckBoxPanel.Controls.Add(checkBox);

                // ���������� ��������� ��� ���������� CheckBox'�
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

            // ���������, ��� ��������� ������� ���������� � dataSet
            if (GlobalInx < dbContext.Model.GetEntityTypes().Count())
            {
                var entityType = dbContext.Model.GetEntityTypes().ElementAt(GlobalInx).ClrType;

                var property = entityType.GetProperty(propertyName);

                if (property != null)
                {
                    // �������� ��������� ���������������� �������� � DataGridView
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
            // ����������� ���������� ������� � ComboBoxCommand
            switch (comboBoxComand.SelectedIndex)
            {
                case 0:
                    // ������� ��������� � FuncPanel � ����� ������ ��� ���������� ��������� ��� �������
                    FuncPanel.Controls.Clear();
                    Func_Insert(GlobalInx);
                    break;
                case 1:
                    // ������� ��������� � FuncPanel � ����� ������ ��� ���������� ��������� ��� ����������
                    FuncPanel.Controls.Clear();
                    Func_Update(GlobalInx);
                    break;
                case 2:
                    // ������� ��������� � FuncPanel � ����� ������ ��� ���������� ��������� ��� ��������
                    FuncPanel.Controls.Clear();
                    Func_Delete(GlobalInx);
                    break;
                default:
                    break;
            }
        }
        private void Func_Insert(int tableIndex)
        {
            // ������ ��� ������� ������ � ��������� �������

            int step = 50;
            int tableIndx = tableIndex;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // ������� ������ �� ���������� ���������
            FuncPanel.Controls.Clear();

            // ��������� ��������� �����
            LocationTextBox.Text = dataTable.ToString();

            // �������� ������ ��� ������
            Font newFont = new Font("Arial", 12);

            // �������� � ��������� ��������� �����
            Label labelTitle = new Label();
            labelTitle.Location = new Point(150, 10);
            labelTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            labelTitle.Text = "������ ��� ��� ������ �����";
            labelTitle.AutoSize = true;
            FuncPanel.Controls.Add(labelTitle);

            // ������� �������� �������
            foreach (DataColumn column in dataTable.Columns)
            {
                // �������� ���������� ���� ��� ����� ������
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

                // ���������� ��������� �� ������
                FuncPanel.Controls.Add(label);
                FuncPanel.Controls.Add(textBox);

                // ���������� ���� ��� ���������� ��������
                step += 40;
            }

            // �������� ������ ��� ������
            Font buttonFont = new Font("Arial", 14, FontStyle.Bold);

            // �������� � ��������� ������ "�������� ����"
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "�������� ����";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            // ���������� ������� Click ��� ������ "�������� ����"
            buttonClear.Click += (sender, e) =>
            {
                // ������� ��������� �����
                foreach (DataColumn column in dataTable.Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    if (text != null)
                    {
                        text.Text = "";
                    }
                }
            };

            // �������� � ��������� ������ "������ �����"
            Button buttonInsert = new Button();
            buttonInsert.FlatStyle = FlatStyle.Flat;
            buttonInsert.FlatAppearance.BorderSize = 0;
            buttonInsert.ForeColor = Color.White;
            buttonInsert.Location = new Point(330, 200);
            buttonInsert.Size = new Size(200, 40);
            buttonInsert.Font = buttonFont;
            buttonInsert.Text = "������ �����";
            buttonInsert.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonInsert);

            // ���������� ������� Click ��� ������ "������ �����"
            buttonInsert.Click += (sender, e) =>
            {
                using (var context = new OrderDbContext())
                {
                    // �������� ������������� ���� �����
                    if (FuncPanel.Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
                    {
                        MessageBox.Show("��������� ��� ���� ����� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // ��������� ���������� �������, ��� ��� �� ��� ���� ���������
                    }

                    // ������������ SQL-������� ��� ������� ����� ������
                    StringBuilder sqlCommand = new StringBuilder();
                    sqlCommand.Append($"INSERT INTO [{dataTable.TableName.ToString()}] (");

                    // ������� ������� ������� (ID)
                    bool skipFirstColumn = true;

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        sqlCommand.Append($"[{column.ColumnName}], ");
                    }

                    // �������� ������ �������� � ������ SQL-�������
                    sqlCommand.Length -= 2;

                    sqlCommand.Append(") VALUES (");

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // ��������� �������� �� TextBox ��� �������� �������
                        TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                        string textValue = text.Text.Trim();

                        sqlCommand.Append($"'{textValue}', ");
                    }

                    // �������� ������ �������� � ������ SQL-�������
                    sqlCommand.Length -= 2;

                    sqlCommand.Append(")");

                    try
                    {
                        // ���������� SQL-������� ��� ������� ������
                        context.Database.ExecuteSqlRaw(sqlCommand.ToString());
                        context.SaveChanges();
                        // ����� ��������� �� �������� �������
                        MessageBox.Show("��� ������� ��������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // ����� ��������� �� ������ ��� ���������� SQL-�������
                        MessageBox.Show("������ ��� ������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // ���������� ����� ��� ����������
            Label label = new Label();
            label.Location = new Point(50, 10);
            label.Font = newFont;
            label.Text = "������ ����� ��� ����������� �� ���� ID";
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

                // ������ �������������� ������� ���������� ����
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

            // ���������� ����� � ���������� ���� ��� ������ ID ����
            Label chooseLabel = new Label();
            chooseLabel.Location = new Point(320, 40);
            chooseLabel.AutoSize = true;
            chooseLabel.Font = new Font("Arial", 14);
            chooseLabel.Text = "������ ����� �� ���� ID";
            FuncPanel.Controls.Add(chooseLabel);

            TextBox chooseText = new TextBox();
            chooseText.Location = new Point(400, 70);
            chooseText.Size = new Size(50, 20);
            FuncPanel.Controls.Add(chooseText);

            // ���������� ������ ��� ������ ����
            Button buttonChoose = new Button();
            buttonChoose.FlatStyle = FlatStyle.Flat;
            buttonChoose.FlatAppearance.BorderSize = 0;
            buttonChoose.ForeColor = Color.White;
            buttonChoose.Location = new Point(330, 100);
            buttonChoose.Size = new Size(200, 40);
            buttonChoose.Font = buttonFont;
            buttonChoose.Text = "������ �����";
            buttonChoose.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonChoose);

            buttonChoose.Click += (sender, e) =>
            {
                int selectedID;
                if (int.TryParse(chooseText.Text, out selectedID))
                {
                    DataRow selectedRow = null;

                    // ����� ���������� ���� �� ID
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[0] is int && (int)row[0] == selectedID)
                        {
                            selectedRow = row;
                            break;
                        }
                    }

                    // ���������� ��������� ����� ������� ���������� ����
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
                        // ����� ��������� �� ������, ���� ��� �� ������
                        MessageBox.Show("��� � ��������� ID �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // ������� ��������� �����
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
                    // ����� ��������� �� ������, ���� ������ ������������ ID
                    MessageBox.Show("������� ���������� �������� ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // ���������� ������ ��� ������� �����
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "�������� ����";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            buttonClear.Click += (sender, e) =>
            {
                // ������� ���� ��������� �����
                foreach (DataColumn column in dataTable.Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    text.Text = "";
                }
            };

            // ���������� ������ ��� ���������� ����
            Button buttonUpdate = new Button();
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(330, 200);
            buttonUpdate.Size = new Size(200, 40);
            buttonUpdate.Font = buttonFont;
            buttonUpdate.Text = "�̲���� �����";
            buttonUpdate.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonUpdate);

            buttonUpdate.Click += (sender, e) =>
            {
                using (var context = new OrderDbContext())
                {
                    // ��������� ID ���������� ���� ��� ����������
                    int selectedID;
                    if (int.TryParse(chooseText.Text, out selectedID))
                    {
                        // �������� ������������� ���� �����
                        if (FuncPanel.Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
                        {
                            MessageBox.Show("��������� ��� ���� ����� �����������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // ��������� ���������� ����������, ��� ��� �� ��� ���� ���������
                        }

                        // ������������ SQL-������� ��� ���������� ������
                        StringBuilder sqlCommand = new StringBuilder();
                        sqlCommand.Append($"UPDATE [{dataTable.TableName.ToString()}] SET ");

                        foreach (DataColumn column in dataTable.Columns)
                        {
                            // ��������� �������� �� TextBox ��� �������� �������
                            TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                            string textValue = text.Text.Trim();

                            sqlCommand.Append($"[{column.ColumnName}] = '{textValue}', ");
                        }

                        // �������� ������ �������� � ������ SQL-�������
                        sqlCommand.Length -= 2;

                        // ���������� ������� ��� ����������� ���� �� ID
                        sqlCommand.Append($" WHERE [{dataTable.Columns[0].ColumnName}] = {selectedID}");

                        try
                        {
                            // ���������� SQL-������� ��� ���������� ������
                            context.Database.ExecuteSqlRaw(sqlCommand.ToString());
                            context.SaveChanges();
                            // ����� ��������� �� �������� ���������� ����
                            MessageBox.Show("��� ������� ��������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // ����� ��������� �� ������ ��� ���������� SQL-�������
                            MessageBox.Show("������ ��� ���������� ������: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // ����� ��������� �� ������, ���� ������ ������������ ID
                        MessageBox.Show("������� ���������� �������� ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                InitializeDbContext();
                LoadData();
                dataGridView.DataSource = dataSet.Tables[tableIndx];
            };
        }

        private void Func_Delete(int tableIndex)
        {
            // ������������� ����������
            int tableIndx = tableIndex;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // ������� ������ �� ���������� ���������
            FuncPanel.Controls.Clear();

            // ��������� ��������� �����
            LocationTextBox.Text = dataTable.ToString();

            // ��������� ����� �������
            string nameTable = dataTable.TableName.ToString();

            // �������� ������� ��� ������ � ������
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);
            Font newFont = new Font("Arial", 12, FontStyle.Bold);

            // �������� � ��������� ����� ��� ����������
            Label label = new Label();
            label.Location = new Point(50, 10);
            label.Font = newFont;
            label.Text = "������ ��������� �����, ���� ���� �������� �� ���� ID";
            label.AutoSize = true;
            FuncPanel.Controls.Add(label);

            // ������������� ���������� ��� ������� ��������� �� ������
            int step = 50;

            // ������� �������� �������
            foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
            {
                // �������� ���������� ���� ��� ����������� ������
                TextBox textBox = new TextBox();
                Label labelText = new Label();
                textBox.Location = new Point(120, step);
                textBox.Size = new Size(200, 50);
                textBox.Name = "textBox_" + column.ColumnName;
                textBox.Font = new Font("Arial", 12);
                labelText.Location = new Point(5, step);

                // ������ �������������� ��������� �����
                textBox.ReadOnly = true;

                labelText.Font = new Font("Arial", 12);
                labelText.Text = column.ColumnName;
                labelText.AutoSize = true;
                step += 40;

                // ���������� ���������� ���� � ����� �� ������
                FuncPanel.Controls.Add(textBox);
                FuncPanel.Controls.Add(labelText);
            }

            // �������� � ��������� ����� ��� ������ ���� �� ID
            Label chooseLabel = new Label();
            chooseLabel.Location = new Point(320, 40);
            chooseLabel.AutoSize = true;
            chooseLabel.Font = new Font("Arial", 14);
            chooseLabel.Text = "������ ����� �� ���� ID";
            FuncPanel.Controls.Add(chooseLabel);

            // �������� ���������� ���� ��� ����� ID ����
            TextBox chooseText = new TextBox();
            chooseText.Location = new Point(400, 70);
            chooseText.Size = new Size(50, 20);
            FuncPanel.Controls.Add(chooseText);

            // �������� � ��������� ������ "������ �����"
            Button buttonChoose = new Button();
            buttonChoose.FlatStyle = FlatStyle.Flat;
            buttonChoose.FlatAppearance.BorderSize = 0;
            buttonChoose.ForeColor = Color.White;
            buttonChoose.Location = new Point(330, 100);
            buttonChoose.Size = new Size(200, 40);
            buttonChoose.Font = buttonFont;
            buttonChoose.Text = "������ �����";
            buttonChoose.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonChoose);

            // ���������� ������� Click ��� ������ "������ �����"
            buttonChoose.Click += (sender, e) =>
            {
                // ������� �������������� ���������� ID � �����
                int selectedID;
                if (int.TryParse(chooseText.Text, out selectedID))
                {
                    // ����� ���������� ���� �� ID
                    DataRow selectedRow = null;
                    foreach (DataRow row in dataSet.Tables[tableIndx].Rows)
                    {
                        if (row[0] is int && (int)row[0] == selectedID)
                        {
                            selectedRow = row;
                            break;
                        }
                    }

                    // ����������� ������ ���������� ���� � ��������� �����
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
                        // ����� ��������� �� ������, ���� ��� �� ������
                        MessageBox.Show("��� � ��������� ID �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // ����� ��������� �� ������ ��� ������������ ����� ID
                    MessageBox.Show("������� ���������� �������� ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // �������� � ��������� ������ "�������� ����"
            Button buttonClear = new Button();
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.ForeColor = Color.White;
            buttonClear.Location = new Point(330, 150);
            buttonClear.Size = new Size(200, 40);
            buttonClear.Font = buttonFont;
            buttonClear.Text = "�������� ����";
            buttonClear.BackColor = Color.FromArgb(92, 142, 173);
            FuncPanel.Controls.Add(buttonClear);

            // ���������� ������� Click ��� ������ "�������� ����"
            buttonClear.Click += (sender, e) =>
            {
                foreach (DataColumn column in dataSet.Tables[tableIndx].Columns)
                {
                    TextBox text = FuncPanel.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == "textBox_" + column.ColumnName);
                    text.Text = "";
                }
            };

            // �������� � ��������� ������ "�������� �����"
            Button buttonDelete = new Button();
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(330, 200);
            buttonDelete.Size = new Size(200, 40);
            buttonDelete.Font = buttonFont;
            buttonDelete.Text = "�������� �����";
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

                        // ��������� SQL-������ �� �������� ����
                        var sqlQuery = $"DELETE FROM {tableName} WHERE {primaryKeyColumnName} = {selectedID}";

                        try
                        {
                            // ��������� SQL-������
                            context.Database.ExecuteSqlRaw(sqlQuery);

                            MessageBox.Show("��� ������� ������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // ���������� ������ � ������� ����� ��������� ��������
                            LoadData();
                            dataGridView.DataSource = dataSet.Tables[tableIndx];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"������ ��� �������� ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("������� ���������� �������� ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InitializeDbContext();
                LoadData();
                dataGridView.DataSource = dataSet.Tables[tableIndx];
            };
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            // �������� � ����������� ����� "� ���������"
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void AdviceButtonFunc_Click(object sender, EventArgs e)
        {
            // �������� � ����������� ����� �������
            AdviceFuncForm adviceFuncForm = new AdviceFuncForm();
            adviceFuncForm.Show();
        }

        private void AdviceButtonSearch_Click(object sender, EventArgs e)
        {
            // �������� � ����������� ����� ������ �������
            AdviceSearchForm adviceSearchForm = new AdviceSearchForm();
            adviceSearchForm.Show();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            // ��������� ������� ������� �������
            int tableIndx = GlobalInx;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // �������� ������ ��� ����������
            StringBuilder filterExpression = new StringBuilder();

            // ������� �������� �������
            foreach (DataColumn column in dataTable.Columns)
            {
                // ���������� ������� ��� ��������� ��������
                if (column.DataType == typeof(string))
                {
                    filterExpression.Append($" OR {column.ColumnName} LIKE '%{SearchBox.Text}%'");
                }
            }

            // �������� ������ 4 ��������, ���� ������ ���������� �� �����
            if (filterExpression.Length > 0)
            {
                filterExpression.Remove(0, 4);
            }

            // ���������� ������� � ������ �������
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();
        }

        private void SearchIDtextBox_TextChanged(object sender, EventArgs e)
        {
            // ��������� ������� ������� �������
            int tableIndx = GlobalInx;
            DataTable dataTable = dataSet.Tables[tableIndx];

            // ��������� ������� �� ID ��� ������� �������, ���� ���� ������
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
            // �������� ������ ������� � ����������� �� ������� �������
            if (Control.ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.I: // ��� �������
                        comboBoxComand.SelectedIndex = 0;
                        break;
                    case Keys.U: // ��� ����������
                        comboBoxComand.SelectedIndex = 1;
                        break;
                    case Keys.D: // ��� ��������
                        comboBoxComand.SelectedIndex = 2;
                        break;
                    case Keys.Escape:
                        Application.Exit();
                        break;
                    // ����� �������
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
            // ������������ �������� � �������� ���������� � ����� ������
            dbContext.Dispose();
        }
    }
}