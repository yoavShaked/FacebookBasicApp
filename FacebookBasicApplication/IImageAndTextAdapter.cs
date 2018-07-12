using System.Drawing;

namespace FacebookBasicApplication
{
    public interface IImageAndTextAdapter
    {
        Image GetImage { get; }

        string GetName { get; }
    }
}
