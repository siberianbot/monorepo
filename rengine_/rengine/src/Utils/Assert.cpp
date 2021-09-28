#include "Assert.hpp"

#include <cassert>

#include "../Common/EngineException.hpp"
#include "../Common/Log.hpp"

namespace rengine
{
    void engineAssert(const bool &expression)
    {
        engineAssert(expression, "Assertion", "Engine assertion failed");
    }

    void engineAssert(const bool &expression, const std::string &source, const std::string &msg)
    {
        if (!expression)
        {
            throw EngineException(source, msg);
        }
    }

    bool safeAssert(const bool &expression)
    {
        return safeAssert(expression, "Assertion", "Safe engine assertion failed");
    }

    bool safeAssert(const bool &expression, const std::string &source, const std::string &msg)
    {
        if (!expression)
        {
            Log::instance()->error(source, msg);

            return false;
        }

        return true;
    }

    void debugAssert(const bool &expression)
    {
        assert(expression);
    }
}