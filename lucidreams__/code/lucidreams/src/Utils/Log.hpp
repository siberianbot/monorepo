#ifndef LUCIDREAMS_SRC_UTILS_LOG_HPP
#define LUCIDREAMS_SRC_UTILS_LOG_HPP

#include <fstream>
#include <iostream>

#include <lucidreams/Types.hpp>

namespace lucidreams
{
    class Log
    {
    public:
        explicit Log(const MbString &path);
        ~Log();

        void flush();

        void trace(const MbString &src, const MbString &msg);
        void info(const MbString &src, const MbString &msg);
        void warn(const MbString &src, const MbString &msg);
        void error(const MbString &src, const MbString &msg);

    private:
        std::ofstream _fileStream;

        void write(const MbString &tag, const MbString &src, const MbString &msg);
    };
}

#endif //LUCIDREAMS_SRC_UTILS_LOG_HPP
