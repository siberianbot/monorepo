#ifndef LUCIDREAMS_SRC_SYSTEM_WIN32_WIN32DYNAMICLIBRARYPROXY_HPP
#define LUCIDREAMS_SRC_SYSTEM_WIN32_WIN32DYNAMICLIBRARYPROXY_HPP

#include <Windows.h>

#include "../IDynamicLibraryProxy.hpp"

namespace lucidreams
{
    class Win32DynamicLibraryProxy final : public IDynamicLibraryProxy
    {
    public:
        explicit Win32DynamicLibraryProxy(WideString name);
        ~Win32DynamicLibraryProxy() final;

        [[nodiscard]] ProcPtr getProcPtr(const MbString &procName) const final;

        [[nodiscard]] bool isLoaded() const final { return this->_module != nullptr; }
        void load() final;
        void unload() final;

    private:
        HMODULE _module;
    };
}

#endif //LUCIDREAMS_SRC_SYSTEM_WIN32_WIN32DYNAMICLIBRARYPROXY_HPP
