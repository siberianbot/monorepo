#ifndef RENGINE_COMMON_LOG_HPP
#define RENGINE_COMMON_LOG_HPP

#include <fstream>
#include <string>

#include "../utils/string.hpp"

namespace rengine
{
    class log
    {
    public:
        static log &instance();

        void debug(const std::string &msg);

        template<typename Arg, typename... Args>
        inline void debug(const std::string &fmt, Arg &&arg, Args &&... args)
        {
            debug(format(fmt, arg, args...));
        }

        void info(const std::string &msg);

        template<typename Arg, typename... Args>
        inline void info(const std::string &fmt, Arg &&arg, Args &&... args)
        {
            info(format(fmt, arg, args...));
        }

        void warning(const std::string &msg);

        template<typename Arg, typename... Args>
        inline void warning(const std::string &fmt, Arg &&arg, Args &&... args)
        {
            warning(format(fmt, arg, args...));
        }

        void error(const std::string &msg);

        template<typename Arg, typename... Args>
        inline void error(const std::string &fmt, Arg &&arg, Args &&... args)
        {
            error(format(fmt, arg, args...));
        }

    private:
        std::ofstream _stream;

        log();

        void write(const std::string &tag, const std::string &msg);
    };
}

#endif //RENGINE_COMMON_LOG_HPP
