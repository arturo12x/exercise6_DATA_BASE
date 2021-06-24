using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;



namespace exercise6_DATA_BASE
{
    public partial class Form1 : Form
    {
        SqlConnection cadena_conexion = new SqlConnection(@"DATA SOURCE=ARTURO-PC; INITIAL CATALOG=UTLD; USER ID=sa; PASSWORD='aeiou1234'");
        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenar_tabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
            string query1, name, last,ERROR;

            name = textBox1.Text;
            last = textBox2.Text;
            //validaciones




            ERROR = "";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            name = textBox1.Text;
            last = textBox2.Text;


            //VALIDACIONES
            if (string.IsNullOrWhiteSpace(name))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE NAME |";
                textBox1.BackColor = Color.DarkRed;

            }
            if (string.IsNullOrWhiteSpace(last))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE LAST NAME |";
                textBox2.BackColor = Color.DarkRed;

            }

            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }







            SqlCommand comandos = cadena_conexion.CreateCommand();

            query1 = "INSERT INTO STUDENTS VALUES ('" + name + "','" + last + "')";

            cadena_conexion.Open();


            comandos = new SqlCommand(query1, cadena_conexion);
            comandos.ExecuteNonQuery();

            cadena_conexion.Close();


            llenar_tabla();


        }

        private void validacio_empty_space()
        {
            string name, last, ERROR;

            ERROR = "";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            name = textBox1.Text;
            last = textBox2.Text;


            //VALIDACIONES
            if (string.IsNullOrWhiteSpace(name))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE NAME |";
                textBox1.BackColor = Color.DarkRed;

            }
            if (string.IsNullOrWhiteSpace(last))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE LAST NAME |";
                textBox2.BackColor = Color.DarkRed;

            }

            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string ID, ERROR;
            ID = textBox3.Text;
            ERROR = "";
            textBox3.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(ID))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE ID |";
                textBox3.BackColor = Color.DarkRed;

            }

            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            borrar();
        }
        private void borrar()
        {
            SqlCommand comandos = cadena_conexion.CreateCommand();
            string ID, query2;
            ID = textBox3.Text;
            query2 = "DELETE FROM STUDENTS WHERE IDSTUDENT=" + ID;
            cadena_conexion.Open();
            comandos = new SqlCommand(query2, cadena_conexion);
            comandos.ExecuteNonQuery();

            cadena_conexion.Close();



            llenar_tabla();
        }

        private void llenar_tabla() {
            dataGridView1.Columns.Clear();
            //llenar tabla
            cadena_conexion.Open();
            string query3 = "SELECT * from STUDENTS";
            SqlCommand cmd = new SqlCommand(query3, cadena_conexion);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            da.Fill(dt);



            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image.HeaderText = "SEL";
         

            image.Width = 100;
            dataGridView1.Columns.Add(image);
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewImageCell cell = row.Cells[3] as DataGridViewImageCell;

           //   cell.Value = Properties.Resources.update;
            }

        //    dataGridView1.Rows[i].Cells[12].Value = Image.FromFile(dataGridView1.Rows[i].Cells[11].Value.ToString());




            DataGridViewImageColumn image2 = new DataGridViewImageColumn();
            image2.HeaderText = "SEL";

;
            image2.Width = 100;
            dataGridView1.Columns.Add(image2);
            image2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewImageCell cell = row.Cells[12] as DataGridViewImageCell;

              cell.Value = exercise6_DATA_BASE.Properties.Resources.delete;
            }



            cadena_conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand comandos = cadena_conexion.CreateCommand();
            string ID, query2, ERROR;
            ID = textBox3.Text;
            string name, last;

ERROR = "";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            name = textBox1.Text;
            last = textBox2.Text;


            //VALIDACIONES
            if (string.IsNullOrWhiteSpace(name))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE NAME |";
                textBox1.BackColor = Color.DarkRed;

            }
            if (string.IsNullOrWhiteSpace(last))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE LAST NAME |";
                textBox2.BackColor = Color.DarkRed;

            }

            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ERROR = "";
            textBox3.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(ID))
            {
                ERROR += "| YOU CAN'T LEAVE EMPTY THE ID |";
                textBox3.BackColor = Color.DarkRed;

            }

                if (ERROR != "")
                {
                    MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                name = textBox1.Text;
                last = textBox2.Text;

                query2 = "UPDATE STUDENTS SET NAME=" + "'" + name + "'" + ",LASTNAME=" + "'" + last + "'" + "  WHERE IDSTUDENT=" + ID;
                textBox4.Text = query2;


                cadena_conexion.Open();
                comandos = new SqlCommand(query2, cadena_conexion);
                comandos.ExecuteNonQuery();

                cadena_conexion.Close();


                llenar_tabla();

            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Back);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Back);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Back);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnrow, btncol;

            btnrow = e.RowIndex;
            btncol = e.ColumnIndex;

            if (btncol == 3)
            {
                textBox1.Text = dataGridView1.Rows[btnrow].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[btnrow].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[btnrow].Cells[0].Value.ToString();
            }
            if (btncol == 4)
            {
                if (MessageBox.Show("ESTAS SEGURO QUE LO DESEAS ELIMINAR?", "eo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox3.Text = dataGridView1.Rows[btnrow].Cells[0].Value.ToString();
                    borrar();
                }

            }
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Update();
        }
    }

    }
