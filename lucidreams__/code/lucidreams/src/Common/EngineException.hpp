#ifndef LUCIDREAMS_SRC_COMMON_ENGINEEXCEPTION_HPP
#define LUCIDREAMS_SRC_COMMON_ENGINEEXCEPTION_HPP

#include <exception>

#include <lucidreams/Types.hpp>

namespace lucidreams
{
    class EngineException : public std::exception
    {
    public:
        explicit EngineException(const MbString &msg);
    };
}

#endif //LUCIDREAMS_SRC_COMMON_ENGINEEXCEPTION_HPP
