using Magnesium;
using System;
using System.Diagnostics;

namespace VulkanTest
{
    public class SDL2PresentationSurface : IMgPresentationSurface
    {
        private IMgSurfaceKHR mSurface;
        public IMgSurfaceKHR Surface
        {
            get
            {
                return mSurface;
            }
        }

        private readonly MgDriverContext mDriverContext;
        private ISDL2GameWindow mWindow;
        public SDL2PresentationSurface(MgDriverContext context, ISDL2GameWindow window)
        {
            mDriverContext = context;
            mWindow = window;
        }

        private bool mIsDisposed = false;
        public void Dispose()
        {
            if (mIsDisposed)
                return;

            if (mSurface != null)
            {
                mSurface.DestroySurfaceKHR(mDriverContext.Instance, null);
            }

            mIsDisposed = true;
        }

        public void Initialize(uint width, uint height)
        {
            var info = new SDL2.SDL.SDL_SysWMinfo();
            if (SDL2.SDL.SDL_GetWindowWMInfo(mWindow.Handle, ref info) != SDL2.SDL.SDL_bool.SDL_TRUE)
            {
                throw new InvalidOperationException("SDL_GetWindowWMInfo error");
            }

            var createInfo = new MgWin32SurfaceCreateInfoKHR
            {
                // DOUBLE CHECK 
                Hinstance = Process.GetCurrentProcess().Handle,
                Hwnd = info.info.win.window,
            };
            var err = mDriverContext.Instance.CreateWin32SurfaceKHR(createInfo, null, out mSurface);
            Debug.Assert(err == Result.SUCCESS);
        }
    }
}
