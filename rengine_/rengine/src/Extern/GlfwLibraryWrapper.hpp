#ifndef RENGINE_SRC_EXTERN_GLFWLIBRARYWRAPPER_HPP
#define RENGINE_SRC_EXTERN_GLFWLIBRARYWRAPPER_HPP

#include <GLFW/glfw3.h>

#include "ILibraryWrapper.hpp"
#include "../Utils/Types.hpp"

namespace rengine
{
    /// Wrapper class for GLFW library.
    /// \note Here we doesn't make any difference between window and context,
    ///  because GLFW stores information about GL context in its window primitive.
    class GlfwLibraryWrapper : public ILibraryWrapper<GlfwLibraryWrapper>
    {
    public:
        /// Initializes GLFW library. Also creates GLFW window and setups
        /// it, and creates GL context via GLAD.
        void init() override;

        /// Terminates GLFW library.
        void terminate() override;

        /// Makes context current.
        void makeContextCurrent();

        /// Checks that window is still opened.
        [[nodiscard]]
        bool isContextAlive() const;

        /// Returns sizes
        /// \return
        [[nodiscard]]
        point_t getContextSize() const;

        /// Swap context buffers and poll GLFW events.
        void refresh();

    private:
        GLFWwindow *_window;

        /// Initializes window.
        void initWindow();

        /// Initializes GLAD.
        void initGlad();

        /// Callback function for any key input.
        static void windowKeyCallback(GLFWwindow *window, int key, int scancode, int action, int mods);
    };
}

#endif //RENGINE_SRC_EXTERN_GLFWLIBRARYWRAPPER_HPP
