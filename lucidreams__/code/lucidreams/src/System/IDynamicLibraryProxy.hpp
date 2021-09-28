#ifndef LUCIDREAMS_SRC_SYSTEM_IDYNAMICLIBRARYPROXY_HPP
#define LUCIDREAMS_SRC_SYSTEM_IDYNAMICLIBRARYPROXY_HPP

#include <lucidreams/Types.hpp>
#include <lucidreams/Interfaces/IDisplayNameProvider.hpp>

namespace lucidreams
{
    // Dynamic library proxy.
    // Loads and unloads library and provides addresses of exported procedures.
    class IDynamicLibraryProxy : virtual public IDisplayNameProvider
    {
    public:
        explicit IDynamicLibraryProxy(WideString name);
        ~IDynamicLibraryProxy() override = default;

        [[nodiscard]] virtual ProcPtr getProcPtr(const MbString &procName) const = 0;
        virtual void load() = 0;
        virtual void unload() = 0;

        [[nodiscard]] virtual bool isLoaded() const = 0;

        [[nodiscard]] MbString getMbStringName() const { return this->_mbName; }
        [[nodiscard]] WideString getWideStringName() const { return this->_wsName; }

        [[nodiscard]] MbString getDisplayName() const final;

    protected:
        MbString _mbName;
        WideString _wsName;
    };
}

#endif //LUCIDREAMS_SRC_SYSTEM_IDYNAMICLIBRARYPROXY_HPP
