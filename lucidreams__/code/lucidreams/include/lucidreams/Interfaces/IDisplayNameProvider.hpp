#ifndef LUCIDREAMS_INTERFACES_IDISPLAYNAMEPROVIDER_HPP
#define LUCIDREAMS_INTERFACES_IDISPLAYNAMEPROVIDER_HPP

#include <lucidreams/Types.hpp>

namespace lucidreams
{
    // Display name provider interface.
    // Class which implements this interface can return display name of its instance.
    // Examples:
    // - IDynamicLibraryProxy: "{name} proxy"
    // - IViewport: "{platform name} viewport"
    class IDisplayNameProvider
    {
    public:
        virtual ~IDisplayNameProvider() = default;

        // Gets display name of instance.
        [[nodiscard]] virtual MbString getDisplayName() const = 0;
    };
}

#endif //LUCIDREAMS_INTERFACES_IDISPLAYNAMEPROVIDER_HPP
