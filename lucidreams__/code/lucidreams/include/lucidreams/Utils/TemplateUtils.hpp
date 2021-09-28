#ifndef LUCIDREAMS_UTILS_TEMPLATEUTILS_HPP
#define LUCIDREAMS_UTILS_TEMPLATEUTILS_HPP

namespace lucidreams
{
    template<typename T>
    struct isWideCharType
    {
        static const bool VALUE = false;
    };

    template<>
    struct isWideCharType<wchar_t>
    {
        static const bool VALUE = true;
    };
}

#endif //LUCIDREAMS_UTILS_TEMPLATEUTILS_HPP
