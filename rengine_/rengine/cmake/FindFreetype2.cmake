# TODO: add git check https://cliutils.gitlab.io/modern-cmake/chapters/projects/submodule.html

set(FREETYPE_DIR "extern/freetype2")

set(FT_WITH_ZLIB OFF)
set(CMAKE_DISABLE_FIND_PACKAGE_ZLIB TRUE)
add_subdirectory("${FREETYPE_DIR}")

include_directories("${FREETYPE_DIR}/include")