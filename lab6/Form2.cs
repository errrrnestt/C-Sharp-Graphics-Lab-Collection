using System;
using System.Windows.Forms;

/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Form2 Layout Elements (Quadratic Equation Solver):
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - Input for coefficient 'a'
 * ▪ textBox2 - Input for coefficient 'b'
 * ▪ textBox3 - Input for coefficient 'c'
 *
 * 📝 Outputs (TextBoxes)
 * ▪ textBox4 - Output for root X1
 * ▪ textBox5 - Output for root X2
 *
 * 🔘 Buttons
 * ▪ button2 - "Розрахунок" (Calculate)
 *
 * ========================================================================= */

namespace WindowsFormsApp1
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Form2                                               ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Secondary UI Window for Quadratic Equation Calculator                ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: CALCULATE ROOTS (button2_Click)
        // 🎯 Target: Parse coefficients, calculate discriminant, find roots
        // ──────────────────────────────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            // ▫ Local Variables for coefficients, discriminant, and roots
            double a, b, c, D, x1, x2;

            // ⟳ Parse input values from text boxes
            double.TryParse(textBox1.Text, out a);
            double.TryParse(textBox2.Text, out b);
            double.TryParse(textBox3.Text, out c);

            // ⚡ Compute Discriminant: D = b^2 - 4ac
            D = Math.Pow(b, 2) - (4 * a * c);

            // ⚡ Logic: Determine number of roots based on discriminant value
            if (D > 0)
            {
                // ➔ Two real roots found
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                
                textBox4.Text = x1.ToString();
                textBox5.Text = x2.ToString();
            }
            else if (D == 0)
            {
                // ➔ One real root
                x1 = -b / (2 * a);
                textBox4.Text = x1.ToString();
                textBox5.Clear(); 
                
                MessageBox.Show("The discriminant is zero, the equation has one root.", 
                                "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (D < 0)
            {
                // ➔ No real roots
                textBox4.Clear();
                textBox5.Clear();
                
                MessageBox.Show("The discriminant is less than zero, there are no real roots.", 
                                "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}