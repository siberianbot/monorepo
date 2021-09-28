#ifndef LUCIDREAMS_SYSTEM_ILIBRARYPROXY_HPP
#define LUCIDREAMS_SYSTEM_ILIBRARYPROXY_HPP

#include <lucidreams/Types.hpp>

namespace lucidreams
{
    class ILibraryProxy
    {
    public:
        virtual ~ILibraryProxy() = default;

        virtual bool isLoaded() const = 0;

        virtual void destroy() = 0;
        virtual void *get(const String &procName) const = 0;
    };
}

#endif //LUCIDREAMS_SYSTEM_ILIBRARYPROXY_HPP
