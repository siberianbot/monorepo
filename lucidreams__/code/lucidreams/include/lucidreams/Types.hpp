#ifndef LUCIDREAMS_TYPES_HPP
#define LUCIDREAMS_TYPES_HPP

#include <string>

namespace lucidreams
{
    // Multi-byte string.
    typedef std::basic_string<char> MbString;
    // Wide-char string.
    typedef std::basic_string<wchar_t> WideString;

    // Pointer to some library procedure.
    typedef void *ProcPtr;
}

#endif //LUCIDREAMS_TYPES_HPP
