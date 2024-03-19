using Notes.Models;

namespace Notes.Desktop.Views;

internal partial class NoteDetails : Form {
    private readonly Note _note;

    public NoteDetails(Note note) {
        _note = note;
        InitializeComponent();
    }

    private void NoteDetails_Load(object sender, EventArgs e) {
        Title.Text = _note.Title;
        Description.Text = string.IsNullOrEmpty(_note.Description) ? "Отсутствует" : _note.Description;
    }
}