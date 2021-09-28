#include "renderer.hpp"

#define GLFW_INCLUDE_NONE
#include <GLFW/glfw3.h>
#include <glad/glad.h>

#include "../utils/assert.hpp"

namespace rengine
{
    renderer &renderer::instance()
    {
        static renderer instance;
        return instance;
    }

    void renderer::init()
    {
        engineAssert(gladLoadGLLoader(reinterpret_cast<GLADloadproc>(glfwGetProcAddress)), "GLAD: initialization failed");
    }

    void renderer::render()
    {
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

        
    }
}