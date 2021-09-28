# Tasks / Version 0.1 #

## Summary ##

### To be done ###

* Basic rendering pipeline (loading textures, shaders, buffers, meshes and putting them together);
* Text rendering (should implement texture atlas for storing glyphs);
* Camera subsystem (viewport + framebuffers);
* Basic input subsystem (keyboard only);
* ~~Configurations;~~ (moved to 0.2)
* Logging (kind of);

## Progress ##

* Basic rendering:
    * loading...
        * ~~textures;~~
        * ~~shaders;~~
        * _meshes;_
    * create...
        * ~~OpenGL buffers;~~
        * texture atlases;
        * framebuffers;
    * render...
        * ~~textures;~~
        * text;
        * models;
* Entities:
    * camera;
        * camera subsystem;
* Input processing:
    * ~~map input from GLFW;~~
    * ~~parse input accords from accord code string;~~
    * ~~input callbacks;~~
* Logging:
    * ~~write to file;~~
    * ~~write to console;~~
        * multi-threading support;