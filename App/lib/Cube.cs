using App.lib.utils;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace App.lib
{
    public class Cube
    {
        public static void Draw(List<Point> points , int FACE_TO_BE_CHANGED , bool isButtonPressed , Color4 nextColor , List<Color4> randomColors )
        {
            Randomizer r = new Randomizer();
            int index = 0;

            GL.Begin(PrimitiveType.Triangles);

            for (int i = 0; i < points.Count; i += 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(randomColors.Count == 0)
                    {
                        if (i == 0 || i == 3)
                        {
                            if (isButtonPressed)
                            {
                                GL.Color4(nextColor);
                            }
                            else
                            {
                                GL.Color4(1.0f, 0.0f, 0.0f, 1.0f);
                            }
                        }
                        else
                        {
                            GL.Color4(1.0f, 0.0f, 0.0f, 1.0f);

                        }
                    } else
                    {
                        GL.Color4(randomColors[index]);

                    }

                    // Define each vertex for the triangle
                    GL.Vertex3(points[i + j].X, points[i + j].Y, points[i + j].Z);
                    index++;
                }
            }

            GL.End();
        }
    }
}
