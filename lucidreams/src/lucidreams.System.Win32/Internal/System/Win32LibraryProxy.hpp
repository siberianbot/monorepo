#ifndef LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXY_HPP
#define LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXY_HPP

#include <Windows.h>

#include <lucidreams/System/ILibraryProxy.hpp>

namespace lucidreams
{
    class Win32LibraryProxy : public ILibraryProxy
    {
    private:
        HMODULE _handle;

    public:
        explicit Win32LibraryProxy(const HMODULE &handle);
        ~Win32LibraryProxy() override;

        bool isLoaded() const override { return _handle != nullptr; }

        void destroy() override;
        void * get(const String &procName) const override;
    };
}

#endif //LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXY_HPP
