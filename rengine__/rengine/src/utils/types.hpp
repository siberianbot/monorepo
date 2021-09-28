#ifndef RENGINE_SRC_UTILS_TYPES_HPP
#define RENGINE_SRC_UTILS_TYPES_HPP

namespace rengine
{
    template<typename T>
    struct size { T width, height; };

    typedef struct size<int> i32_size_t;
}

#endif //RENGINE_SRC_UTILS_TYPES_HPP
