﻿using BitPixel.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BitPixel.World.Graphics
{
	public class WorldRenderer : IWorldRenderer
	{
		private readonly ShaderProgram _shaderProgram;

		public WorldRenderer(ShaderProgram shaderProgram)
		{
			_shaderProgram = shaderProgram;
		}
		
		public void Render(Terrain terrain)
		{
			_shaderProgram.Use();
			
			const float ratio = 720.0f / 1280.0f;

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(-40, 40, -40 * ratio, 40 * ratio, 1, -1);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();

			GL.Begin(PrimitiveType.Quads);

			GL.Color3(0f, 1f, 1f);
			GL.Vertex2(-0.5, -0.5);
			GL.Vertex2(0.5, -0.5);
			GL.Vertex2(0.5, 0.5);
			GL.Vertex2(-0.5, 0.5);
			GL.End();

			/*GL.Translate(-50, -20, 0);
			GL.Color3(1.0, 1.0, 1.0);
			GL.Begin(PrimitiveType.Quads);
			var x = 0;
			foreach (var segment in terrain.TerrainSegments)
			{
				GL.Vertex2(x, 0);
				GL.Vertex2(x + 1, 0);
				GL.Vertex2(x + 1, segment.Height);
				GL.Vertex2(x, segment.Height);

				x++;
			}
			GL.End();*/
		}
	}
}