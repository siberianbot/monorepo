#ifndef LUCIDREAMS_SRC_UTILS_ASSERTION_HPP
#define LUCIDREAMS_SRC_UTILS_ASSERTION_HPP

#include <lucidreams/Types.hpp>

namespace lucidreams
{
    void engineAssert(bool expression, const MbString &msg);

    void debugAssert(bool expression);
}

#endif //LUCIDREAMS_SRC_UTILS_ASSERTION_HPP
