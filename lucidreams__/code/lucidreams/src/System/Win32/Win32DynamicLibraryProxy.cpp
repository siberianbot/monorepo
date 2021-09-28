#include "Win32DynamicLibraryProxy.hpp"

#include <utility>

#include <Windows.h>

#include "lucidreams/Utils/StringFormat.hpp"

#include "../../Engine/Engine.hpp"
#include "../../Utils/Assertion.hpp"
#include "../../Utils/Log.hpp"

namespace lucidreams
{
    Win32DynamicLibraryProxy::Win32DynamicLibraryProxy(WideString name) : IDynamicLibraryProxy(std::move(name)), _module(nullptr)
    {
        //
    }

    Win32DynamicLibraryProxy::~Win32DynamicLibraryProxy()
    {
        if (this->isLoaded())
        {
            this->unload();
        }
    }

    ProcPtr Win32DynamicLibraryProxy::getProcPtr(const MbString &procName) const
    {
        Engine::instance().getLog()->trace(this->getDisplayName(), format<char>("looking for procedure %0 in library %1", procName, this->_mbName));

        FARPROC procPtr = GetProcAddress(this->_module, procName.c_str());

        engineAssert(procPtr != nullptr, format<char>("failed to get procedure %0 from library %1: WinAPI error: %2", procName, this->_mbName, GetLastError()));

        return reinterpret_cast<ProcPtr>(procPtr);
    }

    void Win32DynamicLibraryProxy::load()
    {
        if (this->isLoaded())
        {
            this->unload();
        }

        Engine::instance().getLog()->trace(this->getDisplayName(), format<char>("loading library %0", this->_mbName));

        this->_module = LoadLibrary(this->_wsName.c_str());

        engineAssert(this->_module != nullptr, format<char>("failed to load %0: WinAPI error %1", this->_mbName, GetLastError()));
    }

    void Win32DynamicLibraryProxy::unload()
    {
        Engine::instance().getLog()->trace(this->getDisplayName(), format<char>("unloading library %0", this->_mbName));

        if (!this->isLoaded())
        {
            Engine::instance().getLog()->warn(this->getDisplayName(), format<char>("library %0 is already unloaded", this->_mbName, GetLastError()));
        }

        FreeLibrary(this->_module);

        this->_module = nullptr;
    }
}