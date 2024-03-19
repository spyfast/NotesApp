using System.ComponentModel;

namespace Notes.Desktop.Views;

internal partial class NoteDetails {
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelForTitle = new Label();
        Title = new Label();
        Description = new Label();
        labelForDescription = new Label();
        SuspendLayout();
        // 
        // labelForTitle
        // 
        labelForTitle.AutoSize = true;
        labelForTitle.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelForTitle.Location = new Point(12, 22);
        labelForTitle.Name = "labelForTitle";
        labelForTitle.Size = new Size(171, 38);
        labelForTitle.TabIndex = 0;
        labelForTitle.Text = "Название: ";
        // 
        // Title
        // 
        Title.AutoSize = true;
        Title.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
        Title.Location = new Point(189, 34);
        Title.Name = "Title";
        Title.Size = new Size(47, 23);
        Title.TabIndex = 1;
        Title.Text = "TEXT";
        // 
        // Description
        // 
        Description.AutoEllipsis = true;
        Description.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
        Description.Location = new Point(21, 128);
        Description.Name = "Description";
        Description.Size = new Size(656, 173);
        Description.TabIndex = 3;
        Description.Text = "TEXT";
        // 
        // labelForDescription
        // 
        labelForDescription.AutoSize = true;
        labelForDescription.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
        labelForDescription.Location = new Point(12, 80);
        labelForDescription.Name = "labelForDescription";
        labelForDescription.Size = new Size(165, 38);
        labelForDescription.TabIndex = 2;
        labelForDescription.Text = "Описание:";
        // 
        // NoteDetails
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(689, 322);
        Controls.Add(Description);
        Controls.Add(labelForDescription);
        Controls.Add(Title);
        Controls.Add(labelForTitle);
        MaximizeBox = false;
        Name = "NoteDetails";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NoteDetails";
        Load += NoteDetails_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelForTitle;
    private Label Title;
    private Label Description;
    private Label labelForDescription;
}