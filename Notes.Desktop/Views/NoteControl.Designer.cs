using System.ComponentModel;

namespace Notes.Desktop.Views;

internal partial class NoteControl {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        NoteListBox = new ListBox();
        labelForNoteListBox = new Label();
        CreateNoteBtn = new Button();
        DescriptionBox = new RichTextBox();
        RemoveNoteBtn = new Button();
        TitleTextBox = new TextBox();
        notesTabControl = new TabControl();
        tabPage1 = new TabPage();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        labelForDescription = new Label();
        labelForTitle = new Label();
        tabPage2 = new TabPage();
        labelForSq = new Label();
        SearchQueryTextBox = new TextBox();
        notesTabControl.SuspendLayout();
        tabPage1.SuspendLayout();
        statusStrip1.SuspendLayout();
        tabPage2.SuspendLayout();
        SuspendLayout();
        // 
        // NoteListBox
        // 
        NoteListBox.DisplayMember = "Title";
        NoteListBox.FormattingEnabled = true;
        NoteListBox.Location = new Point(3, 29);
        NoteListBox.Name = "NoteListBox";
        NoteListBox.Size = new Size(917, 244);
        NoteListBox.TabIndex = 0;
        NoteListBox.DoubleClick += NoteListBox_DoubleClick;
        NoteListBox.KeyDown += NoteListBox_KeyDown;
        // 
        // labelForNoteListBox
        // 
        labelForNoteListBox.AutoSize = true;
        labelForNoteListBox.Location = new Point(3, 6);
        labelForNoteListBox.Name = "labelForNoteListBox";
        labelForNoteListBox.Size = new Size(119, 20);
        labelForNoteListBox.TabIndex = 1;
        labelForNoteListBox.Text = "Список заметок";
        // 
        // CreateNoteBtn
        // 
        CreateNoteBtn.FlatStyle = FlatStyle.Flat;
        CreateNoteBtn.Location = new Point(626, 91);
        CreateNoteBtn.Name = "CreateNoteBtn";
        CreateNoteBtn.Size = new Size(190, 46);
        CreateNoteBtn.TabIndex = 2;
        CreateNoteBtn.Text = "Добавить заметку";
        CreateNoteBtn.UseVisualStyleBackColor = true;
        CreateNoteBtn.Click += CreateNoteBtn_Click;
        // 
        // DescriptionBox
        // 
        DescriptionBox.Location = new Point(197, 91);
        DescriptionBox.MaxLength = 150;
        DescriptionBox.Name = "DescriptionBox";
        DescriptionBox.Size = new Size(413, 111);
        DescriptionBox.TabIndex = 3;
        DescriptionBox.Text = "";
        // 
        // RemoveNoteBtn
        // 
        RemoveNoteBtn.FlatStyle = FlatStyle.Flat;
        RemoveNoteBtn.Location = new Point(626, 143);
        RemoveNoteBtn.Name = "RemoveNoteBtn";
        RemoveNoteBtn.Size = new Size(190, 46);
        RemoveNoteBtn.TabIndex = 4;
        RemoveNoteBtn.Text = "Удалить заметку";
        RemoveNoteBtn.UseVisualStyleBackColor = true;
        RemoveNoteBtn.Click += RemoveNoteBtn_Click;
        // 
        // TitleTextBox
        // 
        TitleTextBox.Location = new Point(197, 49);
        TitleTextBox.MaxLength = 35;
        TitleTextBox.Name = "TitleTextBox";
        TitleTextBox.Size = new Size(413, 27);
        TitleTextBox.TabIndex = 5;
        // 
        // notesTabControl
        // 
        notesTabControl.Controls.Add(tabPage1);
        notesTabControl.Controls.Add(tabPage2);
        notesTabControl.Location = new Point(3, 279);
        notesTabControl.Name = "notesTabControl";
        notesTabControl.SelectedIndex = 0;
        notesTabControl.Size = new Size(917, 289);
        notesTabControl.TabIndex = 6;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(statusStrip1);
        tabPage1.Controls.Add(labelForDescription);
        tabPage1.Controls.Add(labelForTitle);
        tabPage1.Controls.Add(TitleTextBox);
        tabPage1.Controls.Add(CreateNoteBtn);
        tabPage1.Controls.Add(RemoveNoteBtn);
        tabPage1.Controls.Add(DescriptionBox);
        tabPage1.Location = new Point(4, 29);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(909, 256);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Основное";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
        statusStrip1.Location = new Point(3, 227);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(903, 26);
        statusStrip1.TabIndex = 9;
        statusStrip1.Text = "FactorStrip";
        // 
        // toolStripStatusLabel1
        // 
        toolStripStatusLabel1.ForeColor = Color.Red;
        toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        toolStripStatusLabel1.Size = new Size(280, 20);
        toolStripStatusLabel1.Text = "* - обязательное поле для заполнения";
        // 
        // labelForDescription
        // 
        labelForDescription.AutoSize = true;
        labelForDescription.Location = new Point(106, 130);
        labelForDescription.Name = "labelForDescription";
        labelForDescription.Size = new Size(82, 20);
        labelForDescription.TabIndex = 8;
        labelForDescription.Text = "Описание:";
        // 
        // labelForTitle
        // 
        labelForTitle.AutoSize = true;
        labelForTitle.Location = new Point(98, 52);
        labelForTitle.Name = "labelForTitle";
        labelForTitle.Size = new Size(90, 20);
        labelForTitle.TabIndex = 7;
        labelForTitle.Text = "Заголовок*:";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(labelForSq);
        tabPage2.Controls.Add(SearchQueryTextBox);
        tabPage2.Location = new Point(4, 29);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(909, 256);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Прочее";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // labelForSq
        // 
        labelForSq.AutoSize = true;
        labelForSq.Location = new Point(142, 100);
        labelForSq.Name = "labelForSq";
        labelForSq.Size = new Size(128, 20);
        labelForSq.TabIndex = 9;
        labelForSq.Text = "Запрос на поиск:";
        // 
        // SearchQueryTextBox
        // 
        SearchQueryTextBox.Location = new Point(276, 97);
        SearchQueryTextBox.MaxLength = 35;
        SearchQueryTextBox.Name = "SearchQueryTextBox";
        SearchQueryTextBox.Size = new Size(413, 27);
        SearchQueryTextBox.TabIndex = 8;
        SearchQueryTextBox.TextChanged += SearchQueryTextBox_TextChanged;
        // 
        // NoteControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(notesTabControl);
        Controls.Add(labelForNoteListBox);
        Controls.Add(NoteListBox);
        Name = "NoteControl";
        Size = new Size(934, 589);
        Load += NoteControl_Load;
        notesTabControl.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox NoteListBox;
    private Label labelForNoteListBox;
    private Button CreateNoteBtn;
    private RichTextBox DescriptionBox;
    private Button RemoveNoteBtn;
    private TextBox TitleTextBox;
    private TabControl notesTabControl;
    private TabPage tabPage1;
    private Label labelForDescription;
    private Label labelForTitle;
    private TabPage tabPage2;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private Label labelForSq;
    private TextBox SearchQueryTextBox;
}