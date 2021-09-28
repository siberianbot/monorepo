#include "assert.hpp"

#ifdef NDEBUG

#include "../common/engineException.hpp"

#else

#include <cassert>

#endif

namespace rengine
{
    static const char *STR_ASSERT_MSG = "Assertion failed";

    void engineAssert(bool expression)
    {
        engineAssert(expression, STR_ASSERT_MSG);
    }

    void engineAssert(bool expression, const std::string &msg)
    {
#ifdef NDEBUG
        if (!expression)
        {
            throw engineException(msg);
        }
#else
        assert(expression);
#endif
    }
}