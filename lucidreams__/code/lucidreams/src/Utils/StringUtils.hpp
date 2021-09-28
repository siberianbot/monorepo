#ifndef LUCIDREAMS_SRC_UTILS_STRINGUTILS_HPP
#define LUCIDREAMS_SRC_UTILS_STRINGUTILS_HPP

#include <string>

#include "lucidreams/Types.hpp"

namespace lucidreams
{
    MbString toMultibyte(const WideString &wideStr);
}

#endif //LUCIDREAMS_SRC_UTILS_STRINGUTILS_HPP
