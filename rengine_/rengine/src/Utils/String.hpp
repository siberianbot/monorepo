#ifndef RENGINE_SRC_UTILS_STRING_HPP
#define RENGINE_SRC_UTILS_STRING_HPP

#include <sstream>
#include <string>
#include <vector>

namespace rengine
{
    /// Converts value to its string representation.
    /// \tparam T Type of value.
    /// \param value Value.
    /// \return String representation.
    template<typename T>
    std::string toString(const T &value)
    {
        std::stringstream ss;
        ss << value;
        return ss.str();
    }

    /// Converts boolean value to its string representation.
    /// \param value Value.
    /// \return String representation.
   extern template
   std::string toString<bool>(const bool &value);

    /// Returns passed string value. Required for formatting.
    /// \param value Value.
    /// \return Passed value.
    extern template
    std::string toString<std::string>(const std::string &value);

    /// Formats string using string format and array of string arguments.
    /// All arguments in format string should be in this format "%<argument #>".
    /// \param fmt Format of string.
    /// \param vargs Array of string arguments.
    /// \return Formatted string.
    std::string vformat(const std::string &fmt, const std::vector<std::string> &vargs);

    /// Formats string using string format and array of string arguments.
    /// All arguments in format string should be in this format "%<argument #>".
    /// \tparam Arg Type of first argument of variadic arguments
    /// \tparam Args Type of rest variadic arguments.
    /// \param fmt Format of string.
    /// \param vargs Array of string arguments.
    /// \param arg First argument of variadic arguments.
    /// \param args Rest variadic arguments.
    /// \return Formatted string.
    template<typename Arg, typename ...Args>
    std::string vformat(const std::string &fmt, std::vector<std::string> &vargs, Arg &&arg, Args &&...args)
    {
        vargs.push_back(toString(std::forward<Arg>(arg)));
        return vformat(fmt, vargs, std::forward<Args>(args)...);
    }

    /// Formats string.
    /// All arguments in format string should be in this format "%<argument #>".
    /// \tparam Arg Type of first argument of variadic arguments
    /// \tparam Args Type of rest variadic arguments.
    /// \param fmt Format of string.
    /// \param arg First argument of variadic arguments.
    /// \param args Rest variadic arguments.
    /// \return Formatted string.
    template<typename Arg, typename... Args>
    std::string format(const std::string &fmt, Arg &&arg, Args &&... args)
    {
        std::vector<std::string> vargs;
        return vformat(fmt, vargs, std::forward<Arg>(arg), std::forward<Args>(args)...);
    }

    /// Converts string to its upper-case analogue.
    /// \param str Source string.
    /// \return Upper-case string.
    [[nodiscard]]
    std::string toUpper(const std::string &str);
}

#endif //RENGINE_SRC_UTILS_STRING_HPP
