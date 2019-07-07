using System.Drawing;
namespace AdvancedScada.Controls.HslControls.Keypad
{
    public delegate void ButtonClickEventHandler(object sender, KeypadEventArgs e);

    public interface IKeyboard
    {
        // Events
        event ButtonClickEventHandler ButtonClick;

        // Properties
        Font Font { get; set; }
        Color ForeColor { get; set; }
        Point Location { get; set; }
        object StartPosition { get; set; }
        string Text { get; set; }
        bool TopMost { get; set; }
        string Value { get; set; }
        bool Visible { get; set; }

    }





}