// TODO: refactor this file.

#ifndef RENGINE_SRC_UTILS_TYPES_HPP
#define RENGINE_SRC_UTILS_TYPES_HPP

#include <cstdint>

namespace rengine
{
    template<typename T>
    struct Point
    {
        T x;
        T y;
    };

    typedef Point<int> point_t;

    template<typename T>
    struct Size
    {
        T width;
        T height;
    };

    typedef Size<int> int_size_t;
    typedef Size<unsigned int> uint_size_t;
    typedef Size<std::uint32_t> uint32_size_t;

    template<typename T>
    struct Rect
    {
        Point<T> position;
        Size<T> size;
    };

    typedef Rect<std::uint32_t> uint32_rect_t;
}

#endif //RENGINE_SRC_UTILS_TYPES_HPP
