using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace App.lib
{
    public class Axis
    {

        private const int AXIS_LENGTH = 75;

        public static void Draw()
        {
            GL.LineWidth(3.0f);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(AXIS_LENGTH, 0, 0);
            GL.Color3(Color.ForestGreen);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, AXIS_LENGTH, 0);
            GL.Color3(Color.RoyalBlue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, AXIS_LENGTH);
            GL.End();

            GL.LineWidth(1.0f);
        }
    }
}
