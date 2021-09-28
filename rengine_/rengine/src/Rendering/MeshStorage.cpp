#include "MeshStorage.hpp"

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(MeshStorage);

    void MeshStorage::addMesh(mesh_t *mesh)
    {
        _meshes.push_back(mesh);
    }

    void MeshStorage::removeMesh(mesh_t *mesh)
    {
        _meshes.erase(std::remove(_meshes.begin(), _meshes.end(), mesh));
    }
}