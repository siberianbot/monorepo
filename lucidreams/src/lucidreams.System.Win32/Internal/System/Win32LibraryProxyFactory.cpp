#include "Win32LibraryProxyFactory.hpp"

#include <memory>

#include <Windows.h>

#include "Win32LibraryProxy.hpp"

namespace lucidreams
{
    std::shared_ptr<ILibraryProxy> Win32LibraryProxyFactory::create(const WideString &path)
    {
        HMODULE handle = LoadLibrary(path.c_str());

        return std::make_shared<Win32LibraryProxy>(handle);
    }
}