using SDL2;
using System;

namespace VulkanTest
{
    public interface ISDL2GameWindow : IDisposable
    {
        IntPtr Handle { get; }
        void Initialise(string name, SDL.SDL_WindowFlags flags);
    }
}