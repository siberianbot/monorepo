#include "ISurface.hpp"

namespace lucidreams
{
    ISurface::ISurface(const std::weak_ptr<IViewport> &viewport) : _viewport(viewport)
    {
        //
    }
}