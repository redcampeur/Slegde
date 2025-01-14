using System;
using System.Numerics;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Rendering.Viewport;
using Forgery.Rendering.Cameras;
using Forgery.Rendering.Overlay;
using Forgery.Rendering.Resources;
using Forgery.Rendering.Viewports;

namespace Forgery.BspEditor.Tools.Draggable
{
    public abstract class BaseDraggable : IDraggable
    {
        public abstract Vector3 Origin { get; }
        public virtual Vector3 ZIndex => Origin;

        public event EventHandler DragStarted;
        public event EventHandler DragMoved;
        public event EventHandler DragEnded;

        protected virtual void OnDragStarted()
        {
            DragStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDragMoved()
        {
            DragMoved?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDragEnded()
        {
            DragEnded?.Invoke(this, EventArgs.Empty);
        }

        public virtual void StartDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position)
        {
            OnDragStarted();
        }

        public virtual void Drag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 lastPosition, Vector3 position)
        {
            OnDragMoved();
        }

        public virtual void EndDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position)
        {
            OnDragEnded();
        }
        
        public virtual void MouseDown(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position)
        {

        }

        public virtual void MouseUp(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position)
        {
            
        }

        public abstract void Click(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        public abstract bool CanDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e, Vector3 position);
        public abstract void Highlight(MapDocument document, MapViewport viewport);
        public abstract void Unhighlight(MapDocument document, MapViewport viewport);
        public abstract void Render(MapDocument document, BufferBuilder builder);
        public abstract void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
        public abstract void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im);
    }
}