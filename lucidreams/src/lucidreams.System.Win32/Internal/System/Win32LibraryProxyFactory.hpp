#ifndef LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXYFACTORY_HPP
#define LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXYFACTORY_HPP

#include <lucidreams/System/ILibraryProxyFactory.hpp>

namespace lucidreams
{
    class Win32LibraryProxyFactory : public ILibraryProxyFactory
    {
    public:
        std::shared_ptr<ILibraryProxy> create(const WideString &path) override;
    };
}

#endif //LUCIDREAMS_INTERNAL_SYSTEM_WIN32LIBRARYPROXYFACTORY_HPP
