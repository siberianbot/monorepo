#include "ViewportManagerFactory.hpp"

#ifdef WIN32
    #include "Win32/Win32ViewportManager.hpp"
#endif

namespace lucidreams
{
    std::shared_ptr<IViewportManager> ViewportManagerFactory::create()
    {
        #ifdef WIN32
        return std::make_shared<Win32ViewportManager>();
        #else
            #error INCOMPATIBLE
        #endif
    }
}