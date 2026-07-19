using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 /* =========================================================================
 * 🎨 UI BUILD GUIDE
 * =========================================================================
 * The designer file (Form1.Designer.cs) is not included.
 * Add the following controls:
 *
 * 
 * 📦 Controls
 * ▪ No buttons required
 * ▪ No textBoxes required
 *
 *
 * 🖼️ Form
 * ▪ Form1 - Solar System animation window
 *
 *
 * ⏱️ Timers
 * ▪ Timer1 - Optional / unused
 * ▪ Runtime timers are created automatically in Form1_Load:
 *      - Primary orbit timer (40ms)
 *      - Secondary orbit timer (400ms)
 *      - Tertiary orbit timer (100ms)
 *      - Moon orbit timer (15ms)
 *
 *
 * ⚙ Required Events:
 * ▪ Form.Load
 * ▪ Form.Paint
 *
 *
 * ✨ Features:
 * ✔ Animated solar system
 * ✔ Multiple orbiting planets
 * ✔ Moon rotation around planet
 * ✔ Double buffering for smooth animation
 *
 * ========================================================================= */

// ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨
// Part 2: Solar System Animation


namespace WindowsFormsApplication9
{
  
    // 🖼️ MAIN FORM CLASS - ANIMATION ORBIT SYSTEM
   

    public partial class Form1 : Form
    {
        
        // 🏗️ CONSTRUCTOR
       

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;      // 📥 Form load event
            this.Paint += Form1_Paint;    // 🎨 Paint event for drawing
            DoubleBuffered = true;        // 🖥️ Enable double buffering to reduce flicker
        }

        
        // 📦 ORBIT PARAMETERS - Primary orbit (Red/Brown)
       

        int r = 150;     // 📏 Orbit radius (primary)
        int x0 = 400;    // 📍 X coordinate of center
        int y0 = 300;    // 📍 Y coordinate of center

    
        // 📦 ORBIT PARAMETERS - Secondary orbit (RosyBrown)
      

        int q = 500;     // 📏 Orbit radius (secondary)
        int w0 = 400;    // 📍 X coordinate of center
        int e0 = 300;    // 📍 Y coordinate of center

       
        // 📦 ORBIT PARAMETERS - Tertiary orbit (Blue)
       

        int q1 = 300;    // 📏 Orbit radius (tertiary)

      
        // 📦 ORBIT PARAMETERS - Quaternary orbit (Gray - small moon)
    

        int q2 = 70;     // 📏 Orbit radius (quaternary - moon)

        
        // 📊 POSITION VARIABLES
       

        float x = 0, y = 0, z = 0, c = 0, x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        
       
        // 🔄 ANGLE VARIABLES (in radians)
      

        double fi = 0.0;     // 🌀 Primary orbit angle
        double fii = 0.0;    // 🌀 Secondary orbit angle
        double fiii = 0.0;   // 🌀 Tertiary orbit angle
        double fiiii = 0.0;  // 🌀 Quaternary orbit angle

       
        // 🚀 FORM LOAD - Initialize all timers
    

        void Form1_Load(object sender, EventArgs e)
        {
            // ⏱️ Timer 1: Primary orbit (slow - 40ms)
            Timer tmr = new Timer();
            tmr.Interval = 40;
            tmr.Tick += tmr_Tick;
            tmr.Start();

            // ⏱️ Timer 2: Secondary orbit (very slow - 400ms)
            Timer tmr2 = new Timer();
            tmr2.Interval = 400;
            tmr2.Tick += tmr2_Tick;
            tmr2.Start();

            // ⏱️ Timer 3: Tertiary orbit (medium - 100ms)
            Timer tmr3 = new Timer();
            tmr3.Interval = 100;
            tmr3.Tick += tmr3_Tick;
            tmr3.Start();

            // ⏱️ Timer 4: Quaternary orbit (fastest - 15ms)
            Timer tmr4 = new Timer();
            tmr4.Interval = 15;
            tmr4.Tick += tmr4_Tick;
            tmr4.Start();
        }

       
        // 🔄 TIMER TICK EVENTS - Update positions
        // ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨

        // 🌟 PRIMARY ORBIT: Brown circle (slow rotation)
        void tmr_Tick(object sender, EventArgs e)
        {
            fi += 0.01;
            if (fi > 2 * Math.PI) fi = 0.0;
            x = (float)(r * Math.Cos(fi) + x0);
            y = (float)(r * Math.Sin(fi) + y0);

            Invalidate(); // 🔄 Trigger repaint
        }

        // 🌟 SECONDARY ORBIT: RosyBrown circle (very slow rotation)
        void tmr2_Tick(object sender, EventArgs e)
        {
            fii += 0.001;
            if (fii > 2 * Math.PI) fii = 0.0;
            z = (float)(q * Math.Sin(fii) + w0);
            c = (float)(q * Math.Cos(fii) + e0);

            Invalidate(); // 🔄 Trigger repaint
        }

        // 🌟 TERTIARY ORBIT: Blue circle (medium rotation)
        void tmr3_Tick(object sender, EventArgs e)
        {
            fiii += 0.001;
            if (fiii > 2 * Math.PI) fii = 0.0;
            x1 = (float)(q1 * Math.Cos(fiii) + x0);
            y1 = (float)(q1 * Math.Sin(fiii) + y0);

            Invalidate(); // 🔄 Trigger repaint
        }

        // 🌟 QUATERNARY ORBIT: Gray moon (fastest rotation)
        void tmr4_Tick(object sender, EventArgs e)
        {
            fiiii += 0.01;
            if (fiiii > 2 * Math.PI) fii = 0.0;
            x2 = (float)(q2 * Math.Cos(fiiii) + x1);
            y2 = (float)(q2 * Math.Sin(fiiii) + y1);

            Invalidate(); // 🔄 Trigger repaint
        }

        
        // 🎨 PAINT EVENT - Render all orbiting objects
        // ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 🟤 Orbit 1: Brown planet (size 30x30)
            e.Graphics.FillEllipse(Brushes.Brown, x, y, 30, 30);

            // 🟠 Orbit 2: RosyBrown planet (size 60x60)
            e.Graphics.FillEllipse(Brushes.RosyBrown, z, c, 60, 60);

            // 🔵 Orbit 3: Blue planet (size 45x45)
            e.Graphics.FillEllipse(Brushes.Blue, x1, y1, 45, 45);

            // ⚪ Orbit 4: Gray moon (size 10x10)
            e.Graphics.FillEllipse(Brushes.Gray, x2, y2, 10, 10);

            // 🌟 Central Sun: Yellow star (size 100x100)
            e.Graphics.FillEllipse(Brushes.Yellow, 400, 300, 100, 100);
        }


        // ⏱️ DEFAULT TIMER (unused)
        // ✨⊱✥━━━━━━━━━━━━━━━━━━━━━━━━━ ❧ ☙ ━━━━━━━━━━━━━━━━━━━━━━━━━✥⊰✨

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 🔲 Placeholder timer - not used
        }
    }
}
