list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Engine.cpp")

add_subdirectory("Commands")
add_subdirectory("Input")

set(SRC ${SRC} PARENT_SCOPE)