#ifndef LUCIDREAMS_UTILS_STRINGFORMAT_HPP
#define LUCIDREAMS_UTILS_STRINGFORMAT_HPP

// TODO CPP20: remove when <format> will be available and use it wherever possible.

#include <string>
#include <sstream>
#include <vector>
#include <utility>

namespace lucidreams
{
    template<typename TStrChar, typename TValue>
    std::basic_string<TStrChar> toString(const TValue &value);

    template<typename TStrChar, typename TValue>
    std::basic_string<TStrChar> toHexString(const TValue &value);

    template<typename TStrChar>
    std::basic_string<TStrChar> vformat(const std::basic_string<TStrChar> &fmt, const std::vector<std::basic_string<TStrChar>> &args);

    template<typename TStrChar, typename Arg, typename ...Args>
    [[nodiscard]]
    std::basic_string<TStrChar> vformat(const std::basic_string<TStrChar> &fmt, std::vector<std::basic_string<TStrChar>> &vargs, Arg &&arg, Args &&...args);

    template<typename TStrChar, typename Arg, typename... Args>
    [[nodiscard]]
    std::basic_string<TStrChar> format(const std::basic_string<TStrChar> &fmt, Arg &&arg, Args &&... args);
}

#include "StringFormat.Impl.hpp"

#endif //LUCIDREAMS_UTILS_STRINGFORMAT_HPP
