#include "engineException.hpp"

namespace rengine
{
    engineException::engineException(const char *msg) noexcept: std::exception(msg)
    {
        //
    }

    engineException::engineException(const std::string &msg) noexcept: std::exception(msg.c_str())
    {
        //
    }
}