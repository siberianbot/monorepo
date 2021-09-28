#ifndef RENGINE_SRC_SYSTEM_WINDOW_HPP
#define RENGINE_SRC_SYSTEM_WINDOW_HPP

#include <functional>
#include <string>

#define GLFW_INCLUDE_NONE
#include <GLFW/glfw3.h>

#include "../utils/types.hpp"

namespace rengine
{
    typedef struct windowParams
    {
        int width, height;
        std::string title;
    } window_params_t;

    class window
    {
    public:
        explicit window(const window_params_t &params);

        ~window();

        [[nodiscard]]
        bool isOpen() const;

        void makeCurrent() const;

        void refresh() const;

        [[nodiscard]]
        i32_size_t getSize() const;

    private:
        GLFWwindow *_glfwWindow;

        static void onResize([[maybe_unused]] GLFWwindow *window, int width, int height);
    };
}

#endif //RENGINE_SRC_SYSTEM_WINDOW_HPP
