# TODO: add git check https://cliutils.gitlab.io/modern-cmake/chapters/projects/submodule.html

set(ASSIMP_DIR "extern/assimp")

add_subdirectory("${ASSIMP_DIR}")
include_directories("${ASSIMP_DIR}/include")