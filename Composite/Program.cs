using System;
using System.Collections.Generic;

namespace Composite
{
    public interface IGraphic
    {
        IGraphic Move(int x, int y);
        IGraphic Draw();
    }

    public class Dot:IGraphic
    {

        protected int X;
        protected int Y;

        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IGraphic Move(int x, int y)
        {
            X += x;
            Y += y;
            return this;
        }

        virtual public IGraphic Draw()
        {
            Console.WriteLine($"Dot draw x: {X} y: {Y}");
            return this;
        }
    }

    public class Circle:Dot
    {
        public double Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        public override IGraphic Draw()
        {
            Console.WriteLine($"Circle draw x: {X} y: {Y} radius: {Radius}");
            return this;
        }
    }

    public class CompoundGraphic : IGraphic
    {
        public List<IGraphic> Children { get; set; } = new List<IGraphic>();

        public IGraphic Add(IGraphic graphic)
        {
            Children.Add(graphic);
            return this;
        }

        public IGraphic Remove(IGraphic graphic)
        {
            Children.Remove(graphic);
            return this;
        }

        public IGraphic Draw()
        {
            foreach (var child in Children)
            {
                child.Draw();
                
            }
            return this;
        }

        public IGraphic Move(int x, int y)
        {
            foreach (var child in Children)
            {
                child.Move(x, y);
            }
             return this;
        }
    }

    public class ImageEditor
    {
       
        public CompoundGraphic All { get; set; }

        public void Load()
        {
            All = new CompoundGraphic();
            All.Add(new Dot(1, 2));
            All.Add(new Circle(5, 3, 10));
        }

        public void GroupSelected(List<IGraphic> components)
        {
            var group = new CompoundGraphic();
            for (int i = 0; i < components.Count; i++)
            {
                group.Add(components[i]);
                group.Remove(components[i]);
            }
            All.Add(group);
            All.Draw();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ImageEditor imageEditor = new ImageEditor();
            imageEditor.Load();
            imageEditor.GroupSelected(imageEditor.All.Children);
        }
    }
}
