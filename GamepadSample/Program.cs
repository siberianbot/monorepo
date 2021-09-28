using System;
using System.Linq;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace GamepadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using IWindow window = Window.Create(new WindowOptions
            {
                API = GraphicsAPI.Default,
                Title = "gamepad sample",
                Size = new Vector2D<int>(400, 400)
            });

            window.Initialize();

            using IInputContext inputs = window.CreateInput();

            IGamepad gamepad;
            do
            {
                gamepad = inputs.Gamepads.FirstOrDefault();
            } while (gamepad == null);

            Console.WriteLine($"Connected gamepad {gamepad.Index}");

            Thumbstick rightThumbstick = gamepad.Thumbsticks.Last();
            
            gamepad.ThumbstickMoved += (_, thumbstick) =>
            {
                if (thumbstick.Index == rightThumbstick.Index)
                {
                    // Console.WriteLine("Triggered thumbstick");
                    
                    foreach (IMotor motor in gamepad.VibrationMotors)
                    {
                        motor.Speed = thumbstick.Position / (float)Math.PI;
                    }
                }
            };

            while (!window.IsClosing)
            {
                window.DoUpdate();
                window.DoEvents();
            }
        }
    }
}