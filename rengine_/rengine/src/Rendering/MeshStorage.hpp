#ifndef RENGINE_SRC_RENDERING_MESHSTORAGE_HPP
#define RENGINE_SRC_RENDERING_MESHSTORAGE_HPP

#include <vector>

#include "Mesh.hpp"
#include "../Common/ISingleton.hpp"

namespace rengine
{
    /// Mesh storage class.
    /// Stores all instances of meshes.
    class MeshStorage : public ISingleton<MeshStorage>
    {
    public:
        using iterator = std::vector<mesh_t *>::iterator;

        /// Adds mesh in storage.
        /// \param mesh Mesh to add.
        void addMesh(mesh_t *mesh);

        /// Removes mesh from storage.
        /// \param mesh Mesh to remove.
        void removeMesh(mesh_t *mesh);

        /// Returns begin iterator of mesh storage.
        /// \return Begin iterator.
        [[nodiscard]]
        iterator begin() { return _meshes.begin(); }

        /// Returns end iterator of mesh storage.
        /// \return End iterator.
        [[nodiscard]]
        iterator end() { return _meshes.end(); }

    private:
        std::vector<mesh_t *> _meshes;
    };
}

#endif //RENGINE_SRC_RENDERING_MESHSTORAGE_HPP
