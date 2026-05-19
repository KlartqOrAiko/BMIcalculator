using System;
using System.Drawing;
using System.Windows.Forms;

class BMICalculator : Form
{
    // ── Controls ──────────────────────────────────────────────
    // O '= null!' diz ao compilador: "Eu sei que começa nulo, mas confia em mim, vou inicializar já já."
    private Label lblTitle = null!, lblHeight = null!, lblWeight = null!, lblResult = null!, lblCategory = null!, lblInfo = null!;
    private TextBox txtHeight = null!, txtWeight = null!;
    private Button btnCalculate = null!, btnClear = null!;
    private Panel panelResult = null!;

    public BMICalculator()
    {
        InitializeUI();
    }

    void InitializeUI()
    {
        // ── Form ──────────────────────────────────────────────
        this.Text            = "BMI Calculator";
        this.Size            = new Size(400, 520);
        this.StartPosition   = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox     = false;
        this.BackColor       = Color.FromArgb(18, 18, 28);
        this.Font            = new Font("Segoe UI", 10f);

        // ── Title ─────────────────────────────────────────────
        lblTitle = new Label
        {
            Text      = "BMI CALCULATOR",
            ForeColor = Color.FromArgb(100, 200, 255),
            Font      = new Font("Segoe UI", 16f, FontStyle.Bold),
            AutoSize  = false,
            Size      = new Size(360, 40),
            Location  = new Point(20, 20),
            TextAlign = ContentAlignment.MiddleCenter
        };

        // ── Height ────────────────────────────────────────────
        lblHeight = new Label
        {
            Text      = "Height (cm)",
            ForeColor = Color.FromArgb(180, 180, 200),
            AutoSize  = true,
            Location  = new Point(20, 80)
        };

        txtHeight = new TextBox
        {
            Location  = new Point(20, 105),
            Size      = new Size(340, 30),
            BackColor = Color.FromArgb(30, 30, 45),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font      = new Font("Segoe UI", 11f)
        };

        // ── Weight ────────────────────────────────────────────
        lblWeight = new Label
        {
            Text      = "Weight (kg)",
            ForeColor = Color.FromArgb(180, 180, 200),
            AutoSize  = true,
            Location  = new Point(20, 150)
        };

        txtWeight = new TextBox
        {
            Location  = new Point(20, 175),
            Size      = new Size(340, 30),
            BackColor = Color.FromArgb(30, 30, 45),
            ForeColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Font      = new Font("Segoe UI", 11f)
        };

        // ── Calculate Button ──────────────────────────────────
        btnCalculate = new Button
        {
            Text      = "CALCULATE",
            Location  = new Point(20, 225),
            Size      = new Size(220, 40),
            BackColor = Color.FromArgb(100, 200, 255),
            ForeColor = Color.FromArgb(18, 18, 28),
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
            Cursor    = Cursors.Hand
        };
        btnCalculate.FlatAppearance.BorderSize = 0;
        btnCalculate.Click += BtnCalculate_Click;

        // ── Clear Button ──────────────────────────────────────
        btnClear = new Button
        {
            Text      = "CLEAR",
            Location  = new Point(250, 225),
            Size      = new Size(110, 40),
            BackColor = Color.FromArgb(50, 50, 70),
            ForeColor = Color.FromArgb(180, 180, 200),
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
            Cursor    = Cursors.Hand
        };
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.Click += BtnClear_Click;

        // ── Result Panel ──────────────────────────────────────
        panelResult = new Panel
        {
            Location  = new Point(20, 285),
            Size      = new Size(340, 160),
            BackColor = Color.FromArgb(25, 25, 40),
            Visible   = false
        };

        lblResult = new Label
        {
            Text      = "",
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 28f, FontStyle.Bold),
            AutoSize  = false,
            Size      = new Size(340, 60),
            Location  = new Point(0, 15),
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblCategory = new Label
        {
            Text      = "",
            ForeColor = Color.White,
            Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
            AutoSize  = false,
            Size      = new Size(340, 30),
            Location  = new Point(0, 75),
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblInfo = new Label
        {
            Text      = "",
            ForeColor = Color.FromArgb(150, 150, 170),
            Font      = new Font("Segoe UI", 9f),
            AutoSize  = false,
            Size      = new Size(320, 30),
            Location  = new Point(10, 115),
            TextAlign = ContentAlignment.MiddleCenter
        };

        panelResult.Controls.AddRange(new Control[] { lblResult, lblCategory, lblInfo });

        // ── Add all controls to form ───────────────────────────
        this.Controls.AddRange(new Control[]
        {
            lblTitle, lblHeight, txtHeight,
            lblWeight, txtWeight,
            btnCalculate, btnClear,
            panelResult
        });
    }

    // Adicionado 'object? sender' para aceitar nulo conforme o padrão do C# atual
    void BtnCalculate_Click(object? sender, EventArgs e)
    {
        if (!double.TryParse(txtHeight.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double height) || height <= 0)
        {
            MessageBox.Show("Please enter a valid height.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!double.TryParse(txtWeight.Text.Replace(",", "."), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double weight) || weight <= 0)
        {
            MessageBox.Show("Please enter a valid weight.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        double heightInMeters = height / 100.0;
        double bmi = weight / (heightInMeters * heightInMeters);

        string category, info;
        Color  color;

        if (bmi < 18.5)
        {
            category = "Underweight";
            info     = "Consider consulting a nutritionist.";
            color    = Color.FromArgb(100, 180, 255);
        }
        else if (bmi < 25.0)
        {
            category = "Normal weight";
            info     = "Great! Keep up your healthy habits.";
            color    = Color.FromArgb(100, 220, 130);
        }
        else if (bmi < 30.0)
        {
            category = "Overweight";
            info     = "A balanced diet and exercise can help.";
            color    = Color.FromArgb(255, 200, 80);
        }
        else
        {
            category = "Obese";
            info     = "Please consult a healthcare professional.";
            color    = Color.FromArgb(255, 100, 100);
        }

        lblResult.Text        = bmi.ToString("F1");
        lblCategory.Text      = category;
        lblCategory.ForeColor = color;
        lblInfo.Text          = info;
        panelResult.Visible   = true;
    }

    // Adicionado 'object? sender' aqui também
    void BtnClear_Click(object? sender, EventArgs e)
    {
        txtHeight.Clear();
        txtWeight.Clear();
        panelResult.Visible = false;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new BMICalculator());
    }
}