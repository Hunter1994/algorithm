using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var field = "\"" + textBox1.Text.Trim() + "\":";
            var str = richTextBox1.Text;
            int idx = 0;
            bool start = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == field[idx])
                {
                    idx++;
                }
                else
                {
                    idx = 0;
                }
                if (idx == field.Length)
                {
                    start = true;
                }

            }




            //var datas= JsonConvert.DeserializeObject<List<dynamic>>(richTextBox1.Text);

            //int index = 0;
            //string ls = "";
            //foreach (var item in datas)
            //{
            //    var aaa = item._source.GetType();
            //    var ps = (List<PropertyInfo>)item._source.GetType().GetPropertys();
            //    foreach (var item1 in ps)
            //    {
            //        if (item1.Name == textBox1.Text.Trim())
            //        {
            //            var v= item1.GetValue(item);
            //            ls += $"\"{v}\",\r\n";
            //            index++;
            //        }
            //    }

            //    //ls += $"\"{item._source.payrollNo}\",\r\n";
            //    //index++;
            //}
            //label1.Text = index.ToString();
            //richTextBox2.Text= ls;

        }
    }
}
