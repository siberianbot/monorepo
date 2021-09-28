#include "Renderer.hpp"

#include <filesystem>
#include <string>

#include <glad/glad.h>
#include <glm/mat4x4.hpp>

#include "MeshStorage.hpp"
#include "ShaderFactory.hpp"

namespace rengine
{
    // TODO: this paths should lead to default rendering shader.
    static std::string renderingShaderVertexPath = "../tests/shaders/rendering.shader.vert";
    static std::string renderingShaderFragmentPath = "../tests/shaders/rendering.shader.frag";

    GENERATE_SINGLETON_INSTANCE(Renderer);

    void Renderer::init()
    {
        glEnable(GL_DEPTH_TEST);

        shader_load_from_files_args_t renderingShaderArgs;
        renderingShaderArgs.vertexShader = renderingShaderVertexPath;
        renderingShaderArgs.fragmentShader = renderingShaderFragmentPath;

        _renderingShader = ShaderFactory::loadFromFile(renderingShaderArgs);
    }

    void Renderer::terminate()
    {
        _renderingShader.reset();
    }

    void Renderer::render(const viewport_t &viewport) const
    {
        glViewport(0, 0, viewport.width, viewport.height);

        glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        glClear(GL_DEPTH_BUFFER_BIT | GL_COLOR_BUFFER_BIT);

        glm::mat4 viewportProjection = viewportMatrix(viewport);

        _renderingShader->use();
        for (auto mesh : *MeshStorage::instance())
        {
            glm::mat4 transform = viewportProjection * modelMatrix(*mesh);

            if (mesh->texture != nullptr)
            {
                glActiveTexture(GL_TEXTURE0);
                mesh->texture->bind();

                // TODO: more textures
                _renderingShader->setInt("texture0", 0);
            }

            _renderingShader->setMat4("transform", transform);

            mesh->vertexBuffer->bind();
            glDrawElements(GL_TRIANGLES, mesh->vertexBuffer->getElementsCount(), GL_UNSIGNED_INT, nullptr);
        }
    }

    std::uint32_t Renderer::maxTextureSize() const
    {
        GLint maxSize = 0;
        glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxSize);

        return maxSize;
    }
}