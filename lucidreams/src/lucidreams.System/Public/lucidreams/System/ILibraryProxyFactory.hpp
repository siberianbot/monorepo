#ifndef LUCIDREAMS_SYSTEM_ILIBRARYPROXYFACTORY_HPP
#define LUCIDREAMS_SYSTEM_ILIBRARYPROXYFACTORY_HPP

#include <memory>

#include <lucidreams/Types.hpp>
#include <lucidreams/System/ILibraryProxy.hpp>

namespace lucidreams
{
    class ILibraryProxyFactory
    {
    public:
        virtual ~ILibraryProxyFactory() = default;

        virtual std::shared_ptr<ILibraryProxy> create(const WideString &path) = 0;
    };
}

#endif //LUCIDREAMS_SYSTEM_ILIBRARYPROXYFACTORY_HPP
