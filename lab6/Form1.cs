using System;
using System.Windows.Forms;

/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Form1 Layout Elements:
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - Input X
 * ▪ textBox2 - Input Y
 * ▪ textBox3 - Input Z
 * ▪ textBox4 - Results display area
 *
 * 🔘 Selection Controls
 * ▪ radioButton1, 2, 3 - Choose f(x) function (sin, x^2, e^x)
 * ▪ radioButton4, 5, 6 - Select math case (17, 15, 13)
 *
 * 🔘 Navigation Buttons
 * ▪ button3 - Link to Form 2
 * ▪ button4 - Link to Form 3
 * ▪ button5 - Link to Form 4
 * ▪ button1 - Execute computation
 *
 * ========================================================================= */

namespace WindowsFormsApp1
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Form1                                               ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Primary UI Window for Mathematical Computations                      ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Form1 : Form
    {
        // ⚙ Internal State: Tracks which formula case is selected (default 17)
        int caseSwitch = 17;

        public Form1()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: COMPUTE EXPRESSION
        // 🎯 Target: Get inputs from textboxes, compute f(x) and u, show results
        // ──────────────────────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            // ▫ Parse numeric values from text input fields
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double z = Convert.ToDouble(textBox3.Text);
            double f_x = 0;
            double u = 0;

            // ⟳ Calculate base f(x) based on user selection (sin, x^2, or exp)
            if (radioButton1.Checked) f_x = Math.Sin(x);
            else if (radioButton2.Checked) f_x = Math.Pow(x, 2);
            else if (radioButton3.Checked) f_x = Math.Exp(x);

            // ⚡ Algorithmic Logic: Execute specific formula based on chosen case
            switch (caseSwitch)
            {
                case 17:
                    // 17. Formula implementation
                    if ((y + x) == 0) u = Math.Pow(f_x, 3) - Math.Pow(y, 3) * Math.Sin(x);
                    else if ((y + x) > 0) u = Math.Pow((f_x * y), 2) - Math.Cos(y);
                    else u = Math.Pow(y * f_x, 2) + Math.PI;
                    break;

                case 15:
                    // 15. Formula implementation
                    if ((x - y) == 0) u = Math.Pow(Math.Sin(f_x), 2) + Math.Sin(y);
                    else if ((x - y) > 0) u = Math.Sin(f_x) - Math.Cos(y);
                    else u = y - Math.Pow(Math.Tan(f_x), 2) + Math.Tan(y);
                    break;

                case 13:
                    // 13. Formula implementation
                    u = (Math.Min(f_x, y) - Math.Max(y, z)) / 2;
                    break;
            }

            // 📝 Display results in the output window
            textBox4.Text = "Results:" + Environment.NewLine;
            textBox4.Text += "X = " + x + Environment.NewLine;
            textBox4.Text += "Y = " + y + Environment.NewLine;
            
            // ▫ Add Z value to output only if case 13 is selected
            if (caseSwitch == 13) textBox4.Text += "Z = " + z + Environment.NewLine; 
            
            textBox4.Text += "Result = " + u.ToString() + Environment.NewLine;
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: NAVIGATION LOGIC
        // ──────────────────────────────────────────────────────────────────────
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();        // Hide current form
            new Form2().Show(); // Open Form 2
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();        // Hide current form
            new Form3().Show(); // Open Form 3
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Placeholder for Form 4 navigation
        }

        // ──────────────────────────────────────────────────────────────────────
        // ⚙ ACTION: STATE UPDATES
        // ──────────────────────────────────────────────────────────────────────
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { caseSwitch = 17; }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { caseSwitch = 15; }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { caseSwitch = 13; }
        
        private void radioButton4_CheckedChanged(object sender, EventArgs e) { caseSwitch = 17; }
        private void radioButton5_CheckedChanged(object sender, EventArgs e) { caseSwitch = 15; }
        private void radioButton6_CheckedChanged(object sender, EventArgs e) { caseSwitch = 13; }
    }
}