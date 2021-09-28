#ifndef RENGINE_SRC_COMMON_ENGINEEXCEPTION_HPP
#define RENGINE_SRC_COMMON_ENGINEEXCEPTION_HPP

#include <exception>
#include <string>

namespace rengine
{
    /// Engine exception class.
    /// We use this class for all kind of exceptions in engine.
    class EngineException : public std::exception
    {
    public:
        /// Creates instance of exception and writes messages in log.
        /// \param source Exception source.
        /// \param msg Exception message.
        explicit EngineException(const std::string &source, const std::string &msg);
    };
}

#endif //RENGINE_SRC_COMMON_ENGINEEXCEPTION_HPP
