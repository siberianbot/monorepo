#include <Windows.h>

#include "Win32Viewport.hpp"

namespace lucidreams
{
    Win32Viewport* GetWin32Viewport(HWND hwnd)
    {
        return reinterpret_cast<Win32Viewport*>(GetWindowLongPtr(hwnd, GWLP_USERDATA));
    }

    LRESULT Win32NcCreate(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
    {
        auto *viewport = reinterpret_cast<Win32Viewport *>(reinterpret_cast<CREATESTRUCT *>(lParam)->lpCreateParams);

        SetWindowLongPtr(hwnd, GWLP_USERDATA, (LONG_PTR) viewport);
        viewport->setHandle(hwnd);
        viewport->setDeviceContext(GetDC(hwnd));

        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }

    LRESULT Win32ShowWindow(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
    {
        GetWin32Viewport(hwnd)->setVisibilityInternal(wParam == TRUE);

        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }

    LRESULT Win32Close(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
    {
        GetWin32Viewport(hwnd)->destroy();

        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }

    LRESULT CALLBACK Win32WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
    {
        switch (uMsg)
        {
            case WM_NCCREATE:
                return Win32NcCreate(hwnd, uMsg, wParam, lParam);

            case WM_SHOWWINDOW:
                return Win32ShowWindow(hwnd, uMsg, wParam, lParam);

            case WM_CLOSE:
                return Win32Close(hwnd, uMsg, wParam, lParam);

            default:
                return DefWindowProc(hwnd, uMsg, wParam, lParam);
        }
    }
}