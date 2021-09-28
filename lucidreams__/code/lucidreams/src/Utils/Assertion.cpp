#include "Assertion.hpp"

#include <cassert>

#include "../Common/EngineException.hpp"

namespace lucidreams
{
    void engineAssert(bool expression, const MbString &msg)
    {
        if (!expression)
        {
            throw EngineException(msg);
        }
    }

    void debugAssert(bool expression)
    {
        assert(expression);
    }
}