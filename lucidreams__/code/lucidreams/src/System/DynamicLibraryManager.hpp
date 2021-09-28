#ifndef LUCIDREAMS_SRC_SYSTEM_DYNAMICLIBRARYMANAGER_HPP
#define LUCIDREAMS_SRC_SYSTEM_DYNAMICLIBRARYMANAGER_HPP

#include <memory>
#include <vector>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Types.hpp>

namespace lucidreams
{
    // Dynamic library manager.
    // Manages all dynamic library proxies.
    class DynamicLibraryManager
    {
    public:
        // Creates instance of dynamic library proxy.
        [[nodiscard]] std::weak_ptr<IDynamicLibraryProxy> createProxy(const WideString &name);

        // Unloads all libraries.
        void unloadAll();

    private:
        std::vector<std::shared_ptr<IDynamicLibraryProxy>> _libraries;
    };
}

#endif //LUCIDREAMS_SRC_SYSTEM_DYNAMICLIBRARYMANAGER_HPP
