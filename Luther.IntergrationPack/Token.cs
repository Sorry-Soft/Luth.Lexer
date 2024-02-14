using System.Drawing;

namespace Luth.IntergrationPack
{

    public class Token
    {
        public string Type { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
        public Color Color { get; set; } = Color.White;
        public bool InError { get; set; } = false;
    }
}