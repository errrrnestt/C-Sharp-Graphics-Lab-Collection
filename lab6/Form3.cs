using System;
using System.Drawing;
using System.Windows.Forms;

/* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * Form3 Layout Elements (Currency Exchange):
 *
 * 📝 Inputs (TextBoxes)
 * ▪ textBox1 - Buy Rate (Купівля)
 * ▪ textBox2 - Sell Rate (Продаж)
 * ▪ textBox3 - Amount in USD
 * ▪ textBox4 - Resulting Amount in UAN
 *
 * 🔘 Controls
 * ▪ radioButton1 - "Купуємо" (Buy mode)
 * ▪ radioButton2 - "Продаємо" (Sell mode)
 * ▪ button1 - "Обчислити" (Calculate)
 * ▪ button2 - "Вихід" (Exit)
 *
 * 📝 Labels
 * ▪ label4 - Direction indicator (">" or "<")
 *
 * ========================================================================= */

namespace WindowsFormsApp1
{
    // ╔════════════════════════════════════════════════════════════════════════╗
    // ║ 🧩 CORE COMPONENT: Form3                                               ║
    // ╠════════════════════════════════════════════════════════════════════════╣
    // ║ ▪ Currency Exchange Calculator UI                                      ║
    // ╚════════════════════════════════════════════════════════════════════════╝
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: PERFORM CALCULATION (button1_Click)
        // 🎯 Target: Multiply chosen rate by USD amount ➔ Display in UAN
        // ──────────────────────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            // ⚡ Validation: Ensure rates and USD amount are provided
            if (((textBox1.Text != "" && radioButton1.Checked) || 
                 (textBox2.Text != "" && radioButton2.Checked)) && textBox3.Text != "")
            {
                // ➔ Calculate based on selected radio button (Buy or Sell rate)
                if (radioButton1.Checked)
                    textBox4.Text = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox3.Text)).ToString();
                else
                    textBox4.Text = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)).ToString();
            }
            else
            {
                textBox4.Clear(); // ∅ Reset output if fields are empty
            }
        }

        // ──────────────────────────────────────────────────────────────────────
        // ➔ ACTION: TERMINATE APPLICATION (button2_Click)
        // ──────────────────────────────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ──────────────────────────────────────────────────────────────────────
        // ⚙ ACTION: UI FEEDBACK (Updates highlighting for active exchange mode)
        // ──────────────────────────────────────────────────────────────────────
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.BackColor = SystemColors.Window; // Reset Buy box color[cite: 11]
                textBox2.BackColor = Color.Gold;          // Highlight Sell box[cite: 11]
                label4.Text = "     >";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox2.BackColor = SystemColors.Window; // Reset Sell box color[cite: 11]
                textBox1.BackColor = Color.Gold;          // Highlight Buy box[cite: 11]
                label4.Text = "<     ";
            }
        }
    }
}