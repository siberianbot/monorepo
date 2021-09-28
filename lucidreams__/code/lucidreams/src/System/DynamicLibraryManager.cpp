#include "DynamicLibraryManager.hpp"

#include <lucidreams/Utils/StringFormat.hpp>

#include "IDynamicLibraryProxy.hpp"
#include "../Engine/Engine.hpp"
#include "../Utils/Log.hpp"
#include "../Utils/StringUtils.hpp"

#ifdef WIN32
    #include "Win32/Win32DynamicLibraryProxy.hpp"
#endif

namespace lucidreams
{
    std::shared_ptr<IDynamicLibraryProxy> createProxyInstance(const WideString &name)
    {
        #ifdef WIN32
        return std::make_shared<Win32DynamicLibraryProxy>(name);
        #else
            #error INCOMPATIBLE
        #endif
    }

    std::weak_ptr<IDynamicLibraryProxy> DynamicLibraryManager::createProxy(const WideString &name)
    {
        Engine::instance().getLog()->trace("DynamicLibraryManager", format<char>("creating instance of dynamic library proxy for %0", toMultibyte(name)));

        std::shared_ptr<IDynamicLibraryProxy> dynamicLibrary = createProxyInstance(name);

        this->_libraries.push_back(dynamicLibrary);

        return dynamicLibrary;
    }

    void DynamicLibraryManager::unloadAll()
    {
        Engine::instance().getLog()->trace("DynamicLibraryManager", "unloading all libraries");

        for (const std::shared_ptr<IDynamicLibraryProxy> &proxy : this->_libraries)
        {
            proxy->unload();
        }

        this->_libraries.clear();
    }
}