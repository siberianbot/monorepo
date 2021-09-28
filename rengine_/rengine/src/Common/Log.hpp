#ifndef RENGINE_SRC_COMMON_LOG_HPP
#define RENGINE_SRC_COMMON_LOG_HPP

#include <fstream>
#include <string>

#include "ISingleton.hpp"
#include "../Utils/String.hpp"

namespace rengine
{
    /// Log subsystem.
    /// Writes all input in log file.
    class Log : public ISingleton<Log>
    {
    public:
        /// Initializes log subsystem: opens output stream for writing.
        void init();

        /// Terminates log subsystem: closes output stream.
        void terminate();

        /// Writes debug message. Works only on debug binaries.
        /// \param source Message source.
        /// \param msg Message.
        void debug(const std::string &source, const std::string &msg);

        /// Writes debug message. Works only on debug binaries.
        /// \tparam Arg Type of first argument of variadic arguments
        /// \tparam Args Type of rest variadic arguments.
        /// \param source Message source.
        /// \param fmt Message format.
        /// \param arg First argument of variadic arguments.
        /// \param args Rest variadic arguments.
        template<typename Arg, typename ... Args>
        void debug(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args);

        /// Writes information message.
        /// \param source Message source.
        /// \param msg Message.
        void info(const std::string &source, const std::string &msg);

        /// Writes information message.
        /// \tparam Arg Type of first argument of variadic arguments
        /// \tparam Args Type of rest variadic arguments.
        /// \param source Message source.
        /// \param fmt Message format.
        /// \param arg First argument of variadic arguments.
        /// \param args Rest variadic arguments.
        template<typename Arg, typename ... Args>
        void info(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args);

        /// Writes warning message.
        /// \param source Message source.
        /// \param msg Message.
        void warning(const std::string &source, const std::string &msg);

        /// Writes warning message.
        /// \tparam Arg Type of first argument of variadic arguments
        /// \tparam Args Type of rest variadic arguments.
        /// \param source Message source.
        /// \param fmt Message format.
        /// \param arg First argument of variadic arguments.
        /// \param args Rest variadic arguments.
        template<typename Arg, typename ... Args>
        void warning(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args);

        /// Writes error message.
        /// \param source Message source.
        /// \param msg Message.
        void error(const std::string &source, const std::string &msg);

        /// Writes error message.
        /// \tparam Arg Type of first argument of variadic arguments
        /// \tparam Args Type of rest variadic arguments.
        /// \param source Message source.
        /// \param fmt Message format.
        /// \param arg First argument of variadic arguments.
        /// \param args Rest variadic arguments.
        template<typename Arg, typename ... Args>
        void error(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args);

        /// Writes critical error message.
        /// \param source Message source.
        /// \param msg Message.
        void critical(const std::string &source, const std::string &msg);

    private:
        std::ofstream _file;

        /// Writes message in log file.
        /// \param source Message source.
        /// \param type Type of message.
        /// \param msg Message.
        void write(const std::string &source, const std::string &type, const std::string &msg);
    };

    template<typename Arg, typename... Args>
    void Log::debug(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args)
    {
#ifndef NDEBUG
        std::string msg = format(fmt, std::forward<Arg>(arg), std::forward<Args>(args)...);
        debug(source, msg);
#endif
    }

    template<typename Arg, typename... Args>
    void Log::info(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args)
    {
        std::string msg = format(fmt, std::forward<Arg>(arg), std::forward<Args>(args)...);
        info(source, msg);
    }

    template<typename Arg, typename... Args>
    void Log::warning(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args)
    {
        std::string msg = format(fmt, std::forward<Arg>(arg), std::forward<Args>(args)...);
        warning(source, msg);
    }

    template<typename Arg, typename... Args>
    void Log::error(const std::string &source, const std::string &fmt, Arg &&arg, Args &&... args)
    {
        std::string msg = format(fmt, std::forward<Arg>(arg), std::forward<Args>(args)...);
        error(source, msg);
    }
}

#endif //RENGINE_SRC_COMMON_LOG_HPP
