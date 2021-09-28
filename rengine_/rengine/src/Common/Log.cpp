#include "Log.hpp"

#include <iostream>
#include <sstream>

#include "../Utils/Assert.hpp"

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(Log);

    void Log::init()
    {
        _file.open("latest.log");

        safeAssert(_file.is_open(), "Log", "log file can not be opened");
    }

    void Log::terminate()
    {
        _file.close();
    }

    void Log::debug(const std::string &source, const std::string &msg)
    {
#ifndef NDEBUG
        write(source, "Debug", msg);
#endif
    }

    void Log::info(const std::string &source, const std::string &msg)
    {
        write(source, "Info", msg);
    }

    void Log::warning(const std::string &source, const std::string &msg)
    {
        write(source, "Warning", msg);
    }

    void Log::error(const std::string &source, const std::string &msg)
    {
        write(source, "Error", msg);
    }

    void Log::critical(const std::string &source, const std::string &msg)
    {
        write(source, "CRITICAL", msg);
    }

    void Log::write(const std::string &source, const std::string &type, const std::string &msg)
    {
        // TODO: multithreading will tear log file apart
        std::stringstream ss;
        ss << source << " / " << type << ": " << msg << std::endl;

        std::string str = ss.str();

        std::cout << str;


        if (_file.is_open())
        {
            _file << str;
        }
    }
}