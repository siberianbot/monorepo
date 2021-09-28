#ifndef RENGINE_UTILS_STRING_HPP
#define RENGINE_UTILS_STRING_HPP

#include <sstream>
#include <string>
#include <vector>

namespace rengine
{
    template<typename T>
    [[nodiscard]]
    std::string toString(const T &value)
    {
        std::stringstream ss;
        ss << value;
        return ss.str();
    }

    extern template std::string toString<bool>(const bool &value);

    extern template std::string toString<std::string>(const std::string &value);

    [[nodiscard]]
    std::string vformat(const std::string &fmt, const std::vector<std::string> &args);

    template<typename Arg, typename ...Args>
    [[nodiscard]]
    std::string vformat(const std::string &fmt, std::vector<std::string> &vargs, Arg &&arg, Args &&...args)
    {
        vargs.push_back(toString(std::forward<Arg>(arg)));
        return vformat(fmt, vargs, std::forward<Args>(args)...);
    }

    template<typename Arg, typename... Args>
    [[nodiscard]]
    std::string format(const std::string &fmt, Arg &&arg, Args &&... args)
    {
        std::vector<std::string> vargs;
        return vformat(fmt, vargs, std::forward<Arg>(arg), std::forward<Args>(args)...);
    }
}

#endif //RENGINE_UTILS_STRING_HPP
