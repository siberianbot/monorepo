#include "Win32LibraryProxy.hpp"

#include <Windows.h>

namespace lucidreams
{
    Win32LibraryProxy::Win32LibraryProxy(HMODULE const &handle) : _handle(handle)
    {
        //
    }

    Win32LibraryProxy::~Win32LibraryProxy()
    {
        Win32LibraryProxy::destroy();
    }

    void Win32LibraryProxy::destroy()
    {
        if (isLoaded())
        {
            return;
        }

        FreeLibrary(_handle);
        
        _handle = nullptr;
    }

    void *Win32LibraryProxy::get(const String &procName) const
    {
        return reinterpret_cast<void *>(GetProcAddress(_handle, procName.c_str()));
    }
}