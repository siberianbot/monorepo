#include "EngineException.hpp"

namespace lucidreams
{
    EngineException::EngineException(const MbString &msg) : exception(msg.c_str())
    {
        //
    }
}