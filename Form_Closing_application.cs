using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Store_Project
{
    public partial class Form_Closing_application : Form
    {
        public Form_Closing_application()
        {
            InitializeComponent();
            Makinganapplication();
            ShowStaffofemployees();
            ShowStaffofemployees2();
        }

        private void labelFirstName_Click(object sender, EventArgs e)
        {

        }

        private void Form_Closing_application_Load(object sender, EventArgs e)
        {

        }
        void Makinganapplication()
        {

            comboBoxIdMakinganapplication.Items.Clear();
            foreach (Making_an_application making_an_application in Program.wftDb.Making_an_application)
            {

                string[] item = {  making_an_application.Id.ToString()+".",making_an_application.FirstName, making_an_application.MiddleName, making_an_application.LastName, making_an_application.Phone.ToString(), making_an_application.Type };
                comboBoxIdMakinganapplication.Items.Add(string.Join(" ", item));

            }
        }
        void ShowStaffofemployees()
        {
            comboBoxIdStaffofemployees.Items.Clear();
            foreach (Staff_of_employees staff_of_employees in Program.wftDb.Staff_of_employees)
            {

                string[] item = { staff_of_employees.Id.ToString()+".", staff_of_employees.FirstName, staff_of_employees.MiddleName, staff_of_employees.LastName};
                comboBoxIdStaffofemployees.Items.Add(string.Join(" ", item));


            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxIdMakinganapplication.SelectedItem != null && comboBoxIdStaffofemployees.SelectedItem != null &&  textBoxPrice.Text != " ")
            {
                Closing_application closing_application = new Closing_application();
               
                closing_application.IdMakinganapplication = Convert.ToInt32(comboBoxIdMakinganapplication.SelectedItem.ToString().Split('.')[0]);
                closing_application.IdStaffofemployees = Convert.ToInt32(comboBoxIdStaffofemployees.SelectedItem.ToString().Split('.')[0]);

                closing_application.Price = Convert.ToInt32(textBoxPrice.Text);
                Program.wftDb.Closing_application.Add(closing_application);
                Program.wftDb.SaveChanges();
                ShowStaffofemployees2();

            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ShowStaffofemployees2()
        {
            listViewMaking_an_application.Items.Clear();
           
            foreach (Closing_application losing_application in Program.wftDb.Closing_application)
            {
                
                ListViewItem item = new ListViewItem(new string[]
                {   losing_application.Id.ToString(),
                    losing_application.Making_an_application.LastName+" "+losing_application.Making_an_application.FirstName+" "+losing_application.Making_an_application.Type + " "+losing_application.Making_an_application.Quantity+ " шт.",
                   
                     
                    losing_application.Staff_of_employees.LastName+" "+losing_application.Staff_of_employees.FirstName,
                   
                    losing_application.Price.ToString(),
                    
                   
                    losing_application.IdMakinganapplication.ToString(),losing_application.IdStaffofemployees.ToString(),losing_application.Price.ToString()
                });
                
                item.Tag = losing_application;
                
                listViewMaking_an_application.Items.Add(item);
            }

        }
    

        private void listViewMaking_an_application_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewMaking_an_application.SelectedItems.Count == 1)
            {
                Closing_application closing_application = listViewMaking_an_application.SelectedItems[0].Tag as Closing_application;

                comboBoxIdMakinganapplication.SelectedIndex = comboBoxIdMakinganapplication.FindString(closing_application.IdMakinganapplication.ToString());
                comboBoxIdStaffofemployees.SelectedIndex = comboBoxIdStaffofemployees.FindString(closing_application.IdStaffofemployees.ToString());

                textBoxPrice.Text = closing_application.Price.ToString();

            }
            else
            {
                comboBoxIdMakinganapplication.SelectedItem = null;
                comboBoxIdStaffofemployees.SelectedItem = null;
                textBoxPrice.Text = " ";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewMaking_an_application.SelectedItems.Count == 1)
                {    
                   Closing_application closing_application = listViewMaking_an_application.SelectedItems[0].Tag as  Closing_application;
                    
                    closing_application.IdMakinganapplication = Convert.ToInt32(comboBoxIdMakinganapplication.SelectedItem.ToString().Split('.')[0]);
                    closing_application.IdStaffofemployees = Convert.ToInt32(comboBoxIdStaffofemployees.SelectedItem.ToString().Split('.')[0]);
                    closing_application.Price = Convert.ToInt32(textBoxPrice.Text);
                    Program.wftDb.SaveChanges();
                    ShowStaffofemployees2();
                }
            
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {     //если в listView выбран элимент
                if (listViewMaking_an_application.SelectedItems.Count == 1)
                {    //ищем элемент из таблицы по тегу
                    Closing_application closing_application = listViewMaking_an_application.SelectedItems[0].Tag as Closing_application;
                    Program.wftDb.Closing_application.Remove(closing_application);
                    Program.wftDb.SaveChanges();
                    //отображаем обновленный список
                    ShowStaffofemployees2();
                }
                comboBoxIdMakinganapplication.SelectedItem = null;
                comboBoxIdStaffofemployees.SelectedItem = null;
                textBoxPrice.Text = "" ;
            }
            catch
            {
                MessageBox.Show("Данные не удаляются", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }

