#include <iostream>

#include "common/engine.hpp"

int main(int argc, char **argv)
{
    // TODO: pass argc/argv as args in runtime params.
    rengine::engine::instance().run({});

    return 0;
}
