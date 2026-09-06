using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form1 : Form
    {
        Order order = new Order();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Burger");
            comboBox1.Items.Add("Pizza");
            comboBox1.Items.Add("Coffee");
            comboBox1.Items.Add("Sandwich");
            comboBox1.Items.Add("Pasta");

            labelNumberOfItem.Text = "Number Of Item: 0";
            labelTotalBill.Text = "Total Bill: 0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a food item!");
                return;
            }

            string food = comboBox1.SelectedItem.ToString();

            if (order.Contains(food))
            {
                MessageBox.Show("This food item is already added!");
                return;
            }

            order.AddItem(food);
            listBox1.Items.Add(food);

            labelNumberOfItem.Text =
                "Number Of Item: " + order.Count;

            labelTotalBill.Text =
                "Total Bill: " + CalculateBill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Name and Number cannot be empty!");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select Gender!");
                return;
            }

            if (!radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Please select Membership!");
                return;
            }

            string gender = "";

            if (radioButton1.Checked)
                gender = "Male";

            if (radioButton2.Checked)
                gender = "Female";

            string membership = "";

            if (radioButton3.Checked)
                membership = "Premium";

            if (radioButton4.Checked)
                membership = "Regular";

            SqlConnection con = new SqlConnection(
                @"Data Source=DESKTOP-QD2NICG\SQLEXPRESS;
                Initial Catalog=Customer;
                Integrated Security=True");

            try
            {
                con.Open();

                string checkQuery =
                    "SELECT COUNT(*) FROM HHHH WHERE [Name] = @Name";

                SqlCommand checkCmd =
                    new SqlCommand(checkQuery, con);

                checkCmd.Parameters.AddWithValue(
                    "@Name", textBox1.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Customer already exists!");
                    return;
                }

                string query =
     "INSERT INTO HHHH " +
     "([Name], [Phone], [Gender], [Membership], [OrderItems], [NumberOfItems], [TotalBill]) " +
     "VALUES " +
     "(@Name, @Phone, @Gender, @Membership, @OrderItems, @NumberOfItems, @TotalBill)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Membership", membership);
                cmd.Parameters.AddWithValue("@OrderItems", GetOrderItems());
                cmd.Parameters.AddWithValue("@NumberOfItems", order.Count);
                cmd.Parameters.AddWithValue("@TotalBill", CalculateBill());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Customer Inserted Successfully!");

                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private double CalculateBill()
        {
            double total = 0;

            for (int i = 0; i < order.Count; i++)
            {
                try
                {
                    string food = order[i];

                    if (food == "Burger")
                        total += 150;
                    else if (food == "Pizza")
                        total += 300;
                    else if (food == "Coffee")
                        total += 100;
                    else if (food == "Sandwich")
                        total += 120;
                    else if (food == "Pasta")
                        total += 200;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Invalid food item index!");
                }
            }

            return total;
        }


        private string GetOrderItems()
        {
            string items = "";

            for (int i = 0; i < order.Count; i++)
            {
                try
                {
                    items += order[i];

                    if (i < order.Count - 1)
                        items += ",";
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Invalid index!");
                }
            }

            return items;
        }


        private void ClearAll()
        {
            textBox1.Clear();
            textBox2.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            comboBox1.SelectedIndex = -1;

            listBox1.Items.Clear();

            order.Clear();

            labelNumberOfItem.Text =
                "Number Of Item: 0";

            labelTotalBill.Text =
                "Total Bill: 0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter customer name!");
                return;
            }

            SqlConnection con = new SqlConnection(
                 @"Data Source=DESKTOP-QD2NICG\SQLEXPRESS;
                Initial Catalog=Customer;
                Integrated Security=True");

            try
            {
                con.Open();

                string query =
                    "SELECT * FROM HHHH WHERE [Name] = @Name";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Name", textBox1.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox2.Text =
                      reader["Phone"].ToString();

                    string gender =
                        reader["Gender"].ToString();

                    if (gender == "Male")
                        radioButton1.Checked = true;
                    else if (gender == "Female")
                        radioButton2.Checked = true;

                    string membership =
                        reader["Membership"].ToString();

                    if (membership == "Premium")
                        radioButton3.Checked = true;
                    else if (membership == "Regular")
                        radioButton4.Checked = true;

                    listBox1.Items.Clear();

                    string items =
                        reader["OrderItems"].ToString();

                    string[] itemArray =
                        items.Split(',');

                    order.Clear();

                    foreach (string item in itemArray)
                    {
                        if (item.Trim() != "")
                        {
                            order.AddItem(item.Trim());
                            listBox1.Items.Add(item.Trim());
                        }
                    }

                    labelNumberOfItem.Text =
                        "Number Of Item: " +
                        reader["NumberOfItems"].ToString();

                    labelTotalBill.Text =
                        "Total Bill: " +
                        reader["TotalBill"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer not found!");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter customer name!");
                return;
            }

            string gender = "";

            if (radioButton1.Checked)
                gender = "Male";
            else if (radioButton2.Checked)
                gender = "Female";

            string membership = "";

            if (radioButton3.Checked)
                membership = "Premium";
            else if (radioButton4.Checked)
                membership = "Regular";

            SqlConnection con = new SqlConnection(
                @"Data Source=DESKTOP-QD2NICG\SQLEXPRESS;
                Initial Catalog=Customer;
                Integrated Security=True");

            try
            {
                con.Open();

                string query =
    "UPDATE HHHH SET " +
    "[Phone] = @Phone, " +
    "[Gender] = @Gender, " +
    "[Membership] = @Membership, " +
    "[OrderItems] = @OrderItems, " +
    "[NumberOfItems] = @NumberOfItems, " +
    "[TotalBill] = @TotalBill " +
    "WHERE [Name] = @Name";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Name", textBox1.Text);

                cmd.Parameters.AddWithValue(
     "@Phone", textBox2.Text);

                cmd.Parameters.AddWithValue(
                    "@Gender", gender);

                cmd.Parameters.AddWithValue(
                    "@Membership", membership);

                cmd.Parameters.AddWithValue(
                    "@OrderItems", GetOrderItems());

                cmd.Parameters.AddWithValue(
                    "@NumberOfItems", order.Count);

                cmd.Parameters.AddWithValue(
                    "@TotalBill", CalculateBill());

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Customer Updated Successfully!");
                else
                    MessageBox.Show("Customer not found!");

                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter customer name!");
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            SqlConnection con = new SqlConnection(
                @"Data Source=DESKTOP-QD2NICG\SQLEXPRESS;
                Initial Catalog=Customer;
                Integrated Security=True");

            try
            {
                con.Open();

                string query =
                    "DELETE FROM HHHH WHERE [Name] = @Name";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Name", textBox1.Text);

                int deleted =
                    cmd.ExecuteNonQuery();

                if (deleted > 0)
                    MessageBox.Show("Customer Deleted Successfully!");
                else
                    MessageBox.Show("Customer not found!");

                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

