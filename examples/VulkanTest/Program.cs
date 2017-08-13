using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulkanTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SDL2.SDL.SDL_Init(SDL2.SDL.SDL_INIT_VIDEO) != 0)
            {
                Console.WriteLine("SDL_Init error");
            }

            var window = SDL2.SDL.SDL_CreateWindow(
                "SDL Vulkan Sample", SDL2.SDL.SDL_WINDOWPOS_UNDEFINED, SDL2.SDL.SDL_WINDOWPOS_UNDEFINED, 640, 480,
               SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
            if (window == IntPtr.Zero)
            {
                Console.WriteLine("SDL_CreateWindow error");
                SDL2.SDL.SDL_Quit();
            }
            else
            {
                Console.WriteLine("Hello World");

                var info = new SDL2.SDL.SDL_SysWMinfo();
                if (SDL2.SDL.SDL_GetWindowWMInfo(window, ref info) == SDL2.SDL.SDL_bool.SDL_TRUE)
                {
                    Console.WriteLine(info.info.win.window);
                    Console.WriteLine(info.info.win.hdc);
                    Console.WriteLine(info.info.win.hinstance);
                }

                bool quit = false;
                while (!quit)
                {
                    SDL2.SDL.SDL_Event ev;
                    while (SDL2.SDL.SDL_PollEvent(out ev) != 0)
                    {
                        if (ev.type == SDL2.SDL.SDL_EventType.SDL_QUIT)
                        {
                            quit = true;
                        }
                    }
                }
                SDL2.SDL.SDL_DestroyWindow(window);
                SDL2.SDL.SDL_Quit();
            }
        }
    }
}
