namespace Asteroids.System.Core.Abstractions
{
    public interface IViewportManager
    {
        public IViewport CreateViewport(/* TODO */);

        public void DestroyAll();
    }
}