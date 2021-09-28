#ifndef RENGINE_SRC_RENDERING_MESHFACTORY_HPP
#define RENGINE_SRC_RENDERING_MESHFACTORY_HPP

#include <memory>
#include <vector>

#include "Mesh.hpp"
#include "VertexBuffer.hpp"
#include "Texturing/Texture.hpp"

namespace rengine
{
    /// Arguments for creating mesh from arrays.
    typedef struct MeshFactoryCreateFromArraysArgs
    {
        /// Array of vertices.
        std::vector<vertex_t> vertices;
        /// Array of elements.
        std::vector<index_t> indices;
    } mesh_factory_create_from_arrays_args_t;

    /// Mesh factory for creating meshes.
    class MeshFactory
    {
    public:
        /// Creates empty mesh: no vertices and textures, default values of position, scale and angles.
        /// \return Empty mesh.
        [[nodiscard]]
        static std::shared_ptr<mesh_t> createEmpty();

        /// Creates mesh by provided arrays of vertices and elements.
        /// \param args Arguments for creating mesh from arrays.
        /// \return Mesh.
        [[nodiscard]]
        static std::shared_ptr<mesh_t> createFromArrays(const mesh_factory_create_from_arrays_args_t &args);
    };
}

#endif //RENGINE_SRC_RENDERING_MESHFACTORY_HPP
