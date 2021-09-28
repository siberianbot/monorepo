#include "Engine.hpp"

#include <memory>
#include <utility>

#include "../Common/Log.hpp"
#include "../Rendering/Mesh.hpp"
#include "../Rendering/MeshFactory.hpp"
#include "../Rendering/Renderer.hpp"
#include "../Rendering/Texturing/TextureFactory.hpp"
#include "../Rendering/Viewport.hpp"
#include "../Extern/GlfwLibraryWrapper.hpp"
#include "Input/InputSystem.hpp"

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(Engine);

    std::vector<rengine::vertex_t> vertices = {
            {{0.5f,  0.5f,  0.0f}, {0.0f, 0.0f, 0.0f}, {1.0f, 1.0f, 1.0f}, {1.0f, 1.0f}},
            {{0.5f,  -0.5f, 0.0f}, {0.0f, 0.0f, 0.0f}, {1.0f, 1.0f, 1.0f}, {1.0f, 0.0f}},
            {{-0.5f, -0.5f, 0.0f}, {0.0f, 0.0f, 0.0f}, {1.0f, 1.0f, 1.0f}, {0.0f, 0.0f}},
            {{-0.5f, 0.5f,  0.0f}, {0.0f, 0.0f, 0.0f}, {1.0f, 1.0f, 1.0f}, {0.0f, 1.0f}}
    };

    std::vector<rengine::index_t> indices = {  // note that we start from 0!
            {0, 1, 3},  // first Triangle
            {1, 2, 3}   // second Triangle
    };

    void Engine::run(const engine_args_t &args)
    {
        Log::instance()->init();
        Log::instance()->info("rengine", "version %0", RENGINE_VERSION);

        GlfwLibraryWrapper::instance()->init();
        Renderer::instance()->init();

        viewport_t viewport;
        viewport.position = glm::vec3(5, 0, 5);
        viewport.target = glm::vec3(0);

        auto mesh = MeshFactory::createFromArrays({vertices, indices});
        mesh->texture = TextureFactory::loadFromFile({std::string("../tests/textures/stub1024.png"), true});
        mesh->position = glm::vec3(0);

        auto inputAccord = fromAccordCode("Ctrl-Shift-F12");
        auto inputDef = InputSystem::instance()->getInputDefinition(inputAccord);
        InputSystem::instance()->addBinding(inputDef, []() { Engine::instance()->exit(0); });

        double delta = 0.0;

        while (rengine::GlfwLibraryWrapper::instance()->isContextAlive())
        {
            auto viewportSize = rengine::GlfwLibraryWrapper::instance()->getContextSize();
            viewport.width = viewportSize.x;
            viewport.height = viewportSize.y;

            double startTime = glfwGetTime();

            mesh->yaw += 30.0 * delta;

            Renderer::instance()->render(viewport);

            double endTime = glfwGetTime();
            delta = endTime - startTime;

            GlfwLibraryWrapper::instance()->refresh();
            InputSystem::instance()->invokeBindings();
        }

        mesh.reset();

        exit(0);
    }

    void Engine::exit(const int &returnCode)
    {
        Renderer::instance()->terminate();
        GlfwLibraryWrapper::instance()->terminate();
        Log::instance()->terminate();

        std::exit(returnCode);
    }
}
