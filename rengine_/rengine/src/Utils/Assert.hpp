#ifndef RENGINE_SRC_UTILS_ASSERT_HPP
#define RENGINE_SRC_UTILS_ASSERT_HPP

#include <string>

namespace rengine
{
    /// Engine assert. Throws engine exception if expression is false.
    /// Uses default message "Engine assertion failed".
    /// \param expression Assertion expression.
    void engineAssert(const bool &expression);

    /// Engine assert. Throws engine exception if expression is false.
    /// \param expression Assertion expression.
    /// \param source Message source.
    /// \param msg Failure message.
    void engineAssert(const bool &expression, const std::string &source, const std::string &msg);

    /// Safe engine assert. Doesn't throw exception if assertion is false, but writes it in log.
    /// Uses default message "Safe engine assertion failed".
    /// \param expression Assertion expression.
    /// \return Expression result.
    bool safeAssert(const bool &expression);

    /// Safe engine assert. Doesn't throw exception if assertion is false, but writes it in log.
    /// \param expression Assertion expression.
    /// \param source Message source.
    /// \param msg Failure message.
    /// \return Expression result.
    bool safeAssert(const bool &expression, const std::string &source, const std::string &msg);

    /// Engine assert for debug. Calls assert(...) in debug binaries.
    /// \param expression Assertion expression.
    void debugAssert(const bool &expression);
}

#endif //RENGINE_SRC_UTILS_ASSERT_HPP
