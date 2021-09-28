#ifndef RENGINE_UTILS_ASSERT_HPP
#define RENGINE_UTILS_ASSERT_HPP

#include <string>

namespace rengine
{
    void engineAssert(bool expression);

    void engineAssert(bool expression, const std::string &msg);
}

#endif //RENGINE_UTILS_ASSERT_HPP
