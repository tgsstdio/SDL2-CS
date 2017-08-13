using SDL2;
using System;

namespace VulkanTest
{
    class SDL2GameWindow : ISDL2GameWindow
    {
        private IntPtr mHandle = IntPtr.Zero;
        public IntPtr Handle
        {
            get
            {
                return mHandle;
            }
        }

        private bool mIsDisposed = false;
        public void Dispose()
        {
            if (mIsDisposed)
                return;

            if (mHandle != IntPtr.Zero)
            {
                SDL.SDL_DestroyWindow(mHandle);
            }

            mIsDisposed = true;
        }

        public void Initialise(string name, SDL.SDL_WindowFlags flags)
        {
            const int INIT_WIDTH = 640;
            const int INIT_HEIGHT = 480;

            mHandle = SDL2.SDL.SDL_CreateWindow(
               name,
               SDL.SDL_WINDOWPOS_UNDEFINED,
               SDL.SDL_WINDOWPOS_UNDEFINED,
               INIT_WIDTH,
               INIT_HEIGHT,
               flags);
        }
    }
}
