#include "Log.hpp"

#include <sstream>

namespace lucidreams
{
    Log::Log(const MbString &path) : _fileStream(path)
    {
        //
    }

    Log::~Log()
    {
        if (!this->_fileStream.is_open())
        {
            return;
        }

        this->_fileStream.close();
    }

    void Log::flush()
    {
        this->_fileStream.flush();
    }

    void Log::trace(const MbString &src, const MbString &msg)
    {
        this->write("trace", src, msg);
    }

    void Log::info(const MbString &src, const MbString &msg)
    {
        this->write("info", src, msg);
    }

    void Log::warn(const MbString &src, const MbString &msg)
    {
        this->write("warn", src, msg);
    }

    void Log::error(const MbString &src, const MbString &msg)
    {
        this->write("error", src, msg);
    }

    void Log::write(const MbString &tag, const MbString &src, const MbString &msg)
    {
        std::stringstream ss;

        ss << tag;
        if (!src.empty())
        {
            ss << "\t " << src;
        }
        ss << ":\t " << msg << std::endl;

        std::string line = ss.str();

        this->_fileStream << line;
        std::cout << line;
    }
}