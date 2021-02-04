using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Zaposleni : Form
    {
        private readonly EmployeeBusiness employeeBusiness;
        public Zaposleni()
        {
            this.employeeBusiness = new EmployeeBusiness();
            InitializeComponent();
        }

        private void Zaposleni_Load(object sender, EventArgs e)
        {
            FillList();
        }
        private void FillList()
        {
            listBoxLista.Items.Clear();

            List<Employee> employees = this.employeeBusiness.GetEmployees();

            foreach (Employee e in employees)
            {
                listBoxLista.Items.Add(e.Id + ". " + e.Name + " " + e.Surname + " - " + e.Salary);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Name = textBoxIme.Text;
            em.Surname = textBoxPrezime.Text;
            em.Salary = Convert.ToDecimal(textBoxPlata.Text);


            bool result = this.employeeBusiness.InsertEmployee (em);

            if (result)
            {
                FillList();
                 MessageBox.Show("Uspešan unos!");
            }
            else
            {
                MessageBox.Show("Unos nije uspešan!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxLista.Items.Clear();
            List <Employee> empl = this.employeeBusiness.GetEmployeesRange(Convert.ToDecimal(textBoxOd.Text) , Convert.ToDecimal(textBoxDo.Text));
            foreach (Employee p in empl)
            {
                listBoxLista.Items.Add(p.Id + ". " + p.Name + " " + p.Surname + " - " + p.Salary);
            }
        }
    }
}
