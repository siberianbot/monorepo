# TODO: add git check https://cliutils.gitlab.io/modern-cmake/chapters/projects/submodule.html

set(GLM_DIR "extern/glm")

add_subdirectory("${GLM_DIR}")
include_directories("${GLM_DIR}")