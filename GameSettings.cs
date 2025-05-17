using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public static class GameSettings
    {
        public static float Volume { get; set; } = 0.8f;
        public static Color BackgroundColor { get; set; } = Color.AliceBlue;

        public static void ApplySettingsTo(Form form)
        {
            form.BackColor = BackgroundColor;
        }
    }
}
