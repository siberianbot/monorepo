#include "log.hpp"

#include <iostream>

namespace rengine
{
    static const char *STR_DEBUG_TAG = "debug";
    static const char *STR_INFO_TAG = "info";
    static const char *STR_WARNING_TAG = "warning";
    static const char *STR_ERROR_TAG = "error";

    static const char *STR_LOG_FILE_PATH = "rengine.log";

    log &log::instance()
    {
        static log instance;
        return instance;
    }

    log::log() : _stream(STR_LOG_FILE_PATH)
    {
        //
    }

    void log::write(const std::string &tag, const std::string &msg)
    {
        if (_stream.is_open())
        {
            _stream << tag << ": " << msg << std::endl;
        }

        std::cout << tag << ": " << msg << std::endl;
    }

    void log::debug(const std::string &msg)
    {
        write(STR_DEBUG_TAG, msg);
    }

    void log::info(const std::string &msg)
    {
        write(STR_INFO_TAG, msg);
    }

    void log::warning(const std::string &msg)
    {
        write(STR_WARNING_TAG, msg);
    }

    void log::error(const std::string &msg)
    {
        write(STR_ERROR_TAG, msg);
    }
}