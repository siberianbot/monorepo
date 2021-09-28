#ifndef RENGINE_COMMON_ENGINEEXCEPTION_HPP
#define RENGINE_COMMON_ENGINEEXCEPTION_HPP

#include <exception>
#include <string>

namespace rengine
{
    class engineException : public std::exception
    {
    public:
        explicit engineException(const char *msg) noexcept;

        explicit engineException(const std::string &msg) noexcept;
    };
}

#endif //RENGINE_COMMON_ENGINEEXCEPTION_HPP
