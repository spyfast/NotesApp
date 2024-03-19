namespace Notes.Desktop;

internal partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        NoteControl = new Views.NoteControl();
        SuspendLayout();
        // 
        // NoteControl
        // 
        NoteControl.Location = new Point(6, 8);
        NoteControl.Name = "NoteControl";
        NoteControl.Size = new Size(933, 575);
        NoteControl.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(944, 583);
        Controls.Add(NoteControl);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Note UI";
        ResumeLayout(false);
    }

    #endregion

    private Views.NoteControl NoteControl;
}