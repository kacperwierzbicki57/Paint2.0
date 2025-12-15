

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Paint2._0
{
public class Form1 : Form
{
  private Graphics g;
  private bool start = false;
  private int? initX = new int?();
  private int? initY = new int?();
  private bool r_kwadrat = false;
  private bool r_prostokat = false;
  private bool r_kolo = false;
  private bool gumka = false;
  private bool r_pedzel = true;
  private bool r_text = false;
  private IContainer components = (IContainer) null;
  private TextBox txt_ShapeSize;
  private Button btn_kwadrat;
  private Button btn_prostokat;
  private Button btn_kolo;
  private ColorDialog colorDialog1;
  private SaveFileDialog saveFileDialog1;
  private ErrorProvider errorProvider1;
  private MenuStrip menuStrip1;
  private ToolStripMenuItem exitToolStripMenuItem;
  private OpenFileDialog openFileDialog1;
  private Button btn_PenColor;
  private ComboBox cmb_PenSize;
  private Panel pnl_Draw;
  private Label label2;
  private SaveFileDialog saveFileDialog2;
  private Panel panel1;
  private Button btn_pedzel;
  private Button btn_gumka;
  private Label label5;
  private Label label4;
  private Label label3;
  private Button btn_tekst;
  private TextBox txt_tekst;
  private Button btn_font;
  private FontDialog fontDialog1;

  public Form1()
  {
    this.InitializeComponent();
    this.g = this.pnl_Draw.CreateGraphics();
  }

  private void btn_Square_Click(object sender, EventArgs e)
  {
    this.r_kwadrat = true;
    this.r_prostokat = false;
    this.r_kolo = false;
    this.r_text = false;
    this.gumka = false;
  }

  private void btn_Rectangle_Click(object sender, EventArgs e)
  {
    this.r_kwadrat = false;
    this.r_prostokat = true;
    this.r_kolo = false;
    this.r_text = false;
    this.gumka = false;
  }

  private void btn_Circle_Click(object sender, EventArgs e)
  {
    this.r_kwadrat = false;
    this.r_prostokat = false;
    this.r_kolo = true;
    this.r_text = false;
    this.gumka = false;
  }

  private void btn_gumka_Click(object sender, EventArgs e)
  {
    this.r_prostokat = false;
    this.r_kolo = false;
    this.r_kwadrat = false;
    this.r_pedzel = false;
    this.gumka = true;
    this.r_text = false;
  }

  private void btn_pedzel_Click(object sender, EventArgs e)
  {
    this.gumka = false;
    this.r_pedzel = true;
    this.r_prostokat = false;
    this.r_kolo = false;
    this.r_kwadrat = false;
    this.r_text = false;
  }

  private void button1_Click(object sender, EventArgs e)
  {
    this.r_text = true;
    this.gumka = false;
    this.r_pedzel = false;
    this.r_prostokat = false;
    this.r_kolo = false;
    this.r_kwadrat = false;
  }

  private void exitToolStripMenuItem_Click(object sender, EventArgs e)
  {
    if (MessageBox.Show("Czy chcesz zakończyć program?", "Wyjście", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
      return;
    Application.Exit();
  }

  private void btn_PenColor_Click(object sender, EventArgs e)
  {
    ColorDialog colorDialog = new ColorDialog();
    colorDialog.Color = this.btn_PenColor.BackColor;
    if (colorDialog.ShowDialog() != DialogResult.OK)
      return;
    this.btn_PenColor.BackColor = colorDialog.Color;
  }

  private void pnl_Draw_MouseDown_1(object sender, MouseEventArgs e)
  {
    this.start = true;
    if (this.r_kwadrat)
    {
      this.g.FillRectangle((Brush) new SolidBrush(this.btn_PenColor.BackColor), e.X, e.Y, int.Parse(this.txt_ShapeSize.Text), int.Parse(this.txt_ShapeSize.Text));
      this.start = false;
    }
    if (this.r_prostokat)
    {
      this.g.FillRectangle((Brush) new SolidBrush(this.btn_PenColor.BackColor), e.X, e.Y, 2 * int.Parse(this.txt_ShapeSize.Text), int.Parse(this.txt_ShapeSize.Text));
      this.start = false;
    }
    if (this.r_kolo)
    {
      this.g.FillEllipse((Brush) new SolidBrush(this.btn_PenColor.BackColor), e.X, e.Y, int.Parse(this.txt_ShapeSize.Text), int.Parse(this.txt_ShapeSize.Text));
      this.start = false;
    }
    if (!this.r_text)
      return;
    this.g.DrawString(this.txt_tekst.Text, this.txt_tekst.Font, (Brush) new SolidBrush(this.btn_PenColor.BackColor), (PointF) new Point(e.X, e.Y));
  }

  private void pnl_Draw_MouseMove_1(object sender, MouseEventArgs e)
  {
    if (!this.start)
      return;
    int? nullable;
    if (this.gumka)
    {
      Pen pen1 = new Pen(this.btn_gumka.BackColor, float.Parse(this.cmb_PenSize.Text));
      Graphics g = this.g;
      Pen pen2 = pen1;
      nullable = this.initX;
      int x = nullable ?? e.X;
      nullable = this.initY;
      int y = nullable ?? e.Y;
      Point pt1 = new Point(x, y);
      Point pt2 = new Point(e.X, e.Y);
      g.DrawLine(pen2, pt1, pt2);
      this.initX = new int?(e.X);
      this.initY = new int?(e.Y);
    }
    if (this.r_pedzel)
    {
      this.gumka = false;
      Pen pen3 = new Pen(this.btn_PenColor.BackColor, float.Parse(this.cmb_PenSize.Text));
      Graphics g = this.g;
      Pen pen4 = pen3;
      nullable = this.initX;
      int x = nullable ?? e.X;
      nullable = this.initY;
      int y = nullable ?? e.Y;
      Point pt1 = new Point(x, y);
      Point pt2 = new Point(e.X, e.Y);
      g.DrawLine(pen4, pt1, pt2);
      this.initX = new int?(e.X);
      this.initY = new int?(e.Y);
    }
  }

  private void pnl_Draw_MouseUp_1(object sender, MouseEventArgs e)
  {
    this.start = false;
    this.initX = new int?();
    this.initY = new int?();
  }

  private void pnl_Draw_Paint(object sender, PaintEventArgs e)
  {
  }

  private void button1_Click_1(object sender, EventArgs e)
  {
    FontDialog fontDialog = new FontDialog();
    if (fontDialog.ShowDialog() != DialogResult.OK)
      return;
    this.txt_tekst.Font = fontDialog.Font;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    this.txt_ShapeSize = new TextBox();
    this.btn_kwadrat = new Button();
    this.btn_prostokat = new Button();
    this.btn_kolo = new Button();
    this.colorDialog1 = new ColorDialog();
    this.saveFileDialog1 = new SaveFileDialog();
    this.errorProvider1 = new ErrorProvider(this.components);
    this.openFileDialog1 = new OpenFileDialog();
    this.menuStrip1 = new MenuStrip();
    this.exitToolStripMenuItem = new ToolStripMenuItem();
    this.btn_PenColor = new Button();
    this.cmb_PenSize = new ComboBox();
    this.pnl_Draw = new Panel();
    this.label2 = new Label();
    this.saveFileDialog2 = new SaveFileDialog();
    this.panel1 = new Panel();
    this.btn_tekst = new Button();
    this.label5 = new Label();
    this.label4 = new Label();
    this.label3 = new Label();
    this.btn_pedzel = new Button();
    this.btn_gumka = new Button();
    this.txt_tekst = new TextBox();
    this.fontDialog1 = new FontDialog();
    this.btn_font = new Button();
    ((ISupportInitialize) this.errorProvider1).BeginInit();
    this.menuStrip1.SuspendLayout();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.txt_ShapeSize.Location = new Point(3, 58);
    this.txt_ShapeSize.Margin = new Padding(0);
    this.txt_ShapeSize.Name = "txt_ShapeSize";
    this.txt_ShapeSize.Size = new Size(88, 20);
    this.txt_ShapeSize.TabIndex = 0;
    this.txt_ShapeSize.Text = "50";
    this.btn_kwadrat.Location = new Point(3, 146);
    this.btn_kwadrat.Name = "btn_kwadrat";
    this.btn_kwadrat.Size = new Size(75, 25);
    this.btn_kwadrat.TabIndex = 2;
    this.btn_kwadrat.Text = "Kwadrat";
    this.btn_kwadrat.UseVisualStyleBackColor = true;
    this.btn_kwadrat.Click += new EventHandler(this.btn_Square_Click);
    this.btn_prostokat.Location = new Point(3, 177);
    this.btn_prostokat.Name = "btn_prostokat";
    this.btn_prostokat.Size = new Size(75, 23);
    this.btn_prostokat.TabIndex = 3;
    this.btn_prostokat.Text = "Prostokąt";
    this.btn_prostokat.UseVisualStyleBackColor = true;
    this.btn_prostokat.Click += new EventHandler(this.btn_Rectangle_Click);
    this.btn_kolo.Location = new Point(3, 206);
    this.btn_kolo.Name = "btn_kolo";
    this.btn_kolo.Size = new Size(75, 26);
    this.btn_kolo.TabIndex = 4;
    this.btn_kolo.Text = "Koło";
    this.btn_kolo.UseVisualStyleBackColor = true;
    this.btn_kolo.Click += new EventHandler(this.btn_Circle_Click);
    this.errorProvider1.ContainerControl = (ContainerControl) this;
    this.openFileDialog1.FileName = "openFileDialog1";
    this.menuStrip1.Items.AddRange(new ToolStripItem[1]
    {
      (ToolStripItem) this.exitToolStripMenuItem
    });
    this.menuStrip1.Location = new Point(0, 0);
    this.menuStrip1.Name = "menuStrip1";
    this.menuStrip1.Size = new Size(837, 24);
    this.menuStrip1.TabIndex = 5;
    this.menuStrip1.Text = "menuStrip1";
    this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
    this.exitToolStripMenuItem.Size = new Size(63 /*0x3F*/, 20);
    this.exitToolStripMenuItem.Text = "Zakończ";
    this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
    this.btn_PenColor.BackColor = Color.Black;
    this.btn_PenColor.Location = new Point(3, 405);
    this.btn_PenColor.Name = "btn_PenColor";
    this.btn_PenColor.Size = new Size(42, 39);
    this.btn_PenColor.TabIndex = 6;
    this.btn_PenColor.UseVisualStyleBackColor = false;
    this.btn_PenColor.Click += new EventHandler(this.btn_PenColor_Click);
    this.cmb_PenSize.FormattingEnabled = true;
    this.cmb_PenSize.Items.AddRange(new object[15]
    {
      (object) "1",
      (object) "2",
      (object) "3",
      (object) "4",
      (object) "5",
      (object) "6",
      (object) "7",
      (object) "8",
      (object) "9",
      (object) "10",
      (object) "12",
      (object) "14",
      (object) "16",
      (object) "18",
      (object) "20"
    });
    this.cmb_PenSize.Location = new Point(3, 19);
    this.cmb_PenSize.Name = "cmb_PenSize";
    this.cmb_PenSize.Size = new Size(83, 21);
    this.cmb_PenSize.TabIndex = 7;
    this.cmb_PenSize.Text = "1";
    this.pnl_Draw.BackColor = Color.White;
    this.pnl_Draw.BorderStyle = BorderStyle.FixedSingle;
    this.pnl_Draw.Location = new Point(138, 27);
    this.pnl_Draw.Name = "pnl_Draw";
    this.pnl_Draw.Size = new Size(664, 441);
    this.pnl_Draw.TabIndex = 8;
    this.pnl_Draw.MouseDown += new MouseEventHandler(this.pnl_Draw_MouseDown_1);
    this.pnl_Draw.MouseMove += new MouseEventHandler(this.pnl_Draw_MouseMove_1);
    this.pnl_Draw.MouseUp += new MouseEventHandler(this.pnl_Draw_MouseUp_1);
    this.label2.AutoSize = true;
    this.label2.Location = new Point(3, 390);
    this.label2.Name = "label2";
    this.label2.Size = new Size(31 /*0x1F*/, 13);
    this.label2.TabIndex = 0;
    this.label2.Text = "Kolor";
    this.panel1.BackColor = Color.Silver;
    this.panel1.Controls.Add((Control) this.btn_font);
    this.panel1.Controls.Add((Control) this.txt_tekst);
    this.panel1.Controls.Add((Control) this.btn_tekst);
    this.panel1.Controls.Add((Control) this.label5);
    this.panel1.Controls.Add((Control) this.label4);
    this.panel1.Controls.Add((Control) this.btn_kolo);
    this.panel1.Controls.Add((Control) this.label3);
    this.panel1.Controls.Add((Control) this.btn_prostokat);
    this.panel1.Controls.Add((Control) this.btn_pedzel);
    this.panel1.Controls.Add((Control) this.btn_kwadrat);
    this.panel1.Controls.Add((Control) this.btn_gumka);
    this.panel1.Controls.Add((Control) this.cmb_PenSize);
    this.panel1.Controls.Add((Control) this.btn_PenColor);
    this.panel1.Controls.Add((Control) this.txt_ShapeSize);
    this.panel1.Controls.Add((Control) this.label2);
    this.panel1.Dock = DockStyle.Left;
    this.panel1.Location = new Point(0, 24);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(118, 454);
    this.panel1.TabIndex = 9;
    this.btn_tekst.Location = new Point(3, 238);
    this.btn_tekst.Name = "btn_tekst";
    this.btn_tekst.Size = new Size(75, 23);
    this.btn_tekst.TabIndex = 0;
    this.btn_tekst.Text = "Tekst";
    this.btn_tekst.UseVisualStyleBackColor = true;
    this.btn_tekst.Click += new EventHandler(this.button1_Click);
    this.label5.AutoSize = true;
    this.label5.Location = new Point(51, 390);
    this.label5.Name = "label5";
    this.label5.Size = new Size(41, 13);
    this.label5.TabIndex = 10;
    this.label5.Text = "Gumka";
    this.label4.AutoSize = true;
    this.label4.BackColor = Color.White;
    this.label4.BorderStyle = BorderStyle.FixedSingle;
    this.label4.Location = new Point(3, 43);
    this.label4.Name = "label4";
    this.label4.Size = new Size(88, 15);
    this.label4.TabIndex = 12;
    this.label4.Text = "Rozmiar kształtu";
    this.label3.AutoSize = true;
    this.label3.BackColor = Color.White;
    this.label3.BorderStyle = BorderStyle.FixedSingle;
    this.label3.Location = new Point(3, 8);
    this.label3.Name = "label3";
    this.label3.Size = new Size(83, 15);
    this.label3.TabIndex = 10;
    this.label3.Text = "Grubość pędzla";
    this.btn_pedzel.Location = new Point(3, 117);
    this.btn_pedzel.Name = "btn_pedzel";
    this.btn_pedzel.Size = new Size(75, 23);
    this.btn_pedzel.TabIndex = 10;
    this.btn_pedzel.Text = "Pędzel";
    this.btn_pedzel.UseVisualStyleBackColor = true;
    this.btn_pedzel.Click += new EventHandler(this.btn_pedzel_Click);
    this.btn_gumka.BackColor = Color.White;
    this.btn_gumka.Location = new Point(51, 406);
    this.btn_gumka.Name = "btn_gumka";
    this.btn_gumka.Size = new Size(55, 36);
    this.btn_gumka.TabIndex = 11;
    this.btn_gumka.UseVisualStyleBackColor = false;
    this.btn_gumka.Click += new EventHandler(this.btn_gumka_Click);
    this.txt_tekst.Location = new Point(0, 308);
    this.txt_tekst.Multiline = true;
    this.txt_tekst.Name = "txt_tekst";
    this.txt_tekst.Size = new Size(100, 50);
    this.txt_tekst.TabIndex = 0;
    this.txt_tekst.Text = "Tu wpisz swój tekst";
    this.btn_font.Location = new Point(0, 355);
    this.btn_font.Name = "btn_font";
    this.btn_font.Size = new Size(72, 23);
    this.btn_font.TabIndex = 0;
    this.btn_font.Text = "Font";
    this.btn_font.UseVisualStyleBackColor = true;
    this.btn_font.Click += new EventHandler(this.button1_Click_1);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(837, 478);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.pnl_Draw);
    this.Controls.Add((Control) this.menuStrip1);
    this.MainMenuStrip = this.menuStrip1;
    this.Name = "Form1";
    this.Text = "Form1";
    ((ISupportInitialize) this.errorProvider1).EndInit();
    this.menuStrip1.ResumeLayout(false);
    this.menuStrip1.PerformLayout();
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
}