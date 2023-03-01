﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Forgery.BspEditor.Primitives;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Tools.Brush.Brushes.Controls;
using Forgery.Common;
using Forgery.Common.Shell.Components;
using Forgery.Common.Translations;
using Forgery.DataStructures.Geometric;

namespace Forgery.BspEditor.Tools.Brush.Brushes
{
    [Export(typeof(IBrush))]
    [OrderHint("A")]
    [AutoTranslate]
    public class BlockBrush : IBrush
    {
        public string Name { get; set; } = "Block";
        public bool CanRound => true;

        public IEnumerable<BrushControl> GetControls()
        {
            yield break;
        }

        public IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals)
        {
            var solid = new Solid(idGenerator.Next("MapObject"));
            solid.Data.Add(new ObjectColor(Colour.GetRandomBrushColour()));

            foreach (var arr in box.GetBoxFaces())
            {
                var face = new Face(idGenerator.Next("Face"))
                {
                    Plane = new Plane(arr[0], arr[1], arr[2]),
                    Texture = { Name = texture }
                };
                face.Vertices.AddRange(arr.Select(x => x.Round(roundDecimals)));
                solid.Data.Add(face);
            }
            solid.DescendantsChanged();
            yield return solid;
        }
    }
}