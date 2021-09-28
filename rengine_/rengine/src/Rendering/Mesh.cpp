#include "Mesh.hpp"

#include <glm/gtc/quaternion.hpp>
#include <glm/gtx/transform.hpp>
#include <glm/gtx/quaternion.hpp>

#include "MeshStorage.hpp"

namespace rengine
{
    Mesh::Mesh() : position(0), scale(1), pitch(0), yaw(0), roll(0)
    {
        MeshStorage::instance()->addMesh(this);
    }

    Mesh::~Mesh()
    {
        MeshStorage::instance()->removeMesh(this);
    }

    glm::mat4 modelMatrix(const mesh_t &mesh)
    {
        glm::vec3 rotations = glm::vec3(glm::radians(mesh.pitch), glm::radians(mesh.yaw), glm::radians(mesh.roll));

        return glm::mat4(1)
               * glm::translate(mesh.position)
               * glm::toMat4(glm::quat(rotations))
               * glm::scale(mesh.scale);
    }
}