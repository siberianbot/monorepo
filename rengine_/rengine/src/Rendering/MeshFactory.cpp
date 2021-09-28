#include "MeshFactory.hpp"

#include <glm/vec3.hpp>

namespace rengine
{
    std::shared_ptr<mesh_t> MeshFactory::createEmpty()
    {
        return std::make_shared<mesh_t>();
    }

    std::shared_ptr<mesh_t> MeshFactory::createFromArrays(const mesh_factory_create_from_arrays_args_t &args)
    {
        std::shared_ptr<mesh_t> mesh = MeshFactory::createEmpty();

        mesh->vertexBuffer = VertexBuffer::create(args.vertices, args.indices);

        return mesh;
    }
}