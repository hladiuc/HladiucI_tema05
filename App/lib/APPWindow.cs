using App.lib.utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace App.lib
{
    public class APPWindow : GameWindow
    {
        Randomizer randomizer;

        List<Point> points;
        private KeyboardState oldKeyboard;
        private MouseState oldMouse;

        private float angleHorizontal = 0f;
        private float angleVertical = 0f;
        private float speed = 25f; 


        private Color BACKGROUND = Color.GhostWhite;
        private int FACE_TO_BE_CHANGED = 0;
        private bool isButtonPressed = false;
        List<Color4> randomColors = new List<Color4>();
        private Color4 nextColor;

        /// <summary>
        /// Parametrised constructor. Invokes the anti-aliasing engine. All inits are placed here, for convenience.
        /// </summary>
        public APPWindow() : base(1280, 768, new GraphicsMode(32, 24, 0, 8)) 
        {
            VSync = VSyncMode.On;

            randomizer = new Randomizer();
        }

        /// <summary>
        /// OnLoad() method. Part of the control loop of the OpenTK API. Executed only once.
        /// </summary>
        /// <param name="e">event parameters that triggered the method;</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            points = LoadCoordinates.Get();

            DisplayHelp();
        }

        /// <summary>
        /// OnResize() method. Part of the control loop of the OpenTK API. Executed at least once (after OnLoad()).
        /// </summary>
        /// <param name="e">event parameters that triggered the method;</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // set background
            GL.ClearColor(BACKGROUND);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // set the eye
            Matrix4 camera = Matrix4.LookAt(120, 120, 120, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        /// <summary>
        /// OnUpdateFrame() method. Part of the control loop of the OpenTK API. Executed periodically, with a frequency determined when launching
        /// the graphics window(<see cref = "GameWindow.Run(double,double)" />). In this case should be 30.00 (if unmodified).
        /// 
        /// All logic should reside here!
        /// </summary>
        /// <param name="e">event parameters that triggered the method;</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }

            if (keyboard[Key.H] && !oldKeyboard[Key.H])
            {
                DisplayHelp();
            }

            if (keyboard[Key.R] && !oldKeyboard[Key.R])
            {
                isButtonPressed = !isButtonPressed;
                nextColor = randomizer.RandomColor();
            }

            if(keyboard[Key.X] && !oldKeyboard[Key.X])
            {
                if( randomColors.Count == 0 )
                {
                    Randomizer x = new Randomizer();
                    foreach ( var _ in points )
                    {
                        Color4 newColor = x.RandomColor();
                        randomColors.Add(newColor);
                        Console.WriteLine( newColor );
                    }
                } else
                {
                    randomColors.Clear();
                }
            }


            if (mouse[MouseButton.Left])
            {
                angleHorizontal += 180f / 3 * (float)e.Time;
            }

            if (mouse[MouseButton.Right])
            {
                angleVertical += 180f / 3 * (float)e.Time;
            }

            oldKeyboard = keyboard;
            oldMouse = mouse;
        }

        /// <summary>
        /// OnRenderFrame() method. Part of the control loop of the OpenTK API. Executed periodically, with a frequency determined when launching
        /// the graphics window (<see cref="GameWindow.Run(double,double)"/>). In this case should be 0.00 (if unmodified) - the renderinh is triggered
        /// only when the scene is modified.
        /// 
        /// All render calls should reside here!
        /// </summary>
        /// <param name="e">event parameters that triggered the method;</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();

            GL.Rotate(angleHorizontal, 0.0f, 1.0f, 0.0f);
            GL.Rotate(angleVertical, 0.0f, 0.0f, 1.0f);

            Axis.Draw();
            Cube.Draw( points , FACE_TO_BE_CHANGED , isButtonPressed , nextColor , randomColors);

            GL.PopMatrix();

            GL.Flush();

            SwapBuffers();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("Meniu");
            Console.WriteLine("H. Help");
            Console.WriteLine("R. Schimba background latura");
            Console.WriteLine("X. Manipuleaza RGB pentru toate vertexurile");
            Console.WriteLine("ESC. Exit");
        }


    }
}
