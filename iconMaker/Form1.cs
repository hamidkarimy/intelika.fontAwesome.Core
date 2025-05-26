using System.Text;
using System.Text.Json;

namespace iconMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                var json = File.ReadAllText(openFileDialog1.FileName);
                using var doc = JsonDocument.Parse(json);
                var icons = doc.RootElement;
                StringBuilder sb = new StringBuilder();
                foreach (var icon in icons.EnumerateObject())
                {
                    var name = icon.Name.Replace("-", "_");

                    if (icon.Value.TryGetProperty("unicode", out var unicodeProp))
                    {
                        var unicode = unicodeProp.GetString();
                        sb.AppendLine($"{name} = 0x{unicode},");                        
                    }
                }
                textBox1.Text = sb.ToString();
            }
        }
    }
}
