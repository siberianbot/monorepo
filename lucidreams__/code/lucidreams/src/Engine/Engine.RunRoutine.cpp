#include <lucidreams/Engine.hpp>

#include "Engine.hpp"

namespace lucidreams
{
    void run(const std::vector<WideString> &args)
    {
        Engine::instance().run();
    }
}