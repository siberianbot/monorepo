#include "window.hpp"

#include <glad/glad.h>

#include "../utils/assert.hpp"

namespace rengine
{
    window::window(const window_params_t &params)
    {
        _glfwWindow = glfwCreateWindow(params.width, params.height, params.title.c_str(), nullptr, nullptr);

        engineAssert(_glfwWindow, "GLFW: window initialization failed");

        // TODO: callbacks should depend on window instance.
        glfwSetFramebufferSizeCallback(_glfwWindow, window::onResize);
    }

    window::~window()
    {
        if (_glfwWindow)
        {
            glfwDestroyWindow(_glfwWindow);
        }
    }

    bool window::isOpen() const
    {
        return !glfwWindowShouldClose(_glfwWindow);
    }

    void window::makeCurrent() const
    {
        glfwMakeContextCurrent(_glfwWindow);
    }

    void window::refresh() const
    {
        glfwSwapBuffers(_glfwWindow);
    }

    i32_size_t window::getSize() const
    {
        i32_size_t size;
        glfwGetWindowSize(_glfwWindow, &(size.width), &(size.height));

        return size;
    }

    void window::onResize([[maybe_unused]] GLFWwindow *window, int width, int height)
    {
        // TODO: changing of viewport size is not intended to be here.
        glViewport(0, 0, width, height);
    }
}