#include "Win32ViewportManager.hpp"

#include <Windows.h>

#include "../../Engine/Engine.hpp"
#include "../../Utils/Assertion.hpp"
#include "../../Utils/Log.hpp"
#include "lucidreams/Utils/StringFormat.hpp"
#include "Win32Viewport.hpp"

namespace lucidreams
{
    static const wchar_t LUCIDREAMS_WIN32_VIEWPORT_CLASS_NAME[] = L"lucidreams.Win32Viewport.ClassName";

    LRESULT CALLBACK Win32WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

    void Win32ViewportManager::init()
    {
        Engine::instance().getLog()->trace("Win32ViewportManager", "initialization");

        IViewportManager::init();

        // TODO: pixel format

        WNDCLASS wndClass = {};
        wndClass.lpszClassName = LUCIDREAMS_WIN32_VIEWPORT_CLASS_NAME;
        wndClass.hInstance = GetModuleHandle(nullptr);
        wndClass.lpfnWndProc = Win32WindowProc;
        wndClass.style = CS_OWNDC;

        engineAssert(RegisterClass(&wndClass) != 0, format<char>("Failed to create Win32 viewport class due to WinAPI error ({0}).", GetLastError()));
    }

    void Win32ViewportManager::terminate()
    {
        Engine::instance().getLog()->trace("Win32ViewportManager", "termination");

        IViewportManager::terminate();

        UnregisterClass(LUCIDREAMS_WIN32_VIEWPORT_CLASS_NAME, GetModuleHandle(nullptr));;
    }

    std::weak_ptr<IViewport> Win32ViewportManager::createViewport(const viewport_params_t &params)
    {
        Engine::instance().getLog()->trace("Win32ViewportManager", "creating viewport instance");

        std::shared_ptr<IViewport> viewport = std::make_shared<Win32Viewport>();

        this->_viewports.push_back(viewport);

        HWND handle = CreateWindowEx(0, LUCIDREAMS_WIN32_VIEWPORT_CLASS_NAME,
                                     params.title.c_str(),
                                     WS_OVERLAPPEDWINDOW | WS_VISIBLE, // NOLINT(hicpp-signed-bitwise)
                                     CW_USEDEFAULT, CW_USEDEFAULT, params.width, params.height,
                                     nullptr, nullptr, GetModuleHandle(nullptr), viewport.get());

        engineAssert(handle != nullptr, format<char>("Failed to create Win32 viewport due to WinAPI error ({0}).", GetLastError()));

        return viewport;
    }
}