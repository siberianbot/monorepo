#include "StringUtils.hpp"

#include <cstdlib>

#include "Assertion.hpp"

namespace lucidreams
{
    MbString toMultibyte(const WideString &wideStr)
    {
        const size_t maxOctetCount = 4;

        if (wideStr.empty())
        {
            return MbString();
        }

        size_t mbBufferSize = sizeof(char) * wideStr.size() * maxOctetCount;
        char *mbBuffer = new char[mbBufferSize];

        engineAssert(wcstombs(mbBuffer, wideStr.c_str(), mbBufferSize) >= 0, "wide-char string conversion is failed");

        MbString result(mbBuffer);

        delete[] mbBuffer;

        return result;
    }
}